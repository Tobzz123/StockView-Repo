using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    //DELETE THIS MODEL, NO ADMINS TABLE
    [Table("admins")]
    public partial class Admins
    {
        [Key]
        [Column("admin_id")]
        public int AdminId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Column("admin_user_name")]
        [StringLength(255)]
        public string AdminUserName { get; set; }
        [Column("admin_user_role")]
        [StringLength(255)]
        public string AdminUserRole { get; set; }
    }
}
