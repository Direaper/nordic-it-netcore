﻿using System;
using System.Collections.Generic;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = LogWriterFactory.GetInstance();

            var consoleLogWriter = factory.GetLogWriter<ConsoleLogWriter>(parameters: null);
            var fileLogWriter = factory.GetLogWriter<FileLogWriter>(parameters: @"C:\Users\jimac\Desktop\log.txt");
            var multiLogWriter = factory.GetLogWriter<FileLogWriter>(parameters: new[] { consoleLogWriter, fileLogWriter });

            multiLogWriter.LogError(message: "Error!");


            //var clw = new ConsoleLogWriter();
            ////clw.LogInfo("Test Information message");

            //var flw = new FileLogWriter(@"C:\Users\jimac\Desktop\log.txt");
            ////flw.LogInfo("Test information message");

            //var mlw = new MultipleLogWriter(new List<ILogWriter> { clw, flw });
            //clw.LogInfo("Test info mess");
            //flw.LogInfo("Test info mess");
            //mlw.LogInfo("testsdasd");
            //mlw.Dispose();
            //flw.Dispose();
        }
    }
}
