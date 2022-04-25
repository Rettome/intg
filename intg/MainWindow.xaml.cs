using Integral.Intrrr;
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
using OxyPlot;
using OxyPlot.Series;

namespace Integral
{
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

            int upLim, downLim;
            try
            {
                upLim = Convert.ToInt32(TxtBoxUplim.Text);
                downLim = Convert.ToInt32(TxtBoxDownlim.Text);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input!");
            }

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
            switch (metod.SelectedIndex)
            {
                case 0: return new Primog();
                case 1: return new Trapec();
                default: throw new NotImplementedException();

            }
        }
        private void DoCalculate()
        {
            int schet = Convert.ToInt32(TxtBoxSteps.Text);
            double upLine = Convert.ToDouble(TxtBoxUplim.Text);
            double downLine = Convert.ToDouble(TxtBoxDownlim.Text);
            double time = 0;

            ICalcult calcult = GetCalcult();
            double result = calcult.Calcul(schet, upLine, downLine, x => (11 * x) - Math.Log(11 * x) - 2, out time);
            MessageBox.Show(result.ToString() + "\nTime: " + Convert.ToString(time), "Results", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
