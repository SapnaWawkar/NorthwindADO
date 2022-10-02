using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNorthwind
{
    public class ProductMonthlyReport
    {
        public static void Execute()
        {
            using (var db = new NorthwindEntities())
            {
                Console.WriteLine("Enter product Name");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter Month (Ex:April)");
                string month = Console.ReadLine();
                Console.WriteLine("Enter Year (Ex:2000)");
                string year = Console.ReadLine();

                var result = db.ProductWiseMonthlyReport(productName, month, year);
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ProductName\tMonth\tTotalOrderPrice");
                if(result != null)
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.ProductName + "\t\t" + item.Month + "\t" + item.TotalOrderPrice);
                    }
                }
                else
                {
                    Console.Clear();
                    ProductMonthlyReport.Execute();
                }
                    
                
            }


        }
    }
}
