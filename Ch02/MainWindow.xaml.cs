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
    // MainWindow 클래스: 화면(창) 하나를 나타내는 클래스입니다.
    public partial class MainWindow : Window
    {
        // 생성자: 창이 생성될 때 실행되는 초기화 코드입니다.
        public MainWindow()
        {
            // XAML에 정의된 화면 요소들을 초기화합니다.
            InitializeComponent();

            // 창 전체의 DataContext(데이터 연결 대상)를 BindData 객체로 설정합니다.
            // 이렇게 하면 XAML에서 {Binding DataStr}처럼 값을 가져다 쓸 수 있습니다.
            this.DataContext = new BindData("12345", 200);

            // btn이라는 이름의 버튼만 별도로 DataContext를 다르게 지정합니다.
            // 같은 창 안이라도 컨트롤마다 다른 데이터에 바인딩할 수 있음을 보여주는 예시입니다.
            btn.DataContext = new BindData("newbind", 500);
        }
    }

    // BindData 클래스: 바인딩(화면과 데이터 연결) 실습에 사용할 간단한 데이터 클래스입니다.
    public class BindData
    {
        // DataStr 속성: 문자열 데이터를 저장합니다.
        public string DataStr { get; set; }

        // DataInt 속성: 정수 데이터를 저장합니다.
        public int DataInt { get; set; }

        // 매개변수 없는 생성자: 값을 지정하지 않으면 "none"과 0으로 기본값을 채웁니다.
        // (아래의 BindData(string, int) 생성자를 그대로 호출)
        public BindData() : this("none", 0) { }

        // 매개변수 있는 생성자: 문자열 s와 정수 n을 받아서 속성에 저장합니다.
        public BindData(string s, int n)
        {
            DataStr = s;
            DataInt = n;
        }

        // ToString() 메서드를 오버라이드하여
        // BindData 객체를 화면에 표시하거나 출력할 때 보여줄 문자열을 정의합니다.
        public override string ToString()
        {
            // DataStr과 DataInt 값을 조합해서 "[값] : [값]" 형태의 문자열로 반환합니다.
            return $"[{DataStr}] : [{DataInt}]";
        }
    }
}