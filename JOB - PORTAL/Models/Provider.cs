using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOB___PORTAL.Models
{
    public class Provider
    {
        [Key]
        [Required(ErrorMessage ="Write Your Email ID")]
        [DataType(DataType.EmailAddress)]
         public string Email { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Set a Password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Write Your Full Name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Write Your Company Name")]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage ="Write Your Phone Number/Contact Info")]
        [MaxLength (10)]
        public string ContactInfo { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string NewPassword { get; set; }
        //public ICollection<Jobs>Jobs { get; set; }
    }
}
