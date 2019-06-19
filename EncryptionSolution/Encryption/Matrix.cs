using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Matrix<T>
    {
        public T[,] data;
        public int rows;
        public int columns;

        public Matrix(int rows, int columns, T[] inputData)
        {
            this.rows = rows;
            this.columns = columns;

            data = new T[rows, columns];

            int temp = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (temp == inputData.Length)
                        break;
                    data[i, j] = inputData[temp];
                    temp++;
                }
            }

        }

        public void DisplayMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("         ");

                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{data[i,j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
