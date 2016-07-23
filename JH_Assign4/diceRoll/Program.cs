using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Janelle Heron
    300839820   
    Date Created: July 12 2016
    Version 2: Created new Reop due to github sync error

    Dice Roll Simulation 
*/
namespace diceRoll
{
    /*
             * Driver Class {Program}
             * <summary>
             * This purpose of this class is to represent a dice roll simulation, of the event of 
             * rolling two dice, and presenting a series of outcomes 
             * </summary>
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] count = new int[11];
            Random rnd = new Random();

            int diceA, diceB;

            int total;

            for (int i = 0; i < 36000; i++)
            {

                diceA = rnd.Next(6) + 1;

                diceB = rnd.Next(6) + 1;

                total = diceA + diceB;

                switch (total)
                {
                    case 2:
                        count[0] += 1;
                        break;

                    case 3:
                        count[1] += 1;
                        break;

                    case 4:
                        count[2] += 1;
                        break;

                    case 5:
                        count[3] += 1;
                        break;

                    case 6:
                        count[4] += 1;
                        break;

                    case 7:
                        count[5] += 1;
                        break;

                    case 8:
                        count[6] += 1;
                        break;


                    case 9:
                        count[7] += 1;
                        break;

                    case 10:
                        count[8] += 1;
                        break;

                    case 11:
                        count[9] += 1;
                        break;

                    case 12:
                        count[10] += 1;
                        break;

                    default:
                        Console.WriteLine("Error unknown number");
                        break;
                }
            }

            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("  Digit:               Times Rolled: ");
            System.Console.WriteLine("=====================================");

            for (int track = 0; track < 11; track++)
            {
                Console.WriteLine(" " + (track + 2) + ": \t\t" + count[track] + " times");
            }
        }
    }
}
