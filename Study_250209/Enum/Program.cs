namespace Enum
{
    internal class Program
    {
        enum Item
        {
            Coffee = 1,
            Tea,
            IceCream,
            Bread
        }

        [Flags]
        enum Border
        {
            None = 0,
            Top = 1,   // 0000 0001
            Right = 2, // 0000 0010
            Bottom = 4,// 0000 0100
            Left = 8   // 0000 1000
        }
        static void Main(string[] args)
        {
            Order(Item.Tea, 3); //Tea 3잔 주문

            Border b= Border.Top | Border.Right; // OR 다중 플래그 할당

            if ((b & Border.Top) != 0) //0101 & 0001 = 1
            {

            }

            if (b.HasFlag(Border.Top | Border.Bottom))
            {
                Console.WriteLine(b.ToString());
            }
        }

        static void Order(Item item, int qty)
        {
            switch(item)
            {
                case Item.Coffee:
                    //MakeCoffee
                    break;
                case Item.Tea:
                    //MakeTea
                    break;
                case Item.IceCream:
                    //MakeIceCream
                    break;
                case Item.Bread:
                    //MakeBread
                    break;
                default:
                    break;
            }    
        }
    }
}
