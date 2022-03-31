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
using MosaicFunds.MVVM.Model;
using MosaicFunds.MVVM.ViewModel;

namespace MosaicFunds.MVVM.View
{
    /// <summary>
    /// Interaction logic for DiscoverView.xaml
    /// </summary>
    public partial class DiscoverView : UserControl
    {
        public DiscoverView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;


            // cirlce
            if (button == this.circleBSE) {
                mainViewModel.InfoViewModel.ticker = new Ticker("BSE", "BSE Stock Exchange", "$58,683.99", "+14.17", "+1.68%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleChina) {
                mainViewModel.InfoViewModel.ticker = new Ticker("China", "China Stock Exchange", "$3,266.59 ", "-13.98", "-3.49%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleDJI) {
                mainViewModel.InfoViewModel.ticker = new Ticker("DJI", "Dow Jones Industrial Average", "$32,632.64", "-184.74", "-0.56%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleFTSE) {
                mainViewModel.InfoViewModel.ticker = new Ticker("FTSE", "Times Stock Exchange", "$7,578.75", "-4.47", "+0.53%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleNasdaq) {
                mainViewModel.InfoViewModel.ticker = new Ticker("NASDAQ", "NASDAQ Composite", "$12,795.55", "+35.41", "+0.28%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleNifty) {
                mainViewModel.InfoViewModel.ticker = new Ticker("Nifty", "Nifty Stock Exchange", "$17,498.25", "+56.89", "+0.43%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleSP) {
                mainViewModel.InfoViewModel.ticker = new Ticker("SPX", "Standard and Poor's 500", "$4,170.62", "+30.47", "+0.73%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleSSE) {
                mainViewModel.InfoViewModel.ticker = new Ticker("SSE", "Shanghai Stock Exchange", "$3,266.59", "-147.32", "-2.60%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.circleTSX) {
                mainViewModel.InfoViewModel.ticker = new Ticker("TSX", "TSX Composite", "$21,232.03", "+72.37", "+0.34%", "NA", "      NA      ", "      NA      ");
            }

            // main page
            if (button == this.mainBRO) {
                mainViewModel.InfoViewModel.ticker = new Ticker("BRO", "Brown & Brown, Inc.", "$61.13", "-5.10", "-7.70%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainCORZ) {
                mainViewModel.InfoViewModel.ticker = new Ticker("CORZ", "Core Scientific, Inc.", "$7.19", "+0.91", "+14.49%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainCSIQ) {
                mainViewModel.InfoViewModel.ticker = new Ticker("CSIQ", "Canadian Solar Inc.", "$36.40", "+4.50", "+14.11%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainDJI) {
                mainViewModel.InfoViewModel.ticker = new Ticker("DJI", "Dow Jones Industrial Average", "$32,632.64", "-184.74", "-0.56%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainENSV) {
                mainViewModel.InfoViewModel.ticker = new Ticker("ENSV", "Enservco Corporation", "$4.21", "+1.70", "+68.00%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainISRG) {
                mainViewModel.InfoViewModel.ticker = new Ticker("ISRG", "Intuitive Surgical, Inc.", "$269.32", "-23.37", "-7.98%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainLAC) {
                mainViewModel.InfoViewModel.ticker = new Ticker("LAC", "Lithium Americas Corp.", "$26.06", "+2.21", "+9.27%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainNasdaq) {
                mainViewModel.InfoViewModel.ticker = new Ticker("NASDAQ", "NASDAQ Composite", "$12,795.55", "+35.41", "+0.28%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainNICMF) {
                mainViewModel.InfoViewModel.ticker = new Ticker("NICMF", "NASDAQ Composite", "$1.17", "-0.10", "-7.87%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainNINE) {
                mainViewModel.InfoViewModel.ticker = new Ticker("NICMF", "Nickel Mines Limited", "$1.17", "-0.10", "-7.87%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainNKLA) {
                mainViewModel.InfoViewModel.ticker = new Ticker("NKLA", "Nikola Corporation", "$7.55", "+0.91", "+13.70%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainPBF) {
                mainViewModel.InfoViewModel.ticker = new Ticker("PBF", "PBF Energy Inc.", "$23.54", "+3.70", "+18.65%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainSHOP) {
                mainViewModel.InfoViewModel.ticker = new Ticker("SHOP", "Shopify Inc.", "$514.85", "-45.70", "-8.18%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainSHOP2) {
                mainViewModel.InfoViewModel.ticker = new Ticker("SHOP", "Shopify Inc.", "$514.85", "-45.70", "-8.18%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainSPX) {
                mainViewModel.InfoViewModel.ticker = new Ticker("SPX", "Standard and Poor's 500", "$4,170.62", "+30.47", "+0.73%", "NA", "      NA      ", "      NA      ");
            } else if (button == this.mainTSX) {
                mainViewModel.InfoViewModel.ticker = new Ticker("TSX", "TSX Composite", "$21,232.03", "+72.37", "+0.34%", "NA", "      NA      ", "      NA      ");
            }




            mainViewModel.CurrentView = mainViewModel.InfoViewModel;

            mainViewModel.pageBuffer.Add(mainViewModel.DiscoverVM);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }
    }
}
