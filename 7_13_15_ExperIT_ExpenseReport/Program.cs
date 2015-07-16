using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_13_15_ExperIT_ExpenseReport
{
   

class Program
    {

        //A program that determines if an expense is approved or disapproved based on who sumbits it and certain criteria. 

        static void Main(string[] args)
        {

            bool parse;
            int empLevel;

            //define levels
            string[] jobLevel = {"Employee", "FirstLevelManager", "SecondLevelManager", "Director", "CEO"};

            //prompt user for their level           
            for (int i = 0; i <5; i++)
            {
                Console.WriteLine(i + ": " + jobLevel[i]);
            }
            
            //repeat prompting until we get a recognizable level
            do
            {
                Console.WriteLine("Please enter your rank within HappyFace, Inc.:");
                parse = Int32.TryParse(Console.ReadLine(), out empLevel);
            } while (!parse || empLevel < 0 || empLevel > 5);

            
            //prompt user for input
            Console.WriteLine("What is the decription of the item?");
            string itemDescription = Console.ReadLine();
           
            double itemPrice;
            
            do {
                Console.WriteLine("What is the price of the item?");
                parse = Double.TryParse(Console.ReadLine(), out itemPrice);
            } while (!parse);

            bool approved = false;
            switch (empLevel)
            {
                case 0:
                    approved = firstLevelMgr(itemDescription, itemPrice);
                    break;
                case 1:
                    approved = secondLevelMgr(itemDescription, itemPrice);
                    break;
                case 2:
                    approved = director(itemDescription, itemPrice);
                    break;
                case 3:
                    approved = ceo(itemDescription, itemPrice);
                    break;
                case 4:
                    approved = boardOfDirectors(itemDescription, itemPrice);
                    break;
                default:
                    Console.WriteLine("I am confused.");
                    break;
            }

            if (approved)
            {
                Console.WriteLine("Your request is approved!");
            }
            else
            {
                Console.WriteLine("Sorry, your request is denied!");
            }

            Console.WriteLine();    //whitespace
            Console.WriteLine("Press return to exit.");
            Console.Read();

        }

        static bool firstLevelMgr(string description, double price)
        {
            //check if the decription contains entertainment (regardless of case)
            if (description.ToLower().Contains("entertainment"))
            {
                return false;
            }
            //cannot approve if over $250
            if (price > 250)
            {
                return secondLevelMgr(description, price);
            }

            //otherwise approve!  we are liberal managers
            Console.WriteLine("Considered by the first level manager.");
            return whim();
        }

        static bool secondLevelMgr(string description, double price)
        {
            //check if the decription contains towncar(s) (regardless of case)
            if (description.ToLower().Contains("towncar"))
            {
                return false;
            }
            //cannot approve if over 500, kick it up a level!
            if (price > 500)
            {
               return director(description, price);
            }

            //otherwise approve!  we are liberal managers
            Console.WriteLine("Considered by the second level manager.");
            return whim();
        }

        static bool director(string description, double price)
        {
            //check if the decription contains hardawre (regardless of case)
            //currently assuming that the keyword hardware will be explicitly contained in the decription
            if (description.ToLower().Contains("hardware") && price > 5000)
            {
                return false;
            }
            //cannot approve if over 1000, kick it up a level!
            if (price > 1000)
            {
                return ceo(description, price);
            }

            //otherwise approve!  we are liberal managers
            Console.WriteLine("Considered by the director.");
            return whim();
        }

        static bool ceo(string description, double price)
        {
            //check if the request will ruin the company
            //illegal activity, unethical activity, etc.
            if (description.ToLower().Contains("payoff")
                || description.ToLower().Contains("junket")
                || description.ToLower().Contains("vacation")
                || description.ToLower().Contains("bribe"))               
            {
                return false;
            }
            //cannot approve if over 100000, kick it up a level!
            if (price > 100000)
            {
                return boardOfDirectors(description, price);
            }

            //our CEO loves us and wants us to be happy!
            Console.WriteLine("Considered by the CEO.");
            return whim();
        }

        static bool boardOfDirectors(string description, double price)
        {
            //Board allows any amount donated to charity
            if (description.ToLower().Contains("charity"))
            {
                return true;
            }
            return false;
        }

    //randomly approves or disapproves 
        static bool whim()
        {
            //models a random true/false decision   
            Random rnd = new Random();
            int rad = rnd.Next(0, 2); // creates a number between 0 and 1
            if (rad == 0)
                return true;
            return false;
        }

    }
}