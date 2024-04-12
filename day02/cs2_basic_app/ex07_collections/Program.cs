using Microsoft.VisualBasic;
using System.Collections;
using System.Runtime.InteropServices;

namespace ex07_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5]; // '초기화 방법 1'
            // Console.WriteLine(int.MaxValue); // C#의 각 타입의 최대, 최소 값을 찾을 수 있는 방법
            array[0] = 80;
            array[1] = 81;
            array[2] = 100;
            array[3] = 34;
            array[4] = 98;
            // array[5] = 100;

            //var text = Console.ReadLine(); // 콘솔에서 값 입력
            //// 수정 오류 테스트
            //Console.WriteLine(text);
             
            // '초기화 방법 2' : 초기화 선언하면서 값을 바로 지정
            int[] score = new int[5] { 80, 74, 81, 90, 34 };

            // '초기화 방법 3' : 배열의 크기를 생략
            string[] names = new string[] { "hello", "world", "C#!" };
            
            // '초기화 방법 4' : 전부 다 생략
            float[] points = { 3.14f, 5.5f, 4.4f, 10.8f };

            // 함수, 메서드 : 괄호 사용
            // 프로퍼티 : 괄호 사용 X

            // 타입 확인
            Console.WriteLine($"배열의 타입은 : {score.GetType()}"); // GetType : 자료형을 얻어낼 수 있는 함수
            Console.WriteLine($"배열 기본 타입 : {score.GetType().BaseType}"); // Array라는 기본 타입을 가진 상태로 int, float와 같은 타입을 추가로 가진다

            foreach (var item in names) // 코드 스니치를 활용하자
            {
                Console.WriteLine($"문자열은, {item}");
            }

            Console.WriteLine(score.Rank);

            Array.Sort(score);

            foreach (var item in score)
            {
                Console.Write($"{item}, ");

            }
            Console.WriteLine("");
            Console.WriteLine(Array.BinarySearch(score, 90)); // '결과 : 4' -> 인덱스 4에 90이 존재한다.

            // 배열 분할. (python의 range)
            char[] array2 = new char[26]; // ['Z' - 'A' + 1]; : 90 - 65 + 1
            for (int i = 0; i < array2.Length; i++)
                array2[i] = (char)('A' + i); // ABCDE ... Z

            foreach (var item in array2)
            {
                Console.Write(item);
            }
            Console.WriteLine(); // ㄱ. 굳이 이렇게 복잡하게 출력할 필요 없다.

            // 배열 분할 전
            Console.WriteLine(array2); // ㄴ. 훨씬 편한 방법

            // 배열 분할 후
            // [시작인덱스 .. 종료인덱스+1]
            Console.WriteLine(array2[..]); // System.Range
            Console.WriteLine(array2[5..]); // System.Range
            Console.WriteLine(array2[5..11]); // 5번째 부터 10번째까지 출력할게

            // 2차원 배열, 3차원 배열, 가변배열 등 C++과 동일

            /* 컬렉션
             *   
             */
            // ArrayList
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add(array2);
            arrayList.Add(true);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(arrayList.Count); // arrayList의 길이
            arrayList.Remove(1); // arrayList에서 인덱스 1번의 값을 삭제
            arrayList.Insert(2, 25);

            // Stack, Queue : Python 자료구조에서 배웠던 Stack, Queue와 동일하다.
            Stack stack = new Stack();
            stack.Push(1);
            stack.Pop();

            Queue que = new Queue();
            que.Enqueue(1);
            que.Dequeue();

            // Hashtable == Dictionary
            Hashtable ht = new Hashtable();
            ht["book"] = "책";
            ht["cook"] = "요리사";
            ht["programmer"] = "프로그래머";

            Console.WriteLine(ht["programmer"]);

            // foreach 가 가능한 객체 만들기
            var obj = new CustomEnumerator();
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }

        }
    }

    class CustomEnumerator 
    {
        int[] numbers = { 1, 2, 3, 4 }; // 임의로 마치 반복문(foreach)를 못쓴다고 가정

        // foreach로 사용할 수 없는 객체를 반복문을 쓸 수 있도록 만들어주는 것
        public IEnumerator GetEnumerator()
        {
            // 일반 return은 return문을 만나면 메서드를 빠져나감
            // yield return은 return문을 실행한 뒤 멈춰있음. 다음 yield return문을 실행하기 전까지
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break; // 모든 로직을 빠져나감.
        }
    }
}
