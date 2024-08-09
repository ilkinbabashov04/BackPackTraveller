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
    public class FaqManager : IFaqService
    {
        IFaqDal _faqDal;
        public FaqManager(IFaqDal faqDal )
        {
            _faqDal = faqDal;
        }
        public IResult Add(Faq faq)
        {
            _faqDal.Add(faq);
            return new SuccesResult();
        }

        public IResult Delete(int id)
        {
            var deletedFaq = _faqDal.Get(p => p.Id == id && p.IsDelete == false);
            if (deletedFaq != null)
            {
                deletedFaq.IsDelete = true;
                _faqDal.Delete(deletedFaq);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<Faq> Get(int id)
        {
            var getFaq = _faqDal.Get(p => p.Id == id && p.IsDelete == false);
            if (getFaq != null)
            {
                return new SuccesDataResult<Faq>(getFaq);
            }
            else
            {
                return new ErrorDataResult<Faq>();
            }
        }

        public IDataResult<List<Faq>> GetAll()
        {
            var getAllFaq = _faqDal.GetAll(p => p.IsDelete == false);
            if (getAllFaq != null)
            {
                return new SuccesDataResult<List<Faq>>(getAllFaq);
            }
            else
            {
                return new ErrorDataResult<List<Faq>>();
            }
        }

        public IResult Update(Faq faq)
        {
            var updatedFaq = _faqDal.Get(p => p.Id == faq.Id && p.IsDelete == false);
            if (updatedFaq != null)
            {
                updatedFaq.Title = faq.Title;
                updatedFaq.Description = faq.Description;
                updatedFaq.ImageLink = faq.ImageLink;
                _faqDal.Update(updatedFaq);
                return new SuccesResult("Faq updated successfully!");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
