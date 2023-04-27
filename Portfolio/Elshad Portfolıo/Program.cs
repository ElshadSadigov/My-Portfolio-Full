using Elshad_Portfolıo.Database;
using JobBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Elshad_Portfolıo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<Portfolio_Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Def")));
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.User.RequireUniqueEmail = false;

                //opt.SignIn.RequireConfirmedEmail= true;
            }).AddEntityFrameworkStores<Portfolio_Context>().AddDefaultTokenProviders();

            var app = builder.Build();

	

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
		
				app.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
				);
			

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}