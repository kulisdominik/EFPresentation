using System;
using System.Linq;
using EF.Server.REST.Contexts;
using EF.Server.REST.Models;
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
			SchoolContext context = serviceScope.ServiceProvider.GetService<SchoolContext>();

			context.Students.AddRange(
				new StudentModel(Guid.NewGuid(), "95040807133", "Dominik Kulis"),
				new StudentModel(Guid.NewGuid(), "95040807134", "Kasia"));

			context.SaveChanges();
		}
	}
}
