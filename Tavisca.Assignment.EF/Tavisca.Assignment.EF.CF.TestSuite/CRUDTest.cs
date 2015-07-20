using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Assignment.EF.CF.Model;
using Tavisca.Asssignment.EF.CF.DataLayer;
using System.Linq;

namespace Tavisca.Assignment.EF.CF.TestSuite
{
    [TestClass]
    public class CRUDTest
    {
        [TestMethod]
        public void Read_Users()
        {
            var context = new UserDbContext(); 
            var users = GetFirst10Users(context);

            if (users == null)
                Assert.Fail("Database Error: No User Found In Database");

            users.ForEach(user => Assert.IsNotNull(user.FirstName));
        }


        [TestMethod]
        public void Update_UserType()
        {
        }

        [TestMethod]
        public void Insert_UserPermissions()
        {
        }

        [TestMethod]
        public void Delete_Permissions()
        {
        }


        private static List<User> GetFirst10Users(UserDbContext context)
        {
            using (var db = context)
            {
                return db.Users.OrderBy(user => user.Id).Take(10).ToList();
            }
        }
    }
}
