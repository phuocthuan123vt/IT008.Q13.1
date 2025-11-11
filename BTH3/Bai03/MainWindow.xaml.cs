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

namespace Bai03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random randomColorGenerator = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            byte red = (byte)randomColorGenerator.Next(256);
            byte green = (byte)randomColorGenerator.Next(256);
            byte blue = (byte)randomColorGenerator.Next(256);

            Color randomColor = Color.FromRgb(red, green, blue); 
            SolidColorBrush randomBrush = new SolidColorBrush(randomColor);
            MainGrid.Background = randomBrush;
        }
    }
}