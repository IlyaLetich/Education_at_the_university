namespace Lab_01
{
    public partial class Form1 : Form
    {
        internal ICalculator Calculator;

        public Form1()
        {
            Calculator = new Calculator();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void action_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result.Text = "";
            switch (Action.Text.ToString())
            {
                case "row power":
                    Number02.Visible = true;
                    TextNumber02.Text = "Enter max power";
                    TextNumber02.Visible = true;
                    break;
                case "plus":
                    Number02.Visible = true;
                    TextNumber02.Text = "Enter 2 number";
                    TextNumber02.Visible = true;
                    break;
                default:
                    Number02.Text = "";
                    TextNumber02.Visible = false;
                    Number02.Visible = false;
                    break;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Number01.Text = "";
            Action.Text = "";
            Result.Text = "";
            Number02.Text = "";
            Buffer.Text = "";
            TextNumber02.Visible = false;
            Number02.Visible = false;
        }

        private void buttom2_Click(object sender, EventArgs e)
        {
            try
            {
                Result.Text = "";

                switch (Action.Text.ToString())
                {
                    case "sin":
                        if (Number01.Text == "") throw new Exception("Field number empty");
                        Result.Text = Calculator.CalculateSin(Convert.ToDouble(Number01.Text)).ToString();
                        break;
                    case "cos":
                        if(Number01.Text == "") throw new Exception("Field number empty");
                        Result.Text = Calculator.CalculateCos(Convert.ToDouble(Number01.Text)).ToString();
                        break;
                    case "plus":
                        if (Number01.Text == "" && Number02.Text == "")
                        {
                            throw new Exception("Field 1 number and 2 number empty");
                        }
                        else
                        {
                            if (Number01.Text == "")
                            {
                                throw new Exception("Field 1 number empty");
                            }
                            else if (Number02.Text == "")
                            {
                                throw new Exception("Field 2 number empty");
                            }
                        }
                        Result.Text = Calculator.CalculateSum(Convert.ToDouble(Number01.Text), Convert.ToDouble(Number02.Text)).ToString();
                        break;
                    case "tang":
                        if(Number01.Text == "") throw new Exception("Field number empty");
                        Result.Text = Calculator.CalculateTan(Convert.ToDouble(Number01.Text)).ToString();
                        break;
                    case "sqrt":
                        if(Number01.Text == "") throw new Exception("Field number empty");
                        Result.Text = Calculator.CalculateSqrt(Convert.ToDouble(Number01.Text)).ToString();
                        break;
                    case "square":
                        if(Number01.Text == "") throw new Exception("Field number empty");
                        Result.Text = Calculator.CalculateSquare(Convert.ToDouble(Number01.Text)).ToString();
                        break;
                    case "row power":
                        if (Number01.Text == "" && Number02.Text == "")
                        {
                            throw new Exception("Field number and max power empty");
                        }
                        else
                        {
                            if (Number01.Text == "")
                            {
                                throw new Exception("Field number empty");
                            }
                            else if (Number02.Text == "")
                            {
                                throw new Exception("Field max power empty");
                            }
                        }
                        Result.Text = Calculator.CalculateRowPow(Convert.ToDouble(Number01.Text), Convert.ToInt32(Number02.Text)).ToString();
                        break;
                    default:
                        throw new Exception("Field action empty");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("Undefined error");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Result.Text == "") throw new Exception("Result empty");
                Buffer.Text = Result.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Buffer.Text == "") throw new Exception("Bufer empty");

                Number01.Text = Buffer.Text;
                Action.Text = "";
                Result.Text = "";
                Number02.Text = "";
                TextNumber02.Visible = false;
                Number02.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void Number01_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Convert.ToDouble(Number01.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Number01.Text = "";
            }
        }

        private void Number02_TextChanged(object sender, EventArgs e)
        {

        }

        private void Number02_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Convert.ToDouble(Number01.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Number02.Text = "";
            }
        }

        private void Action_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                switch (Action.Text.ToString())
                {
                    case "sin":
                        break;
                    case "cos":
                        break;
                    case "plus":
                        break;
                    case "tang":
                        break;
                    case "sqrt":
                        break;
                    case "square":
                        break;
                    case "row power":
                        break;
                    default:
                        throw new Exception("Action not set");
                }
            }
            catch(Exception ex)
            {
                Action.Text = "";
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}