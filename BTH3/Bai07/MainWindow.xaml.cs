using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bai07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum seatStatus {Available, Selected, Sold};
        private seatStatus[] seatStates = new seatStatus[15];
        private readonly int[] seatPrices = new int[15];
        public MainWindow()
        {
            InitializeComponent();
            InitializeSeatStates();
        }
        private void InitializeSeatStates() {
            for (int i = 0; i<5; i++)
            {
                seatPrices[i] = 5000;
                seatStates[i] = seatStatus.Available;
            }
            for (int i = 5; i < 10; i++)
            {
                seatPrices[i] = 6500;
                seatStates[i] = seatStatus.Available;
            }
            for (int i = 10; i < 15; i++)
            {
                seatPrices[i] = 8000;
                seatStates[i] = seatStatus.Available;
            }

        }
        private void UpdateAllSeatColor()
        {
            for (int i = 1; i <= 15; i++)
            {
                Button seatButton = (Button)FindName($"Seat{i}");
                if (seatButton != null)
                {
                    int index = i - 1;
                    switch (seatStates[index])
                    {
                        case seatStatus.Available:
                            seatButton.Background = Brushes.White;
                            break;
                        case seatStatus.Sold:
                            seatButton.Background = Brushes.Yellow;
                            break;
                        case seatStatus.Selected:
                            seatButton.Background = Brushes.Blue;
                            break;
                    }
                }
            }
        }
        private int calcTotalAmount()
        {
            int totalAmount = 0;
            for (int i = 0; i<15; i++)
            {
                if (seatStates[i] == seatStatus.Selected)
                {
                    totalAmount+= seatPrices[i];
                }
            }
            return totalAmount;
        }
        private void updateTotalAmountDisplay()
        {
            int totalAmount = calcTotalAmount();
            TotalAmount.Text = totalAmount.ToString();
        }
        private bool HasSelectedSeat()
        {
            for (int i = 0; i<15; i++)
            {
                if (seatStates[i] == seatStatus.Selected)
                    return true;
            }
            return false;
        }
        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button Button = sender as Button;
            if (Button == null) return;
            int seatNumber = int.Parse(Button.Content.ToString());
            int index = seatNumber - 1;

            seatStatus currStatus = seatStates[index];
            switch (currStatus) {
                case seatStatus.Available:
                    seatStates[index] = seatStatus.Selected;
                    Button.Background = Brushes.Blue;
                    break;
                case seatStatus.Selected:
                    seatStates[index] = seatStatus.Available;
                    Button.Background = Brushes.White;
                    break;
                case seatStatus.Sold:
                    MessageBox.Show($"Ghế số {seatNumber} đã được bán. Vui lòng chọn ghế khác.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
            UpdateButtonState();
        }
        private void UpdateButtonState()
        {
            bool state = HasSelectedSeat();
            SelectButton.IsEnabled = state;
            CancelButton.IsEnabled = state;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            updateTotalAmountDisplay();
            for (int i = 0; i<15; i++)
            {
                if (seatStates[i] == seatStatus.Selected)
                {
                    seatStates[i] = seatStatus.Sold;
                }
            }
            UpdateAllSeatColor();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                if (seatStates[i] == seatStatus.Selected)
                {
                    seatStates[i] = seatStatus.Available;
                }
            }
            UpdateAllSeatColor();
            TotalAmount.Text = "0";
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}