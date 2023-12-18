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
using WindowsFormsApp1.Documents;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Hotel : Form
    {
        private bool isCollapsed;
        public Hotel()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string connectString = "Data Source = DESKTOP-PD7QD52; Initial Catalog=aeroport;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * FROM hoteli$ ORDER BY id_hotel";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                Profile_Button.Image = Resources.Collapse_Arrow_20px;
                panelDropDown.Height += 10;
                if (panelDropDown.Size == panelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                Profile_Button.Image = Resources.Expand_Arrow_20px;
                panelDropDown.Height -= 10;
                if (panelDropDown.Size == panelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void Profile_Button_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Documents.Settings qs = new Documents.Settings();
            this.Hide();
            qs.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Uvedom uved = new Uvedom();
            this.Hide();
            uved.Show();
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

        private void Supp_Button_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            this.Hide();
            support.Show();
        }
    }
}
