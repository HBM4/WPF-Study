using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Ch03_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new Person() { Name = "홍길동", Age = 25, Clr = Colors.DarkGreen };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person per = this.DataContext as Person;
            per.Age++;
        }
    }

    // 속성 변경을 바인딩 엔진에 알려주는 공통 베이스
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
                // 나이 바뀔 때 추가로 할 일 있으면 여기에
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

    // Color -> Brush 변환용 컨버터 (Background에는 Brush만 들어갈 수 있어서 필요함)
    public class ColorConverter : IValueConverter
    {
        // 소스 -> 타겟
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color clr = (Color)value;
            return new SolidColorBrush(clr);
        }

        // 타겟 -> 소스 (여기선 굳이 되돌릴 필요 없어서 그대로 반환)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
