using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BizSession.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageManager manager = new StorageManager();
            manager.Set("1001", "12345678");

            string s1 = manager.Get("1001");

            bool b1=manager.Remove("1001");

            string s2 = manager.Get("1001");
        }
    }
}
