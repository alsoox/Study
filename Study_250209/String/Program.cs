using System.Text;

namespace String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //문자열(string)
            string s1 = "C#";
            string s2 = "Programing";

            //문자(char)
            char c1 = 'A';
            char c2 = 'B';

            char c = s2[0]; // P -> 읽기전용

            //문자열 결합
            string s = s1 + "" + s2; // "C# Programing"

              //문자열을 문자배열로
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);   
            }

              //문자배열을 문자열로
            string ss = new string(arr);

            //부분 문자열
            string s4 = s2.Substring(1, 4); //rogr

            //문자열 치환
            string s5 = s2.Replace("Pro", "PRO"); //PROgraming

            //문자열 삭제
            string s6 = s2.Remove(3); //Pro

            //공백 삭제
            string s7 ="Hello        ".Trim();


            //mutable type
            int i = 1; // Stack 상 300번지
            i = 2;     // Stack 상 300번지

            //immutable type
            string ss1 = "C#"; // 100번지 "C#"
            ss1 = "F#";        // 200번지 "F#"


            //각각 생성
            string a = "";
            for (int j = 0; j < 1000000; j++)
            {
                a = a + i.ToString();
            }
            //"0"
            //"01"
            //...
            //"012..."

            //String Builder
            StringBuilder sb = new StringBuilder(); ////mutable type

            for (int j = 0; j < 1000000; j++)
            {
                sb.Append(j.ToString());
            }

            string result = s.ToString();
        }
    }
}
