using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Assignment.EF.CF.Model;
using Tavisca.Asssignment.EF.CF.DataLayer;
using System.Linq;
using System.Collections.ObjectModel; 

namespace Tavisca.Assignment.EF.CF.TestSuite
{
    [TestClass]
    public class CRUDTest
    {
        private UserDbContext _dbContext { get { return new UserDbContext(new TestDatabaseInitializer()); } }

        [TestMethod]
        public void Read_Users()
        {
            var dbContext = _dbContext;
            var users = GetFirstNUsers(dbContext, 10);

            if (users == null)
                Assert.Fail("Database Error: No User Found In Database");

            users.ForEach(user => Assert.IsNotNull(user.FirstName));
        }


        [TestMethod]
        public void Update_UserType()
        {

            using (var dbContext = _dbContext)
            {
                var firstUserType = dbContext.UserTypes.First();

                if (firstUserType == null)
                    Assert.Fail("Database Error: No Usertypes Found In Database");

                var users = GetFirstNUsers(dbContext,10);

                users.ForEach(user => user.UserTypeId = firstUserType.Id);
                dbContext.SaveChanges();

                var updatedUsers = GetFirstNUsers(dbContext, 10);
                updatedUsers.ForEach(user => Assert.AreEqual(user.UserTypeId, firstUserType.Id));
            }
           
        }

        [TestMethod]
        public void Insert_UserPermissions()
        {

            List<User> users = null;
            List<User> updatedUsers = null; 

            using (var dbContext = _dbContext)
            {
                var permissions = dbContext.Permissions.ToList();

                users = GetFirstNUsers(dbContext, 10);

                for (var i = 1; i <= users.Count; i++)
                {
                    var user = users[i-1];
                    user.Permissions = new Collection<Permission>();
                    user.Permissions.Add(permissions[i%permissions.Count]);
                }
                
                dbContext.SaveChanges();

                updatedUsers = dbContext.Users.Include("Permissions").OrderBy(user => user.Id).Take(10).ToList();
                updatedUsers.ForEach(user => Assert.IsNotNull(user.Permissions));

                foreach (var user in updatedUsers)
                {
                    var oldUser = users.FirstOrDefault(usr => usr.Id == user.Id);
                    if (oldUser == null)
                        Assert.Fail("Database Error: Could Not fetch Previous Users");
                    Assert.AreEqual(user.Permissions.First().Type, oldUser.Permissions.First().Type);
                }
            }
          
        }

        [TestMethod]
        public void Delete_Permissions()
        {
            using (var dbContext = _dbContext)
            {
                var users = dbContext.Users.Include("Permissions").ToList();
                users.ForEach(user => user.Permissions = null);
                dbContext.SaveChanges();

                var permisns = dbContext.Permissions.ToList();
                dbContext.Permissions.RemoveRange(permisns);
                dbContext.SaveChanges();

                var newPermissions = dbContext.Permissions.ToList();
                Assert.AreEqual(0, newPermissions.Count);
            }
        }

        private static List<User> GetFirstNUsers(UserDbContext context,int count )
        {
            return context.Users.OrderBy(user => user.Id).Take(count).ToList();
        }
    }
}
