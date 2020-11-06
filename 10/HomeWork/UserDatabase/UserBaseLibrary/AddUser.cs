namespace UserDatabaseLibrary
{
   public class AddUser : User
    {
        public void adding(string Name, int Age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                this.Name = Name;
                this.Age = Age;

                if ((Name != null) || (Age != 0))
                {
                    User user = new User { Name = Name, Age = Age };
                    db.Add(user);
                    db.SaveChanges();
                }
            }
        }
    }
}