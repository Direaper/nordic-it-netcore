using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    abstract class AbstractLogWriter : ILogWriter
    { 
        private readonly string _logFormat = "{0:yyyy-MM-ddThh:mm:ss}+0000\t{1}\t{2}"; //поле, которое задает формат

        protected string GetFormatedMessage(LogMessageType logMessageType, string message)
        {
            return string.Format(_logFormat, DateTime.UtcNow, logMessageType, message);   //Создается реализация абстрактного метода, которая включает метот string.format, позволяющий передавать любое кол-во параметров)
        }
        public void LogError(string message)
        {
            LogSingleRecord(LogMessageType.Error, message);
        }

        public void LogInfo(string message)
        {
            LogSingleRecord(LogMessageType.Info, message);
        }

        public void LogWarning(string message)
        {
            LogSingleRecord(LogMessageType.Warning, message);
        }
        public abstract void LogSingleRecord(LogMessageType logMessageType, string message); //абстрактный метод, который только принимает одну переменную

        public abstract void Dispose();
    }
}
