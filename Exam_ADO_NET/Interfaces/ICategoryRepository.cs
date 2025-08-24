using Exam_ADO_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.Interfaces
{
    public interface ICategoryRepository
    {
        bool AddCategory(CategoryModel categoryModel);
        bool DeleteCategory(int categoryId);
        bool UpdateCategory(CategoryModel categoryModel);
        List<CategoryModel> GetAllCategories();
        CategoryModel GetCategoryById(int id);
    }
}
