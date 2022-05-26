using System;

namespace LangUp.ViewModels.CategoriesViewModel
{
    public class EditCategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
    }
}
