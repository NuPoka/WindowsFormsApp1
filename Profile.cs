using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsApp1.Documents;

namespace WindowsFormsApp1
{
    public partial class Profile : Form
    {
        List<string> names = new List<string> { "паспорт РФ", "загранпаспорт", "свид. о рождении", "документ" };
        private int currentIndex = 0;
        public Profile()
        {
            InitializeComponent();
            label6.Text = DataBank.Text;
            guna2TextBox1.Text = DataBank.Text2;
            guna2TextBox2.Text = DataBank.Text3;
            guna2TextBox3.Text = DataBank.Text4;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = DataBank.Text;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label16.Text = names[currentIndex];

            // Увеличиваем индекс или сбрасываем, если достигли конца списка
            currentIndex = (currentIndex + 1) % names.Count;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Podpiska podpiska = new Podpiska();
            this.Hide();
            podpiska.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DataBank.Text2 = guna2TextBox1.Text;
            DataBank.Text3 = guna2TextBox2.Text;
            DataBank.Text4 = guna2TextBox3.Text;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Uvedom uved = new Uvedom();
            this.Hide();
            uved.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();
            settings.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void Supp_Button_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            this.Hide();
            support.Show();
        }
    }
}