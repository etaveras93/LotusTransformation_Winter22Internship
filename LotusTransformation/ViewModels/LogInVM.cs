using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusTransformation.ViewModels
{
    public class LogInVM
    {

        [Required]
        [ForeignKey("UserID")]
        [Key()]
        public long UserID { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
