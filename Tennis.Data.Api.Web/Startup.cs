using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Application.Players.Queries;
using Tennis.Data.Api.Application.Players.Services;
using Tennis.Data.Api.Infrastructure.Options;
using Tennis.Data.Api.Infrastructure.Options.Installers;
using Tennis.Data.Api.Persistence.Data;

namespace Tennis.Data.Api.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.InstallServicesInAssembly(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();
                services.AddScoped<IPlayerService, PlayerService>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Tennis Data API", Version = "v1" });
            });

            services.AddMediatR(typeof(GetAllPlayersQuery).Assembly);
            services.AddMediatR(typeof(CreatePlayerCommand).Assembly);
            services.AddMediatR(typeof(DeletePlayerCommand).Assembly);
            services.AddMediatR(typeof(GetPlayerQuery).Assembly);
            services.AddMediatR(typeof(UpdatePlayerCommand).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option => option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
