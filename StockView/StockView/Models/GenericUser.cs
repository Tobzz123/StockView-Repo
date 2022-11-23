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
           // Watchlist = new HashSet<Watchlist>();
        }

     
        [PersonalData]
        public string FirstName { get; set; }  

        [PersonalData]
        public string LastName { get; set; }

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

 



      /*  [InverseProperty("GenericUser")]
        public virtual ICollection<Watchlist> Watchlist { get; set; }*/
    }
}
