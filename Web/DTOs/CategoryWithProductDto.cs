using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTOs
{
    public class CategoryWithProductDto
    {
        public IEnumerable<ProductDto> products { get; set; }
    }
}
