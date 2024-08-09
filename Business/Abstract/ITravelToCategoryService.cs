using Core.Helper.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITravelToCategoryService : IBaseService<TravelToCategory>
    {
        IDataResult<List<TravelToCategoryDto>> GetAllTravelByCategoryId(int categoryId);
    }
}
