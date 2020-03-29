using ComputerStore.Api.Repositories;
using ComputerStore.Api.Services;
using ComputerStore.Data;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ComputerStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       ;
                });
            });
            //dependencies
            services.AddScoped<DataContext>();
            services.AddScoped<MakerRepository>();
            services.AddScoped<PcPartRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<PcBuildRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<BearerHistoryRepository>();
            services.AddScoped<MessageRepository>();

            // parts dependencies 
            services.AddScoped<PartRepository<Gpu>>();
            services.AddScoped<PartRepository<Cpu>>();
            services.AddScoped<PartRepository<MotherBoard>>();
            services.AddScoped<PartRepository<PcCase>>();
            services.AddScoped<PartRepository<Memory>>();



            // authentication service jwt bearer token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "computerstore.be",
                    ValidAudience = "computerstore.be",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lkjqsdflkjsdfkljqsdfkljqsdlkfjslqdkfjlskdfjlskqdjfhlk"))
                };
            });
            // add role names for accessing the endpoints
            services.AddAuthorization(options =>
            {
                options.AddPolicy("MemberRole", policy => policy.RequireRole("Member"));
                options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ManagerRole", policy => policy.RequireRole("Manager"));
            });

            //add loophandling for relations between entities
            services.AddMvc().AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            //datacontext config
            services.AddDbContext<DataContext>(opt => opt.
                UseSqlServer(Configuration.GetConnectionString("ApiDatabaseConnectionString")).EnableSensitiveDataLogging(true));

            //mapper configuration
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHsts();

            // add cors before the mvc in the pipeline
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();


            app.UseMvc();

        }
    }
}
