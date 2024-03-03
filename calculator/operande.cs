using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Operande
    {
        public myOperator op { set; private get; }
        Queue<char> myNumber;
        public event EventHandler addingAChar;

        public Operande()
        {
            myNumber = new Queue<char>();
            this.op = new myOperator('+');
        }

        public Operande(char op)
        {
            myNumber = new Queue<char>();
            this.op = new myOperator(op);
        }

        public Operande(Operande o)
        {
            myNumber = new Queue<char>();
            foreach (char elem in o.myNumber)
            {
                myNumber.Enqueue(elem);
            }
            this.op = o.op;
        }

        public Boolean isEmpty()
        {
            return myNumber.Count == 0;
        }

        public void addChar(char c)
        {
            myNumber.Enqueue(c);
            addingAChar(this, new EventArgs());
        }

        public void removeLast()
        {
            int size = myNumber.Count();
            if (size > 0)
            {
                Queue<char> tmp = new Queue<char>();

                for (int i = 0; i < size - 1; i++)
                {
                    tmp.Enqueue(myNumber.Dequeue());
                }
                myNumber = tmp;

                addingAChar(this, new EventArgs());
            }
        }

        public int toInt()
        {
            int value = 0;

            foreach (char elem in myNumber)
            {
                if (elem == '.') break;
                value *= 10;
                value += elem - '0';
            }

            return value;
        }

        public double toDouble()
        {
            int value = 0;
            int nbFloat = 0;
            Boolean isDouble = false;

            foreach (char elem in myNumber)
            {
                if (isDouble) nbFloat++;
                if (elem != '.')
                {
                    value *= 10;
                    value += elem - '0';
                }
                else
                {
                    isDouble = true;
                }
            }

            return value / (double)(Math.Pow(10, nbFloat));
        }

        public double makeOperation(double op1)
        {
            double op2 = this.toDouble();
            return op.makeOperation(op1, op2);
        }

        public double makeOperation(Operande o2)
        {
            double nbr1 = this.toDouble();
            double nbr2 = o2.toDouble();
            return op.makeOperation(nbr1, nbr2);
        }

        public override string ToString()
        {
            string str = op.ToString();
            foreach(char elem in myNumber)
            {
                str += elem;
            }
            return str;
        }
    }
}
