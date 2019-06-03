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
        [DllImport("LIB_CppClassLibraryWin32", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethodCpp();

        [DllImport("LIB_CppUwpDLLWin32", EntryPoint = "TestMethod")]
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
#elif WINDOWS_UWP
            return "CsClassLibrary is Not Called";
#endif
        }

        public static string InvokeWinmdDLL()
        {
#if WINDOWS_UWP
            try
            {
                return LIB_RuntimeComponent.CsWinmdClass.TestMethod();
            }
            catch
            {
                return "CsWinmdLibrary is Not Called";
            }
#elif NET_STANDARD
            return "CsWinmdLibrary is Not Called";
#endif
        }
        public static string InvokeCppCxDLL()
        {
#if WINDOWS_UWP
            try
            {
                //LIB_RuntimeComponent_C___.CppCxClass cx  = new LIB_RuntimeComponent_C___.CppCxClass();
                LIB_RuntimeComponent_C___.CppCxClass.TestMethod();
                return "CsCppCxDLL is Called";
            }
            catch
            {
                return "CsCppCxDLL is Not Called";
            }
#elif NET_STANDARD
            return "CsCppCxDLL is Not Called";
#endif
        }
    }
}
