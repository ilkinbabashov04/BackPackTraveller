using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TravelToCategory : BaseEntity
    {
        public int TravelId { get; set; }
        public int CategoryId { get; set; }
    }
}
