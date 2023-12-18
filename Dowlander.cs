using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dowlander : Form
    {
        public Dowlander()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();

          

            // Закрываем текущую форму
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            // Отменяем закрытие формы
            e.Cancel = true;
            // Открываем вторую форму
            login form2 = new login();
            form2.Show();

            // Отключаем обработчик события FormClosing
            this.FormClosing -= Form1_FormClosing;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Включаем обработчик события FormClosing
            this.FormClosing += Form1_FormClosing;
        }
        }
    }
