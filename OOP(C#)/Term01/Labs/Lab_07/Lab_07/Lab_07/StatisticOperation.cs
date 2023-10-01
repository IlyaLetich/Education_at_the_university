using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Lab_07
{
    public static class StatisticOperation
    {
        public static string SumElement<T>(List<T> list) where T : class
        {
            string strResult = "";

            Node<T> current = list.head;

            while (current != null)
            {
                strResult += current.Data.ToString();
                current = current.Next;
            }

            return strResult.ToString();
        }

        public static int LengthElement<T>(List<T> list)
        {
            Node<T> current = list.head;
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

        public static void WriteListFile<String>(List<String> list,string patch)
        {
            using StreamWriter streamWriter = new(patch);

            Node<String> current = list.head;
            while (current != null)
            {
                streamWriter.Write(current.Data + " # ");
                current = current.Next;
            }
        }
        public static void ReadListFile<T>(ref List<String> listResult,List<String> list,string patch)
        {
            using StreamReader streamReader = new(patch);
            var textFile = streamReader.ReadToEnd();

            string[] elementFile = textFile.Split("#");

            for(int  i = 0; i < elementFile.Length - 1; i++)
            {
                if (elementFile[i].Length != 0)
                    listResult.Add(elementFile[i]);
            }
        }
    }
}