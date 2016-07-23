using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
           Janelle Heron
           300839820   
           Date Created: 2016-07-10
           Date Modified: 2016-07-22  
           version 0.0.4 - Created a new repo -- due to sync github error 
    */
namespace JH_Assign4
{

    /* Airline Reservation System
* <summary>
* The purpose of this program is to simulate a Airline Reservation Application
* </summary>
*/
    class Program
    {
     
        static void Main(string[] args)
        {
            // random number generator, added feature, to auto assign user's seat. 
            Random rand = new Random(); //Since some airlines, dont let people choose their own seats
            bool[] seats = new bool[10]; //seats is a bool (true or false)

            //To keep a separate list of seats taken         
            List<int> firstSeatsBooked = new List<int>(); //first class seats assigned to user
            List<int> economySeatsBooked = new List<int>(); //Economy class seats assigned to user
            int userclassChoice = 0; //User choice for airline menu
            char userYorN = ' '; //User choice for next selection
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine("              Select (1) for First Class                     ");
                Console.WriteLine("              Select (2) for Economy Class                   ");
                Console.WriteLine("              Select (3) to exit the order system            ");
                Console.WriteLine("_____________________________________________________________");
                Console.Write("You entered: ");
                userclassChoice = Int32.Parse(Console.ReadLine());
                switch (userclassChoice)
                {
                    case 1:
                        int seatFirstClass; //First class ~ Global Variable

                        if (firstSeatsBooked.Count == 0) //if this is the first seat to be booked...
                        {
                            seatFirstClass = rand.Next(0, 5);
                            seats[seatFirstClass] = true;
                            firstSeatsBooked.Add(seatFirstClass);  //Add seat to the list of assigned user seats.                           
                        }
                        else
                        {
                            do //do-while there are available seats and current seat 
                               //has not being assigned a seat

                            {
                                seatFirstClass = rand.Next(0, 5);
                                if (!firstSeatsBooked.Contains(seatFirstClass)) //if seatAssingF is not booked.
                                {
                                    seats[seatFirstClass] = true;
                                }
                                //Go through loop, while the random seat number is already assigned 
                                //and there are avaialable seats
                            } while (firstSeatsBooked.Contains(seatFirstClass) && firstSeatsBooked.Count < 5);

                            if (firstSeatsBooked.Count < 5) //if seatsBooked list is not ful, and there are still seats left for First Class
                            {
                                firstSeatsBooked.Add(seatFirstClass); //Add current random-generated seat to the list.
                            }
                        }
                        //
                        if (firstSeatsBooked.Count >= 5)
                        {
                            Console.WriteLine("All seats for First Class are booked!");
                            Console.WriteLine();
                            Console.WriteLine("_________________________________________________________________");
                            Console.WriteLine("   If it’s acceptable to be placed in the economy-class?         ");
                            Console.WriteLine("   Please type (y) for Economy Class                             ");
                            Console.WriteLine("      Please type (n) to exit the order systemy                  ");
                            Console.WriteLine("_________________________________________________________________");
                            Console.Write("You entered: ");
                            userYorN = Char.Parse(Console.ReadLine());
                            if (userYorN == 'y')
                            {
                                Console.WriteLine("Press enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("_________________________________________________________________");
                                Console.WriteLine("              Next flight leaves in 3 hours.                     ");
                                Console.WriteLine("                Press enter to continue...                       ");
                                Console.WriteLine("_________________________________________________________________");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your seat is: {0}", seatFirstClass + 1); //Show User's random First Class seat
                            Console.WriteLine();
                            Console.WriteLine("Press enter to continue...");
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        int seatEconClass;
                        if (economySeatsBooked.Count == 0) //if Economy Class seat has been selected by the user
                        {
                            seatEconClass = rand.Next(5, 10);
                            seats[seatEconClass] = true;
                            economySeatsBooked.Add(seatEconClass);  //Add user seat to the list of taken/assigned seats.                           
                        }
                        else
                        {
                            do //do-while loop if there are free seats available and selected seat has not being choosen by the user
                            {
                                seatEconClass = rand.Next(5, 10);
                                if (!economySeatsBooked.Contains(seatEconClass)) //if Economy Class seats haven't been sold out.
                                {
                                    seats[seatEconClass] = true;
                                }
                                //repeat while the random seat number is already booked and there are  avaialable seats
                            } while (economySeatsBooked.Contains(seatEconClass) && economySeatsBooked.Count < 5);

                            if (economySeatsBooked.Count < 5) //if seatsBooked <list> is not full for Economy Class
                            {
                                economySeatsBooked.Add(seatEconClass); //Add current random-generated seat to the list.
                            }
                        }
                        if (economySeatsBooked.Count >= 5)
                        {
                            Console.WriteLine("All seats for Economy Class are booked");
                            Console.WriteLine();
                            Console.WriteLine("_________________________________________________________________");
                            Console.WriteLine("      If it’s acceptable to be placed in the First-class?     ");
                            Console.WriteLine("      Please type (y) for First Class                         ");
                            Console.WriteLine("      Please type (n) to exit the order systemy               ");
                            Console.WriteLine("_________________________________________________________________");
                            Console.Write("You entered: ");
                            userYorN = Char.Parse(Console.ReadLine());
                            if (userYorN == 'y')
                            {
                                Console.WriteLine("Press enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("_________________________________________________________________");
                                Console.WriteLine("              Next flight leaves in 3 hours.                     ");
                                Console.WriteLine("              Press enter to continue...                         ");
                                Console.WriteLine("_________________________________________________________________");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Your seat is: {0}", seatEconClass + 1);
                            Console.WriteLine();
                            Console.WriteLine("Press enter to continue...");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        quit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid Option");
                        quit = true;
                        break;
                }
            }

            waitForAnyKey();
        }

        private static void waitForAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
