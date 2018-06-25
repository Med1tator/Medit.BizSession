using Medit.BizSession.StorageManger.Intf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BizSession.StorageManager.Impl
{
    public class MongoStorageManagerProvider : IStorageManagerProvider
    {
        private MongoDbClient _client;

        public MongoStorageManagerProvider()
        {
            _client = new MongoDbClient();
        }

        public string Get(string id)
        {
            return _client.Get(id);
        }

        public bool Remove(string id)
        {
            return _client.Remove(id);
        }

        public bool RemoveBefore(DateTime dateLimit)
        {
            return _client.RemoveBefore(dateLimit);
        }

        public bool Set(string id, string jsonData)
        {
            return _client.Set(id, jsonData);
        }

        public bool TryGet(string id, out string jsonData)
        {
            jsonData = string.Empty;
            try
            {
                jsonData = _client.Get(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
