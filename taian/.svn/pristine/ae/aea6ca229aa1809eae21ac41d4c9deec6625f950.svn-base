using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Data
{
    /// <summary>
    /// 上下文抽象工厂
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IDbContextFactory<TContext> : IUnitOfWork, IMySqlRepositoryContext
        where TContext : DbContext, new()
    {
        TContext GetDbContext();
    }
}
