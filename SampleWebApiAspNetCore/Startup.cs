using AutoMapper;
using LangUp.Repositories;
using LangUp.Repositories.Interfaces;
using LangUp.Services;
using LangUp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.MappingProfiles;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;
using SampleWebApiAspNetCore.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SampleWebApiAspNetCore
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
            services.AddOptions();
           // services.AddDbContext<FoodDbContext>(opt => opt.UseInMemoryDatabase("FoodDatabase"));
            //services.AddCustomCors("AllowAllOrigins");

            services.AddSingleton<ISeedDataService, SeedDataService>();
            services.AddScoped<IFoodRepository, FoodSqlRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICourseOfUserRepository, CourseOfUserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IUsersInfoRepository, UsersInfoRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IWordDetailRepository, WordDetailRepository>();
            services.AddScoped<IWordRepository, WordRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseOfUserService, CourseOfUserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWordDetailService, WordDetailService>();
            services.AddScoped<IWordService, WordService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            
            services.AddControllers()
                   .AddNewtonsoftJson(options =>
                       options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddVersioning();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(FoodMappings));

            services.AddDbContext<LangUpDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LangUpContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            ILoggerFactory loggerFactory, 
            IWebHostEnvironment env, 
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.AddProductionExceptionHandling(loggerFactory);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
