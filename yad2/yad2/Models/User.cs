using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yad2.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required]
        [StringLength(50)]
        [Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}