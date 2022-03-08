using System;
using System.Globalization;

namespace HiJeanCleaning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Welcome to Hi-Jean Cleaning!\n"+
                " You will enter sample of germs and the chemical you are wanting to test \n" +
                "These tests will show the efficiency rating of each test you complete \n" +
                "-------------------------------------------------------------------------\n\n" +
                "Please enter the number of germs you are sampling with. This can be entered manually or randomly\n"+
                "Enter 1 if you want to input manually or Enter 2 if you want a randomly generated number \n"+
                "-----------------------------------------------------------------------------------------");

            TestChem();
        
        
        }
        static void TestChem()
        {
            float germNum = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

            if (germNum == 1)
            {
                Console.WriteLine("Enter amount of Germs you would like to sample with");
            }
            else
            {
                Random rnd = new Random();
                float randNum = rnd.Next();
                Console.WriteLine($"{randNum}");
            }


        }
    }


}
