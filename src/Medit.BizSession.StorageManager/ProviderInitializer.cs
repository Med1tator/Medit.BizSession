using Medit.BizSession.StorageManger.Intf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BizSession
{
    internal class ProviderInitializer
    {
        public static IStorageManagerProvider Initial()
        {
            string storageMedia = GetStorageMedia();

            Assembly assembly = Assembly.Load(string.Format("Medit.BizSession.StorageManager.{0}", storageMedia));
            IStorageManagerProvider provider = (IStorageManagerProvider)assembly.CreateInstance(string.Format("Medit.BizSession.StorageManager.Impl.{0}StorageManagerProvider", storageMedia));

            return provider;
        }

        private static string GetStorageMedia()
        {
            string storageMedia = ConfigurationManager.AppSettings["BizSessionStorageMedia"];
            if (string.IsNullOrEmpty(storageMedia))
                storageMedia = "Mongo";

            return storageMedia;
        }
    }
}
