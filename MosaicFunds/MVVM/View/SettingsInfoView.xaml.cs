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
    /// Interaction logic for SettingsInfoView.xaml
    /// </summary>
    public partial class SettingsInfoView : UserControl {

        private SettingsModel settingsModel;

        public SettingsInfoView() {
            InitializeComponent();
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            this.settingsModel = mainViewModel.SettingsInfoViewModel.settingsModel;
            this.titleLabel.Text = this.settingsModel.Title;
        }

    }
}
