using Business.Abstract;
using Core.Helper.Results.Abstract;
using Core.Helper.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccesResult();
        }

        public IResult Delete(int id)
        {
            var deletedCategory = _categoryDal.Get(p => p.Id == id && p.IsDelete == false);
            if (deletedCategory != null)
            {
                deletedCategory.IsDelete = true;
                _categoryDal.Delete(deletedCategory);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<Category> Get(int id)
        {
            var getCategory = _categoryDal.Get(p => p.Id == id && p.IsDelete == false);
            if (getCategory != null)
            {
                return new SuccesDataResult<Category>(getCategory);
            }
            else
            {
                return new ErrorDataResult<Category>();
            }
        }

        public IDataResult<List<Category>> GetAll()
        {
            var getAllCategory = _categoryDal.GetAll(p => p.IsDelete == false);
            if (getAllCategory != null)
            {
                return new SuccesDataResult<List<Category>>(getAllCategory);
            }
            else
            {
                return new ErrorDataResult<List<Category>>();
            }
        }

        public IResult Update(Category category)
        {
            var updatedCategory = _categoryDal.Get(p => p.Id == category.Id && p.IsDelete == false);
            if (updatedCategory != null)
            {
                updatedCategory.CategoryName = category.CategoryName;
                updatedCategory.IconUrl = category.IconUrl;
                updatedCategory.ImageUrl = category.ImageUrl;
                _categoryDal.Update(updatedCategory);
                return new SuccesResult("Category updated successfully!");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
