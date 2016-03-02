using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyFrameWork.Common;

namespace MyFrameWork.Data
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        /// <summary>
        /// 返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(int size = -1);

        /// <summary>
        /// 通过条件查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int size = -1);

        /// <summary>
        /// 通过条件查询，并且贪婪查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties, int size = -1);

        /// <summary>
        /// 通过条件查询，并且排序，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int size = -1);

        /// <summary>
        /// 排序，并且贪婪查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int size = -1);

        /// <summary>
        /// 排序，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int size = -1);

        /// <summary>
        /// 贪婪查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(string includeProperties, int size = -1);

        /// <summary>
        /// 通过条件查询，并且贪婪查询、排序，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties, int size, Expression<Func<TEntity, TEntity>> selector = null);


        /// <summary>
        /// 返回分页记录
        /// </summary>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(int index = 0, int size = 20);

        /// <summary>
        /// 通过条件查询，返回分页记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, int index = 0, int size = 20);

        /// <summary>
        /// 通过条件查询，并且贪婪查询，返回分页记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, string includeProperties, int index = 0, int size = 20);

        /// <summary>
        /// 通过条件查询，并且排序，返回分页记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int index = 0, int size = 20);

        /// <summary>
        /// 排序，并且贪婪查询，返回分页记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int index = 0, int size = 20);

        /// <summary>
        /// 排序，返回分页记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int index = 0, int size = 20);

        /// <summary>
        /// 贪婪查询，返回分页记录
        /// </summary>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(string includeProperties, int index = 0, int size = 20);

        /// <summary>
        /// 通过条件查询，并且贪婪查询、排序，返回分页记录
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties, int index = 0, int size = 20);

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified the filter expression</param>
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">Specified the search keys.</param>
        TEntity Find(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        void Create(TEntity t);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        void Delete(TEntity t);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        void Update(TEntity t);

        void Update(TEntity t, params Expression<Func<TEntity, dynamic>>[] fields);

        /// <summary>
        /// To Save all the changes 
        /// </summary>
        /// <returns></returns>
        int Save();

        /// <summary>
        /// Get the total objects count.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Get the object by execute the raw sql statements.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetWithRawSql(string query, params object[] parameters);

        string ToString();
    }
}
