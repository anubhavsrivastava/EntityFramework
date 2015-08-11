using System.Data.Entity;
using Tavisca.Assignment.EF.CF.DataLayer;
using Tavisca.Assignment.EF.CF.Model;

namespace Tavisca.Asssignment.EF.CF.DataLayer
{
    public class UserDbContext : DbContext
    {
        // Your context has been configured to use a 'UserDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Tavisca.Asssignment.EF.CF.DataLayer.UserDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UserDbContext' 
        // connection string in the application configuration file.
        public UserDbContext()
            : base("name=UserDbContext")
        {
            Database.SetInitializer(new DefaultDatabaseInitializer());
        }

        public UserDbContext(IDatabaseInitializer<UserDbContext> strategy)
            : base("name=UserDbContext")
        {
            Database.SetInitializer(strategy);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
  
    }

    
}