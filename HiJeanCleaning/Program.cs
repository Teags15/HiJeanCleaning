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
        static List<float> chemRating = new List<float>();
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
                    "2. Stop", 1, 2);
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

            //sorting chemRating and CHEMICALS lists in order

            for (int leftPointer = 0; leftPointer < chemRating.Count - 1; leftPointer++)
            {
                for (int rightPointer = leftPointer + 1; rightPointer < chemRating.Count; rightPointer++)
                {
                    //Swopping logic
                    if (chemRating[leftPointer] < chemRating[rightPointer])
                    {
                        float tempRATE = chemRating[leftPointer];
                        chemRating[leftPointer] = chemRating[rightPointer];
                        chemRating[rightPointer] = tempRATE;
                        int tempCHEM = chosenChem[leftPointer];
                        chosenChem[leftPointer] = chosenChem[rightPointer];
                        chosenChem[rightPointer] = tempCHEM;



                    }
                }
            }


            //Ordered List (Desc)

            //Most effective chemicals
            
            string topChem = "-----Top Chemicals-----\n";
            int numLoop;

            if (chosenChem.Count >= 3)
            {
                numLoop = 3;
            }
            else
            {
                numLoop = chosenChem.Count;
            }

            for (int chemIndex = 0; chemIndex < numLoop; chemIndex++)
            {
                topChem += chemIndex + 1 + "." + "" + CHEMICALS[chosenChem[chemIndex]] + " " + chemRating[chemIndex] + "\n";

            }

            Console.WriteLine(topChem);

            //least effective chemicals
            string worstChem = "-----Worst Chemicals-----\n";

            int numbLoop;
            int worstchemIndex = chosenChem.Count - 1;

            if (chosenChem.Count >= 3)
            {
                numbLoop = 3;
            }
            else
            {
                numbLoop = chosenChem.Count;
            }

            for (int loop = 0; loop < numbLoop; loop--)
            {
                worstChem += worstchemIndex + 1 + "." + "" + CHEMICALS[chosenChem[worstchemIndex]] + " " + chemRating[worstchemIndex] + "\n";
                worstchemIndex--;
            }
            Console.WriteLine(worstChem);


        }   
            
            //Additional methods

            //Check to see chemical has not been tested before
        static int CheckChemical()
        {
            while (true)
            {
                //Chemical list
                int chemChoice = CheckInt("\nPlease choose a chemical you are wanting to test with from the list:\n" +
                $"1. {CHEMICALS[0]} \n" +
                $"2. {CHEMICALS[1]} \n" +
                $"3. {CHEMICALS[2]} \n" +
                $"4. {CHEMICALS[3]} \n" +
                $"5. {CHEMICALS[4]} \n", 1, 5);
                    
                if (chosenChem.Contains(chemChoice))
                {
                    Console.WriteLine("Error: You have already tested this chemical. Please pick another chemical");

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
                //liveGerm amount between 30-300
                float liveGerm = CheckInt($"Enter amount of Germs you would like to sample with: Test {i}",30,300);
                        
                //Waiting Period for livegerm to die
                Console.WriteLine(
                     "---Please wait 30 mins before entering amount of live germs left---\n" +
                     "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

               float leftGerms = CheckInt($"\nPLease entering the remaining number of germs",0,300);

                //eficiency rate equation
                float effRate = (liveGerm - leftGerms) / 20;

                sumEff += effRate;

                Console.WriteLine(
                    $"The efficency rate of {CHEMICALS[chosenChem[chosenChem.Count - 1]-1]} is: {effRate} \n" +
                    "-----------------------------------------------------------------\n");

            }
                    
                //Final Efficiency Rating of all 5 tests
                float finalEffRate = (float)Math.Round(sumEff / 5, 2);
                    
                chemRating.Add(finalEffRate);

                Console.WriteLine(
                $"The average efficiency rate of the 5 tests of {CHEMICALS[chosenChem[chosenChem.Count - 1]-1]} is: {finalEffRate}\n" +
                "---------------------------------------------------------------------\n");
        }


        
            
        //Error message for player menu
        static int CheckInt(string question, int min, int max)
        {
            string ERROR_MSG = $"Error: Enter a valid number between {min} and {max}\n";
                
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
                            Console.WriteLine(ERROR_MSG);
                        }
                    }
                    catch
                    {
                        Console.WriteLine(ERROR_MSG);
                    }


                }

            }
        
    }
}   


