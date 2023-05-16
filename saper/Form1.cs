namespace SAPER
{
    public partial class Form1 : Form
    {
        public static int d, b;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                d = Int32.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Coœ posz³o nie tak");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                b = Int32.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Coœ posz³o nie tak");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GRA Gra1 = new GRA(d, b);
            Gra1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}