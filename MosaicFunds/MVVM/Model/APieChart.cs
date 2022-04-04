using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace MosaicFunds.MVVM.Model {
    class APieChart {

        private PieChart pieChart;
        private List<Tuple<string, int>> sections;

        public APieChart(PieChart pieChart, List<Tuple<string, int>> sections) {
            this.pieChart = pieChart;
            this.sections = sections;
            this.generateChart();
        }


        private void generateChart() {
            SeriesCollection series = new SeriesCollection();
            foreach (Tuple<string, int> section in this.sections) {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = section.Item1;
                pieSeries.Values = new ChartValues<ObservableValue> { new ObservableValue(section.Item2) };
                pieSeries.DataLabels = true;
                series.Add(pieSeries);
            }
            this.pieChart.Series = series;
        }



    }
}
