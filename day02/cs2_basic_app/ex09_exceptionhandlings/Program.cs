using System.Diagnostics; // Debug 클래스를 사용하려면 추가해야함

namespace ex09_exceptionhandlings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3] { 1, 2, 3 };
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    // 0, 1, 2, 3
                    Console.WriteLine($"{array[i]}");
                }
            }
            catch(IndexOutOfRangeException ex) // IndexOutOfRangeException 대신 Exception 사용가능 
            {                                  // (Exception은 모든 예외 클래스의 조상이므로 어떤 예외클래스를 사용할지 모르겠다면 Exception 클래스) 
                Console.WriteLine(ex.Message );
            }
            finally
            {
                Console.WriteLine("프로그램 종료!");
            }
        }
    }
}
