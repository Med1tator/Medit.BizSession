using Medit.BizSession.StorageManger.Intf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BizSession
{
    public class StorageManager
    {
        private IStorageManagerProvider _managerProvider;

        public StorageManager()
        {
            _managerProvider = ProviderInitializer.Initial();
        }
        public string Get(string id)
        {
            return _managerProvider.Get(id);
        }

        public bool Remove(string id)
        {
            return _managerProvider.Remove(id);
        }

        public bool RemoveBefore(DateTime dateLimit)
        {
            return _managerProvider.RemoveBefore(dateLimit);
        }

        public bool Set(string id, string jsonData)
        {
            return _managerProvider.Set(id, jsonData);
        }

        public bool TryGet(string id, out string jsonData)
        {
            return _managerProvider.TryGet(id, out jsonData);
        }
    }
}
