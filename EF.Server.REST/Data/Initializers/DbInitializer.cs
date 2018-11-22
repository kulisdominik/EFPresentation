using System;
using System.Collections.Generic;
using System.Linq;
using EF.Server.REST.Contexts;
using EF.Server.REST.Models.Basic;
using EF.Server.REST.Models.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Server.REST.Data.Initializers
{
	public class DbInitializer : IDbInitializer
	{
		private readonly IServiceProvider _serviceProvider;

		public DbInitializer(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void Initialize(IConfiguration configuration)
		{
			IServiceScope serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
			ApplicationContext context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

			// Clear db -> https://stackoverflow.com/questions/41616160/dropcreatedatabasealways-in-entityframework-core?noredirect=1&lq=1
			//context.Database.EnsureDeleted();
			//context.Database.EnsureCreated();
			//context.Database.Migrate();

			context.Students.AddRange(
				new OStudent("95040807133", "Dominik Kulis"),
				new OStudent("95040807134", "Kasia"));

			context.SaveChanges();
		}
	}
}
