﻿using System;
using System.Runtime.InteropServices;


namespace LIB_NetStdClassLibrary
{
    public class NetStdClass
    {
        public static string TestMethod() { return "NetStandardDLL_Test"; }
    }
    public class NativeMethods
    {
        [DllImport("LIB_CppClassLibrary", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethodCpp();

        [DllImport("LIB_CppUwpDLL", EntryPoint = "TestMethod")]
        internal static extern Int32 TestMethodCppUwp();

        public static string InvokeCppDLL()
        {
            int num = TestMethodCpp();
            return num.ToString();
        }

        public static string InvokeCppUwpDLL()
        {
            int num = TestMethodCppUwp();
            return num.ToString();
        }

        public static string InvokeCsDLL()
        {
            return LIB_CsClassLibrary.CsDllClass.TestMethod();
        }
    }
}
