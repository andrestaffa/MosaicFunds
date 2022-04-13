using MosaicFunds.MVVM.Model;
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

namespace MosaicFunds.MVVM.View {
    /// <summary>
    /// Interaction logic for DashboardWatchListTickerView.xaml
    /// </summary>
    public partial class DashboardWatchListTickerView : UserControl {

        public bool isWatchListChecked = false;

        public DashboardWatchListTickerView() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.InfoViewModel.ticker = new Ticker(this.Name.Text, this.CompanyName.Text, this.Price.Text, "+2.59", this.ChangePercent.Text, "NA", "NA", "NA");
            mainViewModel.CurrentView = mainViewModel.InfoViewModel;

            mainViewModel.pageBuffer.Add(mainViewModel.DashboardVM);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible)
                main.backButton.Visibility = Visibility.Visible;

        }
    }
}
