using NorthwindClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindClassLibrary.Operations
{
    public class EmployeeOperations
    {
        private static string _connectionString;
        public EmployeeOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static IEnumerable<EmployeesSaleReport> EmployeeSalesReport(string fromdate, string todate)
        {
            List<EmployeesSaleReport> employeeSale = new List<EmployeesSaleReport>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string QueryName = $"EXECUTE [dbo].[EmployeesSaleReport] '{fromdate}','{todate}'";
                SqlCommand command = new SqlCommand(QueryName, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmployeesSaleReport esr = new EmployeesSaleReport();

                    esr.EmployeeName = (string)reader[0];
                    esr.OrderIdList = (string)reader[1];
                    esr.TotalOrderCount = reader.GetInt32(2);

                    employeeSale.Add(esr);

                }
                connection.Close();
            }
            return employeeSale;
        }

        public static List<ProductWiseMonthlyReport> ProductWiseMonthlyReport(string productName, string month, string year)
        {
            List<ProductWiseMonthlyReport> productReport = new List<ProductWiseMonthlyReport>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string QueryName = $"EXECUTE [dbo].[ProductWiseMonthlyReport] '{productName}','{month}','{year}'";
                SqlCommand command = new SqlCommand(QueryName, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductWiseMonthlyReport esr = new ProductWiseMonthlyReport();

                    esr.ProductName = (string)reader[0];
                    esr.Month = (string)reader[1];
                    esr.TotalOrderPrice = (decimal)reader[2];
                    

                    productReport.Add(esr);

                }
                connection.Close();
            }
            return productReport;
        }
    }
}
