using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KtchKhmMrtApi.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}
