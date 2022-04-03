using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveCharts;
using LiveCharts.Wpf;

namespace MosaicFunds.MVVM.Model {
    class Chart {

        private CartesianChart cartesianChart;
        private ChartValues<double> values;
        private int numberOfPoints;

        public Chart(CartesianChart cartesianChart, int numberOfPoints = 25) {
            this.cartesianChart = cartesianChart;
            this.numberOfPoints = numberOfPoints;
            this.generateChart();
        }

        public void generateRandomChart() {
            SeriesCollection series = new SeriesCollection();
            LineSeries lineSeries = new LineSeries();
            this.values = new ChartValues<double>();
            generateValues(ref this.values);
            lineSeries.Values = this.values;
            lineSeries.LabelPoint = point => "$" + String.Format("{0:n}", point.Y);
            series.Add(lineSeries);
            this.cartesianChart.Series = series;
        }

        private void generateChart() {
            SeriesCollection series = new SeriesCollection();
            LineSeries lineSeries = new LineSeries();
            this.values = new ChartValues<double>();
            generateValues(ref this.values);
            lineSeries.Values = this.values;
            lineSeries.LabelPoint = point => "$" + String.Format("{0:n}", point.Y);
            series.Add(lineSeries);
            this.cartesianChart.Series = series;

            this.cartesianChart.AxisX.Add(new Axis());
            this.cartesianChart.AxisY.Add(new Axis());

            this.cartesianChart.AxisX[0].Separator.StrokeThickness = 0;
            this.cartesianChart.AxisY[0].Separator.StrokeThickness = 0;

            this.cartesianChart.AxisX[0].LabelFormatter = val => {
                if (val <= 0) return "";
                return "April " + ((val + 1) % 31) + ", 2022";
            };
            this.cartesianChart.AxisY[0].LabelFormatter = val => "$" + String.Format("{0:n}", val);

            this.cartesianChart.AxisX[0].MaxRange = this.numberOfPoints;

            this.cartesianChart.Zoom = ZoomingOptions.Xy;
            this.cartesianChart.Pan = PanningOptions.Xy;

            this.cartesianChart.AxisY[0].RangeChanged += PortfolioChartRangeChanged;  
        }

        private void PortfolioChartRangeChanged(LiveCharts.Events.RangeChangedEventArgs eventArgs) {
            this.cartesianChart.AxisY[0].MaxValue = this.values.Max();
            this.cartesianChart.AxisY[0].MinValue = this.values.Min();
        }

        private void generateValues(ref ChartValues<double> values) {
            Random random = new Random();
            for (int i = 0; i < this.numberOfPoints; i++) {
                double min = 500000.0 + (500 * (i + 1));
                double x = random.NextDouble() * (517436.43 - min) + min;
                values.Add(x);
            }
        }

    }
}
