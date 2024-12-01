using System;
using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
           

            
            //Creating rank,taxi,transaction managers for storing inside user UI
            RankManager rankMgr = new RankManager();
            TaxiManager taxiMgr = new TaxiManager();
            TransactionManager transactionMgr = new TransactionManager();

            //Create new UserUI
            UserUI ui = new UserUI(rankMgr, taxiMgr, transactionMgr);
            // String list for display results after functions done
            List<string> display=new List<string>();

            //Variables for keeping data(taxiNum,RankID,...)
            //So I don't have to set variable types everytime i need to call them again
            int taxinum;
            int rankid;
            string destination;
            double agreedPrice;
            bool pricePaid;
            //Display menu and ask for user input before starting the loop
            DisplayMenu();
            int user_choice = ReadIntegerInRange(1, 6);

            while (user_choice != 0)
            {
                //Reset everything variables inside
                
                //Taxi joins rank
                if (user_choice == 1)
                {
                     taxinum = ReadInteger("Taxi number: ");
                     rankid = ReadInteger("Rank ID: ");

                    display=ui.TaxiJoinsRank(taxinum, rankid);
                }
                //Taxi leaves rank
                else if(user_choice ==2)
                {
                     rankid = ReadInteger("Rank ID: ");
                     destination = ReadString("Destination: ");
                     agreedPrice = ReadDouble("Price: ");

                    display = ui.TaxiLeavesRank(rankid, destination, agreedPrice);
                }
                //Taxi drop fares
                else if (user_choice == 3)
                {
                    taxinum = ReadInteger("Taxi number: ");
                    pricePaid = ReadBool("Price paid?[Y/N] ");
                    display = ui.TaxiDropsFare(taxinum, pricePaid);
                }
                //View finacial reports
                else if (user_choice == 4)
                {
                    display = ui.ViewFinancialReport();
                }

              
                //View taxi locations
                else if (user_choice == 5)
                {
                    display = ui.ViewTaxiLocations();
                }

                else if (user_choice == 6)
                {
                    display = ui.ViewTransactionLog();
                }
                //Display program outputs
                DisplayResults(display);
                //Ask for user input again if they want to continue or quit program
                DisplayMenu();              
                user_choice = ReadIntegerInRange(1, 7);
                
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n Taxi Management v1" + "\n==============");


            Console.WriteLine(" 1.Taxi joins rank" +
                "\n 2.Taxi leaves ranks" +
                "\n 3.Taxi drop fares" +
                "\n 4.View Finacial report" +
                "\n 5.View Taxi Locations " +
                "\n 6.View Transaction log" +
                "\n 0.Exit program"
                );

            Console.WriteLine("==============");
        }
        //Read integer
        private static int ReadInteger(string prompt)
        {
            Console.Write(prompt);
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        //Read integer in certain ranges
        //Uses for user input validation
        private static int ReadIntegerInRange(int minValue, int maxValue)
        {
            while (true)
            {

                //Ask user for input
                int user_choice = ReadInteger($"Input choice between {minValue} and {maxValue} >");
                //If user input is -1, quit program
                if (user_choice == 0)
                {

                    return user_choice;
                }

                //if user input is out of bound, ask for input again
                else if (user_choice > maxValue || user_choice < minValue)
                {
                    Console.WriteLine("Input out of bound, please try again");
                    continue;
                }
                //if nothing happens, return user input
                else
                {
                    return user_choice;
                }
            }
        }
        //Display results based on methods output string list
        private static void DisplayResults(List<string> results)
            //Write a empty gap here for visibility
            
        {
            Console.WriteLine("==============");
            results.ForEach((text) => Console.WriteLine("{0}", text));
            Console.WriteLine("==============");
        }

        //Read user input and output a double
        private static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            double input = Convert.ToDouble(Console.ReadLine());
            return input;
        }
        //Read user input and output a string
        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }

        //Read user input and output a bool for usage
        private static bool ReadBool(string prompt)
        {
            bool output;
            while (true)
            {
                //Bool value at start, it starts at false but not gonna return it until input validation
                //Get user input and turn them to upper case
                Console.Write(prompt);
                string input = (Console.ReadLine());
                string realInput = input.ToUpper();
                //If input is yes(Y)
                if (realInput == "Y")
                {   
                    output = true;
                    return output;
                }
                //Else if input is no(N)
                else if(realInput == "N")
                {
                    output=false;
                    return output;
                }

                else
                {
                    Console.Write("Invalid input!");
                    continue;
                }
                
            }
        }
    }
}


