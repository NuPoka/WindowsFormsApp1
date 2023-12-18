using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Documents
{
    public partial class Uvedom : Form
    {
        public Uvedom()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();
            settings.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Podpiska podpiska = new Podpiska();
            this.Hide();
            podpiska.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            this.Hide();
            profile.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void Supp_Button_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            this.Hide();
            support.Show();
        }
    }
}
