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
        double previousResult;
        private bool needReset;

        public Form1()
        {
            InitializeComponent();
            label1.Text = null;
            calculation = new Queue<Operande>();
            currentNumber = new Operande('+');
            previousResult = 0.0;
        }

        private void reset(double preRes=0.0)
        {
            calculation = new Queue<Operande>();
            currentNumber = new Operande();
            label1.Text = null;
            previousResult = preRes;
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
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // >
            currentNumber.removeLast();
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
            char value = '.';
            currentNumber.addChar(value);
            label1.Text += value;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // = button
            calculation.Enqueue(currentNumber);

            try 
            { 
                foreach(Operande o in calculation)
                {
                    previousResult = o.makeOperation(previousResult);
                }
            
                reset(previousResult);
                label1.Text = previousResult.ToString();
            }
            catch(ArithmeticException exc)
            {
                label1.Text = "Error div 0 !";
                needReset = true;
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
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char value = '1';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char value = '2';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char value = '3';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char value = '4';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char value = '5';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            char value = '6';
            currentNumber.addChar('6');
            label1.Text += value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char value = '7';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            char value = '8';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            char value = '9';
            currentNumber.addChar(value);
            label1.Text += value.ToString();
        }

    }
}
