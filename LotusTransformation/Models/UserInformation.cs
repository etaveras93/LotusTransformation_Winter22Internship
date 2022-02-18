using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LotusTransformation.Models
{
    [Table("UserInformation")]
    public class UserInformation
    {
        /// <summary>
        /// User Key is auto generated based upon the information provided by the user from the sign-up form. Each key needs to be unique. The key is checked against the database.
        /// If it is duplicated, it will be shifted over to the next available value. In a sense, this is the user's "Account number" and is used as the primary key in the 
        /// database
        /// </summary>
        [Required]
        [Key]
        public long UserID { get; set; }
        
        public string FirstName { get; set; }

        public char MiddleInitial { get; set; } // Optional

        public string LastName { get; set; }
        
        public string Address1 { get; set; }

        public string Address2 { get; set; } // Optional

        public string City { get; set; }

        public string StateOrProvince { get; set; }
        
        public string ZIPorPostal{ get; set; }

        public string Country { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }

        public string PrimaryEmail { get; set; }
     
        public string PrimaryPhoneNumber { get; set; }

        public string PrimaryPhoneType { get; set; }

        public string SecondaryEmail { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string SecondaryPhoneNumber { get; set; }

        public string SecondaryPhoneType { get; set; }

        public virtual LogIn LogIn { get; set; }

    }
}
