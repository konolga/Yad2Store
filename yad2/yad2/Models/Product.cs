using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace yad2.Models
{
    public class Product
    {
        [Required]
        
        public int Id { get; set; }

       

        //  [ForeignKey("ID")]
        public int? OwnerId { get; set; }
        public User Owner { get; set; }

        // [ForeignKey("UserID")]
        public int? UserId { get; set; }
        public User User { get; set; }



        [Required]
        [StringLength(50)]
        public string Title { get; set; }


        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public int Price { get; set; }


        public byte[] Picture1 { get; set; }
        public byte[] Picture2 { get; set; }
        public byte[] Picture3 { get; set; }

        [Required]
        public int State { get; set; }


    }
}