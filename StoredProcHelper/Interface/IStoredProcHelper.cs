using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcHelper.Interface
{
    public interface IStoredProcHelper
    {
        Task<bool> ExecuteStoredProcHelper(string storedProcName, Dictionary<string, object> noteParams);
    }
}
