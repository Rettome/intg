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
            DoCalculete();
        }

        private void btGraph_Click(object sender, RoutedEventArgs e)
        {
            var plot = new PlotModel()
            {
                Title = "11x - log(11x) - 2"
            };
            var lineSeries = new LineSeries();

            int upLim = Convert.ToInt32(tret.Text);
            int downLim = Convert.ToInt32(vtor.Text);
            ICalcult calcultGraph = new Primog();

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
             return metod.SelectedIndex switch
            {
                0 => new Primog();
                1 => new Trapec();
                _ => throw new NotImplementedException();
            };
        }

        private void DoCalculete()
        {
            int countSplits = Convert.ToInt32(perv.Text);
            double upLim = Convert.ToDouble(tret.Text);
            double downLim = Convert.ToDouble(vtor.Text);
            double time = 0;

            ICalcult calcult = GetCalcult();
            double result = calcult.Calcul(countSplits, upLim, downLim, x => (11 * x) - Math.Log(11 * x) - 2, out time);
            MessageBox.Show($"Результат вычислений = {result.ToString()}");
        }
    }
}
