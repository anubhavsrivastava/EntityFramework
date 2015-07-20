using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Assignment.EF.CF.Model
{
    public class UserType
    {
        public UserType()
        {
            Users = new Collection<User>();
        }
        [Key]
        public long Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        public ICollection<User> Users { get; set; }
    }
}
