using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNorthwind
{
    public class EmployeeSalesReport
    {
        public static void Execute()
        {
            using (var db = new NorthwindEntities())
            {
                Console.WriteLine("Enter From Date for Employee Sales Report in yyyy-MM-dd format");
                DateTime fromdate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
                Console.WriteLine("Enter To Date for Employee Sales Report in yyyy-MM-dd format");
                DateTime todate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);

                var employees = db.EmployeesSaleReport(fromdate, todate);
                if(employees != null)
                {
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("EmployeeName    : " + employee.Employee);
                        Console.WriteLine("TotalOrderCount : " + employee.TotalOrderCount);
                        Console.WriteLine("OrderId's List  : " + employee.OrderId + "\n");
                    }
                }
                else
                {
                    Console.Clear();
                    EmployeeSalesReport.Execute();
                }
                


            }
        }
    }
}
