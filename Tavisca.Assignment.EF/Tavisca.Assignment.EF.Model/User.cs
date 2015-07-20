using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Assignment.EF.CF.Model
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        public long? UserTypeId { get; set; }

        public UserType UserTypes { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
