using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

namespace OracleDatabaseHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = "SELECT * FROM EMPLOYEES";
            var connectionString = "DATA SOURCE=HR;USER ID=HR;PASSWORD=HR";

            List<Employee> employees = new List<Employee>();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new Employee() { EmployeeId = Convert.ToInt32(reader[0]), FirstName = reader[1].ToString() });
                    Console.WriteLine(String.Format("{0} - {1}", reader.GetName(0), reader[0]));
                }
            }



            Console.ReadLine();
        }
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
    }
}
