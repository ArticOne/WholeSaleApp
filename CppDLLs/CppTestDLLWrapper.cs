using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CppDLLs
{
    public class CppTestDLLWrapper
    {
        [DllImport("DLLs/Dll1.dll")]
        public static extern void fibonacci_init();
        [DllImport("DLLs/Dll1.dll")]
        public static extern bool fibonacci_next();
        [DllImport("DLLs/Dll1.dll")]
        public static extern long fibonacci_current();
    }
}
