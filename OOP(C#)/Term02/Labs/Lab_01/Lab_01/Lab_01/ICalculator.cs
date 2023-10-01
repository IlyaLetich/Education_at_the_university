using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal interface ICalculator
    {
        double CalculateSin(double number);
        double CalculateCos(double number);
        double CalculateTan(double number);
        double CalculateSum(double number01, double number02);
        double CalculateSqrt(double number);
        double CalculateSquare(double number);
        double[] CalculateRowPow(double number, int maxPower);
    }
}
