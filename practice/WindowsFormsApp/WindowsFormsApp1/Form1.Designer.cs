
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddButton = new System.Windows.Forms.Button();
            this.npgsqlConnection1 = new Npgsql.NpgsqlConnection();
            this.scibox = new System.Windows.Forms.ComboBox();
            this.confbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.namebox = new System.Windows.Forms.TextBox();
            this.datetime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.themebox = new System.Windows.Forms.ComboBox();
            this.citationbox = new System.Windows.Forms.TextBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.deletebutton = new System.Windows.Forms.Button();
            this.conbox = new System.Windows.Forms.ComboBox();
            this.conflist = new System.Windows.Forms.ListBox();
            this.finddata = new System.Windows.Forms.Button();
            this.sciebox = new System.Windows.Forms.ComboBox();
            this.articlelist = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(121, 32);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // npgsqlConnection1
            // 
            this.npgsqlConnection1.ProvideClientCertificatesCallback = null;
            this.npgsqlConnection1.ProvidePasswordCallback = null;
            this.npgsqlConnection1.UserCertificateValidationCallback = null;
            // 
            // scibox
            // 
            this.scibox.FormattingEnabled = true;
            this.scibox.Location = new System.Drawing.Point(107, 232);
            this.scibox.Name = "scibox";
            this.scibox.Size = new System.Drawing.Size(145, 21);
            this.scibox.TabIndex = 1;
            this.scibox.SelectedIndexChanged += new System.EventHandler(this.scibox_SelectedIndexChanged);
            // 
            // confbox
            // 
            this.confbox.FormattingEnabled = true;
            this.confbox.Location = new System.Drawing.Point(107, 259);
            this.confbox.Name = "confbox";
            this.confbox.Size = new System.Drawing.Size(385, 21);
            this.confbox.TabIndex = 2;
            this.confbox.SelectedIndexChanged += new System.EventHandler(this.confbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Год публикации";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ученый";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Конференция";
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(107, 74);
            this.namebox.Multiline = true;
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(681, 67);
            this.namebox.TabIndex = 7;
            // 
            // datetime
            // 
            this.datetime.Location = new System.Drawing.Point(107, 147);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(145, 20);
            this.datetime.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Тема";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Цитирования";
            // 
            // themebox
            // 
            this.themebox.FormattingEnabled = true;
            this.themebox.Location = new System.Drawing.Point(107, 179);
            this.themebox.Name = "themebox";
            this.themebox.Size = new System.Drawing.Size(385, 21);
            this.themebox.TabIndex = 12;
            this.themebox.SelectedIndexChanged += new System.EventHandler(this.themebox_SelectedIndexChanged);
            // 
            // citationbox
            // 
            this.citationbox.Location = new System.Drawing.Point(107, 205);
            this.citationbox.Multiline = true;
            this.citationbox.Name = "citationbox";
            this.citationbox.Size = new System.Drawing.Size(145, 21);
            this.citationbox.TabIndex = 13;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // deletebutton
            // 
            this.deletebutton.Location = new System.Drawing.Point(16, 435);
            this.deletebutton.Name = "deletebutton";
            this.deletebutton.Size = new System.Drawing.Size(180, 28);
            this.deletebutton.TabIndex = 14;
            this.deletebutton.Text = "Удалить конференцию";
            this.deletebutton.UseVisualStyleBackColor = true;
            this.deletebutton.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // conbox
            // 
            this.conbox.FormattingEnabled = true;
            this.conbox.Location = new System.Drawing.Point(16, 393);
            this.conbox.Name = "conbox";
            this.conbox.Size = new System.Drawing.Size(385, 21);
            this.conbox.TabIndex = 15;
            // 
            // conflist
            // 
            this.conflist.FormattingEnabled = true;
            this.conflist.Location = new System.Drawing.Point(12, 692);
            this.conflist.Name = "conflist";
            this.conflist.Size = new System.Drawing.Size(437, 212);
            this.conflist.TabIndex = 16;
            this.conflist.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // finddata
            // 
            this.finddata.Location = new System.Drawing.Point(348, 605);
            this.finddata.Name = "finddata";
            this.finddata.Size = new System.Drawing.Size(184, 28);
            this.finddata.TabIndex = 17;
            this.finddata.Text = "Найти данные";
            this.finddata.UseVisualStyleBackColor = true;
            this.finddata.Click += new System.EventHandler(this.finddata_Click);
            // 
            // sciebox
            // 
            this.sciebox.FormattingEnabled = true;
            this.sciebox.Location = new System.Drawing.Point(16, 610);
            this.sciebox.Name = "sciebox";
            this.sciebox.Size = new System.Drawing.Size(184, 21);
            this.sciebox.TabIndex = 18;
            // 
            // articlelist
            // 
            this.articlelist.FormattingEnabled = true;
            this.articlelist.Location = new System.Drawing.Point(470, 692);
            this.articlelist.Name = "articlelist";
            this.articlelist.Size = new System.Drawing.Size(713, 264);
            this.articlelist.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 1006);
            this.Controls.Add(this.articlelist);
            this.Controls.Add(this.sciebox);
            this.Controls.Add(this.finddata);
            this.Controls.Add(this.conflist);
            this.Controls.Add(this.conbox);
            this.Controls.Add(this.deletebutton);
            this.Controls.Add(this.citationbox);
            this.Controls.Add(this.themebox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datetime);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confbox);
            this.Controls.Add(this.scibox);
            this.Controls.Add(this.AddButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private Npgsql.NpgsqlConnection npgsqlConnection1;
        private System.Windows.Forms.ComboBox scibox;
        private System.Windows.Forms.ComboBox confbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.DateTimePicker datetime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox themebox;
        private System.Windows.Forms.TextBox citationbox;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button deletebutton;
        private System.Windows.Forms.ComboBox conbox;
        private System.Windows.Forms.ListBox conflist;
        private System.Windows.Forms.Button finddata;
        private System.Windows.Forms.ComboBox sciebox;
        private System.Windows.Forms.ListBox articlelist;
    }
}

