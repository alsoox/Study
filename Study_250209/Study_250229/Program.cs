namespace Study_250229
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DataType


            //value type => 널지정 불가능
            bool b= true;

            short sh = 100; // 16bit
            int i = 100; // 32bit
            long l = 10000; // 64bit 부호가 있는 정수 signed integer
            
            ushort us = 111; // u -> unsigned 부호가 없는 정수
            uint ui =110;
            ulong ul = 1000; 

            float f = 3.14f; // 32bit
            double d = 3.141592d; // 64bit;
            decimal dd = 3.14m; //128bit;

            char cha = '한'; // 16 bit UniCode

            byte by = 0 * 46; // 8bit


            //refernece type => null 지정 가능
            string s = " Hello";
            object o = 123; // 모든데이터를 포함할 수 있음



            //value type 에 null 지정 하고싶을때

            int? ix = null;
        }
    }
}
