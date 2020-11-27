using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogApp
{
    class FileLogWriter : AbstractLogWriter
    {
        private StreamWriter _streamWriter;

        private static FileLogWriter instance;
        private FileLogWriter()
        {

        }

        private FileLogWriter(string fileName = "C:\\log.txt")
        {

            _streamWriter = new StreamWriter(
                File.Open(
                    fileName,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.Read));
            _streamWriter.BaseStream.Seek(0, SeekOrigin.End);
        }

        public override void Dispose()
        {
            if (_streamWriter != null)
                _streamWriter.Dispose();
        }

        public static FileLogWriter GetInstance(string patch) //Метод принимает 1 аргумента от пользователя и возвращает через созданный единственный экземпляр класса
        {                                                    //Пользователь не создает экземпляр, но может выбрать куда сохранить файл)
            if (instance == null)
                instance = new FileLogWriter(patch);
            return instance;
        }


        public override void LogSingleRecord(LogMessageType logMessageType, string message)
        {

            {
                _streamWriter.WriteLine(GetFormatedMessage(logMessageType, message));
            }
        }

    }
}
