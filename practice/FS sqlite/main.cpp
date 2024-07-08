#include <iostream>
#include <fstream>
#include <sqlite3.h>
#include <vector>
#include <sstream>
#include <string>

using namespace std;


// Trim leading whitespace
string& TrimSpace(string& str){
size_t pos = str.find_first_not_of(' ');
if (pos != string::npos){
  str.erase(0, pos);
}
return str;
}

// Helper function to count leading spaces
int countLeadingSpaces(const string& str) {
  int count = 0;
  while (count < str.size() && str[count] == ' ') {
    ++count;
  }
  return count;
}

int main(int argc, char *argv[]) {
  if (argc != 2) {
    cerr << "Usage: " << argv[0] << " <daysToKeep>" << endl;
    return 1;
  }

  int daysToKeep = stoi(argv[1]);

  // Connecting to database
  sqlite3 *db;
  int rc = sqlite3_open("main.db", &db);
  if (rc != SQLITE_OK) {
    cerr << "Database opening error: " << sqlite3_errmsg(db) << endl;
    return 1;
  }

  // Process data lines
  vector<string> lines;
  string line;

  // Read all lines first
  while (getline(cin, line)) {
    // Replace || with |NULL|
    size_t pos = 0;
    while ((pos = line.find("||", pos)) != string::npos) {
      line.replace(pos, 2, "|NULL|");
      line += "0.000000|";
      pos += 6; // Move past the inserted "NULL"
    }
    lines.push_back(line);
  }


  // Filter out lines based on the condition: User must be NULL and leading spaces should not be 0 or 1
  vector<string> filteredLines;
  string filteredLine;

  for (const auto& line : lines) {
    vector<string> lineData;
    stringstream ss(line);
    string token;
    while (getline(ss, token, '|')) {
      lineData.push_back(token);
    }

    if (lineData.size() == 6) {
      // Count leading spaces
      int leadingSpaces = countLeadingSpaces(line);

      // Check if User is NULL and leading spaces are not 0 or 1
      if (lineData[1] == "NULL" && leadingSpaces > 1) {
        filteredLines.push_back(line);
      }
    }
  }

  // Prepare SQL statements
  string sql = "INSERT INTO FS1 (Account, User, NormShares, NormUsage, EffectvUsage, FairShare) VALUES (?, ?, ?, ?, ?, ?)";
  sqlite3_stmt *stmt;

  // Insert filtered data into the database
  for (const auto& filteredLine : filteredLines) {
    vector<string> filteredLineData;
    stringstream ss(filteredLine);
    string token;
    while (getline(ss, token, '|')) {
      filteredLineData.push_back(token);
    }

    for (const auto& line : lines){
      vector<string> lineData;
      stringstream ss(line);
      string token;
      while (getline(ss, token, '|')){
        lineData.push_back(token);
      }


      if (TrimSpace(lineData[0]) == TrimSpace(filteredLineData[0]) && TrimSpace(lineData[1]) != "NULL"){
        filteredLineData[5] = lineData[5];
        cout << "-------------------" << endl;
        for (int i = 0; i < lineData.size(); ++i){
          cout << lineData[i] << endl;
        }
      }
    }

    if (filteredLineData.size() != 6) {
      cerr << "Invalid row format: " << filteredLine << endl;
      continue;
    }
/*
    if (filteredLineData[5].empty() || filteredLineData[5] == "NULL") {
      filteredLineData[5] = "0.000000";
    }
*/
    rc = sqlite3_prepare_v2(db, sql.c_str(), -1, &stmt, nullptr);
    if (rc != SQLITE_OK) {
      cerr << "Query preparing error: " << sqlite3_errmsg(db) << endl;
      continue;
    }

    sqlite3_bind_text(stmt, 1, TrimSpace(filteredLineData[0]).c_str(), -1, SQLITE_TRANSIENT);
    sqlite3_bind_text(stmt, 2, filteredLineData[1].c_str(), -1, SQLITE_TRANSIENT);
    sqlite3_bind_double(stmt, 3, stod(filteredLineData[2]));
    sqlite3_bind_double(stmt, 4, stod(filteredLineData[3]));
    sqlite3_bind_double(stmt, 5, stod(filteredLineData[4]));
    sqlite3_bind_double(stmt, 6, stod(filteredLineData[5]));

    rc = sqlite3_step(stmt);
    if (rc != SQLITE_DONE) {
      cerr << "Query execution error: " << sqlite3_errmsg(db) << endl;
    }

    sqlite3_finalize(stmt);
  }

  // Delete old records from db
  time_t now = time(0);
  time_t cutoff = now - (daysToKeep * 24 * 60 * 60);

  string deleteSql = "DELETE FROM FS1 WHERE julianday(TimeStamp, 'localtime') < julianday('now', 'localtime') - ?";

  sqlite3_stmt *deleteStmt;
  rc = sqlite3_prepare_v2(db, deleteSql.c_str(), -1, &deleteStmt, nullptr);
  if (rc != SQLITE_OK) {
    cerr << "Delete query preparing error: " << sqlite3_errmsg(db) << endl;
  } else {
    sqlite3_bind_double(deleteStmt, 1, daysToKeep / 365.25);
    rc = sqlite3_step(deleteStmt);
    if (rc != SQLITE_DONE) {
      cerr << "Delete query execution error: " << sqlite3_errmsg(db) << endl;
    }
    sqlite3_finalize(deleteStmt);
  }
  string vacuumSql = "VACUUM";
  rc = sqlite3_exec(db, vacuumSql.c_str(), nullptr, nullptr, nullptr);
  if (rc != SQLITE_OK) {
    cerr << "VACUUM error: " << sqlite3_errmsg(db) << endl;
  }

  sqlite3_close(db);

  return 0;
}
