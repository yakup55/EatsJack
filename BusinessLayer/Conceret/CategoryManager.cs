using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conceret
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            categoryDal.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            categoryDal.Delete(category);
        }

        public Category GetCategoryByid(int id)
        {
            return categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return categoryDal.List();
        }

        public void UpdateCategory(Category category)
        {
            categoryDal.Update(category);
        }
    }
}
