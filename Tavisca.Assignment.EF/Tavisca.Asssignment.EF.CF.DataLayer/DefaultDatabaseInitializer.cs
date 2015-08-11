using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Assignment.EF.CF.Model;
using Tavisca.Asssignment.EF.CF.DataLayer;

namespace Tavisca.Assignment.EF.CF.DataLayer
{
    public class DefaultDatabaseInitializer : CreateDatabaseIfNotExists<UserDbContext>
    {
        protected override void Seed(UserDbContext context)
        {
            base.Seed(context);
        }
     
    }
}
