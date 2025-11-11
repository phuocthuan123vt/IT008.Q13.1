using System;
using System.Drawing;
using System.Windows.Forms;
namespace Bai02
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int x = rnd.Next(0, formWidth - 100);
            int y = rnd.Next(0, formHeight - 100);

            g.DrawString("Paint Event", new Font("Arial", 16), Brushes.Red, x, y);
        }

        private void Refresh_Button_Click_1(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
