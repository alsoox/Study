using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //초기설정값 (위치4,5 / 뱀 P,길이4 /GameSpeed 100)
            int gameSpeed = 100;
            int foodCount = 0;

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 20, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

         //게임 끝낼때까지 반복
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch(key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.dir = Direction.UP;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.dir = Direction.DOWN;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.dir = Direction.RIGHT;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.dir = Direction.LEFT;
                            break;
                    }
                }
                snake.Move();
                //밥을 먹었다면
                if (snake.EatFood(food))
                {
                    foodCount++;
                    food.Draw();

                    food = foodCreator.CreateFood();
                    food.Draw();
                    if (gameSpeed > 10)
                    {
                        gameSpeed -= 5;
                    }
                }

                Thread.Sleep(gameSpeed);

                if (snake.InHitSnake())
                {
                    break;
                }
                Console.SetCursorPosition(0, 21);
                Console.WriteLine($"먹은 음식 수: {foodCount}");

            }
        //게임 끝났을때

        //게임 내부 
        }

        //위치관련 클래스
        public class Point
        {
            public int x {get; set;}
            public int y {get; set;}
            public char sym {get; set;}

            //포인트 생성자
            public Point(int _x, int _y, char _sym)
            {
                x= _x;
                y = _y;
                sym = _sym;
            }

            //포인트 그리기
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }

            //포인트 지우기
            public void Clear()
            {
                sym = ' ';
                Draw();
            }

            // 포인트끼리 같은지 참 여부
            public bool InHit(Point p)
            {
                return p.x == x && p.y == y;
            }
        }

        //뱀관련 클래스
        public class Snake
        {
            //뱀 몸통 저장 리스트
            List<Point> body;
            public Direction dir;

            public Snake(Point tail, int length, Direction _dir)
            {
                dir = _dir;
                body = new List<Point>();
                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(tail.x, tail.y, tail.sym);
                    body.Add(p);
                    tail.x++;
                }
            }

            //뱀 그리기 메서드
            public void Draw()
            {
                foreach (Point p in body)
                {
                    p.Draw();
                }
            }

            //뱀 이동하기 메서드
            public void Move()
            {
                Point head = GetNextPoint();
                Point tail = body.First();

                body.Add(head);
                body.Remove(tail);
                head.Draw();
                tail.Clear();
            }

            //벰 다음위치 확인 메서드
            public Point GetNextPoint()
            {
                Point head = body.Last();
                Point nextPoint = new Point (head.x, head.y, head.sym);
                switch(dir)
                {
                    case Direction.RIGHT:
                        nextPoint.x += 2;
                        break;
                    case Direction.LEFT:
                        nextPoint.x -= 2;
                        break;
                    case Direction.UP:
                        nextPoint.y -= 1;
                        break;
                    case Direction.DOWN:
                        nextPoint.y += 1;
                        break;
                }
                return nextPoint;
            }

            //밥을 먹었는지
            public bool EatFood(Point food)
            {
                Point head = GetNextPoint ();


                if (head.InHit(food))
                {
                    food.sym = head.sym;
                    body.Add(food);
                    return true;
                }
                else return false;
            }

            //벽이나 몸에 맞았는지 확인 하는 메서드
            public bool InHitSnake()
            {
                Point head = body.Last();

                for (int i = 0; i < body.Count - 2; i++)
                {
                    if (head.InHit(body[i]))
                    {
                        return true;
                    }
                }

                if (head.x <= 0 || head.x >= 80 || head.y <= 0 || head.y >= 20)
                {
                    return true;
                }

                return false;
            }
        }

        //음식 생성 관련 클래스
        public class FoodCreator
        {
            int mapWidth;
            int mapHeight;
            char sym;

            Random random = new Random();

            public FoodCreator(int mapWidth, int mapHeight, char sym)
            {
                this.mapWidth = mapWidth;
                this.mapHeight = mapHeight;
                this.sym = sym;
            }

            // 무작위 위치에 음식을 생성하는 메서드입니다.
            public Point CreateFood()
            {
                int x = random.Next(2, mapWidth - 2);
                // x 좌표를 2단위로 맞추기 위해 짝수로 만듭니다.
                x = x % 2 == 1 ? x : x + 1;
                int y = random.Next(2, mapHeight - 2);
                return new Point(x, y, sym);
            }
        }

        //방향키 배열
        public enum Direction
        {
            UP,
            DOWN,
            RIGHT,
            LEFT
        }
     
        //벽 관련 클래스
    }
}
