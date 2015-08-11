using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Assignment.EF.CF.Model;
using Tavisca.Asssignment.EF.CF.DataLayer;

namespace Tavisca.Assignment.EF.CF.TestSuite
{
    public class TestDatabaseInitializer : DropCreateDatabaseAlways<UserDbContext>
    {
        protected override void Seed(UserDbContext context)
        {
            base.Seed(context);
            InitialiseUserTypes(context);
            InitialiseUsers(context);
            InitialisePermissions(context);
            
        }

        private void InitialisePermissions(UserDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                db.Permissions.Add(new Permission()
                {
                    Type = "Type" + i,
                    Id = i
                    

                });
            }
            db.SaveChanges();
        }

        private void InitialiseUserTypes(UserDbContext db)
        {
            for (var i = 0; i < 5; i++)
            {
                 db.UserTypes.Add(new UserType()
                {
                    Name = "User"+i,
                    Id = i
                });
            }
            db.SaveChanges();
        }

        private void InitialiseUsers(UserDbContext db)
        { 
            var availableUsertypes = db.UserTypes.ToList();
            for (var i = 1; i < 51; i++)
            {
                var userType = availableUsertypes[i % availableUsertypes.Count];
                userType.Users.Add(new User()
                {
                    FirstName = "FName"+i,
                    LastName = "LName" + i,
                });
            }
            db.SaveChanges();
        }

     
    }
}
