using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace SnakeGame2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //초기값
            int speed = 100;
            int foodCount = 0;

            CreatWall creatWall = new CreatWall(80, 20, '#');

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p,4,Dirction.RIGHT);

            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 20, '$');

            Point food = foodCreator.FoodPoint();
            food.Draw();

            //게임실행(반복)
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch(key)
                    {
                        case ConsoleKey.RightArrow:
                            snake.dir = Dirction.RIGHT;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.dir = Dirction.LEFT;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.dir = Dirction.UP;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.dir = Dirction.DOWN;
                            break;
                    }
                }

                if (snake.Eat(food))
                {
                    foodCount++;
                    food.Draw();

                    food = foodCreator.FoodPoint();
                    food.Draw();
                }

                snake.Move();

                Thread.Sleep(speed);

                if (snake.InHitSnake())
                {
                    break;
                }

                Console.SetCursorPosition(0, 21);
                Console.WriteLine("현재 먹은 음식 : {0}", foodCount);
            }

            Console.SetCursorPosition(0, 22);
            Console.WriteLine("GameOver");

        }

        //포인트 클래스
        public class Point
        {
            public int x {  get; set; }
            public int y { get; set; }
            public char sym { get; set; }

            //포인트 생성자
            public Point(int x, int y, char sym)
            {
                this.x = x;
                this.y = y;
                this.sym = sym;
            }

            //심에 따라 포인트에 그리는 메소드
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }

            //포인트에 그려진걸 지우는 메소드
            public void Clear()
            {
                sym = ' ';
                Draw();
            }

            //두 포인트가 서로 같은 포인트인지 확인 하는 메소드
            public bool InHitPoint(Point p)
            {
                return x == p.x && y == p.y;
            }

        }

        //뱀구현 클래스
        public class Snake
        {
            //뱀 몸통에 대한 위치 리스트
            List<Point> body = new List<Point>();
            public Dirction dir;
            
            //뱀생성자
            public Snake(Point tail, int length, Dirction dir)
            {
                this.dir = dir;

                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(tail.x, tail.y,tail.sym);
                    body.Add(p);
                    tail.x++;
                }
            }

            public void Draw()
            {
                foreach (Point p in body)
                {
                    p.Draw();
                }
            }

            public void Move()
            {
                Point head = GetNextPoint();
                Point tail = body.First();


                body.Remove(tail);
                body.Add(head);

                head.Draw();
                tail.Clear();

            }

            public Point GetNextPoint()
            {
                Point head = body.Last();
                Point nextPoint = new Point(head.x, head.y, head.sym);

                switch(dir)
                {
                    case Dirction.RIGHT:
                        nextPoint.x += 2;
                        break;
                    case Dirction.LEFT:
                        nextPoint.x -= 2;
                        break;
                    case Dirction.UP:
                        nextPoint.y -= 1;
                        break;
                    case Dirction.DOWN:
                        nextPoint.y += 1;
                        break;
                }
                return nextPoint;
            }
            
            //뱀이 부딪혔는지 확인하는 메소드
            public bool InHitSnake()
            {
                Point head = body.Last();

                for (int i = 0; i < body.Count - 2; i++)
                {
                    if (head.InHitPoint(body[i]))
                    {
                        return  true;
                    }
                }

                if (head.x >= 80 || head.x <= 0 || head.y >= 20 || head.y <= 0)
                {
                    return true;
                }

                return false;
            }

            public bool Eat(Point food)
            {
                Point head = GetNextPoint();

                if (head.InHitPoint(food))
                {
                    body.Add(food);
                    food.sym = head.sym;
                    return true;
                }
                return false;
            }
            
        }


        //음식 생성 관련 클래스
        public class FoodCreator
        {
            Random rand = new Random();
            int x;
            int y;
            char sym;

            //생성자
            public FoodCreator(int x, int y, char sym)
            {
                this.x = x;
                this.y = y;
                this.sym =sym;
            }

            public Point FoodPoint()
            {
                int randx = rand.Next(2, x - 2);
                randx = randx % 2 == 0 ? randx -1  : randx;

                int randy = rand.Next(2, y - 2);
                return new Point(randx, randy, sym);
            }


        }

        //벽생성 클래스
        public class CreatWall
        {
            public int x;
            public int y;
            public char sym;

            public CreatWall(int x, int y, char sym)
            {
                for (int i = 0; i < x; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write(sym);
                    Console.SetCursorPosition(i, y);
                    Console.Write(sym);
                }

                for (int j = 0; j < y; j++)
                {
                    Console.SetCursorPosition(0, j);
                    Console.Write(sym);
                    Console.SetCursorPosition(x, j);
                    Console.Write(sym);
                }
            }
        }

        //방향키
        public enum Dirction
        {RIGHT, LEFT, UP, DOWN}

    }
}
