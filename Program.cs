using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace Dapper_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string connString = config.GetConnectionString("DefaultConnection");
           
            #endregion
            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Hello user, here are the current departments");
            Console.WriteLine("Please press enter . . .");
            Console.ReadLine();
            var depos = repo.GetAllDepartments();

            Console.WriteLine("Do you want to add a department????");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department???");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());

              
                
                 
            }


            


        }

        private static void Print(IEnumerable<Department> depos)
        {

            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
            Console.WriteLine("Have a great day!!!!!");


        }


    }
}
