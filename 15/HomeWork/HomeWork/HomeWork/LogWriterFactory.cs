using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class LogWriterFactory
    {
        private static LogWriterFactory instance;

        private LogWriterFactory()
        {

        }


 

          public static ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
        {
            if (instance == null)
                 instance = new LogWriterFactory();

            ConsoleLogWriter ConsoleLog = new ConsoleLogWriter();
            FileLogWriter FileLog = new FileLogWriter((string)parameters);
            MultipleLogWriter MultipleLog = new MultipleLogWriter(new List<ILogWriter> { ConsoleLog, FileLog });

            return MultipleLog;

 
         }

    }
}

