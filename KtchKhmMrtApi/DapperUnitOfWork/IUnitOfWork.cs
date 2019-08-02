using KtchKhmMrtApi.Repositories;
using System;

namespace KtchKhmMrtApi.DapperUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IProductDisplayRepository ProductDisplayRepository { get; }

        void Commit();
    }
}
