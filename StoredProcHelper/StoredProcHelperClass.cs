using Microsoft.EntityFrameworkCore;
using StoredProcHelper.Data;
using StoredProcHelper.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcHelper
{
    /// <summary>
    /// Stored proc helper class for a more generic way of dealing with ExecuteSqlRaw
    /// </summary>
    public class StoredProcHelperClass : IStoredProcHelper
    {
        private readonly ProjectDbContext _db;

        public StoredProcHelperClass(ProjectDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Execute the stored procedure
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="noteParams"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteStoredProcHelper(string storedProcName, Dictionary<string, object> noteParams)
        {
            var count = noteParams.Count;

            try
            {

                var commandText = $"EXECUTE {storedProcName} " + GetNumberOfParams(count);

                var sqlParams = CalculateParameters(noteParams);

                if (sqlParams.Count != 0)
                {
                    await _db.Database.ExecuteSqlRawAsync(commandText, sqlParams);

                    return true;
                }
                else
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                return false;
            }

        }

        #region Private Methods

        /// <summary>
        /// Works out how many parameters are needed dynamically
        /// </summary>
        /// <param name="noteParams"></param>
        /// <returns></returns>
        private List<SqlParameter> CalculateParameters(Dictionary<string, object> noteParams)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            foreach (var res in noteParams)
            {
                if(res.Key.Contains(" "))
                {
                    sqlParam.Add(new SqlParameter($"@{res.Key}", res.Value));

                } 
                else
                {
                    return new List<SqlParameter>();
                }

            }

            return sqlParam;

        }

        /// <summary>
        /// Get the number of params needed for the sp
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetNumberOfParams(int count)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                builder.Append($"{{{i}}},");
            }

            return builder.ToString().TrimEnd(',');
        }

        #endregion
    }
}
