using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerball
{
    class Program
    {
        static void Main(string[] args)
        {
            var powerBall = new PowerBallGenerator();
            powerBall.ExecutePowerBall();
            Console.WriteLine("Press button to exit...");
            Console.ReadKey();
        }
    }

    public class PowerBallGenerator
    {
        /// <summary>
        /// Generates the powerball ticket with 5 random numbers
        /// </summary>
        /// <returns></returns>
        public int[] GeneratePowerBallTicket()
        {
            var numbers = new int[5];
            for(var x = 0; x < 5; x++)
            {
                Random r = new Random();
                int rInt = r.Next(1, 59); 
                numbers[x] = rInt;
            }
            return numbers;
        }

        /// <summary>
        /// Checks if powerball ticket and users numbers equal
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public bool CheckTicket(int[] powerballNumbers, int[] userNumbers)
        {
            return powerballNumbers.SequenceEqual(userNumbers);
        }

        /// <summary>
        /// User selects 5 numbers
        /// </summary>
        /// <returns></returns>
        public int[] SelectNumbers()
        {
            var userNumbers = new List<string>();
            Console.WriteLine("Enter 5 numbers");
            for (var x = 1; x <= 5; x++)
            {
                Console.WriteLine("Number " + x);
                userNumbers.Add(Console.ReadLine());
            }
            return Array.ConvertAll(userNumbers.ToArray(), int.Parse);
        }
        /// <summary>
        /// Show the user the results
        /// </summary>
        /// <param name="powerballNumbers"></param>
        /// <param name="userNumbers"></param>
        public void PrintNumbers(int[] powerballNumbers, int[] userNumbers)
        {
            Console.WriteLine("Powerball Numbers : ");
            Console.WriteLine("[{0}]", string.Join(", ", powerballNumbers));

            Console.WriteLine("Your Numbers : ");
            Console.WriteLine("[{0}]", string.Join(", ", userNumbers));
        }

        /// <summary>
        /// Run the entire class
        /// </summary>
        public void ExecutePowerBall()
        {
            var userNumbers = SelectNumbers();
            var powerballNumbers = GeneratePowerBallTicket();
            var ticketCheck = CheckTicket(powerballNumbers, userNumbers);
            if (ticketCheck)
                Console.WriteLine("Congrats, you won!");
            else
                Console.WriteLine("Sorry, maybe next time!");
            PrintNumbers(powerballNumbers, userNumbers);
        }
    }


}
