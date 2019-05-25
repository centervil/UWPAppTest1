using System;
using System.Runtime.InteropServices;


namespace LIB_NetStdClassLibrary
{
    public class NetStdClass
    {
        public static string TestMethod() { return "NetStandardDLL is Called"; }
    }
    public class NativeMethods
    {
        [DllImport("LIB_CppClassLibrary", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethodCpp();

        [DllImport("LIB_CppUwpDLL", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethodCppUwp();

        public static string InvokeCppDLL()
        {
            try
            {
                TestMethodCpp();
                return "CppClassLibrary is Called";
            }
            catch
            {
                return "CppClassLibrary is Not Called";
            }
        }

        public static string InvokeCppUwpDLL()
        {
            try
            {
                TestMethodCppUwp();
                return "CppUwpDLL is Called";
            }
            catch
            {
                return "CppUwpDLL is Not Called";
            }
        }

        public static string InvokeCsDLL()
        {
            try
            {
                return LIB_CsClassLibrary.CsDllClass.TestMethod();
            }
            catch
            {
                return "CsClassLibrary is Not Called";
            }
        }
    }
}
