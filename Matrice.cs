using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_matrici
{
    internal class Matrice
    {
        private int linii, coloane;
        private float[,] matrice;
        private static Random rng = new Random();

        private int max = 1;

        public Matrice(int rows, int columns)
        {
            this.linii = rows;
            this.coloane = columns;
            matrice = new float[this.linii, this.coloane];
        }

        public Matrice(int n) : this(n, n)
        {

        }

        public void RandomInitMatrix()
        {
            int n = this.linii;
            int m = this.coloane;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrice[i, j] = Matrice.rng.Next(10);
                }
            }
        }

        public Matrice Multiply(Matrice m2)
        {
            if (this.coloane != m2.linii)
            {
                throw new ImpossibleMatrixOperationException();
            }
            int n = this.linii;
            int m = m2.coloane;

            Matrice a = new Matrice(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    float suma = 0;
                    for (int k = 0; k < this.coloane; k++)
                    {
                        suma += this.matrice[i, k] * m2.matrice[k, j];
                    }
                    a.matrice[i, j] = suma;
                }
            }

            return a;
        }

        internal Matrice GetInverseMatrix(float det)
        {
            int n = this.linii;
            Matrice transpose = this.GetTransposedMatrix();
            Console.WriteLine("Transpusa:");
            Console.WriteLine(transpose);

            Matrice adjugate = transpose.GetAdjugateMatrix();
            Console.WriteLine("Matricea adjuncta: ");
            Console.WriteLine(adjugate);
            Matrice inverse_matrix = new Matrice(n, n);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverse_matrix.matrice[i, j] = adjugate.matrice[i, j] / det;
                }
            }
            return inverse_matrix;
        }

        public Matrice GetAdjugateMatrix()
        {
            Matrice a = new Matrice(this.linii, this.coloane);

            for (int i = 0; i < this.linii; i++)
            {
                for (int j = 0; j < this.coloane; j++)
                {
                    Matrice b = this.Reduce(this, i, j);
                    a.matrice[i, j] = (int)Math.Pow(-1, (i + j)) * b.GetDeterminant();
                }
            }
            return a;
        }

        public Matrice Reduce(Matrice old, int lin, int col)
        {
            int n = old.linii;
            int m = old.coloane;

            Matrice tmp = new Matrice(n - 1, m - 1);
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp.matrice[i, j] = old.matrice[i, j];
                }
            }

            for (int i = 0; i < lin; i++)
            {
                for (int j = col + 1; j < m; j++)
                {
                    tmp.matrice[i, j - 1] = old.matrice[i, j];
                }
            }

            for (int i = lin + 1; i < n; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp.matrice[i - 1, j] = old.matrice[i, j];
                }
            }

            for (int i = lin + 1; i < n; i++)
            {
                for (int j = col + 1; j < m; j++)
                {
                    tmp.matrice[i - 1, j - 1] = old.matrice[i, j];
                }
            }

            return tmp;
        }

        public float GetDeterminant()
        {
            int n = this.linii;
            int m = this.coloane;

            if (n != m)
            {
                throw new ImpossibleMatrixOperationException();
            }

            if (n == 2)
            {
                return this.matrice[0, 0] * this.matrice[1, 1] - this.matrice[0, 1] * this.matrice[1, 0];
            }
            if (n == 3)
            {
                return (this.matrice[0, 0] * this.matrice[1, 1] * this.matrice[2, 2] + this.matrice[1, 0] * this.matrice[2, 1] * this.matrice[0, 2] + this.matrice[0, 1] * this.matrice[1, 2] * this.matrice[2, 0]) -
                    (this.matrice[0, 2] * this.matrice[1, 1] * this.matrice[2, 0] + this.matrice[0, 1] * this.matrice[1, 0] * this.matrice[2, 2] + this.matrice[1, 2] * this.matrice[2, 1] * this.matrice[0, 0]);
            }
            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                Matrice aux = new Matrice(n - 1, n - 1);
                int y = 0;
                int z = 0;
                for (int k = 1; k < n; k++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            aux.matrice[y, z] = this.matrice[k, j];
                            z++;
                        }
                    }
                    z = 0;
                    y++;
                }
                if ((i + 2) % 2 == 0)
                {
                    sum += this.matrice[0, 1] * aux.GetDeterminant();
                }
                else
                {
                    sum -= this.matrice[0, 1] * aux.GetDeterminant();
                }
            }


            return sum;
        }

        public Matrice GetTransposedMatrix()
        {
            Matrice a = new Matrice(this.linii, this.coloane);

            for (int i = 0; i < this.linii; i++)
            {
                for (int j = 0; j < this.coloane; j++)
                {
                    a.matrice[i, j] = this.matrice[j, i];
                }
            }
            return a;
        }

        public Matrice Pow(int n)
        {
            Matrice a = new Matrice(this.linii, this.coloane);
            while (n > 0)
            {
                a = this.Multiply(this);
                n--;
            }
            return a;
        }

        public Matrice Subtract(Matrice m2)
        {
            if (this.linii != m2.linii && this.coloane != m2.coloane)
            {
                throw new ImpossibleMatrixOperationException();
            }

            int n = this.linii;
            int m = this.coloane;

            Matrice a = new Matrice(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a.matrice[i, j] = this.matrice[i, j] - m2.matrice[i, j];
                }
            }

            return a;
        }

        public Matrice Add(Matrice m2)
        {
            if (this.linii != m2.linii && this.coloane != m2.coloane)
            {
                throw new ImpossibleMatrixOperationException();
            }

            int n = this.linii;
            int m = this.coloane;

            Matrice a = new Matrice(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a.matrice[i, j] = this.matrice[i, j] + m2.matrice[i, j];
                }
            }

            return a;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string formatString = "{0, ";

            formatString += max;
            formatString += "}";
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    sb.AppendFormat(formatString, matrice[i, j]);
                    sb.Append(" ");
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}