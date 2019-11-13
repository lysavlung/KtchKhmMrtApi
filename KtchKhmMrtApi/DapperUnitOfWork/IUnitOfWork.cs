using KtchKhmMrtApi.Repositories;
using KtchKhmMrtDataApi.Repositories;
using System;

namespace KtchKhmMrtApi.DapperUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IProductRepository ProductRepository { get; }
        //IProductDisplayRepository ProductDisplayRepository { get; }
        //IRepository Repository { get; }
        ProductRepository ProductRepository { get; }
        IProductDisplayRepository ProductDisplayRepository { get; }

        void Commit();
    }
}
