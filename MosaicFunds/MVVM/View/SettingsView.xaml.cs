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

namespace MosaicFunds.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void SettingsButtonClicked(object sender, RoutedEventArgs e) {

            Button button = (sender as Button);
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;

            if (button == this.personalInfoButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel("Personal Information");
            } else if (button == this.bankingInfoButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel("Banking and Finance");
            } else if (button == this.securityButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel("Security");
            } else if (button == this.personalizationButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel("Personalization");
            }

            mainViewModel.CurrentView = mainViewModel.SettingsInfoViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.SettingsViewModel);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible) main.backButton.Visibility = Visibility.Visible;

        }

    }
}
