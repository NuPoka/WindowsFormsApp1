using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Reg_Button_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            this.Hide();
            reg.Show();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Baza dataBases = new Baza();
            var Email = Email_TextBox.Text;
            var Password = Password_TextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, email_user, password_user from users where email_user = '{Email}' and password_user ='{Password}'";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                DataBank.Text = fio_TextBox.Text;
                MessageBox.Show("Вы вошли!");
                Main frm1 = new Main();
                frm1.ShowDialog();
                this.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Такого пользователя не существует");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fio_TextChanged(object sender, EventArgs e)
        {

        }

        private void fio_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
