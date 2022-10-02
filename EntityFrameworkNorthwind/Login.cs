using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNorthwind
{
    public class Login
    {
        public static void Execute()
        {
            Console.WriteLine("1. Employee Sales Report");
            Console.WriteLine("2. Weekly Sales Report for last 4 weeks");
            Console.WriteLine("3. Product wise Monthly Report\n");
            Console.WriteLine("Enter your Choice...");

            int choice = 0;
            bool Value = int.TryParse(Console.ReadLine(), out choice);
            if (Value)
            {
                if (choice == 1)
                {
                    EmployeeSalesReport.Execute();

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Sorry..I dont Solve This?");
                }
                else if (choice == 3)
                {
                    ProductMonthlyReport.Execute();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the correct Input..\n");
                    Login.Execute();
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter the correct Input..\n");
                Login.Execute();
            }
        }
    }
}
