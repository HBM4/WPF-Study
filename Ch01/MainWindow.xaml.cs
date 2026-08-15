using System.Collections.ObjectModel;
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
    // MainWindow 클래스: 화면(창) 하나를 나타내는 클래스입니다.
    public partial class MainWindow : Window
    {
        // CarList 속성: 자동차 목록을 보관합니다. 생성자에서 한 번만 생성해 저장하고,
        // 이후 Button_Click에서 같은 인스턴스에 항목을 추가/제거합니다.
        // (매번 새로 생성하면 ObservableCollection의 변경 알림이 화면과 끊어지므로 주의)
        public MyList CarList { get; set; }

        // 생성자: 창이 생성될 때 실행되는 초기화 코드입니다.
        public MainWindow()
        {
            // XAML에 정의된 화면 요소들을 초기화합니다.
            InitializeComponent();

            // 이 창의 DataContext(데이터 연결 대상)를 CarList로 설정합니다.
            // 이렇게 하면 XAML에서 CarList의 데이터를 바인딩해서 화면에 표시할 수 있습니다.
            CarList = new MyList();
            this.DataContext = CarList;
        }

        // "원소 추가" 버튼 클릭 이벤트 핸들러:
        // CarList(ObservableCollection)에 새 Car를 추가하면 변경 알림이 발생해
        // 화면의 ListBox/DataGrid 등이 자동으로 갱신됩니다.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CarList.Add(new Car { Name = "임시차", Make = "임시명" });
        }
    }

    // Car 클래스: 자동차 한 대의 정보를 담는 데이터 클래스입니다.
    public class Car
    {
        // Name 속성: 자동차 소유자를 저장합니다.
        public string Name { get; set; }

        // Make 속성: 자동차 제조사를 저장합니다.
        public string Make { get; set; }

        // ToString() 메서드를 오버라이드하여
        // Car 객체의 문자열 표현을 반환합니다.
        public override string ToString()
        {
            // Name과 Make 값을 조합해서 하나의 문자열로 반환합니다.
            return $"Name:{Name}, Make:{Make}";
        }
    }

    // MyList 클래스: Car 객체들을 담는 리스트 클래스입니다.
    // ObservableCollection<Car>를 상속받아, 항목 추가/삭제 시 변경 알림(INotifyCollectionChanged)을
    // 자동으로 발생시켜 바인딩된 UI가 실시간으로 갱신되도록 합니다.
    public class MyList : ObservableCollection<Car>
    {
        // 생성자: 리스트가 생성될 때 기본 자동차 데이터를 미리 추가합니다.
        public MyList()
        {
            // 첫 번째 자동차 정보를 목록에 추가합니다.
            Add(new Car { Name = "홍길동차", Make = "BMW" });
            // 두 번째 자동차 정보를 목록에 추가합니다.
            Add(new Car { Name = "이몽룡차", Make = "Kia" });
            // 세 번째 자동차 정보를 목록에 추가합니다.
            Add(new Car { Name = "성춘향차", Make = "Honda" });
        }
    }
}