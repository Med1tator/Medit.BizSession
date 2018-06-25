using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BizSession.StorageManger.Intf
{
    public interface IStorageManagerProvider
    {
        bool Set(string id, string jsonData);

        string Get(string id);

        bool TryGet(string id, out string jsonData);

        bool Remove(string id);

        bool RemoveBefore(DateTime dateLimit);
    }
}
