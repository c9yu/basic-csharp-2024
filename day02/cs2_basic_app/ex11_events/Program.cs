using System.Security.Cryptography.X509Certificates;

namespace ex11_events
{
    //delegate int MyDelegate(int a, int b);
    delegate void EventHandler(string message); // 이벤트 핸들러 대리자,
                                                    // 대리자는 자신이 직접 어떠한 메소드를 호출하는 것이 아니라 대신 호출해주는 것

    class CustomNotifier // 미리 만들어져 있다.(라고 생각)
    {
        // 이벤트 등록. event라는 키워드를 사용하면 기본적으로 EventHandler라는 이름을 일반적으로 사용
        public event EventHandler SomethingHappend;
        public void DoSomething(int number)
            {
                int temp = number % 10;
                if (temp != 0 && temp % 3 == 0)
            {   // 3, 6, 9 등의 상태가 되면 짝! 하는 이벤트를 발생시키겠다.
                SomethingHappend($"{number}: 짝!"); // 이벤트 핸들러 발생, 자신의 메서드가 아닌 외부에서 만들어진 메서드를 대신 실행
            }   // SomethingHappend가 처리할 로직이 존재하지 않다
                // 14행의 아무 로직도 가지고 있지 않은 함수를 선언하여 대리자로 사용한다.
        }
    } // 우리가 구현하는게 아니라, 원래부터 만들어져 있는 것
    
    internal class Program
    {
        public static void MyHandler(string message)
        {
            Console.WriteLine("다른 일을 처리합니다.");
            Console.ReadLine();
            Console.Clear();
            //Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] : {message}");
        }


        static void Main(string[] args)
        {
            CustomNotifier notifier = new CustomNotifier();
            notifier.SomethingHappend += new EventHandler(MyHandler);

            for (int i = 0; i < 30; i = i+2)
            {
                notifier.DoSomething(i); // 내장된 클래스의 어떠한 메서드 호출
            }
            #region "익명 메서드"
            /*
            MyDelegate callback; // 대리자
                                 // 메서드 이름이 존재X
                                 // 익명 메서드. 한번 사용 이후 다시 호출할 필요가 없을 때 사용.
            callback = delegate (int a, int b) // delegate는 이름이 아니다. -> 대신 해준다는 의미의 키워드일 뿐.
            {
                return a + b;
            };

            var result = callback(10, 4);*/
            #endregion
        }
    }
}

