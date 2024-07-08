using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string connString = "Host=localhost;Username=postgres;Password=1111;Database=postgres";

            NpgsqlConnection nc = new NpgsqlConnection(connString);
            

            nc.Open();
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT Код_ученого, Фамилия FROM \"Ученые\"", nc);
            adap.Fill(dt);
            scibox.DataSource = dt;
            scibox.DisplayMember = "Фамилия";
            scibox.ValueMember = "Код_ученого";
           // nc.Close();

            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter("SELECT Код_конференции, Название FROM \"Конференции\"", nc);
            adapt.Fill(dt1);
            confbox.DataSource = dt1;
            confbox.DisplayMember = "Название";
            confbox.ValueMember = "Код_конференции";

            DataTable dt2 = new DataTable();
            NpgsqlDataAdapter adapt1 = new NpgsqlDataAdapter("SELECT Код_темы, Название FROM \"Тематики\"", nc);
            adapt1.Fill(dt2);
            themebox.DataSource = dt2;
            themebox.DisplayMember = "Название";
            themebox.ValueMember = "Код_темы";

            DataTable dt3 = new DataTable();
            NpgsqlDataAdapter adapt2 = new NpgsqlDataAdapter("SELECT id, title FROM \"conftest\"", nc);
            adapt2.Fill(dt3);
            conbox.DataSource = dt3;
            conbox.DisplayMember = "title";
            conbox.ValueMember = "id";

            DataTable dt4 = new DataTable();
            NpgsqlDataAdapter adapt3 = new NpgsqlDataAdapter("SELECT Код_ученого, Фамилия FROM \"Ученые\"", nc);
            adapt3.Fill(dt4);
            sciebox.DataSource = dt4;
            sciebox.DisplayMember = "Фамилия";
            sciebox.ValueMember = "Код_ученого";

            nc.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)


        {
            String article = namebox.Text;
            int citation = Convert.ToInt32(citationbox.Text);
            DateTime date = datetime.Value;
            int scientist = scibox.SelectedIndex + 1;
            int theme = themebox.SelectedIndex + 1;
            int conf = confbox.SelectedIndex + 1;

            string connString = "Host=localhost;Username=postgres;Password=1111;Database=postgres";

            NpgsqlConnection nc = new NpgsqlConnection(connString);

            nc.Open();
            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand("insert into \"Статьи1\" (Название, Дата_публикации, Код_темы, Цитирования, Код_ученого, Код_конференции) values(@Название, @Дата_публикации, @Код_темы, @Цитирования,  @Код_ученого, @Код_конференции)", nc);



            cmd.Parameters.AddWithValue("@Название", article);
            cmd.Parameters.AddWithValue("@Дата_публикации", date);
            cmd.Parameters.AddWithValue("@Код_темы", theme);
            cmd.Parameters.AddWithValue("@Цитирования", citation);
            cmd.Parameters.AddWithValue("@Код_ученого", scientist);
            cmd.Parameters.AddWithValue("@Код_конференции", conf);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Статья добавлена");

            nc.Close();
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            int confer = (int)conbox.SelectedValue;

            string connString = "Host=localhost;Username=postgres;Password=1111;Database=postgres";

            NpgsqlConnection nc = new NpgsqlConnection(connString);

            nc.Open();

            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM \"conftest\" WHERE id = @id", nc);

            cmd.Parameters.AddWithValue("@id", confer);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Конференция удалена");

            nc.Close();
        }

        private void finddata_Click(object sender, EventArgs e)
        {
            articlelist.Items.Clear();
            conflist.Items.Clear();
            int scientist = (int)sciebox.SelectedValue;
            string connString = "Host=localhost;Username=postgres;Password=1111;Database=postgres";

            NpgsqlConnection nc = new NpgsqlConnection(connString);


            string SQL = "select Название FROM Статьи1 where Код_ученого=" + scientist;
            string SQL1 = "select Название FROM Конференции WHERE Код_конференции IN (SELECT Код_конференции FROM Статьи1 WHERE Код_ученого IN (SELECT Код_ученого FROM Ученые WHERE Код_ученого = " + scientist + "))";

            NpgsqlCommand cmd = new NpgsqlCommand(SQL, nc);
            NpgsqlDataReader r = null;
            nc.Open();
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                    articlelist.Items.Add(r["Название"]);

            }
            nc.Close();


            NpgsqlCommand command = new NpgsqlCommand(SQL1, nc);
            NpgsqlDataReader rd = null;
            nc.Open();
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                conflist.Items.Add(rd["Название"]);

            }
            nc.Close();
            

            MessageBox.Show("Данные найдены");


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void scibox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void confbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themebox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
