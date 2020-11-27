using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        private static ConsoleLogWriter instance;
        public override void Dispose()
        {

        }

        private ConsoleLogWriter()
        {

        }

        public static ConsoleLogWriter GetIstance()
        {
            if (instance == null)
                instance = new ConsoleLogWriter();
            return instance;

        }

        public override void LogSingleRecord(LogMessageType logMessageType, string message)
        {
            Console.WriteLine(GetFormatedMessage(logMessageType, message));
        }

    }
}
