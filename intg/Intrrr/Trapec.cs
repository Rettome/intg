using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Integral.Intrrr
{
    class Trapec : ICalcult
    {
        double ICalcult.Calcul(int count, double upLim, double downLim, Func<double, double> integral, out double time)
        {
            double h = (upLim - downLim) / (double)count;
            double sum = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < count-1; i++)
            {
                sum += integral(downLim + h * i);
            }
            sum += (integral(downLim) + integral(upLim)) / 2.0;
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            time = ts.TotalMilliseconds;
            return h * sum;
        }
    }
}
