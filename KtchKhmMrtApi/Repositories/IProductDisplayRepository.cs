using KtchKhmMrtApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KtchKhmMrtApi.Repositories
{
    public interface IProductDisplayRepository
    {
        IEnumerable<ProductDisplay> findAllProductDisplay();
        ProductDisplay findProductDisplayByCode(string code);
    }
}
