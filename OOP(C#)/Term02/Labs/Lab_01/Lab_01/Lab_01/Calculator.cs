using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Calculator : ICalculator
    {
        public double CalculateSin(double number)
        {
            return Math.Sin(number);
        }
        public double CalculateCos(double number)
        {
            return Math.Cos(number);
        }
        public double CalculateTan(double number)
        {
            return Math.Tan(number);
        }
        public double CalculateSum(double number01, double number02)
        {
            return number01 + number02;
        }
        public double CalculateSqrt(double number)
        {
            return Math.Sqrt(number);
        }
        public double CalculateSquare(double number)
        {
            return Math.Pow(number, (1/3f));
        }
        public double[] CalculateRowPow(double number,int maxPower)
        {
            double[] doubles = new double[maxPower];
            for (int i = 0; i < maxPower; i++)
            {
                doubles[i] = Math.Pow(number, i + 1);
            }
            return doubles;
        }
    }
}
