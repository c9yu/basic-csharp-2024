# 기본 학습
2024년 IoT 개발자 과정 C# 리포지토리

## 1일차 (2024-04-11)
- C# 소개
    - MS에서 개발한 차세대 프로그래밍 언어
    - 2000년 최초 발표, 엔더스 하일버그(파스칼, 델파이 개발자)
    - 1995년 Java가 발표되면서 이와 경쟁하기 위해 개발
    - 객체지향 언어, C/C++과 Java를 참조하여 개발
    - OS플랫폼 독립적, 메모리 관리가 쉽다.
    - 다양한 분야에서 사용중
    - 2024년 기준 12버전

- .NET Framework (CLR)
    - Windows OS에 종속적
    - OS독립적인 새로운 틀을 제작하기 시작(2022~ ) -> .NET 5.0
    - 2024년 현재 .NET 8.0
        - C/C++ : gcc 컴파일러, Java : JDK, .NET : .NET 5.0 이상, 각각의 프로그래밍 언어들은 컴파일러가 필요하다.
    - 이제는 신규 개발시, .NET Framework는 사용하지 말 것!

- Hello, C#!
    - Visual Studio 시작
        - 프로젝트는 프로그램을 만들기 위한 최소 단위 그룹을 의미하며, 이런 프로그램들의 집합이 솔루션이다.
            - 프로젝트 : 프로그램 개발을 위한 최소단위 그룹
            - 솔루션 : 프로젝트의 묶음

        ```cs
        namespace hello_world // 프로그램 소스의 가장 큰 단위 : namespace
        {
            internal class Program // 접근 제한자 class 파일명
            {
                static void Main(string[] args) // 정적 void Main : 첫글자는 대문자로 쓰기로 약속
                {
                    // System 네임 스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
                    Console.WriteLine("Hello, World!");
                }
            }
        }
        ```
        - Visual Studio 에서의 주석
            - Ctrl + k + c : 주석 처리
            - Ctrl + k + u : 주석 해제

- C#의 변수와 상수
    - C++과 동일하다.
    - 모든 C#의 객체는 Object를 조상으로 한다.
    - 박싱, 언박싱
    
    ```cs
    int 20;
    object b = a; // 박싱(박스에 담는다.)

    int c = (int) b; // 언박싱(object를 각 타입으로 변환
    
    ```
    
    -- 상수는 const 키워드 사용
    -- var는 컴파일러가 자동으로 타입을 지정해주는 변수. 지역 변수에만 사용 가능

- 연산자
    - C++과 동일!
    - ++, --가 파이썬에 없다는 것
    - and, or가 C++, C#에서는 &&, ||라는 것

- 흐름제어
    - C++과 동일
    - if, switch, while, do-while, do ~ while, for, break, continue, goto 모두 동일!!
    - C#에는 foreach가 존재 - python의 for item in []과 동일

    ```cs
    int[] arr = {1, 2, 3, 4, 5};

    foreach (var tiem in arr)
    {
        Console.WriteLine($"현재 수 : {item}");
    }
    ```
- 메서드(Method)
    - 함수와 동일. 구조적 프로그래밍에서 함수면, 객체지향에서는 메서드로 부른다.(파이썬만 예외)
    - 매개변수 참조형식 -> C++에서 Pointer로 값을 사용할 때와 동일한 기능
    
    ```cs
    public static void RefSwap(ref int a, ref int b)
    {
        int temp = b;
        b = a;
        a = temp;
    }

    // 사용시에도 ref 키워드 사용
    RefSwap(ref x, ref y) 
    ```
- 매개변수 출력형식 -> 매개변수를 리턴값으로 사용하도록 대체해주는 방법(과도기적인 방법)

    ```cs
    public static void Divide(int a, int b, out int quotient, out int remainder)
    { // ...
    ```

    - 매개변수 오버로딩 -> 여러 타입으로 같은 처리를 하는 메서드를 여러개 만들 때
    - 매개변수 가변길이 -> 매개변수 개수를 동적으로 처리할 때

        ```cs
        public static int Sum(params int[] argv)
        { // ...
        ```
        - 명명된 매개변수 -> 매개변수 사용순서를 변경가능

        ```cs
        public static void PrintProfile(string name, string phone)
        { //....

        PrintProfile(phone: "010-9999-8888", name: "홍길동");
        ```

        - 기본값 매개변수 -> 매개변수 갑ㅄ 미할당시 기본값으로 지정
        ```cs
        public static void DefaultMethod(int a = 1, int b = 0)
        { //...
        DefaultMethod(10, 8);   // a = 10, b = 8
        DefaultMethod(6);   // a = 6, b = 0
        DefaultMethod();    // a = 1, b = 0
        ```
    

- 클래스
    - C++의 클래스, 객체와 유사(문법이다소 상이)
    - 생성자는 new로 사용해서 객체생성
    - 종료자(파괴자)는 C#에서 거의 사용 안함
    - 생성자 오버로딩 -> 파라미터 개수에 따라서 사용가능, 기본적인 매서드 오버로딩하고 기능 동일
    - this 키워드 -> C++ this -> 라면, C# this. 파이썬의 self.와 동일
    - 접근한정자(Acess Modifier)
        - public - 모든 곳에서 접근
        - private - 외부에서 접근 불가(default)
        - protected - 외부에서 접근 불가, 파생(상속)클래스에서는 사용가능
        - internal - 같은 어셈블리(네임 스페이스)내에서는 public과 동일
        - protected internal, private protected - 난이도 있는 한정자(고급)

        - C#에는 C++과 같은 다중상속 없음. C++ 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 아예 없앰
            - 다중상속이 필요함을 해결 -> 인터페이스
        
        ```cs
        class BaseClass{
            // 부모 클래스
        }
        
        class DerivedClass : BaseClass {
            // 자식(파생) 클래스
        }
        ```
- 구조체
    - 객체지향이 없었을 때 좀 더 객체지향적인 프로그래밍을 위해서 만들어진 부분 (C에서)
    - class 이후로 사용빈도가 완전히 줄어든 구조
    - 구조체 스택(값형식), 클래스 힙(참조형식)
    - C#에서는 구조체를 안써도 됨 

- 튜플 (C# 7.0 이후 반영)
    - 한꺼번에 여러개의 데이터를 리턴하거나 전달할 때 유용
    - 값 할당 후 변경불가

- 인터페이스
    - 클래스 : 객체의 청사진/ 인터페이스 : 클래스의 청사진
    - 인터페이스는 클래스가 어떠한 메서드를 가져야 하는지를 약속하는 것
    - 다중상속의 문제를 단일상속으로도 해결하게 만든 주체
    - 인터페이스는 명명할 때 제일 앞에 I를 적음
    - 인터페이스의 메서드에는 구현을 작성하지 않음
    - 클래스는 상속한다 vs 인터페이스 구현한다.
    - 클래스는 상속 시 별다른 문제없음 vs 인터페이스는 구현할 때 약속을 지키지 않으면 오류표시
    - 인터페이스에서 약속한 메서드를 구현안하면 빌드 안된다!

    ![인터페이스 설명](https://raw.githubusercontent.com/c9yu/basic-csharp-2024/main/images/csharp001.png)

- 추상클래스(abstract)
    - Virtual 메서드하고도 유사하다
    - 추상클래스를 단순화 시키면 인터페이스이다.

- 프로퍼티
    - 클래스의 멤버변수 변형, 일반 변수와 유사하다
    - 멤버변수의 접근제한자를 public으로 했을 때의 객체지향적 문제점(코드오염 등)을 해결하기 위해서
    - GET/SET 접근자
    - SET은 값 할당시에 잘못된 데이터가 들어가지 않도록 막아주는 역할을 함
    - JAVA에서는 'Getter 메서드/Setter 메서드'를 사용, C#은 프로퍼티를 사용

## 2일차 (2024-04-12)
- Tip
    - C#에서 빌드 시 프로세스 액세스 오류 해결
        - 빌드하고자 하는 프로그램이 백그라운드 상에 동작중이기 때문에 발생한다.
        - Ctrl + Shift + ESC(작업관리자)에서 해당 프로세스 작업 끝내기 후 재빌드

- 컬렉션 (배열, 리스트, 인덱서)
    - 배열의 다양한 초기화 방법
    
    ```cs
    // '초기화 방법 1'
    int[] array = new int[5]; 

    // '초기화 방법 2' : 초기화 선언하면서 값을 바로 지정
    int[] score = new int[3] { 70, 80, 90 };
            
    // '초기화 방법 3' : 배열의 크기를 생략
    string[] names = new string[] { "hello", "world", "C#!" }
            
    // '초기화 방법 4' : 전부 다 생략
    float[] points = { 3.14f, 5.5f, 4.4f, 10.8f };
    ```
    - 모든 배열은 System.Array 클래스를 상속한 하위 클래스
    - 기본적인 배열의 사용법, Python의 리스트와 동일
    - 배열 분할 - C# 8.0부터 파이썬의 배열 슬라이스를 도입 (python의 range)
    - 컬렉션
        - ArrayList
        - Stack
        - Queue
        - Hashtable(== Dictionary)
    - foreach를 사용할 수 있는 객체로 만들기 - yield

- 일반화 (Generic) 프로그래밍
    - 파이썬 : 변수에 제약사항이 없음
    - 타입의 제약을 해소하고자 만든 기능이 일반화 기능이다. ArrayList
    - 일반화를 하는 이유
        - 타입이 지정된 프로그래밍 언어의 경우 각 타입마다 함수를 새로 만들어줘야하는 불편함이 생기는데 이를 해결하기 위함이다.
    - 일반화 컬렉션
        - List <T>
        - Stack <T>, Queue <T>
        - Dictionary <TKey, TValue>

- 예외처리
    - 소스코드 상 문법적 오류 -> 오류(Error)
    - 실행 중 생기는 오류 - 예외(Exception)

    ```cs
    try {
        // 예외가 발생할 것 같은 소스코드
    } catch(Exception ex){
        /* 모든 예외 클래스의 조상은 Exception(ex. IndexOutOfRangeException)
           어떤 예외 클래스를 사용할 지 모르겠다면, 무조건 Exception 클래스를 사용하면 된다. */
        Console.WriteLine(ex.Message);
    }finally{
        // 예외 발생 유무에 상관없이 항상 실행
    }
    ```
- 대리자(delegate)와 이벤트
    - 메서드 호출 시 매개변수 전달
    - 대리자 호출 시 함수(메서드) 자체를 전달
    - event : 컴퓨터 내에서 발생하는 객체의 사건들

    - delegate -> event
    - Winform 개발 -> 이벤트 기반 (Event driven) 프로그래밍

    - 대리자(EventHandler)는 일종의 버튼을 만드는 것이라고 생각하면 된다.
        - 버튼은 그저 버튼의 역할만 수행하고, 버튼을 눌렀을 때 어떤 일이 발생할지는 별도로 작성해준다.
        - EventHandler과 MyHandler의 관계는? -> MyHandler가 버튼(EventHandler)가 눌렸을때 실행되는 구문이다.
        - 버튼의 이름과 역할은 무조건 일치한다는 보장은 없다.

- TIP, C# 주석 중 영역을 지정 할 수 있는 주석
    - #region ~ #endregion 영역을 Expend 또는 Collapse 가능

    ![region 주석](https://raw.githubusercontent.com/c9yu/basic-csharp-2024/main/images/csharp002.png)

## 3일차 (2024-04-15)
- 람다식
    - 익명 메서드를 만드는 방식 중 하나 - delegate, lambda expression
    - 무명 함수(Anonymous Function) : 람다식으로 만드는 익명 메소드
    - 무명함수를 작성하기 위해서는 먼저 대리자로 무명함수의 모습을 결정
    - 익명 메서드시 코딩량을 줄여줌, 프로퍼티 사용시에도 코딩양이 줄어든다.
    - 익명 메서드 사용할 때 마다 대리자를 선언해야 하기 때문에 Func, Action을 MS에서 미리 만들어둔다.

- LINQ (Language INtegrated Query)
    - C#에 통합된 데이터 질의 기능 (DB SQL과 거의 동일)
    - group by에 집계함수가 필수가 아닌 것 외에는 SQL과 거의 동일
    - 단, 키워드 사용순서가 다른 것을 인지해야 함
    - LINQ만 고집하면 안된다. 기존의 C# 로직을 사용해야 하는 경우도 존재함

- 리플랙션, 애트리뷰트
    - 리플랙션
        - object.Gettype();
    - 애트리뷰트 
        - [obsolete("다음 버전 사용 불가!")]
        - 이처럼 경고를 통해 알려준다.

- 파이썬 실행
    - COM 객체 사용(dynamic 형식)
    - IronPython 라이브러리 : Python을 C#에서 사용할 수 있도록 해주는 오픈소스 라이브러리
    - NuGet Package : 파이썬 pip와 같은 라이브러리 관리툴
    - 해당 프로젝스 종속성, 마우스 오른쪽 버튼 > NuGet Package 관리
        1. 파이썬 엔진, 스코프 객체, 설정경로 객체 생성
        2. 해당 컴퓨터 파이썬 경로들 설정
        3. 실행시킬 파이썬 파일 경로 지정
        4. 파이썬 실행(scope 연결)
        5. 파이썬 함수를 Func 또는 Action으로 매핑
        6. 매핑시킨 메서드를 실행

- 가비지 컬렉션
    - C, C++ 은 메모리 사용시 개발자가 직접 메모리 해제를 해줘야함
    - C#, Java, Python등의 객체지향 언어는 GC (Garbage Collection : 쓰레기 수집기) 기능으로 프로그램이 대신 관리해준다.
    - C# 개발자는 메모리 관리에 별도로 할 일이 없다.

- 윈폼 UI 개발 + 파일, 스레드
    - 이벤트, 이벤트핸들러 (대리자, 이벤트 연결)
    - 그래픽 사용자 인터페이스를 만드는 방법
    1. Window Forms
    2. WPF(Windows Presentation Foundation)
    - WYSIWYG (What You See IS What You Get) 방식의 GUI 프로그램 개발

    - 보기 탭 -> 도구 상자, 속성(F4)창을 화면에 띄워두는 것 부터 시작

    - 예제 프로젝트

## 4일차 (2024-04-16)
- 윈폼 UI 개발
    - Winforms로 윈폼 개발 학습
    - 윈폼 UI 개발시 컨트롤 박스에서 꺼내온 뒤 '더블 클릭' 은 절대 하지마라!
    - 복사 할 때는 Ctrl + 드래그
    - 컨트롤 Prefix (거의 영문 3글자)
        - ComboBox : Cbo~
        - CheckBox : Chk~
        - RadioButton : Rdo~
        - TextBox : Txt~
        - Button : Btn~
        - TrackBar : Trb~
        - ProgressBar : Prg~
        - TreeView : Trv~
        - ListView : Lsv~
        - PictureBox : Pic~
        - ~Dialog : Dlg~

    - Visual Studio 윈폼 개발
        - 여러가지 스타일을 접목시키고 싶을때는 : |
        - closing이 closed보다 먼저
        - Tree를 확장 하는것 : Expand
        - 전체 저장 : Ctrl + Shift + S
        - 세밀한 크기 조정은 그랩 때문에 힘들 수 있는데 'Alt' 키를 누른 상태로 조절하면 된다.

- WPF
- 예제 프로젝트

## 5일차 (2024-04-17)
- 윈폼 UI 개발(계속)
    - Visual Studio 윈폼 개발
        - 그룹박스의 경우 소스코드 내에서 다룰 때는 이름을 따로 붙여주는 것이 좋다.
        - 디자이너에서 다룰 때는 별도로 이름을 붙일 필요는 없다.
        - Dock : 위치 조정할 때 사용
        - TextBox도 Multiline을 False -> True로 변경하면 여러 줄 입력 가능
        - TextBox에 글자를 입력하지 못하게 하는 방법 
            - enable : True -> False : 사용하지 않겠다 (비교적 추천하지 않는 방법)
            - readonly : False -> True : 사용은 가능하지만, 입력은 안된다. (추천하는 방법)
        - Ctrl + Sapce : content asist
        - MaximizeBox, MinimizeBox를 False로 두면 창의 크기 조절이 불가능하게 바뀐다.

        - MainForm의 코드를 
            - 생성자 초기화 영역
            - 이벤트 핸들러 영역
            - 사용자 메서드 영역 이렇게 3가지로 region을 통해 구분하여 작성하면 관리가 편해진다.

        - 애플리케이션 속성
            - 출력 유형
                - 클래스 라이브러리
                - 콘솔 애플리케이션 : 실행시 콘솔 창이 출력된다.
                - Windows 애플리케이션 : 기본 윈폼
            
            - 대상 프레임워크
                - 프레임워크에 맞춰서 원하는 .NET 버전을 지정 할 수 있다.
                - 높은 버전 -> 낮은 버전으로 변경하는 경우 문제가 발생 할 수 있다.
                - 낮은 버전 -> 높은 버전으로 변경하는 경우 큰 문제는 없다.
                - 추가로 필요한 버전이 있는 경우 '기타 프레임워크 설치 선택'
            
            - 대상 OS, 대상 OS 버전, 지원되는 OS 버전의 경우 그대로 사용하면 된다.

            - 시작 개체
                - 기본적으로 void main부터 진행되지만 추가로 지정이 필요한 경우 사용한다.

            - 어셈블리 이름, 매니페스트, 암시적 전체 사용 (체크박스) : 손 댈 필요 없다.

            - 플랫폼 대상

            - NULL 허용 : 허용 한다.

            - 코드 최적화
                - Debug, Release 둘 중 Debug는 조금 느리고 Release가 조금 더 빠르다.(최적화 때문)

            - 게시
                - 웹 등에 업로드 할 때 사용

            - 보통 애플리케이션만 건드린다.            

    - 스레드 추가
        - 프로세스를 나누어 동시에 여러가지 일을 진행
        - 스레드 사용하기 불편함
        - C# BackgroundWorker 클래스를 추가(Thread를 사용하기 편하게 만든 클래스)

    - 파일 입출력 추가
        - 리치 텍스트 박스(like MSWord, 한글워드)로 파일 저장
        <img src = "https://raw.githubusercontent.com/c9yu/basic-csharp-2024/main/images/csharp003.png" width = "850">

    - 비동기 작업 앱
        - 가장 트렌드가 되는 작업방법
        - 백그라운드 처리는 Thread, BackgroundWorker와 유사
        - async, await 키워드

        ![비동기앱](https://raw.githubusercontent.com/c9yu/basic-csharp-2024/main/images/csharp004.png)

## 6일차 (2024-04-18)
 - 예제 프로젝트
    - 윈도우 탐색기 앱
        - MyExplorer 프로젝트 생성
        - 아이콘 검색, png 2 icon, 구글링 웹사이트
        - 트리뷰, 리스트뷰 기능 추가

        ![중간결과](https://raw.githubusercontent.com/c9yu/basic-csharp-2024/main/images/csharp005.png)

        - Dock : 위치에 맞춰서 크기를 조정해 준다.
        - Anchor : 화면 크기를 조정 할 때 어느 부분을 늘려줄지 정해준다.

## 7일차 (2024-04-19)
- 토이 프로젝트
    - 윈도우 탐색기 앱 종료
        - 실행 결과
     
          https://github.com/c9yu/basic-csharp-2024/assets/158007438/bd0c181d-26f6-40c4-8d59-952fb43d750c


    - README 동영상 업로드
        - 깃허브 안에서 리드미 수정창을 키고, 원하는 영상을 드래그하여 집어넣은 뒤 커밋.
        - 이후 깃허브 데스크탑에서 패치 오리진 해준 뒤, 다시한번 업로드

    - 도서관리 앱 with SQL Server ModernUI 앱 (NuGet 패키지)
    ```cs
    // 값형식 변수에 null값을 넣을 수 있도록 만들어 준 기능 Nullable. 변수명 뒤에 ?만 추가할 것

    int? a = null;
    double? b = null;
    float? c = null;
    ```
        - 로그인 패스워드 암호화 미구현

    - 메뉴 스트립
        - 이름을 지정할 때 ex. '파일(&F)' 처럼 &를 넣어줘야 Alt + F 단축키를 사용할 수 있게 된다.

    - SQL과 연동 방법
        - 보기에서 서버 탐색기 선택하여 추가


## 8일차 (2024-04-22)
- 토이 프로젝트
    - 도서관리 앱 관리화면
        - 앱 사용자 관리 완료

## 9일차 (2024-04-23)
- 토이 프로젝트
    - 기존 만들어진 폼을 복사해서 변경할 시
        - ***.cs에 있는 클래스 명 생성자, *.Designer.cs에 있는 클래스명*** 3군데 이름 변경
    - 도서관리 앱
        - 공통 클래스
            - 한번 만들었는데 여러번 쓰이면 한 공통 파일을 만들어 한번만 입력하면 여러 군데서 사용 할 수 있다.
            - F12 = 정의 따라가기, F12를 눌러보면서 잘 따라가고 있는지 확인한다.
        - 책 장르 관리
        - 책 정보 관리

## 10일차 (2024-04-24)
- 토이 프로젝트
    - 도서관리 앱
        - 도서 회원 관리
        - 대출 관리 
        - 프로그램 소개

        ![도서대여프로그램](https://raw.githubusercontent.com/c9yu/basic-csharp-2024/main/images/csharp005.png)


## 나머지
- Pending
    - IoT Dummy 앱 with SQL Server (Iot, DB)
    - 국가교통정보센터 CCTV 뷰 앱 (OpenAPI, NuGet, Network, UI 디자인, 비동기 메서드)
    
## 개인 토이 프로젝트
- 매장 테이블 관리 및 계산 프로그램

    - 목적
        - DB연동을 진행
        - 로그인 기능 구현
        - 실제 매장의 포스기와 유사한 기능과 형태로 프로그램 제작

    - 기능
        - DB 연동
            - DB 연동을 통해 보다 매끄러운 동작을 하게끔 한다. (구현)

        - 로그인 기능
            - 외부인이 이용할 수 없게 로그인 기능을 통해 DB상에 등록되어 있는 사람만 접속 가능 (구현)
            - 로그인시 이용자에 따라 열람할 수 있는 정보가 달라짐 (미구현)

        - 테이블 관리 기능
            - 매장내 테이블의 개수만큼 테이블을 구현 (2024-04-29기준 '테이블 1'만 구현)
                - 손님이 앉은 테이블을 선택하면 해당 테이블에 손님이 선택한 음식을 추가 가능 (구현)
            - 통계 버튼을 선택시 지금까지 판매된 테이블별 금액을 시간순서로 출력함 (미구현)

        - 메뉴 선택 및 주문 기능
            - 테이블은 선택하면 메뉴창이 출력, DB에 넣어둔 음식들이 선택한 '종류' 컬럼에 따라 출력 (구현)
            - 원하는 메뉴를 선택 후 '+' 버튼을 클릭시 주문목록에 선택한 음식의 수량을 1개 증가 (구현)
            - 원하는 메뉴를 선택 후 '-' 버튼을 클릭시 주문목록에 선택한 음식의 수량을 1개 감소 (구현)
            - 주문목록의 메뉴를 선택 후 '삭제' 버튼을 클릭시 선택한 음식의 수량과 관계없이 해당 음식을 주문목록에서 삭제 (구현)

            - 원하는 메뉴를 모두 담은 뒤 결제 버튼을 클릭시 선택한 음식의 총액과 함께 결제 유무를 물어봄 (구현)
                - 결제를 진행할 경우 결제완료 창의 출력과 함께 결제한 시간과 총액이 DB에 저장 (구현)

            - 뒤로가기 버튼을 클릭시 이전 화면(테이블 선택화면)으로 돌아가며 담아뒀던 메뉴가 테이블에 표시 (구현)
                - 음식이 담겨있는 테이블을 재선택할 경우 다시 결제창으로 돌아가 결제 가능 (미구현)

    - 고찰
        - 로그인 기능으로 인해 선택적으로 기능을 사용하게 하는것이 가능함
        - DB와 연동하여 작업하였기에 매장에 새로운 메뉴가 추가되어도 손쉽게 추가가 가능함.
        - DB의 데이터를 연동시키게 될 경우 로그인, 메뉴출력 등 DB를 사용하지 않고 프로그램을 작성하는것보다 
        유리한 점이 많다는 것을 알 수 있었다.
        - ListBox와 Data Grid View를 연결하여 상호간에 영향을 주게끔 할 수 있었다.

    
    https://github.com/c9yu/basic-csharp-2024/assets/158007438/ec7c4d76-1fe2-4ba2-8d1e-92b3df86355c


