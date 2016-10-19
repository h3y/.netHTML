using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProxySwitchHTML.Model;
using proxyswich;

namespace ProxySwitchHTML
{
    class Global
    {
        public static List<Thread> ThreadPool = new List<Thread>();
        public static int CountThread = 40;
        public static bool IsWork = false;
        public static List<data> LoadProxy = new List<data>();
    }
}
