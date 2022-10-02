using NorthwindClassLibrary.Entities;
using NorthwindClassLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindClassLibrary
{   
    public class Authentication
    {
        private static string connectionString = @"Data Source=LAPTOP-QQJKA00R;Initial Catalog=Northwind;Integrated Security=True";

        private static EmployeeOperations employeeOperations = new EmployeeOperations(connectionString);
        
        public static void Execute()
        {
            Console.WriteLine("1. Employee Sales Report");
            Console.WriteLine("2. Weekly Sales Report for last 4 weeks");
            Console.WriteLine("3. Product wise Monthly Report\n");
            Console.WriteLine("Enter your Choice...");

            int choice = 0;
            bool Value = int.TryParse(Console.ReadLine(),out choice);
            if(Value)
            {
                if(choice==1)
                {
                    Console.WriteLine("Enter From Date for Employee Sales Report in yyyy-MM-dd format");                    
                    DateTime fromdate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
                    Console.WriteLine("Enter To Date for Employee Sales Report in yyyy-MM-dd format");
                    DateTime todate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
            
                    List<EmployeesSaleReport> result = (List<EmployeesSaleReport>)EmployeeOperations.EmployeeSalesReport(fromdate.ToString("yyyy-MM-dd"), todate.ToString("yyyy-MM-dd"));
                    Console.WriteLine("---------------------------");
                    foreach(var employee in result)
                    {
                        Console.WriteLine("EmployeeName    : "+employee.EmployeeName);
                        Console.WriteLine("TotalOrderCount : " + employee.TotalOrderCount);
                        Console.WriteLine("OrderId's List  : " + employee.OrderIdList+"\n");
                    }
                }
                else if(choice==2)
                {
                    Console.WriteLine("It is not Done Sorry..!");
                }
                else if(choice==3)
                {
                    Console.WriteLine("Enter product Name");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Enter Month (Ex:April)");
                    string month = Console.ReadLine();
                    Console.WriteLine("Enter Year (Ex:2000)");         
                    string year=Console.ReadLine();
                    List < ProductWiseMonthlyReport > result= EmployeeOperations.ProductWiseMonthlyReport(productName, month, year);
                    if(result==null)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter Proper Inputs...");
                        Authentication.Execute();
                    }
                    else
                    {
                        foreach(var product in result)
                        {
                            Console.WriteLine(product.ProductName+" "+product.Month+" "+product.TotalOrderPrice);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the correct Input..\n");                                        
                    Authentication.Execute();
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter the correct Input..\n");
                Authentication.Execute();
            }
        }

    }
}
