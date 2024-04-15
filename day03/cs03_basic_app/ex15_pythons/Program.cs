using IronPython.Hosting;

namespace ex15_pythons
{
    /*
     * ['', 
     * 'C:\\DEV\\LANGS\\Python311\\python311.zip', 
     * 'C:\\DEV\\LANGS\\Python311\\DLLs', 
     * 'C:\\DEV\\LANGS\\Python311\\Lib', 
     * 'C:\\DEV\\LANGS\\Python311', 
     * 'C:\\Users\\Administrator\\AppData\\Roaming\\Python\\Python311\\site-packages', 
     * 'C:\\Users\\Administrator\\AppData\\Roaming\\Python\\Python311\\site-packages\\win32', 
     * 'C:\\Users\\Administrator\\AppData\\Roaming\\Python\\Python311\\site-packages\\win32\\lib', 
     * 'C:\\Users\\Administrator\\AppData\\Roaming\\Python\\Python311\\site-packages\\Pythonwin', 
     * 'C:\\DEV\\LANGS\\Python311\\Lib\\site-packages']
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("파이썬 실행예제.");

            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var paths = engine.GetSearchPaths();

            // Python 경로 설정 @(리소스 키워드)
            paths.Add(@"C:\\DEV\\LANGS\\Python311");
            paths.Add(@"C:\\DEV\\LANGS\\Python311\\DLLs");
            paths.Add(@"C:\\Users\\Administrator\\AppData\\Roaming\\Python\\Python311\\site-packages\\win32\\lib");

            // 실행시킬 Python 파일 경로 설정
            var filePath = @"C:\sources\basic-csharp-2024\day03\cs03_basic_app\ex15_pythons\Test.py";
            var source = engine.CreateScriptSourceFromFile(filePath);

            // Python 실행
            source.Execute(scope);

            var PythonFunc = scope.GetVariable<Func<int, int, int>>("sum");
            var result = PythonFunc(10, 7);
            Console.WriteLine($"Python 함수실행 = {result}");

            var PythonGreeting = scope.GetVariable<Func<string>>("sayGreeting");
            var greeting = PythonGreeting();
            Console.WriteLine($"결과 = {greeting}");
        }
    }
}
