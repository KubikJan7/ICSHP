using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
An English text needs to be encrypted using the following encryption scheme.
First, the spaces are removed from the text.Let be the length of this text.
Then, characters are written into a grid.

For example, the sentence s = if man was meant to stay on the ground god would have given us roots 
, after removing spaces is 54 characters long. sqrt(54) is between 7 and 8, so it is written in the form of a grid with 7 rows and 8 columns.

ifmanwas  
meanttos          
tayonthe  
groundgo  
dwouldha  
vegivenu  
sroots

*/
namespace Encryption
{
    class Program
    {
        static private (int, int, char[]) GetRowsAndColumns(string inputStr)
        {
            string str = inputStr.Replace(" ", string.Empty);
            int row, column;
            char[] charAr;
            row = (int) Math.Sqrt(str.Length);
            column = (int) Math.Ceiling(Math.Sqrt(str.Length));
            charAr = str.ToCharArray();
            return (row, column,charAr);
        }

        static private string CreateEncodedString(Matrix<char> mat)
        {
            string str = "";
            for (int i = 0; i < mat.columns; i++)
            {
                for (int j = 0; j < mat.rows; j++)
                {
                    str+=mat.data[j, i];
                }
                str += " ";
            }
            return str;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"The purpose of this program is to encrypt a given string using a matrix.");
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.WriteLine($"Please type in a message to encrypt");
            string inputStr = Console.ReadLine();
            //Console.WriteLine($"The message to encode is following:\n{inputStr}\n");

            int rows, columns;
            char[] charAr;
            (rows,columns, charAr) = GetRowsAndColumns(inputStr);
            Matrix<char> matrix = new Matrix<char>(rows,columns,charAr);
            Console.WriteLine("The matrix used for encoding looks like this:\n");
            matrix.DisplayMatrix();

            Console.WriteLine("\nThe message after encryption:\n");
            Console.WriteLine($"{CreateEncodedString(matrix)}");
        }
    }
}
