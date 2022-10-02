using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindClassLibrary.Entities
{
    public class ProductWiseMonthlyReport
    {
        public string ProductName { get; set; }
        public string Month { get; set; }
        public decimal TotalOrderPrice { get; set; }
    }
}
