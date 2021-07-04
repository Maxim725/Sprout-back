using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sprout.DB;
using Sprout.DB.Init;
using Sprout.Services;
using Sprout.Services.Interfaces;

namespace Sprout
{
	public class Startup
	{
		IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();

			//services.AddSwaggerGen(c =>
			//{
			//	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sprout", Version = "v1" });
			//});

			services.AddDbContext<SproutContext>(options => options
				.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IUserReposritory, UserRepository>();
			services.AddScoped<IProductService, ProductServices>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<JwtService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				//app.UseSwagger();
				//app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sprout v1"));
			}

			app.UseStaticFiles();
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(opt => opt
			   .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8080", "http://localhost:4200" })
			   .AllowAnyHeader()
			   .AllowAnyMethod()
			   .AllowCredentials()
		   );

			app.UseAuthorization();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				   name: "areas",
				   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}" // http://localhost:5000/admin/home/index
			   );

				endpoints.MapControllerRoute(
					name: "api",
					pattern: "api/{controller=Home}/{action=Index}/{id?}"
				);

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
				);

				endpoints.MapControllers();

			});
		}
	}
}
