using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class LogWriterFactory
    {
        private static LogWriterFactory _instance;

        private LogWriterFactory() { }

        public static LogWriterFactory GetInstance()
        {
            if (_instance == null)
                _instance = new LogWriterFactory();

            return _instance;
        }


        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
        {
            if (typeof(T) == typeof(ConsoleLogWriter)) { return new ConsoleLogWriter(); }
            if (typeof(T) == typeof(FileLogWriter)) { return new FileLogWriter((string)parameters); }
            if (typeof(T) == typeof(MultipleLogWriter)) { return new MultipleLogWriter(ConsoleLog, FileLog); }


             
            //     instance = new LogWriterFactory();

            //ConsoleLogWriter ConsoleLog = new ConsoleLogWriter();
            //FileLogWriter FileLog = new FileLogWriter((string)parameters);
            //MultipleLogWriter MultipleLog = new MultipleLogWriter(new List<ILogWriter> { ConsoleLog, FileLog });

        }

    }
}

