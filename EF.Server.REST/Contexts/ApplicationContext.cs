using EF.Server.REST.Models.Objects;
using EF.Server.REST.Models.Relations;

using Microsoft.EntityFrameworkCore;

namespace EF.Server.REST.Contexts
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ApplicationContext"/> class
	/// </summary>
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> opitons)
			: base(opitons)
		{
			// ...
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RStudentSubject>()
				.HasKey(t => new { t.StudentId, t.SubjectId });

			modelBuilder.Entity<RStudentSubject>()
				.HasOne(pt => pt.Student)
				.WithMany(p => p.RStudentsSubjects)
				.HasForeignKey(pt => pt.StudentId);

			modelBuilder.Entity<RStudentSubject>()
				.HasOne(pt => pt.Subject)
				.WithMany(t => t.RStudentsSubjects)
				.HasForeignKey(pt => pt.SubjectId);
		}

		#region Entities

		public DbSet<OStudent> Students { get; set; }

		public DbSet<OGrade> Grades { get; set; }

		public DbSet<OSubject> Subjects { get; set; }
		
		#endregion
	}
}
