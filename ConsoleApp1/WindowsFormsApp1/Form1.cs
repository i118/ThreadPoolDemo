using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            foreach (var item in Controls)
            {
                if (item is PictureBox)
                {
                    (item as PictureBox).Image = Image.FromFile("1.png");
                    (item as PictureBox).SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void rocketStart1(object j)
        {
            List<PictureBox> lists = new List<PictureBox>();
            foreach (var item in Controls)
            {
                if(item is PictureBox)
                {
                    lists.Add((item as PictureBox));
                }
            }
            

            while (true)
            {
                PictureBox p = lists[r.Next(lists.Count)];
                
                if (p.Location.Y < Bounds.Top-100)
                {
                    p.Invoke(new Action(() => {
                        p.Image = Image.FromFile("2.png");
                    }));
                    //break;
                }
                p.Invoke(new Action(()=> {
                    p.Location = new Point(p.Location.X, p.Location.Y - r.Next(10));

                }));
                Thread.Sleep(r.Next(20));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(rocketStart1);
        }
    }
}
