using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_02
{
    public partial class FormCompan : Form
    {
        public FormCompan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");
                MatchCollection matches = regex.Matches(textBox4.Text);
                if (matches.Count <= 0)
                {
                    throw new Exception("Incorrect number");
                }
            }
            catch(Exception ex)
            {
                textBox4.Text = "";
                MessageBox.Show(ex.Message);
            }

        }
    }
}
