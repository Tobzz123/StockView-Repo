using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    //[Table("generic_user")]
    public class GenericUser : IdentityUser
    {
        public GenericUser()
        {
            Watchlist = new HashSet<Watchlist>();
        }

        //[Column("first_name")]
        //[StringLength(255)]
        [PersonalData]
        public string FirstName { get; set; }
        /* [Column("last_name")]
         [StringLength(255)]*/

        [PersonalData]
        public string LastName { get; set; }
        /*   [Column("generic_user_name")]
           [StringLength(255)]*/

        [PersonalData]
        public string DateOfBirth { get; set; }
        [PersonalData]
        public string PostalCode { get; set; }
        [PersonalData]
        public string Address { get; set; }
        [PersonalData]
        public string Country { get; set; }
        [PersonalData]
        public string AboutMe { get; set; }

        /* [Key]
         [Column("generic_user_id")]

         public override string Id { get; set; }*/
        /* [Column("email")]
         [StringLength(255)]

         public override string Email { get; set; }
         [Column("password_hash")]

         [StringLength(255)]
         public override string PasswordHash { get; set; }*/

        /*   public string GenericUserName { get; set; }
           [Column("generic_user_role")]
           [StringLength(255)]
           public string GenericUserRole { get; set; }*/



        [InverseProperty("GenericUser")]
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}
