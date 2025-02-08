namespace Blackjack1
{
    public enum Shape {Heart, Diamond, Clover, Spade }
    public enum Number {Two = 2,Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace  }

    //카드 한장에 대한 정보 메소드
    public class Card
    {
        public Shape Shape { get; set; }
        public Number Number { get; set; }

        public Card(Shape s, Number n)
        {
            Shape = s;
            Number = n;
        }

        public int GetValue()
        {
            if ((int)Number <= 10)
            {
                return (int)Number;
            }
            else if ((int)Number <= 13) return 10;

            else
            {
                return 11;
            }
        }

        public override string ToString()
        {
            return $"{Number} of {Shape}";
        }
    }

    public class Deck
    {
       private List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (Shape s in Enum.GetValues(typeof(Shape)))
            {
                foreach (Number n in Enum.GetValues(typeof(Number)))
                {
                    cards.Add(new Card(s, n));
                }
            }
            Suffle();
        }

        public void Suffle()
        {
            Random random = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                Card card = cards[i];
                cards[i] = cards[j];
                cards[j] = card;
            }
        }
    }

    public class Hand
    {
        private List <Card> cards = new List<Card>();

    }

    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
