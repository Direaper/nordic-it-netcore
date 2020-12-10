using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork
{
    public delegate int WorkPerformedHandler(int hours, FileWriterWithProgress workType);
    public delegate int WorkPerCompletedHandler(string message);
    public class FileWriterWithProgress
    {
        //public string fileName { get; set; }
        //public string filePatch { get; set; }

        //public FileWriterWithProgress(string fileName, string filePatch)
        //{
        //    this.fileName = fileName;
        //    this.filePatch = filePatch;
        //}

        public event WorkPerformedHandler WorkPerformed;
        public event WorkPerCompletedHandler WritingCompleted;
        public void WriteBytes(string fileName, string message, float percentageToFireEvent)
        {
           using( FileStream fs = new FileStream($"C:\\Users\\jimac\\Desktop\\{fileName}.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(message);
                // запись массива байтов в файл
                fs.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");

            }


            WritingCompleted?.Invoke("File completed for 100%");
        }

        //public FileLogWriter(string fileName = "C:\\log.txt")
        //{

        //    _streamWriter = new StreamWriter(
        //        File.Open(
        //            fileName,
        //            FileMode.OpenOrCreate,
        //            FileAccess.ReadWrite,
        //            FileShare.Read));
        //    _streamWriter.BaseStream.Seek(0, SeekOrigin.End);
        //}


    }
}
