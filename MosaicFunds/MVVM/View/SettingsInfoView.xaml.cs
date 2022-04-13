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

            this.settings1_static.Text = this.settingsModel.Settings1_Static;
            this.settings1.Text = this.settingsModel.Settings1;

            this.settings2_static.Text = this.settingsModel.Settings2_Static;
            this.settings2.Text = this.settingsModel.Settings2;

            this.settings3_static.Text = this.settingsModel.Settings3_Static;
            this.settings3.Text = this.settingsModel.Settings3;

            this.settings4_static.Text = this.settingsModel.Settings4_Static;
            this.settings4.Text = this.settingsModel.Settings4;


        }

    }
}
