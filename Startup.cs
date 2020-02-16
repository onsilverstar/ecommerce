using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Commercial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Stripe;

namespace Commercial
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
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MyContext>()
                .AddDefaultTokenProviders();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddScoped<HttpContextAccessor>();
            services.AddSingleton<HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddSession();            
            services.AddMvc();
            services.AddAuthentication();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSession();
            app.UseStaticFiles();
            //InitializeRoles(app.ApplicationServices).Wait();
            app.UseAuthentication();
            app.UseMvc();
            
        }
        /* private async Task InitializeRoles(IServiceProvider serviceProvider)
            {
            // Array of Roles to create
            string[] RolesToCreate = new string[] {"Level1", "Level2", "Level3"};
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach( string role in RolesToCreate )
            {
            // If a Role doesn't already exist, create it
                if( !await roleManager.RoleExistsAsync(role) )
                {
                    await roleManager.CreateAsync( new IdentityRole(role) );
                }
            }
        }*/
    }
}
