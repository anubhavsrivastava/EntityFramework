using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Assignment.EF.CF.Model
{
    public class Permission
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
