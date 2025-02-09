using System.Diagnostics;

namespace TryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try // 요기서 에러가 발생하면
            {
                Run();
                //...
            }
            catch (Exception ex) //에러정보를 가지고
            {
                Console.WriteLine(ex.Message); //에러 메시지만 출력 // throw;
            }

            //...
            Console.WriteLine("Next Step"); //계속 진행
        }

        static void Run()
        {
            try
            {
                int[] a = new int[10];

                for (int i = 0; i <= 10; i++)
                {
                    a[i] = i;
                    Console.WriteLine(a[i]);
                }

                var fs = File.Open("my.config", FileMode.Open);
                //...
            }
            //catch(IndexOutOfRangeException ex)
            //{
            //    //...
            //}
            //catch(FileNotFoundException ex)
            //{
            //    //Use default values
            //    //...
            //}
            catch(Exception ex)
            {
                Log(ex);
                //throw;
                //throw ex;
                throw new ApplicationException(ex.Message, ex);
            }

            //....
        }

        static void Log(Exception ex)
        {
            //File, DB 로깅
        }
        

        
    }
}
