//imports
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HiJeanCleaning
{
    class Program
    {
        //global variables

        static readonly List<string> CHEMICALS = new List<string>() { "Formaldehyde", "Ethanol", "Hydrogen Peroxide", "Chlorine", "Peracetic Acid" };
        static List<float> chemicalRating = new List<float>();
        static List<int> chosenChem = new List<int>();



        //main menu
        static void Main(string[] args)
        {
            int menuPick;
            bool flag = true;
            
            //Welcome message
            Console.WriteLine(
                "Welcome to Hi-Jean Cleaning!\n" +
                "You will enter sample of germs and the chemical you are wanting to test \n" +
                "These tests will show the efficiency rating of each test you complete \n" +
                "-------------------------------------------------------------------------\n\n");

            //App menu
            while (flag)
            {

                menuPick = CheckInt("Menu: \n" +
                    "1. Continue\n" +
                    "2. Stop", 1, 2 );
                Console.WriteLine("----------------");
                
                if (menuPick == 1)
                {
                    TestChem();
                }
                else if (menuPick == 2)
                {
                    Console.WriteLine("Thank you for trying HI-Jean Cleaning :)\n");
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Error: Input must be 1 or 2\n");
                }

            }

            //Additional methods

            //Check to see chemical has not been tested before
            static int CheckChemical()
            {
                while (true)
                {
                    //chemical list 
                    Console.WriteLine("\nPlease choose a chemical you are wanting to test with from the list:\n" +
                    $"1. {CHEMICALS[0]} \n" +
                    $"2. {CHEMICALS[1]} \n" +
                    $"3. {CHEMICALS[2]} \n" +
                    $"4. {CHEMICALS[3]} \n" +
                    $"5. {CHEMICALS[4]} \n"
                    );

                    int chemChoice = Convert.ToInt32(Console.ReadLine());
                    if (chosenChem.Contains(chemChoice))
                    {
                        Console.WriteLine("Error: You have already picked this chemical. Please pick another chemical");

                    }
                    else
                    {
                        return chemChoice;
                    }
                }
            }


            //Calculates efficiency of chemical
            static void TestChem()
            {
                chosenChem.Add(CheckChemical());

                    float sumEff = 0;

                    //for loop for repeating the test 5 times
                    for (int i = 1; i < 6; i++)
                    {

                        Console.WriteLine($"Enter amount of Germs you would like to sample with: Test {i}");
                        float liveGerm = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                        Console.WriteLine(
                            "---Please wait 30 mins before entering amount of live germs left---\n" +
                            "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                        Console.WriteLine("Please enter the remaining number of germs in sample");

                        float leftGerms = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                        //eficiency rate
                        float effRate = (liveGerm - leftGerms) / 20;

                        sumEff += effRate;

                        Console.WriteLine(
                            $"The efficency rate of {CHEMICALS[chosenChem[chosenChem.Count - 1]]} is: {effRate} \n" +
                            "-----------------------------------------------------------------\n");

                    }
                    //Final Efficiency Rating of all 5 tests
                    float finalEffRate = (float)Math.Round(sumEff / 5, 2);
                    chemicalRating.Add(finalEffRate);

                    Console.WriteLine(
                    $"The average efficiency rate of the 5 tests of {CHEMICALS[chosenChem[chosenChem.Count - 1]]} is: {finalEffRate}\n" +
                    "---------------------------------------------------------------------\n");
                }


            }

            static int CheckInt(string question, int min, int max)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine(question);
                        int user_choice = Convert.ToInt32(Console.ReadLine());

                        if (user_choice >= min && user_choice <= max)
                        {
                            return user_choice;
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: Please enter a number between {min} and {max}\n");
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"ERROR: Please enter a number between {min} and {max}\n");
                    }


                }







            }



        
    }
}   


