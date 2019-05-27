using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#if WINDOWS_UWP
namespace LIB_CsUwpClassLibrary
#else
#if NET_STANDARD
namespace LIB_NetStdClassLibrary
#endif
#endif
{
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
#if NET_STANDARD
            try
            {
                return LIB_CsClassLibrary.CsDllClass.TestMethod();
            }
            catch
            {
                return "CsClassLibrary is Not Called";
            }
#endif
            return "CsClassLibrary is Not Called";
        }
    }
}
