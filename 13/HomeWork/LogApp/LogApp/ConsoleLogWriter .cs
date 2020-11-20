using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        public override void Dispose()
        {

        }
        public override void LogSingleRecord(LogMessageType logMessageType, string message)
        {
            Console.WriteLine(GetFormatedMessage(logMessageType, message));
        }

    }
}
