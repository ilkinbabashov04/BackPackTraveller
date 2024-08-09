using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class TravelToCategoryDto : IDto
    {
        public int TravelId { get; set; }
        public int CategoryId { get; set; }
        public string TravelTitle { get; set; }
        public string TravelDescription { get; set;}
        public string CategoryName { get; set; }
    }
}
