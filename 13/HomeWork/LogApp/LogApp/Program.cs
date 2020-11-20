using System;
using System.Collections.Generic;

namespace LogApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var clw = new ConsoleLogWriter();
            //clw.LogInfo("Test Information message");

            var flw = new FileLogWriter(@"C:\Users\jimac\Desktop\log.txt");
            //flw.LogInfo("Test information message");

            var mlw = new MultipleLogWriter(new List<ILogWriter> { clw, flw });
            clw.LogInfo("Test info mess");
            flw.LogInfo("Test info mess");
            mlw.LogInfo("testsdasd");
            mlw.Dispose();
            flw.Dispose();
        }
    }
}
