using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class myOperator
    {
        char op;

        public myOperator(char op)
        {
            this.op = op;
        }

        public double makeOperation(double a, double b)
        {
            switch (this.op)
            {
                case '+':
                    return a + b;

                case '-':
                    return a - b;

                case '*':
                    return a * b;

                case '/':
                    return (double)a / (double)b;

                case 'd':
                    return (int)a / (int)b;

                case 'm':
                    return a % b;

                case '^':
                    if (b == 0) return 1;
                    else 
                    {
                        double res = a;
                        for (int i = 1; i < b; i++) res *= a;
                        return res;
                    }

                case 's':
                    return Math.Sqrt(b);

                case '|':
                    return (int)a | (int)b;

                case '&':
                    return (int)a & (int)b;

                case 'x':
                    return (int)a ^ (int)b;

                default:
                    throw new Exception();
            }
        }

        public String ToString()
        {
            return " " + op.ToString() + " ";
        }

    }
}
