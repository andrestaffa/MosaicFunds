using MosaicFunds.MVVM.Model;
using MosaicFunds.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView : UserControl
    {
        private Ticker ticker;
        private ALineChart lineChart;

        public InfoView()
        {
            InitializeComponent();

            this.loadingSpinner.Foreground = new SolidColorBrush(Color.FromRgb(173, 216, 230));

            this.ShowLoadingSpinner();
            this.lineChart = new ALineChart(this.stockChart, 15.62, 15.62 - 4.47, 0.1, 15);
            _ = HideLoadingSpinner();
            
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            this.watchlistButton.IsChecked = false;
            
            if (mainViewModel.InfoViewModel.ticker != null) {
                this.ticker = mainViewModel.InfoViewModel.ticker;
                this.stockTicker.Text = this.ticker.Name;
                this.stockCompany.Text = this.ticker.CompanyName;
                this.stockPrice.Text = this.ticker.Price;
                this.priceLabel.Text = this.ticker.Price;
                this.confirmPriceLabel.Text = this.ticker.Price;
                this.stockChangeDollar.Text = this.ticker.ChangeDollar;
                this.stockChangePercent.Text = this.ticker.ChangePercent;
                this.stockShares.Text = this.ticker.Shares;
                this.stockValue.Text = this.ticker.Value;
                this.stockProfit.Text = this.ticker.Profit;

                updateChangeLabel(ref this.stockChangeDollar);
                updateChangeLabel(ref this.stockChangePercent);
                updateChangeLabel(ref this.stockValue);
                updateChangeLabel(ref this.stockProfit);

                Debug.WriteLine(this.stockProfit.Text.Substring(0, 1));

                if (this.ticker.Shares == "NA") {
                    this.stockProfit.Foreground = Brushes.DarkGray;
                    int x = (int)(517436.43f / float.Parse(this.ticker.Price.Remove(0, 1)));
                    this._slider.Maximum = x;
                } else if (this.ticker.Shares != "NA") {
                    this._slider.Maximum = double.Parse(this.ticker.Shares.Replace(",", ""));
                }

                if (this.ticker.Name != "AMC") {
                    foreach (DashboardWatchListTickerView tickerButton in mainViewModel.watchlistTickers) {
                        if (tickerButton.Name.Text == this.ticker.Name) {
                            this.watchlistButton.IsChecked = tickerButton.isWatchListChecked;
                            break;
                        }
                    }
                } else {
                    this.watchlistButton.IsChecked = true;
                }

            }

        }

        private void updateChangeLabel(ref TextBlock textBlock)
        {
            string firstChar = textBlock.Text.Substring(0, 1);
            if (firstChar == "-") {
                textBlock.Foreground = Brushes.Red;
            } else if (firstChar == "+") {
                textBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            } else if (firstChar == "$") {
                textBlock.Foreground = Brushes.DarkGray;
                this.stockProfit_static.Text = "     " + this.stockProfit_static.Text;
                textBlock.Text = "     " + textBlock.Text;
            }
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            float estCost = float.Parse(this.estCostLabel.Text.Remove(0, 1));
            if (estCost > 517436.43f) {
                this.dimBackground.Visibility = Visibility.Visible;
                this.warningPanel.Visibility = Visibility.Visible;
                string shares = String.Format("{0:n}", float.Parse(this.sharesTextBox.Text));
                this.warningMessageLabel.Text = "You do not have enough available funds to buy \n                      " + shares + " amount of shares.";
                return;
            }

            this.dimBackground.Visibility = Visibility.Visible;
            this.confirmationPanel.Visibility = Visibility.Visible;

            this.confirmationTitleLabel.Text = "Confirm Transaction\n            " + "(" + this.ticker.Name + ")";

            this.confirmButton.Background = Brushes.Green;
            this.confirmButton.Style = Application.Current.Resources["ConfirmBuyButtonTheme"] as Style;
            this.confirmButtonTextBlock.Text = "BUY";

            this.confirmEstCostLabel_static.Text = "Estimated Cost:";
            this.confirmEstCostLabel.Foreground = new SolidColorBrush(Color.FromRgb(70, 146, 186));

            this.confirmSharesTextBlock.Text = this.sharesTextBox.Text;
            this.confirmEstCostLabel.Text = this.estCostLabel.Text;

            float newBalance = 517436.43f - float.Parse(this.estCostLabel.Text.Remove(0, 1));
            this.confirmNewBalanceLabel.Text = "$" + String.Format("{0:n}", newBalance);

        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ticker.Shares == "NA") {
                this.dimBackground.Visibility = Visibility.Visible;
                this.warningPanel.Visibility = Visibility.Visible;
                this.warningMessageLabel.Text = "You do not own any shares of " + this.ticker.Name + " to sell.";
                return;
            }

            float shares = float.Parse(this.ticker.Shares.Replace(",", ""));
            float shareCount = float.Parse(this.sharesTextBox.Text);

            if (shareCount > shares) {
                this.dimBackground.Visibility = Visibility.Visible;
                this.warningPanel.Visibility = Visibility.Visible;
                string sharesString = String.Format("{0:n}", float.Parse(this.sharesTextBox.Text));
                this.warningMessageLabel.Text = "You do not own " + sharesString + " shares to sell.";
                return;
            }

            this.dimBackground.Visibility = Visibility.Visible;
            this.confirmationPanel.Visibility = Visibility.Visible;

            this.confirmButton.Background = Brushes.Red;
            this.confirmButton.Style = Application.Current.Resources["ConfirmSellButtonTheme"] as Style;
            this.confirmButtonTextBlock.Text = "SELL";

            this.confirmEstCostLabel_static.Text = "Profit and Loss:";
            this.confirmEstCostLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            this.confirmSharesTextBlock.Text = this.sharesTextBox.Text;
            this.confirmEstCostLabel.Text = "+" + this.estCostLabel.Text;

            float newBalance = 517436.43f + float.Parse(this.estCostLabel.Text.Remove(0, 1));
            this.confirmNewBalanceLabel.Text = "$" + String.Format("{0:n}", newBalance);

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.dimBackground.Visibility = Visibility.Hidden;
            this.confirmationPanel.Visibility = Visibility.Hidden;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.dimBackground.Visibility = Visibility.Hidden;
            this.confirmationPanel.Visibility = Visibility.Hidden;

            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            DashboardPortfolioTickerView dashboardPortfolioTickerView = new DashboardPortfolioTickerView();
            dashboardPortfolioTickerView.Name.Text = this.ticker.Name;
            dashboardPortfolioTickerView.CompanyName.Text = this.ticker.CompanyName;
            dashboardPortfolioTickerView.Price.Text = this.ticker.Price;
            dashboardPortfolioTickerView.ChangePercent.Text = this.ticker.ChangePercent;
            dashboardPortfolioTickerView.Shares.Text = String.Format("{0:n0}", int.Parse(this.sharesTextBox.Text));
            dashboardPortfolioTickerView.PortChangeDollar.Text = "$0.00";
            dashboardPortfolioTickerView.portChangePercent.Text = "0.00%";
            dashboardPortfolioTickerView.PortChangeDollar.Foreground = Brushes.DarkGray;
            dashboardPortfolioTickerView.portChangePercent.Foreground = Brushes.DarkGray;
            mainViewModel.portfolioTickers.Add(dashboardPortfolioTickerView);

        }

        private void _slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.sharesTextBox.Text = this._slider.Value.ToString();
            float estCost = float.Parse(this.sharesTextBox.Text) * float.Parse(this.priceLabel.Text.Remove(0, 1));
            this.estCostLabel.Text = "$" + String.Format("{0:n}", estCost);
        }

        private void sharesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (e.Key == Key.Return || e.Key == Key.Enter) {
                if (this.ticker.Shares != "NA") {
                    float ownedShares = float.Parse(this.ticker.Shares.Replace(",", ""));
                    float enteredShares = float.Parse(this.sharesTextBox.Text);
                    this._slider.Value = (enteredShares > ownedShares) ? ownedShares : float.Parse(this.sharesTextBox.Text);
                    this.sharesTextBox.Text = (enteredShares > ownedShares) ? this.ticker.Shares.Replace(",", "") : this._slider.Value.ToString();
                    float estCost = float.Parse(this.sharesTextBox.Text) * float.Parse(this.priceLabel.Text.Remove(0, 1));
                    this.estCostLabel.Text = "$" + String.Format("{0:n}", estCost);
                } else {
                    float availFunds = 517436.43f;
                    float estCost = float.Parse(this.sharesTextBox.Text) * float.Parse(this.priceLabel.Text.Remove(0, 1));
                    if (estCost > availFunds) {
                        this._slider.Value = this._slider.Maximum;
                        int x = (int)(517436.43f / float.Parse(this.ticker.Price.Remove(0, 1)));
                        this.sharesTextBox.Text = x.ToString();
                    } else {
                        this.estCostLabel.Text = "$" + String.Format("{0:n}", estCost);
                        this._slider.Value = float.Parse(this.sharesTextBox.Text);
                    }
                }
            }
        }

        private void watchlistButton_Click(object sender, RoutedEventArgs e)
        {

            RadioButton radioButton = (sender as RadioButton);
            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            foreach (DashboardWatchListTickerView tickerButton in mainViewModel.watchlistTickers) {
                if (tickerButton.Name.Text == this.ticker.Name) {
                    this.watchlistButton.IsChecked = false;
                    tickerButton.isWatchListChecked = false;
                    mainViewModel.watchlistTickers.Remove(tickerButton);
                    return;
                }
            }

            DashboardWatchListTickerView dashboardWatchListTickerView = new DashboardWatchListTickerView();
            dashboardWatchListTickerView.isWatchListChecked = true;
            dashboardWatchListTickerView.Name.Text = this.ticker.Name;
            dashboardWatchListTickerView.CompanyName.Text = this.ticker.CompanyName;
            dashboardWatchListTickerView.Price.Text = this.ticker.Price;
            dashboardWatchListTickerView.ChangePercent.Text = this.ticker.ChangePercent;
            mainViewModel.watchlistTickers.Add(dashboardWatchListTickerView);
        }

            

        private void warningOkButton_Click(object sender, RoutedEventArgs e)
        {
            this.dimBackground.Visibility = Visibility.Hidden;
            this.warningPanel.Visibility = Visibility.Hidden;
        }

        private void IntervalButtonClicked(object sender, RoutedEventArgs e) {

            RadioButton radioButton = (sender as RadioButton);
            if ((string)radioButton.Content == "1D") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "1W") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "1M") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "1Y") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            } else if ((string)radioButton.Content == "5Y") {
                this.ShowLoadingSpinner();
                this.lineChart.generateRandomChart();
                _ = this.HideLoadingSpinner();
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ShowLoadingSpinner() {
            this.loadingSpinner.Visibility = Visibility.Visible;
            this.loadingSpinner.Spin = true;
        }

        private async Task HideLoadingSpinner() {
            await Task.Delay(1000);
            this.loadingSpinner.Visibility = Visibility.Hidden;
            this.loadingSpinner.Spin = false;
        }

    }
}
