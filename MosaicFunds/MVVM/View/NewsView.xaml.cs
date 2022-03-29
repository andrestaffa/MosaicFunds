using MosaicFunds.MVVM.ViewModel;
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

namespace MosaicFunds.MVVM.View
{
    /// <summary>
    /// Interaction logic for NewsView.xaml
    /// </summary>
    public partial class NewsView : UserControl
    {
        public NewsView()
        {
            InitializeComponent();
        }

        private void brentButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.cnbc.com/2022/03/21/oil-markets-european-union-russia-saudi-refinery-output.html";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

        private void goldButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.cnbc.com/2022/03/21/gold-markets-ukraine-crisis-federal-reserve.html";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;

        }

        private void berkshireButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.investing.com/news/stock-market-news/berkshire-hathaway-stock-price-reaches-500000-2784422";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

        private void russiaButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.investing.com/news/forex-news/us-options-remain-toward-russia-including-full-trade-embargo-cnbc-2784270";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

        private void marketButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.marketwatch.com/story/apple-can-withstand-production-disruptions-in-china-analysts-say-11647289600?mod=technology";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

        private void nvidiaButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.fool.com/investing/2022/03/14/why-nvidia-stock-dropped-again-today";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

        private void oilGoldman_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://finance.yahoo.com/news/12-oil-stocks-goldman-sachs-thinks-has-big-upside-potential-165838737.html";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

        private void fordButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.NewsDisplayViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.NewsViewModel);


            mainViewModel.NewsDisplayViewModel.link = "https://www.cnbc.com/2022/03/14/ford-says-it-will-ramp-up-ev-offering-in-europe.html";


            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;
        }

    }
}
