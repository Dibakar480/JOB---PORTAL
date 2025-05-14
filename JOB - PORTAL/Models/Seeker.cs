using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOB___PORTAL.Models
{
    public class Seeker
    {
        [Key]
        [Required(ErrorMessage ="Write Your Email ID")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Set a PassWord")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Write Your Full Name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Write Your Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactInfo { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string NewPassword { get; set; }
        public string SeekerProfilePic {  get; set; }
        [NotMapped]
        public IFormFile? SeekerProfilePicPath { get; set; }
        public string SeekerCVFile { get; set; }
        [NotMapped]
        public IFormFile? SeekerCVFilePath { get; set; }
        //public ICollection<JobApplication> JobApplications { get; set; }

    }
}
