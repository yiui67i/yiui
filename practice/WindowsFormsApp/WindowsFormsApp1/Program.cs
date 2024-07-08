using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connString = "Host=localhost;Username=postgres;Password=1111;Database=postgres";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            NpgsqlConnection nc = new NpgsqlConnection(connString);
            try
            {
                //Открываем соединение.
                nc.Open();
            }

            catch (Exception ex)
            {
                //Код обработки ошибок
                Exception ex1 = new Exception("ошибка", ex);


            }
        }
    }
}
