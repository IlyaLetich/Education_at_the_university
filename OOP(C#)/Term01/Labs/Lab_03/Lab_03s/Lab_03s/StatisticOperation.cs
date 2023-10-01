using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_03.List<string>;


namespace Lab_03
{
    public static class StatisticOperation
    {
        public static string SumElement(List<String> list)
        {
            string strResult = "";

            Node<String> current = list.head;

            while (current != null)
            {
                strResult += current.Data.ToString();
                current = current.Next;
            }

            return strResult.ToString();
        }

        public static int LengthElement(List<String> list)
        {
            Node<String> current = list.head;
            int i = 0;
            while (current != null)
            {
                i++;
                current = current.Next;
            }

            return i;
        }
        public static int MinMax(List<string> list)
        {
            Node<string> current = list.head;
            int result = 0;
            int i = 0;
            while (current != null)
            {
                i++;
                result = current.Data.Length;
                current = current.Next;
            }
            result = result - list.head.Data.Length;
            return result;
        }

        public static string FindLetterNumber(this string str_01)
        {
            string numSymbol = "";
            string numString = "";
            for (int index = 0; index < str_01.Length; index++)
            {
                if (str_01[index] >= '0' && str_01[index] <= '9')
                {
                    numString += str_01[index];
                }
                else
                {
                    if (numString != "") numSymbol = numString;
                    numString = "";
                }
            }

            return numSymbol;
        }
    }
}
