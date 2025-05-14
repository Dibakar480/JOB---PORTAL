using Microsoft.EntityFrameworkCore;

namespace JOB___PORTAL.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext>options):base(options) 
        {
            
        }
        public DbSet<Provider> tblProvider { get; set; }
        public DbSet<Seeker> tblSeeker { get; set; }
        public DbSet<Jobs> tblJobs { get; set; }
        public DbSet<Apply> tblApply { get; set; }
    }
}
