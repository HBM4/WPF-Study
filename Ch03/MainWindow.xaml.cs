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

namespace Ch03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BindData bd = new BindData("Hello!2", 200);
            this.DataContext = bd;
        }
    }

    public class BindData
    {
        public string DataStr { get; set; }
        public int DataInt { get; set; }

        public BindData() : this("", 0)
        {

        }

        public BindData(string s, int n)
        {
            DataStr = s;
            DataInt = n;
        }
    }
}