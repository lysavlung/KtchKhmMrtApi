﻿using KtchKhmMrtApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KtchKhmMrtApi.Repositories
{
    public interface IProductRepository
    {
        void Add(Product entity);
        IEnumerable<Product> All();
        Product Find(Guid id);
        IEnumerable<Product> FindByProductCategoryId(Guid productCategoryId);
        void Remove(Guid id);
        void Remove(Product entity);
        void Update(Product entity);
    }
}
