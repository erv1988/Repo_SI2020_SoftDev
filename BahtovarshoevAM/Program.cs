using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[,] desk = {
                          {1,0,1,0,1,0,1,0},
                          {0,1,0,1,0,1,0,1},
                          {1,0,1,0,1,0,1,0},
                          {0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0},
                          {0,2,0,2,0,2,0,2},
                          {2,0,2,0,2,0,2,0},
                          {0,2,0,2,0,2,0,2}
                          };


            while (true)
            {
                Console.Clear();
                ShowDesk(desk);
                Console.Write("\nEnter your move: ");
                var s = Console.ReadLine(); 

                
                var m = Regex.Match(s, "([wd])([abcdefgh])([12345678])-([abcdefgh])([12345678])");
                if (!m.Success)
                    continue;

                var fromX = m.Groups[2].Value[0] - 'a';
                var fromY = m.Groups[3].Value[0] - '1';
                var toX = m.Groups[4].Value[0] - 'a';
                var toY = m.Groups[5].Value[0] - '1';
                var color = m.Groups[1].Value[0] == 'w' ? 1 : 2;

                
                if (desk[fromY, fromX] != color)
                {
                    Console.WriteLine("There is not your draught!");
                    Console.ReadKey();
                    continue;
                }

                if (desk[toY, toX] != 0)
                {
                    Console.WriteLine("Target field is not empty!");
                    Console.ReadKey();
                    continue;
                }

                
                desk[fromY, fromX] = 0;
                desk[toY, toX] = color;
            }
        }

        private static void ShowDesk(int[,] desk)
        {
            char[] chars = new[] { '¦', '?', '?' };
            for (int i = 7; i >= 0; i--)
            {
                Console.Write((i + 1) + "   ");

                for (int j = 0; j < 8; j++)
                    Console.Write(chars[desk[i, j]] + "¦");

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a b c d e f g h");
        }
    }
}