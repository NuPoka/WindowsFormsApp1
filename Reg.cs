using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            Baza dataBases = new Baza();
            var family = Family_TextBox.Text;
            var name = Name_TextBox.Text;
            var otchestvo = Otchestvo_TextBox.Text;
            var email = Email_TextBox.Text;
            var password = Password_TextBox.Text;

            string querystring = $"insert into users(family_user, name_user, otchestvo_user, email_user, password_user) values ('{family}','{name}','{otchestvo}','{email}','{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            dataBases.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан!");
                login frmlgn = new login();
                this.Hide();
                frmlgn.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
            dataBases.closeConnection();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            login log = new login();
            this.Hide();
            log.Show();
        }
    }
}
