using System;
using System.Runtime.InteropServices;


namespace LIB_NetStdClassLibrary
{
    public class Class1
    {
        public static string TestMethod() { return "NetStandardDLL_Test"; }
    }
    public class NativeMethods
    {
        [DllImport("LIB_CppClassLibrary", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethod();

        [DllImport("LIB_CppUwpDLL", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethodUwp();

        public static string InvokeCppDLL()
        {
            int num = TestMethod();
            return num.ToString();
        }

        public static string InvokeCppUwpDLL()
        {
            int num = TestMethodUwp();
            return num.ToString();
        }

    }
}
