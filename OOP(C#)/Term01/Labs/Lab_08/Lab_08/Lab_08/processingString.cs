using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_08
{
    internal class ProcessingString
    {


        public static string FuncString(string str,Func<string,string> func)
        {
            return func(str);
        }

        public static void PredicateString(string str, Predicate<string> func)
        {
           Console.WriteLine($"Результат поиска = {func(str)}");
        }

        public static void ActionString(string str, Action<string> func)
        {
            func(str);
        }

        public static string ToUpperCASE(ref string str)
        {
            return str = FuncString(str, str => str.ToUpper());
        }

        public static string WriteString(ref string str)
        {
            ActionString(str, str => Console.WriteLine(str));
            return str;
        }

        public static string ReplaceChar(ref string str)
        {
            return str = FuncString(str, str => Regex.Replace(str, @"[,]", " "));
        }

        public static string FindChar(ref string str)
        {
            PredicateString(str, str => str.Contains("!"));
            return str;
        }

    }
}
