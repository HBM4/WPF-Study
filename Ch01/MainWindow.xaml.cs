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

namespace Ch01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StackPanel stackpanel = new StackPanel();

            Button button = new Button();
            button.Content = "My Button";
            TextBox textbox = new TextBox();
            textbox.Text = "My Text";

            stackpanel.Children.Add(button);
            stackpanel.Children.Add(textbox);

            this.Content = stackpanel;
        }
    }
}