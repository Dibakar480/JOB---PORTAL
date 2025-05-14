using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOB___PORTAL.Models
{
    public class Jobs
    {
        [Key]
        public int JobID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Company_Name { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string SkillsRequired { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastApplyDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostedDate { get; set; }
        //public Provider Provider { get; set; }
        
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string ProviderEmail { get; set; }

        //public ICollection<JobApplication> JobApplication { get; set; }

    }
}
