using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12IMITAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random random = new Random();
        int days, state, state0 = 0, stateOld;
        int[] emperic = new int [3];
        double[,] P =
        {
            {0.6, 0.3, 0.1},
            {0.4, 0.2, 0.4},
            {0.1, 0.4, 0.5}
        };

        private void button2_Click(object sender, EventArgs e)
        {
            labelDays.Visible = true;
            emp.Visible = true;
            labelDays.Text = days.ToString();
            timer1.Stop();
            for(int i = 0; i < emperic.Length; i++)
            {
                double text = (double)emperic[i] / days;
                emp.Text += "Состояние " + i + ": " + Math.Round(text,2).ToString() + "    ";
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            state = State(state);
            Picter(state);
            days++;

            if(state >=0 && state <=2)
            {
                emperic[state]++;
            }

            chart1.Series[0].Points.AddXY(days, state);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelDays.Visible = false;
            emp.Visible = false;
            emp.Text = "";
            days = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(days, state0);
            Picter(state0);

            for(int i = 0; i < emperic.Length; i++)
            {
                emperic[i] = 0;
            }

            timer1.Start();
        }

        public int State(int oldSt)
        {
            double sum = 0;
            double a = random.NextDouble();
            for (int i = 0; i < 3; i++)
            {
                sum += P[oldSt, i];
                if(a<sum)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Picter(int state)
        {
            switch (state)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile("E:\\Images\\1.jpg");
                    break;
                case 1:
                    pictureBox1.Image = Image.FromFile("E:\\Images\\2.jpg");
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile("E:\\Images\\3.jpg");
                    break;
            }
        }
    }

   
}
