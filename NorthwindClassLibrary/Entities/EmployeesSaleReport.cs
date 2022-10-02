using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindClassLibrary.Entities
{
    public class EmployeesSaleReport
    {
        public string EmployeeName { get; set; }
        public string OrderIdList { get; set; }
        public int TotalOrderCount { get; set; }
    }
}
