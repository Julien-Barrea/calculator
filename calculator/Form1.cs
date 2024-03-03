using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        double previousResult;

        public Form1()
        {
            InitializeComponent();
            reset();
            label1.Text = null;
            label2.Text = null;
        }

        private void reset(double preRes = 0.0)
        {
            //label1.Text = null;
            calculation = new Queue<Operande>();
            currentNumber = new Operande('+');
            previousResult = preRes;

            currentNumber.addingAChar += showOnlabel1;
            //currentNumber.addingAChar += showOnlabel2;
        }

        private void showOnlabel1(object sender, EventArgs e)
        {
            label1.Text = currentNumber.ToString();
        }

        private void showOnlabel2(string str = "")
        {
            if (previousResult == 0) //ne pas montrer 0 +
            {
                label2.Text = "";
                foreach (Operande o in calculation) label2.Text += o.ToString();
                label2.Text += str;

                label2.Text = label2.Text.Remove(0, 3); //retire " + "
            }
            else //montrer x +
            {
                label2.Text = previousResult.ToString();
                foreach (Operande o in calculation) label2.Text += o.ToString();
                label2.Text += str;
            }
        }

        private void manageNewOperator(char op)
        {
            if (currentNumber != null && currentNumber.isEmpty())
            {
                currentNumber.op = new myOperator(op);
            }
            else if (currentNumber != null)
            {
                calculation.Enqueue(currentNumber);
                currentNumber = new Operande(op);
                currentNumber.addingAChar += showOnlabel1;
                //currentNumber.addingAChar += showOnlabel2;
                label1.Text = null;
            }
            showOnlabel2();
        }

//function keys

        private void button10_Click(object sender, EventArgs e)
        {
            // >
            currentNumber.removeLast();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //button A/C
            reset();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // = button
            calculation.Enqueue(currentNumber);
            showOnlabel2();
            try
            {
                foreach (Operande o in calculation)
                {
                    previousResult = o.makeOperation(previousResult);
                }

                label1.Text = previousResult.ToString();
                label2.Text += " = " + label1.Text;
                reset(previousResult);
            }
            catch (ArithmeticException exc)
            {
                reset();
                label1.Text = "Error div 0 !";
            }

        }


// operators
        private void button17_Click(object sender, EventArgs e)
        {
            // operator +
            manageNewOperator('+');
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // operator -
            manageNewOperator('-');
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // operator *
            manageNewOperator('*');
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // operator /
            manageNewOperator('/');
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // operator div
            manageNewOperator('d');
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // operator mod
            manageNewOperator('m');
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // power
            manageNewOperator('^');
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //sqrt
            manageNewOperator('s');
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // or
            manageNewOperator('|');
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // and
            manageNewOperator('&');
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // xor
            manageNewOperator('x');
        }


//Numbers & .
        private void button11_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('.');
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentNumber.addChar('9');
        }
    }
}
  