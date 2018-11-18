using EF.Server.REST.Contexts;
using EF.Server.REST.Data.Initializers;
using EF.Server.REST.Repositories;
using EF.Server.REST.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Server.REST
{
	public class Startup
	{
		/// <summary>
		/// Defoult contructor
		/// </summary>
		/// <param name="configuration">Represents a set of key/value application configuration properties.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Represents a set of key/value application configuration properties.
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services">Specifies the contract for a collection of service descriptors.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddScoped<IDbInitializer, DbInitializer>();

			services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchoolDatabase")));

			services.AddScoped<IStudentRepository, StudentRepository>();
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app">Mechanisms to configure an application's request pipeline.</param>
		/// <param name="env">Provides information about the web hosting environment an application is running in.</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			dbInitializer.Initialize(Configuration);

			// Enables static file serving for the current request path
			app.UseStaticFiles();

			app.UseMvc();
		}
	}
}
