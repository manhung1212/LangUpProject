using LangUp.Entities;
using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Models;

namespace SampleWebApiAspNetCore.Repositories
{
    public class LangUpDbContext : DbContext
    {
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


    }
}
