using System.Globalization;
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

namespace Bai05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txbSource1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num1) &&
                double.TryParse(txbSource2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num2))
            {
                double tong = num1 + num2;
                txbResult.Text = tong.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txbSource1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num1) &&
                double.TryParse(txbSource2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num2))
            {
                double hieu = num1 - num2;
                txbResult.Text = hieu.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txbSource1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num1) &&
                double.TryParse(txbSource2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num2))
            {
                double tich = num1 * num2;
                txbResult.Text = tich.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txbSource1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num1) &&
                double.TryParse(txbSource2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double num2))
            {
                double thuong = num1 / num2;
                txbResult.Text = thuong.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}