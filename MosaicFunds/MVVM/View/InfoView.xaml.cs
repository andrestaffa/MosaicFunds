using MosaicFunds.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView : UserControl
    {

        private static bool watchListChecked = false;

        public InfoView()
        {
            InitializeComponent();
            this.watchlistButton.IsChecked = watchListChecked;
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {

            // TODO: Check whether the user has enough funds to buy.

            this.dimBackground.Visibility = Visibility.Visible;
            this.confirmationPanel.Visibility = Visibility.Visible;

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

            // TODO: Check whether the user has enough shares to sell.

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
                float estCost = float.Parse(this.sharesTextBox.Text) * float.Parse(this.priceLabel.Text.Remove(0, 1));
                this.estCostLabel.Text = "$" + String.Format("{0:n}", estCost);
                this._slider.Value = float.Parse(this.sharesTextBox.Text); 
            }
        }

        private void watchlistButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (sender as RadioButton);
            radioButton.IsChecked = !watchListChecked;
            watchListChecked = !watchListChecked;

            MainViewModel mainViewModel = (MainViewModel)Application.Current.MainWindow.DataContext;
            mainViewModel.DashboardVM.addToWatchList = watchListChecked;

        }
    }
}
