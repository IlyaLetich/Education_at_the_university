using Lab_03;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Json;

namespace Lab_02
{
    public partial class Form1 : Form
    {
        private readonly FormCompan _formCompany = new FormCompan();

        private readonly FormWarehouseman _formWarehouseman = new FormWarehouseman();

        private readonly FormSearch _formSearch;

        public Form1()
        {
            _formSearch = new FormSearch(this);
            InitializeComponent();
            _formSearch.Hide();
            _formCompany.Hide();
            _formWarehouseman.Hide();
            textBox12.Text = 0.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {


                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));

                using (FileStream fs = new FileStream(textBox10.Text, FileMode.OpenOrCreate))
                {
                    List<Product> listProduct = (List<Product>)jsonFormatter.ReadObject(fs);

                    foreach (var item in listProduct)
                    {
                        listBox1.Items.Add(item);
                    }
                }
                textBox11.Text = "Importing list";
                textBox13.Text = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProduct = ((ListBox)sender).SelectedItem as Product;

            if (selectedProduct == null) return;
            textBox8.Text = selectedProduct.CompanyProduct.ToString();
            textBox9.Text = selectedProduct.WarehousemanProduct.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _formCompany.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _formWarehouseman.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""
                    || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""
                    || textBox7.Text == "" || _formCompany.textBox1.Text == "" || _formCompany.textBox2.Text == ""
                    || _formCompany.textBox3.Text == "" || _formCompany.textBox4.Text == ""
                    || _formWarehouseman.textBox2.Text == "" || _formWarehouseman.textBox3.Text == ""
                    || _formWarehouseman.maskedTextBox1.Text == "")
                    throw new Exception("Field empty");

                Product product = new Product(
                    textBox7.Text,
                    textBox5.Text,
                    Convert.ToDouble(textBox3.Text),
                    Convert.ToDouble(textBox6.Text),
                    textBox1.Text, dateTimePicker1.Text,
                    Convert.ToInt32(textBox4.Text),
                    Convert.ToDouble(textBox2.Text),
                    new Company(_formCompany.textBox1.Text, _formCompany.textBox4.Text,
                    _formCompany.textBox4.Text, _formCompany.textBox4.Text),
                    new Warehouseman(_formWarehouseman.textBox3.Text, Convert.ToInt32(_formWarehouseman.maskedTextBox1.Text),
                    _formWarehouseman.textBox2.Text)
                );


                var context = new ValidationContext(product);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(product, context, results, true))
                {
                    string err = "";
                    foreach (var error in results)
                    {
                        err += error.ErrorMessage;
                    }

                    throw new Exception($"{err}");
                }




                listBox1.Items.Add(product);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

                _formCompany.textBox1.Clear();
                _formCompany.textBox2.Clear();
                _formCompany.textBox3.Clear();
                _formCompany.textBox4.Clear();

                _formWarehouseman.textBox2.Clear();
                _formWarehouseman.textBox3.Clear();
                _formWarehouseman.maskedTextBox1.Clear();

                textBox11.Text = "Added new element";
                textBox13.Text = DateTime.Now.ToString();

                textBox12.Text = (Convert.ToInt32(textBox12.Text) + 1).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox12.Text = 0.ToString();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            listBox1.Items.Clear();

            _formCompany.textBox1.Clear();
            _formCompany.textBox2.Clear();
            _formCompany.textBox3.Clear();
            _formCompany.textBox4.Clear();

            _formWarehouseman.textBox2.Clear();
            _formWarehouseman.textBox3.Clear();
            _formWarehouseman.maskedTextBox1.Clear();

            textBox11.Text = "Clear field";
            textBox13.Text = DateTime.Now.ToString();
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
            try
            {
                Convert.ToInt32(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text == "")
                    throw new Exception("Field path empty");

                List<Product> listProduct = new List<Product>();

                foreach (var item in listBox1.Items)
                {
                    listProduct.Add((Product)item);
                }

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));

                using (FileStream fs = new FileStream(textBox10.Text, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, listProduct);
                }
                textBox11.Text = "Save list";
                textBox13.Text = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if(textBox4.Text != "")
                    Convert.ToInt32(textBox4.Text);
            }
            catch (Exception ex)
            {
                textBox4.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                    Convert.ToInt32(textBox2.Text);
            }
            catch (Exception ex)
            {
                textBox2.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox10_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (File.Exists(textBox10.Text))
                {
                     
                }
                else throw new Exception("Path not find");
            }
            catch(Exception ex)
            {
                textBox10.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> listProduct = new List<Product>();

                foreach (var item in listBox1.Items)
                {
                    listProduct.Add((Product)item);
                }

                var sortList = listProduct.OrderBy(product => DateTime.Parse(product.DeliveryDate));

                listBox1.Items.Clear();

                foreach (var item in sortList)
                {
                    listBox1.Items.Add(item);
                }
                textBox11.Text = "Sorted list by date";
                textBox13.Text = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> listProduct = new List<Product>();

                foreach (var item in listBox1.Items)
                {
                    listProduct.Add((Product)item);
                }

                var sortList = listProduct.OrderBy(product => product.CompanyProduct.State);

                listBox1.Items.Clear();

                foreach (var item in sortList)
                {
                    listBox1.Items.Add(item);
                }
                textBox11.Text = "Sorted list by state";
                textBox13.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> listProduct = new List<Product>();

                foreach (var item in listBox1.Items)
                {
                    listProduct.Add((Product)item);
                }

                var sortList = listProduct.OrderBy(product => product.Name);

                listBox1.Items.Clear();

                foreach (var item in sortList)
                {
                    listBox1.Items.Add(item);
                }
                textBox11.Text = "Sorted list by name";
                textBox13.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 2.0, Author: Panchuk Ilya");
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var item in listBox1.Items)
            {
                _formSearch.listProductForm.Add((Product)item);
            }
            _formSearch.ShowDialog();
        }

        private void sortedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nmaeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menuStrip2.Visible == false)
                menuStrip2.Visible = true;
            else menuStrip2.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == -1) throw new Exception("The element is not selected");
                textBox8.Clear();
                textBox9.Clear();
                textBox12.Text = (Convert.ToInt32(textBox12.Text) - 1).ToString();

                textBox11.Text = " Element deleted";
                textBox13.Text = DateTime.Now.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0) throw new Exception("List empty");
                if (listBox1.SelectedIndex == 0)
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    return;
                }
                if (listBox1.SelectedIndex == -1)
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    return;
                }
                listBox1.SelectedIndex -= 1;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0) throw new Exception("List empty");
                if (listBox1.SelectedIndex == -1)
                {
                    listBox1.SelectedIndex = 0;
                    return;
                }
                if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex = 0;
                    return;
                }
                listBox1.SelectedIndex += 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SaveResultSearch()
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}