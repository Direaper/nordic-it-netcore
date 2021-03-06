﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HomeWork
{
    class MultipleLogWriter : AbstractLogWriter
    {
       private readonly List<ILogWriter> _logWriters;
        public MultipleLogWriter(IEnumerable<ILogWriter> logWriters)
        {
            _logWriters = logWriters.ToList();
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
                    logWriter?.Dispose();
            }
        }

    }
}
