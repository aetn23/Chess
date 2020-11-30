using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    static class Coms
    {
        public static void RenderComs(byte stat)
        {
            switch (stat)
            {
                case 1:
                    Console.WriteLine("Which piece to move: ");
                    break;
                case 2:
                    Console.WriteLine("Those values are incorrect!");
                    break;
                case 3:
                    Console.WriteLine("Where to move: ");
                    break;
                case 4:
                    Console.WriteLine("There is nothing there!");
                    break;
                case 5:
                    Console.WriteLine("This place is occupied!");
                    break;
                case 6:
                    Console.WriteLine("This isn't your piece!");
                    break;
                case 7:
                    Console.WriteLine("Choose: K, B, T, Q");
                    break;
                default:
                    break;
                case 8:
                    Console.WriteLine("After this move the King is attacked");
                    break;
            }
        }
    }
}
