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

namespace Practice12
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

        private void AddingCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (AddingCheckBox.IsChecked == true)
            {
                BorderForAdding.Visibility = Visibility.Visible;
                ButtonForAdding.Visibility = Visibility.Visible;
            }
            else
            {
                BorderForAdding.Visibility = Visibility.Collapsed;
                ButtonForAdding.Visibility = Visibility.Collapsed;
            }
        }
    }
}