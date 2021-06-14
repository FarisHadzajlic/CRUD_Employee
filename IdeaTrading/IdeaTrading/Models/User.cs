using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeaTrading.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; } // We should consider using BigInt for Key instead of Int

        [MaxLength(30)]
        [MinLength(2)]
        [Required(ErrorMessage = "Last Name is required"), StringLength(50)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [MinLength(2)]
        [Required(ErrorMessage = "Frist Name is required"), StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required"), StringLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required"), StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Date of employment is a required field")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEmployment { get; set; }

        [Required(ErrorMessage = "Position field is required")]
        public string Position { get; set; }
        [MaxLength(15)]
        [MinLength(3)]
        [Required(ErrorMessage = "Phone field is required")]
        public string Phone { get; set; }
    }
}