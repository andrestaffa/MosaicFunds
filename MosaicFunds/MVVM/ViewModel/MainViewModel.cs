using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MosaicFunds.Core;

namespace MosaicFunds.MVVM.ViewModel 
{
    class MainViewModel : ObservableObject 
    {

        public RelayCommand DashboardCommand { get; set; }
        public RelayCommand DiscoverCommand { get; set; }
        public RelayCommand NewsCommand { get; set; }
        public RelayCommand TransactionsCommand { get; set; }
        public RelayCommand SettingsCommand { get; set; }


        public DashboardViewModel DashboardVM { get; set; }
        public DiscoverViewModel DiscoverVM { get; set; }

        private object currentView;

        public object CurrentView 
        {
            get { return this.currentView; }
            set { this.currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel() {
            this.DashboardVM = new DashboardViewModel();
            this.DiscoverVM = new DiscoverViewModel();
            this.CurrentView = DashboardVM;
            relayCommanders();
        }

        private void relayCommanders() {
            DashboardCommand = new RelayCommand(o => { this.CurrentView = this.DashboardVM; });
            DiscoverCommand = new RelayCommand(o => { this.CurrentView = this.DiscoverVM; });
            NewsCommand = new RelayCommand(o => { });
            TransactionsCommand = new RelayCommand(o => { });
            SettingsCommand = new RelayCommand(o => { });
        }


    }
}
