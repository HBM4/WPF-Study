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
        private Person per = new Person() { Name = "홍길동", Phone = "010-1111-1234" };

        public MainWindow()
        {
            InitializeComponent();

            // 창 전체 DataContext -> BindData2, BindData4에서 사용됨
            BindData bd = new BindData("Hello!2", 200);
            this.DataContext = bd;

            // panel 안쪽만 Person으로 바인딩
            panel.DataContext = per;
        }
    }

    // 바인딩 테스트용 데이터 클래스
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

    // 하단 이름/전화 입력 폼에 바인딩할 데이터
    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}