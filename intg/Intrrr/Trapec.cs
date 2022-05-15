using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intg.Intrrr
{
    class Trapec : ICalcult
    {
        double ICalcult.Calcul(int count, double downLim, double upLim, Func<double, double> integral, out double time) 
        {
            double h = (upLim - downLim) / count;
            double sum = 0;

            //a += h * k;

            for (int i = 1; i < count-1; i++)
            {
                sum += integral(downLim + h * i);
            }
            sum += integral(downLim) + integral(upLim) / 2;
            time = 0;
            return h * sum;
        }
    } 
}
