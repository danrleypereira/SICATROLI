using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using backend.Models;
using backend.Services;
using System.Text.Json.Serialization;
using CleanArchMvc.Application.Mappings;

namespace dal
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
            // Add framework services.
            services.AddControllers().AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
              });

            // Add PostgreSQL database context
            services.AddDbContext<MyDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("MyDbConnection")));

            // Add application services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IGuardianService, GuardianService>();
            services.AddAutoMapper(typeof(EntityToDTOMapping));

            // Add Swagger generator and UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sicatroli API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sicatroli API V1");
                });
            }

            app.UseRouting();
            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
