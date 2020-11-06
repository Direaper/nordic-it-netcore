using System;
using System.Diagnostics;
using System.Linq;
using UserDatabaseLibrary;


namespace UserDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Console.Clear();
                    int command = 0; //команды для меню в приложении
                    Console.WriteLine("Вы в основном меню программы\n" +
                        "Введите 1 для входа в меню добавления пользователей \n" +
                        "Введите 2 для входа в меню удаления пользователей \n" +
                        "Введите 3 посмотреть список пользователей \n" +
                        "Введите 4 для того чтобы посмотреть сколько будет лет пользователям через 4 года");
                    command = Convert.ToInt32(Console.ReadLine());

                    if (command == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            string comm;

                            Console.WriteLine("Вы в меню добавления пользователей");
                            ShowBase.showing();
                            Console.WriteLine("Введите exit, чтобы вернуться в основное меню или нажмите enter чтобы продолжить");
                            comm = Console.ReadLine();
                            if (comm == "exit") { break; }
                            try
                            {
                                Console.WriteLine("Введите имя пользователя");
                                string name = Console.ReadLine();
                                if (name == "exit") { break; }


                                Console.WriteLine("Введите возраст пользователя");
                                int age = Convert.ToInt32(Console.ReadLine());

                                AddUser user = new AddUser();
                                user.adding(name, age);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Вы ввели неверное значение");
                                Console.ReadKey();
                            }

                            Console.Clear();
                            ShowBase.showing();
                        }
                    }

                    if (command == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            string comm;
                            Console.WriteLine("Вы в меню удаления пользователей");
                            ShowBase.showing();
                            Console.WriteLine("Введите exit, чтобы вернутся в основное меню или нажмите enter чтобы продолжить");
                            comm = Console.ReadLine();
                            if (comm == "exit") { break; }
                            try
                            {
                                Console.WriteLine("Введите id пользователя, которого хотите удалить (введите 0 чтобы выйти из меню)");
                                int id = Convert.ToInt32(Console.ReadLine());
                                if (id == 0) { break; }

                                RemoveUser user = new RemoveUser();
                                user.removing(id);

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Вы ввели неверное значение");
                                Console.ReadKey();
                            }
                            Console.Clear();
                        }
                    }

                    if (command == 3)
                    {
                        Console.Clear();
                        ShowBase.showing();
                        Console.ReadKey();
                    }

                    if (command == 4)
                    {
                        Console.Clear();

                        var users = db.Users.ToList();
                        Console.WriteLine("Текущий список пользователей:");
                        foreach (User u in users)
                        {
                            Console.WriteLine($"ID:{u.Id}; Имя: {u.Name}; Текущий Возраст: {u.Age}; Возраст через 4 года: {u.Age + 4}; ");
                        }
                        
                        Console.ReadKey();
                    }

                }
            }
        }
    }
}