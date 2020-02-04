using NUnit.Framework;
using StoredProcHelper.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoredProcHelper.Tests
{
    public class Tests
    {

        private StoredProcHelperClass _sp;
        private ProjectDbContext _db;

        [SetUp]
        public void Setup()
        {
            _sp = new StoredProcHelperClass(_db);
        }

        [Test]
        [TestCase("dbo.usp_TestStoredProc")]
        public async Task TestExecuteStoredProcHelperMethodToNotExecute(string spName)
        {
            // Testing empty dictionary ... 
            var parameters = new Dictionary<string, object>();
            
            var success =  await _sp.ExecuteStoredProcHelper(spName, parameters);

            Assert.IsFalse(success);
                        
        }

     
        [Test]
        [TestCase("dbo.usp_TestStoredProc")]
        public async Task TestExecuteStoredProcHelperMethodIfParamHasSpace(string spName)
        {
            // Testing a space in the key dictionary ... 
            var parameters = new Dictionary<string, object>
            {
                {"Param1", 1 },
                {"Param 2", "Test Value" },
                {"Param3", DateTime.Now },
            };

            var success = await _sp.ExecuteStoredProcHelper(spName, parameters);

            Assert.IsFalse(success);

        }
        
        // Uncomment when EF Core is wired up correctly 
        //
        //[Test]
        //[TestCase("dbo.usp_TestStoredProc")]
        //public async Task TestExecuteStoredProcHelperMethodSuccess(string spName)
        //{
        //    // Testing empty dictionary ... 
        //    var parameters = new Dictionary<string, object>
        //    {
        //        {"Param1", 1 },
        //        {"Param2", "Test Value" },
        //        {"Param3", DateTime.Now },
        //    };

        //    var success = await _sp.ExecuteStoredProcHelper(spName, parameters);

        //    Assert.IsTrue(success);

        //}




    }
}