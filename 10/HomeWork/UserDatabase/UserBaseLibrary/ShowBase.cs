using System;
using System.Linq;


namespace UserDatabaseLibrary
{
   static public class ShowBase
    {
      static  public void showing()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Текущий список пользователей:");
                foreach (User u in users)
                {
                    Console.WriteLine($"ID:{u.Id} Имя: {u.Name} Возраст: {u.Age}");
                }
            }
        }
    }
}
