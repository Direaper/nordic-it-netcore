using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp
{
    class MultipleLogWriter : AbstractLogWriter
    {
        IList<ILogWriter> _logWriters;

        private static MultipleLogWriter instance;

        private MultipleLogWriter()
        {

        }
        private MultipleLogWriter(IList<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public static MultipleLogWriter GetInstance(ConsoleLogWriter consolelogverb, FileLogWriter fileLogverb)   //Метод принимает два аргумента от пользователя и возвращает через созданный единственный экземпляр класса
        {                                                                                                         //таким образом, пользователь может передавать значения, но не создавать экземпляр. Он имеет условно, ссылку на метод
            if (instance == null)
                instance = new MultipleLogWriter(new List<ILogWriter> { consolelogverb, fileLogverb });
            return instance;

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
