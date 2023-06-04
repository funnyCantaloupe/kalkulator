using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Form1 : Form
    {
        bool visible = true;
        private double ans = 0; 

        public Form1()
        {
            InitializeComponent();

           
            button21.Click += numberButton_Click;
            button20.Click += numberButton_Click;
            button24.Click += numberButton_Click;
            button28.Click += numberButton_Click;
            button19.Click += numberButton_Click;
            button23.Click += numberButton_Click;
            button27.Click += numberButton_Click;
            button18.Click += numberButton_Click;
            button22.Click += numberButton_Click;
            button26.Click += numberButton_Click;
            button25.Click += numberButton_Click;

            button34.Click += operationButton_Click;
            button33.Click += operationButton_Click;
            button32.Click += operationButton_Click;
            button31.Click += operationButton_Click;
            button17.Click += operationButton_Click;

            button29.Click += buttonEquals_Click;
            button30.Click += buttonClear_Click;
            button8.Click += buttonAns_Click;

            button2.Click += buttonFunction_Click;
            button3.Click += buttonFunction_Click;
            button10.Click += buttonFunction_Click;
            button14.Click += buttonFunction_Click;
            button4.Click += buttonFunction_Click;
            button5.Click += buttonFunction_Click;
            button15.Click += buttonFunction_Click;
            button6.Click += buttonFunction_Click;
            button7.Click += buttonFunction_Click;
            button16.Click += buttonFunction_Click;
            button9.Click += buttonFunction_Click;
            button13.Click += buttonFunction_Click;

            textBox1.KeyPress += textBox1_KeyPress;
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void buttonFunction_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string function = button.Text;

            double number;
            if (double.TryParse(textBox1.Text, out number))
            {
                double result = 0;

                switch (function)
                {
                    case "lnv":
                        result = Math.Log(number);
                        break;
                    case "sin":
                        result = Math.Sin(number);
                        break;
                    case "x!":
                        result = Factorial(number);
                        break;
                    case "ln":
                        result = Math.Log10(number);
                        break;
                    case "π":
                        result = Math.PI;
                        break;
                    case "cos":
                        result = Math.Cos(number);
                        break;
                    case "log":
                        result = Math.Log(number, 2);
                        break;
                    case "e":
                        result = Math.E;
                        break;
                    case "tan":
                        result = Math.Tan(number);
                        break;
                    case "√":
                        result = Math.Sqrt(number);
                        break;
                    case "exp":
                        result = Math.Exp(number);
                        break;
                    case "%":
                        result = number / 100;
                        break;
                }

                textBox1.Text = result.ToString();
                ans = result;
            }
            else
            {
                MessageBox.Show("Niepoprawna wartość liczby.");
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text;

            
            expression = expression.Replace("×", "*");
            expression = expression.Replace("÷", "/");

            
            expression = expression.Replace("sin", "Math.Sin");
            expression = expression.Replace("cos", "Math.Cos");
            expression = expression.Replace("tan", "Math.Tan");

            
            expression = expression.Replace("rad", "");
            expression = expression.Replace("deg", "* (Math.PI / 180)");

            
            expression = expression.Replace("e", Math.E.ToString());

            
            expression = expression.Replace("π", Math.PI.ToString());


            try
            {
                double result = EvaluateExpression(expression);
                if (!double.IsNaN(result))
                {
                    textBox1.Text = result.ToString();
                    ans = result;

                    UpdateHistory(result.ToString());
                }
                else
                {
                    MessageBox.Show("Niepoprawne wyrażenie.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }

        private double EvaluateExpression(string expression)
        {
            return Convert.ToDouble(new DataTable().Compute(expression, ""));
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonAns_Click(object sender, EventArgs e)
        {
            textBox1.Text += ans.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '^' && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '%' && e.KeyChar != '!')
            {
                e.Handled = true;
            }
        }

        private double Factorial(double number)
        {
            if (number == 0)
                return 1;

            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (visible)
            {
                button1.Hide();
                button10.Hide();
                button2.Hide();
                button3.Hide();
                button14.Hide();
                button4.Hide();
                button5.Hide();
                button15.Hide();
                button6.Hide();
                button7.Hide();
                button16.Hide();
                button8.Hide();
                button9.Hide();
                button17.Hide();
                visible = false;
            }
            else
            {
                button1.Show();
                button10.Show();
                button2.Show();
                button3.Show();
                button14.Show();
                button4.Show();
                button5.Show();
                button15.Show();
                button6.Show();
                button7.Show();
                button16.Show();
                button8.Show();
                button9.Show();
                button17.Show();
                visible = true;
            }
        }

        private void UpdateHistory(string result)
        {
            ListViewItem item = new ListViewItem(result);
            listView1.Items.Add(item);
        }

    }
}
