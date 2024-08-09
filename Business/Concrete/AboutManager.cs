using Business.Abstract;
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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccesResult();
        }

        public IResult Delete(int id)
        {
            var deletedAbout = _aboutDal.Get(p => p.Id == id && p.IsDelete == false);
            if (deletedAbout != null)
            {
                deletedAbout.IsDelete = true;
                _aboutDal.Delete(deletedAbout);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<About> Get(int id)
        {
            var getAbout = _aboutDal.Get(p => p.Id == id && p.IsDelete == false);
            if (getAbout != null)
            {
                return new SuccesDataResult<About>(getAbout);
            }
            else
            {
                return new ErrorDataResult<About>();
            }
        }

        public IDataResult<List<About>> GetAll()
        {
            var getAllAbout = _aboutDal.GetAll(p => p.IsDelete == false);
            if (getAllAbout != null)
            {
                return new SuccesDataResult<List<About>>(getAllAbout);
            }
            else
            {
                return new ErrorDataResult<List<About>>();
            }
        }

        public IResult Update(About about)
        {
            var updatedAbout = _aboutDal.Get(p => p.Id == about.Id && p.IsDelete == false);
            if (updatedAbout != null)
            {
                updatedAbout.Title = about.Title;
                updatedAbout.Description = about.Description;
                updatedAbout.ImageLink = about.ImageLink;
                _aboutDal.Update(updatedAbout);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
