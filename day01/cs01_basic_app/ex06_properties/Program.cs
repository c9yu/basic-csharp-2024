namespace ex06_properties
{
    class WaterBoiler
    {
        // 디폴트 값이 private
        private int temperature; // 온도

        private int year; // 제작년도 멤버 변수

        public int Year
        {
            get { return year; }
            set { year = value; }
        } // 일반 프로퍼티

        public string Name { get; set; }

        // Rosalyn Visual Studio 개발서포터
        public int Temperature
        {
            get 
            {  // 값을 리턴하니까 특별한 기능이 없다.
                return temperature; }
            set
            {  // 잘못된 값이 들어오면 안되기 때문에 여러 제약을 걸어줌
                if (value < 10)
                {
                    temperature = 20; // 10도 미만은 허용 안함
                }
                else if (value > 70)
                {
                    temperature = 50; // 70도 초과는 허용 안함
                }
                else
                {
                    temperature = value;
                }
            }
        }

        public WaterBoiler(int year, string name, int temperature)
        {
            Year = year;
            Name = name;
            Temperature = temperature;
        }


        //public void SetTemperature(int temp)
        //{
        //    if (temp > 70)
        //    {
        //        Console.WriteLine("온도가 너무 높습니다. 50도로 조정합니다./");
        //        this.temperature = 50;
        //    }
        //    else if (temperature < 10)
        //    {
        //        Console.WriteLine("온도가 너무 낮습니다. 20도로 조정합니다./");
        //        this.temperature = 20;
        //    }
        //    else
        //    { 
        //        this.temperature = temp;
        //    }
        //}

        //public int GetTemperature() 
        //{
        //    return this.temperature;
        //}

        public void On()
        {
            Console.WriteLine("보일러 On");
        }

        public void Off()
        {
            Console.WriteLine("보일러 off");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 시작");
            //WaterBoiler boiler = new WaterBoiler();
            ////boiler.temperature = 400;
            ////Console.WriteLine($"보일러 온도는 {boiler.temperature}도");
            ////boiler.SetTemperature(400); // Getter/Setter 메서드로 구현한 방법
            ////Console.WriteLine($"보일러 온도는 {boiler.GetTemperature()}");
            //boiler.Temperature = 10; // 프로퍼티로 구현한 방법
            //Console.WriteLine($"보일러 온도는 {boiler.Temperature}도");
            //boiler.On();

            //boiler.Name = "귀뚜라미";
            //Console.WriteLine($"보일러 이름은 {boiler.Name}");

            WaterBoiler waterBoiler = new WaterBoiler(name: "보일러", temperature: 25, year: 2023);
            Console.WriteLine(waterBoiler.Name);
            Console.WriteLine($"제작년도 : {waterBoiler.Year}");
            waterBoiler.Temperature = 180;
            Console.WriteLine($"{waterBoiler.Name} 현재 온도는 {waterBoiler.Temperature}도");
        }
    }
}
