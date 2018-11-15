using Benenden.Core.DAL;
using Benenden.Core.Interface;
using Benenden.Core.Models;
using Benenden.Core.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Benenden
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // connect to the database
            services.AddDbContext<BenendenContext>(options => options.UseInMemoryDatabase("inMemory"));
            services.AddScoped<IGenericRespository<Product>, ProductRepository>();
            services.AddScoped <IGenericRespository<Member>, MemberRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BenendenContext>();
                AddTestData(context);
               
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");


            });
        }
        private void AddTestData(BenendenContext context)
        {
            var Member1 = new Member
            {
                Forename = "Frank",
                Surname = "Thomas"
            };

            var Member2 = new Member
            {
                Forename = "Thomas",
                Surname = "Franks"
            };

            var Member3 = new Member
            {
                Forename = "Christoph",
                Surname = "McMullens"
            };
            var Member4 = new Member
            {
                Forename = "Wanda",
                Surname = "Perri"
            };
            var Member5 = new Member
            {
                Forename = "Helen",
                Surname = "Sparks"
            };
            var Member6 = new Member
            {
                Forename = "Roman",
                Surname = "Brid"
            };

            var Product1 = new Product
            {
                Name = "Healthcare",
                Cost = 100.00f,
                Member = Member1
            };
            var Product2 = new Product
            {
                Name = "Travel Insurance",
                Cost = 150.00f,
                Member = Member1
            };
            var Product3 = new Product
            {
                Name = "Home Insurance",
                Cost = 125.00f,
                Member = Member2
            };
            var Product4 = new Product
            {
                Name = "Healthcare",
                Cost = 100.00f,
                Member = Member6
            };
            var Product5 = new Product
            {
                Name = "Healthcare",
                Cost = 100.00f,
                Member = Member2
            };
            var Product6 = new Product
            {
                Name = "Healthcare",
                Cost = 100.00f,
                Member = Member4
            };
            var Product7 = new Product
            {
                Name = "Travel Insurance",
                Cost = 150.00f,
                Member = Member6
            };
            var Product8 = new Product
            {
                Name = "Travel Insurance",
                Cost = 150.00f,
                Member = Member2
            };
            var Product9 = new Product
            {
                Name = "Home Insurance",
                Cost = 125.00f,
                Member = Member3
            };
            var Product10 = new Product
            {
                Name = "Home Insurance",
                Cost = 125.00f,
                Member = Member5
            };
            context.Add(Member1);
            context.Add(Member2);
            context.Add(Member3);
            context.Add(Member4);
            context.Add(Member5);
            context.Add(Member6);
            context.Add(Product1);
            context.Add(Product2);
            context.Add(Product3);
            context.Add(Product4);
            context.Add(Product5);
            context.Add(Product6);
            context.Add(Product7);
            context.Add(Product8);
            context.Add(Product9);
            context.Add(Product10);
            context.SaveChanges();
        }
    }
}
