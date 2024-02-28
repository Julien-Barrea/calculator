using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        Queue<Operande> calculation;
        Operande currentNumber;
        private bool needReset;
        private bool isDouble;
        public Form1()
        {
            InitializeComponent();
            label1.Text = null;
            calculation = new Queue<Operande>();
            currentNumber = new Operande('+');
            needReset = false;
            isDouble = false;

        }

        private void reset()
        {
            calculation = new Queue<Operande>();
            currentNumber = new Operande();
            label1.Text = null;
            needReset = false;
        }

 //function keys

        private void button21_Click(object sender, EventArgs e)
        {
            // N/A 1
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // N/A 2
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // show
            label1.Text = queue1.toFloat().ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // >
            if (queue2 == null)
            {
                queue1.removeLast();
            }
            else
            {
                queue2.removeLast();   
            }
            if(label1.Text.Length > 0) label1.Text = label1.Text.Remove(label1.Text.Length - 1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //button A/C
            reset();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // .
            isDouble = true;
            char value = '.';
            if (needReset) reset();
            if (queue2 == null)
            {
                queue1.addChar(value);
            }
            else
            {
                queue2.addChar(value);
            }
            label1.Text += value;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // = button
            double result = 0.0;

            foreach(Operande o in calculation)
            {
                
            }
            if (queue2 != null && !queue2.isEmpty())
            {
                double nb1 = queue1.toFloat();
                double nb2 = queue2.toFloat();
                double res = 0.0;
                reset();
                try
                {
                    switch (op)
                    {
                        case '+':
                            res = nb1 + nb2;
                            break;

                        case '-':
                            res = nb1 - nb2;
                            break;

                        case '*':
                            res = nb1 * nb2;
                            break;

                        case '/':
                            res = (double)nb1 / (double)nb2;
                            break;

                        case 'd':
                             res = (int)nb1 / (int)nb2;
                            break;

                        case 'm':
                            res = nb1 % nb2;
                            break;

                        case '^':
                            if (nb2 == 0) res = 1;
                            else
                            {
                                res = nb1;
                                for (int i = 1; i < nb2; i++) res *= nb1;
                            }
                            break;

                        default:
                            res = 0;
                            break;
                    }
                    label1.Text = res.ToString();
                }
                catch(ArithmeticException exc)
                {
                    label1.Text = "Error div 0 !";
                }
                finally
                {
                    needReset = true;
                }
                
            }
        }

// operators
        private void button17_Click(object sender, EventArgs e)
        {
            // operator +
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('+');
            label1.Text = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // operator -
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('-');
            label1.Text = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // operator *
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('*');
            label1.Text = null;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // operator /
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('/');
            label1.Text = null;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // operator div
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('d');
            label1.Text = null;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // operator mod
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('m');
            label1.Text = null;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // power
            calculation.Enqueue(currentNumber);
            currentNumber = new Operande('^');
            label1.Text = null;
        }

//Numbers

        private void button12_Click(object sender, EventArgs e)
        {
            char value = '0';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char value = '1';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char value = '2';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char value = '3';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char value = '4';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char value = '5';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            char value = '6';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char value = '7';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            char value = '8';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            char value = '9';
            if (needReset) reset();

            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

    }
}
