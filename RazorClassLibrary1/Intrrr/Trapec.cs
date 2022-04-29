using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;


namespace Matematics.Intrrr
{
    class Trapec : ICalcult
    {
        private double time;

        double ICalcult.Calcul(int count, double upLim, double downLim, Func<double, double> integral)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double h = (upLim - downLim) / count;
            double sum = 0;
       
            //a += h * k;

            for (int i = 1; i < count-1; i++)
            {
                sum += integral(downLim + h * i);
              
            }
            sum += integral(downLim) + integral(upLim) / 2;
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            
            return h * sum;
           
           
        }
    }
}
