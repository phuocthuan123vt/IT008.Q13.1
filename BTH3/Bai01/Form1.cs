namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExampleForm ef = new ExampleForm(this.listBox1);

            ef.Show();
        }
    }
}
