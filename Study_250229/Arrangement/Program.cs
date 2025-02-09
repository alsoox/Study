namespace Arrangement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1부터 100까지를 변수에 저장
            int n1 = 1;
            int n2 = 2;
            int n3 = 3;
            //...
            int n100 = 100;

            //배열 선언 후 저장
            int[] n = new int[100];
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = i + 1;
            }

            int x = n[10];

            //배열 함수(메서드)에 전달
            PrintArray(n);

            //bollen 배열
            bool[] b = new bool[100];
            //string 배열
            string[] s = new string[100];

        }
        
        static void PrintArray(int[] arr )
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
