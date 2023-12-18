using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using System.IO;
using System.Data.SqlClient;
using WindowsFormsApp1.Documents;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        private NotifyIcon notifyIcon;
        private int borderSize = 2;
        private Size formSize;
        private bool isCollapsed;
        public Main()
        {
            InitializeComponent();
            LoadData();
            label2.Text = DataBank.Text;
            InitializeNotifyIcon();
            this.Padding = new Padding(borderSize);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
        }
        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Text = "Ваша программа";
            notifyIcon.Click += NotifyIcon_Click;
        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // При клике на иконку в области уведомлений, разворачиваем окно
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            this.Hide();
            support.Show();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                // Если окно в нормальном состоянии, свернуть его в область уведомлений
                WindowState = FormWindowState.Minimized;
                notifyIcon.Visible = true;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                // Если окно свернуто, развернуть его на полный экран
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }   
            protected void MainForm_Resize(object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    notifyIcon.Visible = true;
                }
            }
            private void guna2PictureBox3_Click(object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    // Если окно в нормальном состоянии, свернуть его
                    WindowState = FormWindowState.Minimized;
                }
                else if (WindowState == FormWindowState.Minimized || WindowState == FormWindowState.Maximized)
                {
                    // Если окно свернуто или развернуто, восстановить его в нормальное состояние
                    WindowState = FormWindowState.Normal;
                }
            }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string connectString = "Data Source = DESKTOP-PD7QD52; Initial Catalog=aeroport;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * FROM reys$ ORDER BY id_reys";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel();
            this.Hide();
            hotel.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            this.Hide();
            profile.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Documents.Settings qs = new Documents.Settings();
            this.Hide();
            qs.Show();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
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
    }
}

