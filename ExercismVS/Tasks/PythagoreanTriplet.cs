using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Exercism
{
    internal class PythagoreanTriplet
    {
        public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
        {
            List<(int a, int b, int c)> result = new(); 
            int startvalue = (int)sum/5;
            int A, B, C;
            double a, b, c;
            for (int i = sum; i > startvalue; i--)
            {
                C = i;
                b = -2 * (sum - C);
                a = 2;
                c = Math.Pow((double)(sum - C), 2) - Math.Pow(C, 2);
                double x1 = (-1 * b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double x2 = (-1 * b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

                if (x1 == (int)x1 && x1 > 0)
                {
                    B = (int)x1;
                    A = sum - B - C;
                    if (A < B && B < C && A > 0 && B > 0) result.Add((A, B, C));
                }
                if (x2 == (int)x2 && x2 > 0)
                {
                    B = (int)x2;
                    A = sum - B - C;
                    if (A < B && B < C && A > 0 && B > 0) result.Add((A, B, C));
                }
            }
            return result;
        }
    }
}
