using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Ch03_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PersonList List { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            List = new PersonList();

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            MessageBox.Show(btn.DataContext.ToString());
        }
    }
    public class StrList : ObservableCollection<string>
    {
        public string ListName => "연습용 리스트";
        public StrList()
        {
            Add("ABC");
            Add("DEF");
            Add("GIH");
        }
    }
    public class PersonList : ObservableCollection<Person>
    {
        public string ListName => "연습용 리스트";
        public PersonList()
        {
            Add(new Person()
            {
                Name = "홍길동",
                Age = 25,
                Clr = Colors.Beige
            });
            Add(new Person()
            {
                Name = "성춘향",
                Age = 28,
                Clr = Colors.Red
            });
            Add(new Person()
            {
                Name = "이몽룡",
                Age = 35,
                Clr = Colors.RoyalBlue
            });
        }
    }
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Person : Notifier
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
                //부가적인 작업
            }
        }
        private Color clr;
        public Color Clr
        {
            get { return clr; }
            set
            {
                clr = value;
                OnPropertyChanged("Clr");
            }
        }
        public Person()
        {
            Name = "noname";
            Age = 0;
            Clr = Colors.White;
        }
        public override string ToString()
        {
            return $"Name:{Name},Age:{Age},Color:{Clr}";
        }
    }
    public class ColorConverter : IValueConverter
    {
        //소스 -> 타겟
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color clr = (Color)value;
            return new SolidColorBrush(clr);
        }
        //타겟 -> 소스
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}