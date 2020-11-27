using System;
using System.Collections.Generic;

namespace LogApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var clw = ConsoleLogWriter.GetIstance();                                     //Вызвали метод и передали аргумент сообщения

            var flw = FileLogWriter.GetInstance(@"C:\Users\jimac\Desktop\log.txt");      //Вызвали метод и передали аргумент сообщения(при реализации) и пути  

            var mlw = MultipleLogWriter.GetInstance(clw, flw);                          //Вызвали и перадали 3 аргумента, 1 при реалиазации                       

            clw.LogInfo("Test info mess");
            clw.LogError("Test error mess");
            flw.LogInfo("Test info mess");
            flw.LogError("Error Message test");
            mlw.Dispose();
            flw.Dispose();
        }
    }
}
