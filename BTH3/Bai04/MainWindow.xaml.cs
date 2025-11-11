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
using System.Drawing;
using System.Windows.Forms;
namespace Bai04
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

        private void Format_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.ColorDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color winFormsColor = dialog.Color;
                System.Windows.Media.Color wpfColor = System.Windows.Media.Color.FromArgb(
                    winFormsColor.A,
                    winFormsColor.R,
                    winFormsColor.G,
                    winFormsColor.B
                );
                SolidColorBrush brush = new SolidColorBrush(wpfColor);
                MainPanel.Background = brush;
            }
        }
    }
}