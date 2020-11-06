using System;
using System.Linq;
using System.Reflection.Metadata;

namespace UserDatabaseLibrary
{
    public class RemoveUser
    {
        public void removing(int id)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Find(id);
             
                if (id != 0)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }

    }
}
