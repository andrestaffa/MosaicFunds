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

using MosaicFunds.MVVM.ViewModel;

namespace MosaicFunds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = (sender as RadioButton);
            button.Visibility = Visibility.Hidden;

            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.CurrentView = mainViewModel.pageBuffer[mainViewModel.pageBuffer.Count - 1];

            if (mainViewModel.pageBuffer[mainViewModel.pageBuffer.Count - 1] is DashboardViewModel) this.dashboardButton.IsChecked = true;
            else if (mainViewModel.pageBuffer[mainViewModel.pageBuffer.Count - 1] is DiscoverViewModel) this.discoverButton.IsChecked = true;

            mainViewModel.pageBuffer.RemoveAt(mainViewModel.pageBuffer.Count - 1);

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.pageBuffer.Clear();

            this.backButton.Visibility = Visibility.Hidden;

        }
    }
}
