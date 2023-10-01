using System.Runtime.Serialization.Json;

namespace Lab_02
{
    public partial class Form1 : Form
    {
        private readonly FormCompan _formCompany = new FormCompan();

        private readonly FormWarehouseman _formWarehouseman = new FormWarehouseman();

        public Form1()
        {
            InitializeComponent();
            _formCompany.Hide();
            _formWarehouseman.Hide();
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
    }
}