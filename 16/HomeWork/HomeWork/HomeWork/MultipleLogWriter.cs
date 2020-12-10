using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class MultipleLogWriter : AbstractLogWriter
    {
        IList<ILogWriter> _logWriters;
        public MultipleLogWriter(IList<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public override void LogSingleRecord(LogMessageType logMessageType, string message)
        {
            foreach (var logWriter in _logWriters)
            {
                logWriter.LogSingleRecord(logMessageType, message);
            }
        }
        public override void Dispose()
        {
            foreach (var logWriter in _logWriters)
            {
                if (logWriter != null)
                    logWriter.Dispose();
            }
        }

    }
}
