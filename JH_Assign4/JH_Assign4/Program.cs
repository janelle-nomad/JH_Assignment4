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
           Version 4.5: added proper user interaction 
           prompt messages, to create a more fluid user experience
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
            Random seatPicker = new Random(); //Since some airlines, dont let people choose their own seats
            bool[] seats = new bool[10]; //seats is a bool (true or false)

            //To keep a separate list of seats taken         
            List<int> fClassSeatAssign = new List<int>(); //first class seats assigned to user
            List<int> EClassSeatAssigned = new List<int>(); //Economy class seats assigned to user
            int userclassChoice = 0; //User choice for airline menu
            char userYorN = ' '; //User choice for next selection
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine("              Enter (1) for First Class                     ");
                Console.WriteLine("              Enter (2) for Economy Class                   ");
                Console.WriteLine("              Enter (3) to exit the order system            ");
                Console.WriteLine("_____________________________________________________________");
                Console.Write("You entered: ");
                userclassChoice = Int32.Parse(Console.ReadLine());
                switch (userclassChoice)
                {
                    case 1:
                        int seatFirstClass; //First class ~ Global Variable

                        if (fClassSeatAssign.Count == 0) //if this is the first seat to be booked...
                        {
                            seatFirstClass = seatPicker.Next(6, 10); 
                            seats[seatFirstClass] = true;
                            fClassSeatAssign.Add(seatFirstClass);  //Add seat to the list of assigned user seats.                           
                        }
                        else
                        {
                            do //do-while there are available seats and current seat 
                               //has not being assigned a seat

                            {
                                seatFirstClass = seatPicker.Next(0, 5);
                                if (!fClassSeatAssign.Contains(seatFirstClass)) //if seatAssingF is not booked.
                                {
                                    seats[seatFirstClass] = true;
                                }
                                //Go through loop, while the random seat number is already assigned 
                                //and there are avaialable seats
                            } while (fClassSeatAssign.Contains(seatFirstClass) && fClassSeatAssign.Count < 5);

                            if (fClassSeatAssign.Count < 5) //if seatsBooked list is not ful, and there are still seats left for First Class
                            {
                                fClassSeatAssign.Add(seatFirstClass); //Add current random-generated seat to the list.
                            }
                        }
                        //
                        if (fClassSeatAssign.Count >= 5)
                        {
                            Console.WriteLine("All seats for First Class are booked!");
                            Console.WriteLine();
                            Console.WriteLine("_________________________________________________________________");
                            Console.WriteLine("   Would you like to book a seat in Economy Class?               ");
                            Console.WriteLine("   Enter (y) for Economy Class                                   ");
                            Console.WriteLine("   Enter (n) to exit the order systemy                           ");
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
                        if (EClassSeatAssigned.Count == 0) //if Economy Class seat has been selected by the user
                        {
                            seatEconClass = seatPicker.Next(5, 10);
                            seats[seatEconClass] = true;
                            EClassSeatAssigned.Add(seatEconClass);  //Add user seat to the list of taken/assigned seats.                           
                        }
                        else
                        {
                            do //do-while loop if there are free seats available and selected seat has not being choosen by the user
                            {
                                seatEconClass = seatPicker.Next(5, 10);
                                if (!EClassSeatAssigned.Contains(seatEconClass)) //if Economy Class seats haven't been sold out.
                                {
                                    seats[seatEconClass] = true;
                                }
                                //repeat while the random seat number is already booked and there are  avaialable seats
                            } while (EClassSeatAssigned.Contains(seatEconClass) && EClassSeatAssigned.Count < 5);

                            if (EClassSeatAssigned.Count < 5) //if seatsBooked <list> is not full for Economy Class
                            {
                                EClassSeatAssigned.Add(seatEconClass); //Add current random-generated seat to the list.
                            }
                        }
                        if (EClassSeatAssigned.Count >= 5)
                        {
                            Console.WriteLine("Unfortunately all seats for Economy Class are booked");
                            Console.WriteLine();
                            Console.WriteLine("_________________________________________________________________");
                            Console.WriteLine("      Would you like to book a seat in First Class?              ");
                            Console.WriteLine("      Enter (y) for First Class                                  ");
                            Console.WriteLine("      Enter (n) to exit the order systemy                        ");
                            Console.WriteLine("_________________________________________________________________");
                            Console.Write("You entered: "); //Added write instead aof using writeline, in order to create a realistic 
                                                            // user interaction
                            userYorN = Char.Parse(Console.ReadLine());
                            if (userYorN == 'y') //if user chooses y ~ show:
                            {
                                Console.WriteLine("Press enter to continue..."); //press any key to continue
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("_________________________________________________________________");
                                Console.WriteLine("              Next flight leaves in 3 hours!                     ");
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

            WaitForAnyKey();
        }
        private static void WaitForAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear(); //Clears the console, allows user to think and press a key  
                                //when the user chooses to

        }
    }
}
