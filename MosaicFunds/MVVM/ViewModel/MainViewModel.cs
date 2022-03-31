using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MosaicFunds.Core;
using MosaicFunds.MVVM.View;

namespace MosaicFunds.MVVM.ViewModel 
{
    class MainViewModel : ObservableObject 
    {

        // Page buffer
        public List<object> pageBuffer = new List<object>();

        // watchlist buffer
        public List<DashboardWatchListTickerView> watchlistTickers = new List<DashboardWatchListTickerView>();


        public RelayCommand DashboardCommand { get; set; }
        public RelayCommand DiscoverCommand { get; set; }
        public RelayCommand NewsCommand { get; set; }
        public RelayCommand TransactionsCommand { get; set; }
        public RelayCommand SettingsCommand { get; set; }


        public DashboardViewModel DashboardVM { get; set; }
        public DiscoverViewModel DiscoverVM { get; set; }
        public NewsViewModel NewsViewModel { get; set; }
        public TransactionViewModel TransactionViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }

        // Other views
        public InfoViewModel InfoViewModel { get; set; }
        public NewsDisplayViewModel NewsDisplayViewModel { get; set; }

        private object currentView;

        public object CurrentView 
        {
            get { return this.currentView; }
            set { this.currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel() {
            this.DashboardVM = new DashboardViewModel();
            this.DiscoverVM = new DiscoverViewModel();
            this.NewsViewModel = new NewsViewModel();
            this.InfoViewModel = new InfoViewModel();
            this.TransactionViewModel = new TransactionViewModel();
            this.SettingsViewModel = new SettingsViewModel();
            this.NewsDisplayViewModel = new NewsDisplayViewModel();
            this.CurrentView = DashboardVM;
            RelayCommanders();
        }

        private void RelayCommanders() {
            DashboardCommand = new RelayCommand(o => { this.CurrentView = this.DashboardVM; });
            DiscoverCommand = new RelayCommand(o => { this.CurrentView = this.DiscoverVM; });
            NewsCommand = new RelayCommand(o => { this.CurrentView = this.NewsViewModel; });
            TransactionsCommand = new RelayCommand(o => { this.CurrentView = this.TransactionViewModel; });
            SettingsCommand = new RelayCommand(o => { this.CurrentView = this.SettingsViewModel; });
        }


    }
}
