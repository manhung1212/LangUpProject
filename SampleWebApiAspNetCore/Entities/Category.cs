using LangUp.Entities;
using System;
using System.Collections.Generic;

namespace SampleWebApiAspNetCore.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
