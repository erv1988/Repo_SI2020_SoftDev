using System;
using System.Collections.Generic;
using System.Linq;

namespace seabattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуй! Игра Морской бой приветствует тебя.");
            Console.WriteLine("new  - новая игра");
            Console.WriteLine("quit - выход");
            Console.WriteLine("[abcdefghij][0123456789] - сделать ход");
            
            Console.WriteLine("Набери new для старта");

            Game game = new Game();
            while(true)
            {

                string cmd = Console.ReadLine();

                if ( game.ProcessCommand(cmd))
                    return;
                game.DrawScene();

            }

        }
    }


    public enum Direction
    {
        Vertical,
        Horisontal
    }

    public class Dot
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Ship
    {
        // Размер корабля
        public List<Dot> Body = new List<Dot>();
        public List<Dot> Damage = new List<Dot>();

        public int X { set; get; }
        public int Y { set; get; }

        public Direction Direction { set; get; }

        public Ship (int size, Direction direction, int x, int y)
        {
            Damage = new List<Dot>();
            Body = new List<Dot>();
            if (direction == Direction.Vertical)
            {
                for (int i = 0; i < size; ++i)
                {
                    Body.Add(new Dot(x, y + i));
                }
            }
            else
            {
                for (int i = 0; i < size; ++i)
                {
                    Body.Add(new Dot(x + i, y));
                }
            }
        }
        
        public bool Contain(int x, int y)
        {
            return Body.Any(i => i.X == x && i.Y == y);
        }

        public bool Shot(int x, int y)
        {
            Dot dot = Body.Find(i => i.X == x && i.Y == y);
            if (dot == null)
                return false;

            Body.Remove(dot);
            Damage.Add(dot);
            return true;
        }
    }

    public class Player
    {
        public List<Ship> Ships = new List<Ship>();
        public List<Dot> Damages = new List<Dot>();

        public bool Shot(int x, int y)
        {
            if (Damages.Any(d => d.X == x && d.Y == y))
                return false;

            Ship ship = Ships.Find(s => s.Contain(x, y));
            if (ship == null)
            {
                Damages.Add(new Dot(x, y));
                return false;
            }

            ship.Shot(x, y);
            return true;
        }
    }

    class Game
    {
        Player player1, player2;

        Player activePlayer = null;
        Player otherPlayer = null;

        public void DrawScene()
        {
            Console.Clear();
            if (activePlayer == null)
                return;

            Console.SetCursorPosition(0, 0);
            Console.Write("Player 1");
            DrawPlayer(player1, 1, 1);

            Console.SetCursorPosition(20, 0);
            Console.Write("Player 2");
            DrawPlayer(player2, 20, 1);

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(activePlayer == player1 ? "Player1:" : "Player2:");
        }

        private void DrawPlayer(Player player, int x, int y)
        {
            for (int i = 1; i < 11; ++i)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.SetCursorPosition(x + i, y);
                Console.Write((char)('0' + i -1));

                Console.SetCursorPosition(x, y+i);
                Console.Write((char)('A' + i - 1));
            }
            foreach (Ship ship in player.Ships)
            {
                if (activePlayer == player)
                {
                    foreach (var p in ship.Body)
                    {
                        Console.SetCursorPosition(1 + x + p.X, 1 + y + p.Y);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(' ');
                    }
                }
                foreach (var p in ship.Damage)
                {
                    Console.SetCursorPosition(1+x + p.X, 1+y + p.Y);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('*');
                }
            }
            foreach (var p in player.Damages)
            {
                Console.SetCursorPosition(1+x + p.X, 1+y + p.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('*');
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Game()
        {
            player1 = new Player();
            player2 = new Player();
        }

        public bool ProcessCommand(string command)
        {
            command = command.ToLower();
            switch (command)
            {
                case "new":
                    newGame();
                    break;
                case "quit":
                    return true;
                default:
                    int v = command[0] - 'a';
                    int h = command[1] - '0';
                    if (v >=0 && v <= 9 && h >=0 && h <=9)
                    {
                        bool success = otherPlayer.Shot(h,v);

                        if (!success)
                        {
                            var t = activePlayer;
                            activePlayer = otherPlayer;
                            otherPlayer = t;
                        }
                    }
                    break;
            }
            return false;
        }


        private void printHelp()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        private void newGame()
        {
            player1.Damages.Clear();
            player1.Ships = new List<Ship>()
            {
                new Ship(1, Direction.Horisontal, 5,6),
                new Ship(1,Direction.Horisontal, 8,3),
                new Ship(1,Direction.Horisontal, 8,5),
                new Ship(1,Direction.Horisontal, 9,0),

                new Ship(2, Direction.Horisontal, 0,0),
                new Ship(2, Direction.Vertical, 2,9),
                new Ship(2, Direction.Vertical, 8,8),

                new Ship(3, Direction.Vertical, 3,0),
                new Ship(3, Direction.Vertical, 1,4),

                new Ship(4, Direction.Horisontal, 6,0),
            };

            player2.Damages.Clear();
            player2.Ships = new List<Ship>()
            {
                new Ship(1, Direction.Horisontal, 5,6),
                new Ship(1,Direction.Horisontal, 8,3),
                new Ship(1,Direction.Horisontal, 8,5),
                new Ship(1,Direction.Horisontal, 9,0),

                new Ship(2, Direction.Horisontal, 0,0),
                new Ship(2, Direction.Vertical, 2,9),
                new Ship(2, Direction.Vertical, 8,8),

                new Ship(3, Direction.Vertical, 3,0),
                new Ship(3, Direction.Vertical, 1,4),

                new Ship(4, Direction.Horisontal, 6,0),
            };

            activePlayer = player1;
            otherPlayer = player2;
        }
    }
}
