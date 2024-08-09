using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Helper.Results.Abstract;
using Core.Helper.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TravelManager : ITravelService
    {
        ITravelDal _travelDal;
        public TravelManager(ITravelDal travelDal)
        {
            _travelDal = travelDal;
        }

        [ValidationAspect<Travel>(typeof(TravelValidator))]
        public IResult Add(Travel travel)
        {
            _travelDal.Add(travel);
            return new SuccesResult();
        }

        public IResult Delete(int id)
        {
            var deletedTravel = _travelDal.Get(p => p.Id == id && p.IsDelete == false);
            if (deletedTravel != null)
            {
                deletedTravel.IsDelete = true;
                _travelDal.Delete(deletedTravel);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<Travel> Get(int id)
        {
            var getTravel = _travelDal.Get(p => p.Id == id && p.IsDelete == false);
            if(getTravel != null)
            {
                return new SuccesDataResult<Travel>(getTravel);
            }
            else
            {
                return new ErrorDataResult<Travel>();
            }

        }

        public IDataResult<List<Travel>> GetAll()
        {
            var getAllTravel = _travelDal.GetAll(p => p.IsDelete == false);
            if(getAllTravel != null)
            {
                return new SuccesDataResult<List<Travel>>(getAllTravel);
            }
            else
            {
                return new ErrorDataResult<List<Travel>>();
            }
        }

        public IResult Update(Travel travel)
        {
            var updatedTravel = _travelDal.Get(p => p.Id == travel.Id && p.IsDelete == false);
            if (updatedTravel != null)
            {
                updatedTravel.Title = travel.Title;
                updatedTravel.Description = travel.Description;
                updatedTravel.ImageLink = travel.ImageLink;
                _travelDal.Update(updatedTravel);
                return new SuccesResult("Travel updated successfully!");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
