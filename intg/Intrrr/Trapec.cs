using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace intg.Intrrr
{
    class Trapec : ICalcult
    {
        double ICalcult.Calcul(int count, double upLim, double downLim, Func<double, double> integral, out double time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            double h = (upLim - downLim) / count;
            double sum = 0;

            //a += h * k;

            for (int i = 1; i < count-1; i++)
            {
                sum += integral(downLim + h * i);
            }
            sum += integral(downLim) + integral(upLim) / 2;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;
            return h * sum;
        }
    }
}
