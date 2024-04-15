namespace ex12_lambdas
{
    // 대리자를 만드는데, 정수값 두 개 받아서 정수값을 리턴해주는 함수들은 내가 대신 실행시켜줄게
    delegate int Calculate(int a, int b); 
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("익명 메소드");

            // ------------------------------------------------------------------------------------ 1. 대리자로 만든 무명 메서드
            Calculate calc;
            calc = delegate (int a, int b)
            {
                return a + b;
            };

            Console.WriteLine($"계산 결과 = {calc(10,4)}");

            // ------------------------------------------------------------------------------------ 2. 단일 형태의 람다식
            // 람다식을 사용하면 훨씬 짧게 코딩이 가능하다.                                            (사용시 '=>'가 포함된다.) 리턴문도 필요가 없다.
            // calc와 calc2는 동일한 기능을 한다.
            Calculate calc2 = (a, b) => a + b; // (int a, int b) => a + b; // {return a + b};

            Console.WriteLine($"계산 결과 = {calc(11, 4)}");

            // ------------------------------------------------------------------------------------ 3. 문장 형태의 람다식, 
            Calculate calc3 = (a, b) =>                                                             // (이 경우 리턴이 필요하다. {} 안에서는 return 생략이 불가능)
            {
                Console.WriteLine("이런식으로 가능합니다.");
                var sub = a - b;
                return sub;
            };
            Console.WriteLine($"계산 결과 = {calc3(11, 4)}");

            // Func, Action 빌트인 대리자 사용
            // Func 리턴값이 있기 때문에 <int>는 리턴값이 int라는 뜻
            // <int, int>는 매개변수 하나 리턴 하나
            Func<int> func1 = () => 10; // 10을 리턴할게
            Console.WriteLine($"func1 = {func1()}");
            Func<int, int> func2 = (x) => x ^ 2;
            Console.WriteLine($"func2 = {func2(4)}");
            Func<int, int, double> func3 = (x, y) => (double)x / y;
            Console.WriteLine($"func3 = {func3(22, 7)}");

            // Action은 리턴값이 없음
            int result = 0;
            Action<int> act1 = (x) => result = x * x;
            act1(3);
            Console.WriteLine($"act1 = {result}");
            Action<double, double> act2 = (x, y) =>
            {
                double res = x / y;
                Console.WriteLine(res);
            };

            act2(21.1, 7.0);
        }
    }
    class Test
    {
        private int name;
        private double point;

        public int Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Point // 람다식 사용한 프롬퍼터
        {
            get => point;
            set => point = value;
        }
    }
}