using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    [Table("manager")]
    public partial class Manager
    {
        [Key]
        [Column("manager_id")]
        public int ManagerId { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Column("manager_user_name")]
        [StringLength(255)]
        public string ManagerUserName { get; set; }
        [Column("manager_user_role")]
        [StringLength(255)]
        public string ManagerUserRole { get; set; }
    }
}
