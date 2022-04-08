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
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel(title: "Personal Information", 
                                                                                        settings1_static: "First Name", settings1: "Andre",
                                                                                        settings2_static: "Last Name", settings2: "Staffa",
                                                                                        settings3_static: "Email Address", settings3: "andre.staffa@ucalgary.ca",
                                                                                        settings4_static: "Country", settings4: "Canada");
            } else if (button == this.bankingInfoButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel(title: "Banking and Finance",
                                                                                        settings1_static: "Account Number", settings1: "*******0643",
                                                                                        settings2_static: "Bank Number", settings2: "******",
                                                                                        settings3_static: "Branch", settings3: "TD Bank",
                                                                                        settings4_static: "Account Balance", settings4: "$517,436.43");
            } else if (button == this.securityButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel(title: "Security",
                                                settings1_static: "Password", settings1: "*********",
                                                settings2_static: "Change Password", settings2: "",
                                                settings3_static: "Enable Two-Factor Authentication", settings3: "",
                                                settings4_static: "Login Access-Token", settings4: "*****489");
            } else if (button == this.personalizationButton) {
                mainViewModel.SettingsInfoViewModel.settingsModel = new SettingsModel(title: "Personalization",
                                               settings1_static: "Change Theme", settings1: "Color Picker",
                                               settings2_static: "Chart Customization", settings2: "Edit Scheme",
                                               settings3_static: "Remember Login", settings3: "Enabled",
                                               settings4_static: "Reset Settings", settings4: "");
            }

            mainViewModel.CurrentView = mainViewModel.SettingsInfoViewModel;
            mainViewModel.pageBuffer.Add(mainViewModel.SettingsViewModel);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (!main.backButton.IsVisible) main.backButton.Visibility = Visibility.Visible;

        }

    }
}
