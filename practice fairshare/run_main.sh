#!/bin/bash


EXECUTABLE="my_program"

INPUT_FILE="exampledata.txt"

# Define options and arguments
DAYS_TO_KEEP=30  # Default value

# Parse options using getopt
while getopts ":d:" opt; do
  case $opt in
    d) DAYS_TO_KEEP="$OPTARG";;  # Assign value to DAYS_TO_KEEP if -d is used
    ?) echo "Invalid option: -$OPTARG" >&2; exit 1;;  # Handle invalid options
  esac
done

# Shift arguments to remove processed options (optional):
shift $(($OPTIND - 1))  # Remove processed options from $@

g++ -o $EXECUTABLE main.cpp -lsqlite3

# Проверка успешной компиляции
if [ $? -ne 0 ]; then
echo "Compilation failed"
exit 1
fi

# Проверка, что исполняемый файл создан
if [ ! -f $EXECUTABLE ]; then
echo "Executable $EXECUTABLE not found"
exit 1
fi

cat "$INPUT_FILE" | ./"$EXECUTABLE" "$DAYS_TO_KEEP"
