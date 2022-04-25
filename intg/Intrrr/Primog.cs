using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace intg.Intrrr
{
    class Primog : ICalcult
    {
        double ICalcult.Calcul(int count, double upLim, double downLim, Func<double, double> integral, out double time)
        {
            if (count<=0)
            {
                throw new ArgumentException();
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            double h = (upLim - downLim) / count;
            double sum = 0;

            //a += h * k;

            for(int i=0; i<count; i++)
            {
                sum += integral(downLim + h * i);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;
            return h * sum;
        }
    }
}
