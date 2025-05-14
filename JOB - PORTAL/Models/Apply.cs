using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JOB___PORTAL.Models
{
    public class Apply
    {
        [Key]
        public int ApplyID { get; set; }
        public string JobSeekerEmail { get; set; }
        public int JobID { get; set; }
        public  DateTime AppliedDate { get; set; }
        //public Jobs Jobs { get; set; }
        //public Seeker Seeker { get; set; }
    }
}
