

using JobBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Elshad_Portfolıo.Database
{
	public class Portfolio_Context:IdentityDbContext
	{
		public Portfolio_Context(DbContextOptions<Portfolio_Context> options):base(options) { }
		public DbSet<Image> Images { get; set; }
		public DbSet<Cv> Cvs { get; set; }
		public DbSet<Setting> settings { get; set; }
		public DbSet<SoftSkills> softSkills { get; set; }
		public DbSet<SkillType> skillTypes { get; set; }
		public DbSet<HardSkills> hardSkills { get; set; }
		public DbSet<Project> projects { get; set; }
		public DbSet<About> abouts { get; set; }
		public DbSet<AboutImage> AboutImages { get; set; }
		public DbSet<Experience> experiences { get; set; }

		public DbSet<AppUser> users { get; set; }

	}

}
