using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Helper.Results.Abstract;
using Core.Helper.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TravelToCategoryManager : ITravelToCategoryService
    {
        ITravelToCategoryDal _travelToCategoryDal;
        public TravelToCategoryManager(ITravelToCategoryDal travelToCategoryDal)
        {
            _travelToCategoryDal = travelToCategoryDal;
        }
        public IResult Add(TravelToCategory travelToCategory)
        {
            _travelToCategoryDal.Add(travelToCategory);
            return new SuccesResult();
        }

        public IResult Delete(int id)
        {
            var deletedTravelTocategory = _travelToCategoryDal.Get(p => p.Id == id && p.IsDelete == false);
            if (deletedTravelTocategory != null)
            {
                deletedTravelTocategory.IsDelete = true;
                _travelToCategoryDal.Delete(deletedTravelTocategory);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<TravelToCategory> Get(int id)
        {
            var getTravelTocategory = _travelToCategoryDal.Get(p => p.Id == id && p.IsDelete == false);
            if (getTravelTocategory != null)
            {
                return new SuccesDataResult<TravelToCategory>(getTravelTocategory);
            }
            else
            {
                return new ErrorDataResult<TravelToCategory>();
            }

        }

        public IDataResult<List<TravelToCategory>> GetAll()
        {
            var getAllTravelToCategory = _travelToCategoryDal.GetAll(p => p.IsDelete == false);
            if (getAllTravelToCategory != null)
            {
                return new SuccesDataResult<List<TravelToCategory>>(getAllTravelToCategory);
            }
            else
            {
                return new ErrorDataResult<List<TravelToCategory>>();
            }
        }

        public IDataResult<List<TravelToCategoryDto>> GetAllTravelByCategoryId(int categoryId)
        {
            var result = _travelToCategoryDal.GetAllTravelsByCategoryId(categoryId);
            if (result.Count > 0)
            {
                return new SuccesDataResult<List<TravelToCategoryDto>>(result, "Siyahi getirildi");
            }
            else
            {
                return new ErrorDataResult<List<TravelToCategoryDto>>(result, "Xeta bash verdi");
            }
        }

        public IResult Update(TravelToCategory travelToCategory)
        {
            var updatedTravelToCategory = _travelToCategoryDal.Get(p => p.Id == travelToCategory.Id && p.IsDelete == false);
            if (updatedTravelToCategory != null)
            {
                updatedTravelToCategory.TravelId = travelToCategory.TravelId;
                updatedTravelToCategory.CategoryId = travelToCategory.CategoryId;
                return new SuccesResult("TravelToCategory updated successfully!");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
