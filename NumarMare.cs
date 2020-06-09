using System;
using System.Text;
namespace OOP_NumarMare
{
    public class NumarMare
    {
        private int[] NrMare;
        private int length;

        public NumarMare()
        {

        }

        public NumarMare(string nr)
        {
            this.length = nr.Length;
            this.NrMare = new int[nr.Length];
            for (int i = nr.Length - 1; i >= 0; i--)
            {
                NrMare[nr.Length - 1 - i] = int.Parse((nr[i]).ToString());
            }
        }

        public NumarMare(int length)
        {
            this.length = length;
            this.NrMare = new int[length];
        }

        public static NumarMare operator +(NumarMare a, NumarMare b)
        {
            int min = Math.Min(a.NrMare.Length, b.NrMare.Length);
            int max = Math.Max(a.NrMare.Length, b.NrMare.Length);
            NumarMare c = new NumarMare(max + 1);

            int k = 0;
            for (int i = 0; i < min; i++)
            {
                c.NrMare[i] = a.NrMare[i] + b.NrMare[i] + k;

                if (c.NrMare[i] >= 10)
                {
                    k = 1;
                    c.NrMare[i] -= 10;
                }
                else
                {
                    k = 0;
                }
            }
            NumarMare d = new NumarMare();
            if (a.NrMare.Length > b.NrMare.Length)
            {
                d = a;
            }
            else
            {
                d = b;
            }

            for (int i = min; i < max; i++)
            {
                c.NrMare[i] = d.NrMare[i] + k;

                if (c.NrMare[i] >= 10)
                {
                    k = 1;
                    c.NrMare[i] -= 10;
                }
                else
                {
                    k = 0;
                }
            }

            if (k == 1)
            {
                c.NrMare[max] = 1;
            }

            return c.RemoveZeros();
        }

        public NumarMare GetFactorial(int n)
        {
            NumarMare currentNumber = new NumarMare("1");
            NumarMare factorial = new NumarMare("1");

            for (int i = 0; i < n; i++)
            {
                factorial *= currentNumber;
                currentNumber++;
            }

            return factorial;
        }

        public static NumarMare operator ++(NumarMare a)
        {
            return a + new NumarMare("1");
        }

        public static NumarMare operator *(NumarMare a, NumarMare b)
        {
            NumarMare c = new NumarMare(a.NrMare.Length + b.NrMare.Length);

            NumarMare[] intermediar = new NumarMare[b.NrMare.Length];

            for (int i = 0; i < b.length; i++)
            {
                NumarMare d = new NumarMare(a.NrMare.Length + b.NrMare.Length); ;
                int produs, rest, cat = 0;

                for (int j = 0; j < a.length; j++)
                {

                    produs = b.NrMare[i] * a.NrMare[j] + cat;
                    rest = produs % 10;
                    cat = produs / 10;

                    d.NrMare[j + i] = rest;
                }

                if (cat > 0)
                {
                    d.NrMare[a.length + i] = cat;
                }
                intermediar[i] = d;
            }

            for (int i = 0; i < intermediar.Length; i++)
            {
                c = c + intermediar[i];
            }

            return c.RemoveZeros();
        }

        public NumarMare RemoveZeros()
        {
            int ultima_pozitie = -1;
            for (int i = 0; i < this.NrMare.Length; i++)
            {
                if (this.NrMare[i] == 0)
                {
                    if (ultima_pozitie < 0)
                    {
                        ultima_pozitie = i;
                    }
                }
                else
                {
                    ultima_pozitie = -1;
                }
            }
            if (ultima_pozitie > 0)
            {
                NumarMare a = new NumarMare(ultima_pozitie);
                for (int i = 0; i < a.NrMare.Length; i++)
                {
                    a.NrMare[i] = this.NrMare[i];
                }
                return a;
            }
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.NrMare.Length; i++)
            {
                sb.Append(this.NrMare[this.NrMare.Length - 1 - i]);
            }

            return sb.ToString();
        }
    }
}