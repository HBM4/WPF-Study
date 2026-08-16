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

namespace Ch02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new BindData("12345", 200);
            btn.DataContext = new BindData("newbind", 500);
        }
    }

    public class BindData
    {
        public string DataStr { get; set; }
        public int DataInt { get; set; }

        public BindData():this("none", 0)
        {

        }

        public BindData(string s, int n)
        {
            DataStr = s;
            DataInt = n;
        }

        public override string ToString()
        {
            return $"[{DataStr}] : [{DataInt}]";
        }
    }
}