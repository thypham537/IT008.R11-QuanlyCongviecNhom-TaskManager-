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
using QuanlyCongviecNhom.ViewModels;

namespace QuanlyCongviecNhom
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Gán ViewModel làm DataContext cho Window
            this.DataContext = new MainWindowViewModel();
        }
    }
}