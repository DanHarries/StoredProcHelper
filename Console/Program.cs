using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoredProcHelper;
using StoredProcHelper.Data;
using StoredProcHelper.Interface;
using System;
using System.Collections.Generic;

namespace StoredProcHelpers
{
    class Program
    {
        private static readonly ProjectDbContext _db;
        
        /// <summary>
        /// Entry point for console app
        /// </summary>
        /// <param name="args">Can pass stored proc name as a args parameter</param>
        static void Main(string[] args)
        {
            #region Declarations
            
            IStoredProcHelper _sp = new StoredProcHelperClass(_db);

            // Stored Proc name
            var spName = args.Length == 0 ? "dbo.usp_MyStoredProc" : args[0];

            // Build a dictionary that is of type <string, object>;
            var parameters = new Dictionary<string, object>
            {
                {"Param1", "Value" },
                {"Param2", 123 },
                {"Param3", DateTime.Now }
            };

            #endregion

            try
            {
                // Invoke the method ... 
                _sp.ExecuteStoredProcHelper(spName, parameters);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Stored Proc Executed Successfully!");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Something went wrong ... 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);

                Console.ReadKey();
            }
            
        }


        
    }
}
