using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using MyFrameWork.Common;
using System.Data.Common;

namespace MyFrameWork.Data
{
    public class DbContextFactory<TContext> : IDbContextFactory<TContext>, IDisposable
        where TContext : DbContext, new()
    {
        #region 属性、字段
        private TContext _context;
        public DbContext Context
        {
            get { return GetDbContext(); }
        }
        #endregion

        #region 构造
        public DbContextFactory()
        {
            _context = Activator.CreateInstance<TContext>();
            _context.Configuration.ValidateOnSaveEnabled = false;
            _context.Configuration.LazyLoadingEnabled = true;
        }
        #endregion

        #region 方法

        public TContext GetDbContext()
        {
            return _context == null ? Activator.CreateInstance<TContext>() : _context;
        }

        public int Commit(Action func)
        {
            int result = 0;
            var trans = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                func();
                trans.Commit();
                result = 1;
            }
            catch (DbUpdateException e)
            {
                trans.Rollback();
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    var sqlEx = e.InnerException.InnerException as SqlException;
                    string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + (string.IsNullOrEmpty(msg) ? e.GetBaseException().Message : msg), sqlEx);
                }
                else
                {
                    throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + e.Message, e);
                }
            }
            finally
            {
                if (_context.Database.Connection.State == System.Data.ConnectionState.Open)
                    _context.Database.Connection.Close();
                trans.Dispose();
            }
            return result;
        }
        
        #endregion

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
