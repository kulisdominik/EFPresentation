using System;
using EF.Server.REST.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.Server.REST.Contexts
{
	/// <summary>
	/// Initializes a new instance of the <see cref="SchoolContext"/> class
	/// </summary>
	public class SchoolContext : DbContext
	{
		public SchoolContext(DbContextOptions<SchoolContext> opitons)
			: base(opitons)
		{
			// ...
		}

		#region Entities

		public DbSet<StudentModel> Students { get; set; }
		
		#endregion
	}
}
