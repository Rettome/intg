using intg.Intrrr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using OxyPlot;
using OxyPlot.Series;

namespace intg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }

        private void btGraph_Click(object sender, RoutedEventArgs e)
        {
            var plot = new PlotModel()
            {
                Title = "11x - log(11x) - 2"
            };
            var lineSeries = new LineSeries();

            int upLim = Convert.ToInt32(tbUp.Text);
            int downLim = Convert.ToInt32(tbDown.Text);
            ICalcult calcultGraph = GetCalcult();

            for (int i = 1; i < 1000; i++)
            {
                double time = 0;
                double result = calcultGraph.Calcul(i, upLim, downLim, x => (11 * x) - Math.Log(11 * x) - 2, out time);
                lineSeries.Points.Add(new DataPoint(i, time));
            }

            plot.Series.Add(lineSeries);
            Graph.Model = plot;
        }

        private ICalcult GetCalcult()
        {
            switch(MethodCalculate.SelectedIndex)
            {
                case 0: return new Primog();
                case 1: return new Trapec();
                default: throw new NotImplementedException();

            }
        }

        private void DoCalculate()
        {
            int schet = Convert.ToInt32(Count.Text);
            double upLine = Convert.ToDouble(tbUp.Text);
            double downLine = Convert.ToDouble(tbDown.Text);
            double time = 0;

            ICalcult calcult = GetCalcult();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            double result = calcult.Calcul(schet, upLine, downLine, x => (11 * x) - Math.Log(11 * x) - 2, out time);
            
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;
            MessageBox.Show("Result: " + result.ToString()+ "\n time: " +
                Convert.ToString(time));
        }
    }
}
