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

namespace MosaicFunds.MVVM.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            this.watchListStackPanel.Children.Remove(this.amcButton);
            if (mainViewModel.DashboardVM.addToWatchList) this.watchListStackPanel.Children.Insert(0, this.amcButton);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TickerButton button = (sender as TickerButton);
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;

            if (button.Name == "amcButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("AMC", "AMC Theatres", "$15.62", "+4.47", "+5.89%", "8,365", "130.66k", "+$5,461.32");
            } else if (button.Name == "amcButton2") {
                mainViewModel.InfoViewModel.ticker = new Ticker("AMC", "AMC Theatres", "$15.62", "+4.47", "+5.89%", "XX", "XXXXXXX", "XXXXXXX");
            } else if (button.Name == "appleButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("AAPL", "Apple Inc.", "$159.30", "-6.12", "-2.37%", "2,812", "449.95k", "-$3,653.32");
            } else if (button.Name == "baytexButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("BTE.TO", "Baytex Energy", "$6.08", "+0.15", "+2.70%", "15,426", "93.79k", "+$9,197.11");
            } else if (button.Name == "camberButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("CEI", "Camber Energy", "$1.28", "+0.79", "+64.70%", "45,122", "57.56k", "+$33,121.11");
            } else if (button.Name == "teslaButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("TSLA", "Tesla Inc.", "$1009.30", "-15.24", "-2.37%", "XX", "XXXXXXX", "XXXXXXX");
            } else if (button.Name == "adobeButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("ADBE", "Adobe Inc.", "$422.92", "-18.22", "-9.34%", "XX", "XXXXXXX", "XXXXXXX");
            } else if (button.Name == "gameStopButton") {
               mainViewModel.InfoViewModel.ticker = new Ticker("GME", "GameStop Corp.", "$140.15", "+24.89", "+13.81%", "XX", "XXXXXXX", "XXXXXXX");
            }

            mainViewModel.CurrentView = mainViewModel.InfoViewModel;

            mainViewModel.pageBuffer.Add(mainViewModel.DashboardVM);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;

        }

    }
}
