using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }
    }
}
