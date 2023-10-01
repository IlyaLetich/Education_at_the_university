using Lab_02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_03
{
    public partial class FormSearch : Form
    {
        internal List<Product> listProductForm = new List<Product>();
        Form1 form1;

        public FormSearch()
        {
            InitializeComponent();
        }
        public FormSearch(Form1 form)
        {
            form1 = form;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.Text)
                {
                    case "Name":
                        {
                            if (textBox3.Text == "")
                                throw new Exception("Field empty");

                            var sortList = listProductForm.Where(product => product.Name == textBox3.Text);

                            listBox1.Items.Clear();

                            foreach (var item in sortList)
                            {
                                listBox1.Items.Add(item);
                            }
                        }
                        break;
                    case "Type":
                        {
                            if (textBox3.Text == "")
                                throw new Exception("Field empty");

                            var sortList = listProductForm.Where(product => product.Type == textBox3.Text);

                            listBox1.Items.Clear();

                            foreach (var item in sortList)
                            {
                                listBox1.Items.Add(item);
                            }
                        }
                        break;
                    case "Range price":
                        {
                            if (textBox3.Text == "" || textBox4.Text == "")
                                throw new Exception("Field empty");

                            var sortList = listProductForm.Where(product => (product.Price <= Convert.ToDouble(textBox4.Text) && Convert.ToDouble(textBox3.Text) <= product.Price));

                            listBox1.Items.Clear();

                            foreach (var item in sortList)
                            {
                                listBox1.Items.Add(item);
                            }
                        }
                        break;
                    default:
                        throw new Exception("Field action empty");
                }
                textBox4.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
                textBox3.Visible = false;
                textBox3.Clear();
                textBox4.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.Text)
                {
                    case "Name":
                        label5.Visible = true;
                        textBox3.Visible = true;
                        textBox4.Visible = false;
                        label6.Visible = false;
                        label5.Text = "Enter name";
                        break;
                    case "Type":
                        label5.Visible = true;
                        textBox3.Visible = true;
                        textBox4.Visible = false;
                        label6.Visible = false;
                        label5.Text = "Enter type";
                        break;
                    case "Range price":
                        label5.Visible = true;
                        textBox4.Visible = true;
                        textBox3.Visible = true;
                        label6.Visible = true;
                        label5.Text = "Lower limit";
                        label6.Text = "Upper limit";
                        break;
                    default:
                        textBox4.Visible = false;
                        label6.Visible = false;
                        textBox3.Visible = false;
                        label5.Visible = false;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProduct = ((ListBox)sender).SelectedItem as Product;

            if (selectedProduct == null) return;
            textBox1.Text = selectedProduct.CompanyProduct.ToString();
            textBox2.Text = selectedProduct.WarehousemanProduct.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            textBox4.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            textBox3.Visible = false;
            textBox3.Clear();
            textBox4.Clear();

        }

        private void FormSearch_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0) throw new Exception("List empty");

                form1.listBox1.Items.Clear();

                foreach (var item in listBox1.Items)
                {
                    form1.listBox1.Items.Add(item);
                }
                form1.textBox12.Text = (Convert.ToInt32(listBox1.Items.Count)).ToString();
                this.Hide();

                form1.textBox11.Text = "Save result search";
                form1.textBox13.Text = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
