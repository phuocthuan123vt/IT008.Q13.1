using System;
using System.Windows;
using System.Windows.Controls;

namespace Bai06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentValue = 0;
        private double storedValue = 0;
        private string currentOperation = "";
        private bool isNewEntry = true;
        private double memoryValue = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Tag.ToString();

            if (isNewEntry)
            {
                DisplayTextBox.Text = number;
                isNewEntry = false;
            }
            else
            {
                if (DisplayTextBox.Text == "0")
                    DisplayTextBox.Text = number;
                else
                    DisplayTextBox.Text += number;
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (isNewEntry)
            {
                DisplayTextBox.Text = "0.";
                isNewEntry = false;
            }
            else if (!DisplayTextBox.Text.Contains("."))
            {
                DisplayTextBox.Text += ".";
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Tag.ToString();

            if (!isNewEntry && !string.IsNullOrEmpty(currentOperation))
            {
                Calculate();
            }

            storedValue = double.Parse(DisplayTextBox.Text);
            currentOperation = operation;
            isNewEntry = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentOperation))
            {
                Calculate();
                currentOperation = "";
            }
        }

        private void Calculate()
        {
            try
            {
                currentValue = double.Parse(DisplayTextBox.Text);
                double result = 0;

                switch (currentOperation)
                {
                    case "+":
                        result = storedValue + currentValue;
                        break;
                    case "-":
                        result = storedValue - currentValue;
                        break;
                    case "*":
                        result = storedValue * currentValue;
                        break;
                    case "/":
                        if (currentValue == 0)
                        {
                            MessageBox.Show("Không thể chia cho 0!", "Lỗi",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            Clear_Click(null, null);
                            return;
                        }
                        result = storedValue / currentValue;
                        break;
                }

                DisplayTextBox.Text = result.ToString();
                storedValue = result;
                isNewEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính toán: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Clear_Click(null, null);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = "0";
            currentValue = 0;
            storedValue = 0;
            currentOperation = "";
            isNewEntry = true;
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = "0";
            isNewEntry = true;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewEntry && DisplayTextBox.Text.Length > 1)
            {
                DisplayTextBox.Text = DisplayTextBox.Text.Substring(0, DisplayTextBox.Text.Length - 1);
            }
            else
            {
                DisplayTextBox.Text = "0";
                isNewEntry = true;
            }
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(DisplayTextBox.Text);
                DisplayTextBox.Text = (-value).ToString();
            }
            catch
            {
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(DisplayTextBox.Text);
                if (value < 0)
                {
                    MessageBox.Show("Không thể tính căn bậc hai của số âm!", "Lỗi",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DisplayTextBox.Text = Math.Sqrt(value).ToString();
                isNewEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(DisplayTextBox.Text);
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    value = (storedValue * value) / 100;
                }
                else
                {
                    value = value / 100;
                }

                DisplayTextBox.Text = value.ToString();
                isNewEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reciprocal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value = double.Parse(DisplayTextBox.Text);
                if (value == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DisplayTextBox.Text = (1 / value).ToString();
                isNewEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MemoryClear_Click(object sender, RoutedEventArgs e)
        {
            memoryValue = 0;
            MemoryIndicator.Visibility = Visibility.Collapsed;
        }

        private void MemoryRecall_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = memoryValue.ToString();
            isNewEntry = true;
        }

        private void MemoryStore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memoryValue = double.Parse(DisplayTextBox.Text);
                MemoryIndicator.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Không thể lưu giá trị vào bộ nhớ!", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MemoryAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memoryValue += double.Parse(DisplayTextBox.Text);
                MemoryIndicator.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Không thể cộng giá trị vào bộ nhớ!", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}