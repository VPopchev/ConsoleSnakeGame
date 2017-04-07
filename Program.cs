using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    struct Location
    {
       public int X;
       public int Y;

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 45;
            Console.WindowHeight = 20;
            Console.BufferWidth = 45;
            Console.BufferHeight = 20;
            Console.CursorVisible = false;

            Random random = new Random();

            int snakeX = Console.WindowWidth / 2;
            int snakeY = Console.WindowHeight / 2;
            string snakeIcon = "o";
            Location head = new Location(snakeX,snakeY);
            List<Location> snake = new List<Location>();
            snake.Add(head);
            Location next;
            

            int foodX = random.Next(43);
            int foodY = random.Next(19);
            string foodIcon = "x";
            bool foodVisible = false;

            int score = 0;
            int size = 1;

            bool goUp = false;
            bool goDown = false;
            bool goLeft = false;
            bool goRight = false;

            while (true)
            {
                while (true)
                {
                    next = snake[0];
                    foodVisible = true;
                    foreach (Location location in snake)
                    {
                        Console.SetCursorPosition(location.X, location.Y);
                        Console.Write(snakeIcon);
                    }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressed = Console.ReadKey(true);
                        if (pressed.Key == ConsoleKey.UpArrow)
                        {
                            //next.Y--;
                            goUp = true;
                            goDown = false;
                            goLeft = false;
                            goRight = false;
                            
                        }
                        if (pressed.Key == ConsoleKey.DownArrow)
                        {
                            //next.Y++;
                            goDown = true;
                            goLeft = false;
                            goUp = false;
                            goRight = false;
                        }
                        if (pressed.Key == ConsoleKey.LeftArrow)
                        {
                            //next.X--;
                            goLeft = true;
                            goRight = false;
                            goUp = false;
                            goDown = false;
                        }
                        if (pressed.Key == ConsoleKey.RightArrow)
                        {
                            //next.X++;
                            goRight = true;
                            goLeft = false;
                            goUp = false;
                            goDown = false;
                        }
                }
                    if (goUp)
                    {
                        next.Y--;
                    }
                    if (goDown)
                    {
                        next.Y++;
                    }
                    if (goLeft)
                    {
                        next.X--;
                    }
                    if (goRight)
                    {
                        next.X++;
                    }
                    snake.Insert(0, next);
                        

                    if (foodVisible)
                    {
                        Console.SetCursorPosition(foodX, foodY);
                        Console.Write(foodIcon);
                    }
                    if (next.X == foodX && next.Y == foodY)
                    {
                        score+=2;
                        size++;
                        foodX = random.Next(43);
                        foodY = random.Next(19);
                    }
                    else
                    {
                        snake.RemoveAt(snake.Count - 1);
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Score: {0}", score);
                    Console.SetCursorPosition(0, 1);
                    Console.Write("Size: {0}",size);
                    Thread.Sleep(100);
                Console.Clear();
              }
            }
        }
    }
}
