using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vk.Mod
{
    [Table("User")]
    public class UserRto
    {
        public int Id { get; set; }
        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Password { get; set; }

        [Required] public string NumberPhone { get; set; }

        [Required] public string NumberPhonePrefix { get; set; }

        public List<Community> Community { get; set; }

        
    }
}
