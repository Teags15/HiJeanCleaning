using System;
using System.Globalization;

namespace HiJeanCleaning
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome message
            Console.WriteLine(
                "Welcome to Hi-Jean Cleaning!\n" +
                "You will enter sample of germs and the chemical you are wanting to test \n" +
                "These tests will show the efficiency rating of each test you complete \n" +
                "-------------------------------------------------------------------------\n\n");
               

            TestChem();
        
        
        }

        static void TestChem()
        {
            //chemical list 
            Console.WriteLine("Please choose a chemical you are wanting to test with from the list:\n" +
              "1. Formaldehyde \n" +
              "2. Ethanol \n" +
              "3. Hydrogen Peroxide \n" +
              "4. Chlorine \n" +
              "5. Peracetic Acid \n"
              );

            int chemChoice = Convert.ToInt32(Console.ReadLine());

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
                float effRate = (liveGerm - leftGerms) / 30;

                Console.WriteLine(
                    $"The efficency rate of chemcical {chemChoice} is {effRate} \n" +
                    "--------------------------------------------------------------------- \n");

            }
        

        
        }
    
    }


}
