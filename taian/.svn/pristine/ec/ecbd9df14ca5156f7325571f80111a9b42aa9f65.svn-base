using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Data
{
    public interface IUnitOfWork : IDisposable
    {
        System.Data.Entity.DbContext Context { get; }

        int Commit(Action func);
    }
}
