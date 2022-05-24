using LangUp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Models;
using System;

namespace SampleWebApiAspNetCore.Repositories
{
    public class LangUpDbContext : DbContext
    {
        public LangUpDbContext()
        {
        }

        public LangUpDbContext(DbContextOptions<LangUpDbContext> options)
           : base(options)
        {

        }

        //public DbSet<FoodEntity> FoodItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseOfUser> CourseOfUsers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordDetail> WordDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LangUpContext"));
        }
    }
}
