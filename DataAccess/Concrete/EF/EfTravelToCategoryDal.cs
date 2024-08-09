using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfTravelToCategoryDal : BaseReporsitory<TravelToCategory, BaseProjectContext>, ITravelToCategoryDal
    {
        public List<TravelToCategoryDto> GetAllTravelsByCategoryId(int categoryId)
        {
            var context = new BaseProjectContext();
            var result = from tc in context.TravelToCategories
                         where tc.CategoryId == categoryId && tc.IsDelete == false
                         join t in context.Travels
                         on tc.TravelId equals t.Id
                         join c in context.Categories
                         on tc.CategoryId equals c.Id
                         select new TravelToCategoryDto
                         {
                             CategoryId = tc.CategoryId,
                             CategoryName = c.CategoryName,
                             TravelId = tc.TravelId,
                             TravelTitle = t.Title,
                             TravelDescription = t.Description,
                         };
                         return result.ToList();
        }
    }
}
