using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MosaicFunds.MVVM.Model;
using MosaicFunds.MVVM.ViewModel;

using LiveCharts;
using LiveCharts.Wpf;
using System.Threading;

namespace MosaicFunds.MVVM.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {

        private ALineChart lineChart;

        public DashboardView()
        {
            InitializeComponent();

            this.loadingSpinner.Foreground = new SolidColorBrush(Color.FromRgb(173, 216, 230));

            this.ShowLoadingSpinner();
            this.lineChart = new ALineChart(this.portfolioChart, 517436.43, 500000.0, 500);
            _ = HideLoadingSpinner();

            List<Tuple<string, int>> sectorSections = new List<Tuple<string, int>>();
            sectorSections.Add(new Tuple<string, int>("Energy", 33));
            sectorSections.Add(new Tuple<string, int>("Entertainment", 20));
            sectorSections.Add(new Tuple<string, int>("Technology", 20));
            sectorSections.Add(new Tuple<string, int>("Medical", 17));
            new APieChart(this.sectorPieChart, sectorSections);

            List<Tuple<string, int>> assetSections = new List<Tuple<string, int>>();
            assetSections.Add(new Tuple<string, int>("TFSA", 30));
            assetSections.Add(new Tuple<string, int>("CAD Cash", 10));
            assetSections.Add(new Tuple<string, int>("RRSP", 10));
            assetSections.Add(new Tuple<string, int>("USD Cash", 50));
            new APieChart(this.assetPirChart, assetSections);

            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            foreach (DashboardWatchListTickerView tickerButton in mainViewModel.watchlistTickers) this.watchlistStackPanel.Children.Insert(0, tickerButton);
            foreach (DashboardPortfolioTickerView tickerButton in mainViewModel.portfolioTickers) this.portfolioStackPanel.Children.Insert(0, tickerButton);
            mainViewModel.watchlistTickers.Clear();
            mainViewModel.portfolioTickers.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = (sender as Button);
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;

            if (button.Name == "amcButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("AMC", "AMC Theatres", "$15.62", "+4.47", "+5.89%", "8,365", "130.66k", "+$5,461.32");
            } else if (button.Name == "amcButton2") {
               mainViewModel.InfoViewModel.ticker = new Ticker("AMC", "AMC Theatres", "$15.62", "+4.47", "+5.89%", "NA", "      NA      ", "      NA      ");
            } else if (button.Name == "appleButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("AAPL", "Apple Inc.", "$159.30", "-6.12", "-2.37%", "2,812", "449.95k", "-$3,653.32");
            } else if (button.Name == "baytexButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("BTE.TO", "Baytex Energy", "$6.08", "+0.15", "+2.70%", "15,426", "93.79k", "+$9,197.11");
            } else if (button.Name == "camberButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("CEI", "Camber Energy", "$1.28", "+0.79", "+64.70%", "45,122", "57.56k", "+$33,121.11");
            } else if (button.Name == "teslaButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("TSLA", "Tesla Inc.", "$1009.30", "-15.24", "-2.37%", "NA", "      NA      ", "      NA      ");
            } else if (button.Name == "adobeButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("ADBE", "Adobe Inc.", "$422.92", "-18.22", "-9.34%", "NA", "      NA      ", "      NA      ");
            } else if (button.Name == "gameStopButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("GME", "GameStop Corp.", "$140.15", "+24.89", "+13.81%", "NA", "      NA      ", "      NA      ");
            }

            mainViewModel.CurrentView = mainViewModel.InfoViewModel;

            mainViewModel.pageBuffer.Add(mainViewModel.DashboardVM);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;

        }

        private void IntervalButtonClicked(object sender, RoutedEventArgs e) {

            RadioButton radioButton = (sender as RadioButton);
            if ((string)radioButton.Content == "1D") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "1W") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "1M") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "1Y") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "5Y") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            }

        }

        private void ShowLoadingSpinner() {
            this.loadingSpinner.Visibility = Visibility.Visible;
            this.loadingSpinner.Spin = true;
        }

        private async Task HideLoadingSpinner() {
            await Task.Delay(1000);
            this.loadingSpinner.Visibility = Visibility.Hidden;
            this.loadingSpinner.Spin = false;
        }

    }
}
