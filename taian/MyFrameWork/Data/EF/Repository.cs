using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using MyFrameWork.Common;
using System.Data.Entity.Infrastructure;
using MyFrameWork.Log;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using MyFrameWork.Extensions;

namespace MyFrameWork.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region 属性、字段
        protected DbContext _context;
        protected readonly IDbSet<TEntity> _set;
        private LogHelper _logger;
        private string _resultSql = string.Empty;

        protected DbContext Context
        {
            get
            {
                return _context;
            }
        }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return _set == null ? _context.Set<TEntity>() : _set;
            }
        }
        #endregion

        #region 构造
        protected Repository(IUnitOfWork dbContextFactory)
        {
            _context = dbContextFactory.Context;
            _set = _context.Set<TEntity>();
            _logger = Ioc.ServiceLocator.Instance.Resolve<LogHelper>("SqlResult");
        }
        #endregion

        #region 获取集合
        /// <summary>
        /// 返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(int size = -1)
        {
            return Get(null, null, "", size, null);
        }

        /// <summary>
        /// 通过条件查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int size = -1)
        {
            return Get(filter, null, "", size, null);
        }

        /// <summary>
        /// 通过条件查询，并且贪婪查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties, int size = -1)
        {
            return Get(filter, null, includeProperties, size, null);
        }

        /// <summary>
        /// 通过条件查询，并且排序，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int size = -1)
        {
            return Get(filter, orderBy, "", size, null);
        }

        /// <summary>
        /// 排序，并且贪婪查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int size = -1)
        {
            return Get(null, orderBy, includeProperties, size, null);
        }

        /// <summary>
        /// 排序，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int size = -1)
        {
            return Get(null, orderBy, "", size, null);
        }

        /// <summary>
        /// 贪婪查询，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(string includeProperties, int size = -1)
        {
            return Get(null, null, includeProperties, size, null);
        }

        /// <summary>
        /// 通过条件查询，并且贪婪查询、排序，返回所有记录，size大于0时，返回size条记录
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="size">几条记录</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties, int size, Expression<Func<TEntity, TEntity>> selector = null)
        {
            _context.Database.Log = c => WriteResult(c);
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty).AsNoTracking();
            if (selector != null)
                query = query.Select(selector);
            if (orderBy != null)
            {
                if (size > 0)
                    query = orderBy(query).Take(size);
                else
                    query = orderBy(query);
            }
            else
            {
                if (size > 0)
                    query = query.Take(size);
            }
            return query.ToList();
        }
        #endregion

        #region 分页
        /// <summary>
        /// 返回分页记录
        /// </summary>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(int index = 0, int size = 20)
        {
            return GetPaged(null, null, "", index, size);
        }

        /// <summary>
        /// 通过条件查询，返回分页记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, int index = 0, int size = 20)
        {
            return GetPaged(filter, null, "", index, size);
        }

        /// <summary>
        /// 通过条件查询，并且贪婪查询，返回分页记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, string includeProperties, int index = 0, int size = 20)
        {
            return GetPaged(filter, null, includeProperties, index, size);
        }

        /// <summary>
        /// 通过条件查询，并且排序，返回分页记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int index = 0, int size = 20)
        {
            return GetPaged(filter, orderBy, "", index, size);
        }

        /// <summary>
        /// 排序，并且贪婪查询，返回分页记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int index = 0, int size = 20)
        {
            return GetPaged(null, orderBy, includeProperties, index, size);
        }

        /// <summary>
        /// 排序，返回分页记录
        /// </summary>
        /// <param name="orderBy">排序</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int index = 0, int size = 20)
        {
            return GetPaged(null, orderBy, "", index, size);
        }

        /// <summary>
        /// 贪婪查询，返回分页记录
        /// </summary>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(string includeProperties, int index = 0, int size = 20)
        {
            return GetPaged(null, null, includeProperties, index, size);
        }

        /// <summary>
        /// 通过条件查询，并且贪婪查询、排序，返回分页记录
        /// </summary>
        /// <param name="filter">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="includeProperties">贪婪查询</param>
        /// <param name="index">当前页</param>
        /// <param name="size">每页记录</param>
        /// <returns></returns>
        public PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties, int index = 0, int size = 20)
        {
            _context.Database.Log = c => WriteResult(c);
            int page = index;
            index = index > 0 ? index - 1 : index;
            int skipCount = index * size;
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
            if (orderBy != null)
                query = orderBy(query);
            else
            {
                var props = typeof(TEntity).GetProperties().Where(c => c.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true).Length == 1);
                foreach (var prop in props)
                    query = query.OrderByDescending(prop.Name);
            }
            var resetSet = skipCount == 0 ? query.Take(size) : query.Skip(skipCount).Take(size);
            var list = resetSet.AsNoTracking().ToList();
            if (list.Count > 0)
            {
                int total = query.Count();
                return new PagedResult<TEntity>(list, total, page, size);
            }
            return new PagedResult<TEntity>();
        }
        #endregion

        #region 查询一条记录
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            _context.Database.Log = c => WriteResult(c);
            return DbSet.Count(predicate) > 0;
        }

        public virtual TEntity Find(params object[] keys)
        {
            _context.Database.Log = c => WriteResult(c);
            return DbSet.Find(keys);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            _context.Database.Log = c => WriteResult(c);
            return DbSet.AsNoTracking().FirstOrDefault(filter);
        }
        #endregion

        #region 增加、修改、删除
        public virtual void Create(TEntity t)
        {
            DbSet.Add(t);
        }

        public virtual void Delete(TEntity t)
        {
            object obj;
            if (!IsHasObject(t, out obj))
                DbSet.Attach(t);
            DbSet.Remove(t);
            //if (Context.Entry(t).State == EntityState.Detached) {
            //    var context = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)Context).ObjectContext;
            //    object obj;
            //    EntityKey key = GetEntityKey(t);
            //    if (!context.TryGetObjectByKey(key, out obj))
            //        DbSet.Attach(t);
            //    DbSet.Remove(t);
            //}
            //else {
            //    DbSet.Attach(t);
            //    DbSet.Remove(t);
            //}
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> filter)
        {
            var toDelete = Get(filter);
            foreach (var obj in toDelete)
            {
                Delete(obj);
            }
        }

        public virtual void Update(TEntity t)
        {
            object obj;
            var context = ((IObjectContextAdapter)Context).ObjectContext;
            if (IsHasObject(t, out obj))
                context.Detach(obj);
            DbSet.Attach(t);
            Context.Entry(t).State = EntityState.Modified;

            //var entry = Context.Entry(t);
            //if (entry.State == EntityState.Detached) {
            //    var context = ((IObjectContextAdapter)Context).ObjectContext;
            //    object obj;
            //    EntityKey key = GetEntityKey(t);
            //    if (context.TryGetObjectByKey(key, out obj))
            //        context.Detach(obj);
            //    DbSet.Attach(t);
            //    entry.State = EntityState.Modified;
            //}
            //else {
            //    entry.State = EntityState.Modified;
            //}
        }
        public virtual void Update(TEntity t, params Expression<Func<TEntity, dynamic>>[] fields)
        {
            if (t != null && fields != null)
            {
                object obj;
                var context = ((IObjectContextAdapter)Context).ObjectContext;
                if (IsHasObject(t, out obj))
                    context.Detach(obj);
                DbSet.Attach(t);
                var entry = Context.Entry(t);
                foreach (var field in fields)
                    entry.Property(field).IsModified = true;

                //var entry = Context.Entry(t);
                //if (entry.State == EntityState.Detached) {
                //    var context = ((IObjectContextAdapter)Context).ObjectContext;
                //    object obj;
                //    EntityKey key = context.CreateEntityKey(context.DefaultContainerName + "." + t.GetType().Name, t);
                //    if (context.TryGetObjectByKey(key, out obj))
                //        context.Detach(obj);
                //    DbSet.Attach(t); ;
                //    foreach (var field in fields)
                //        entry.Property(field).IsModified = true;
                //}
                //else {
                //    foreach (var field in fields)
                //        entry.Property(field).IsModified = true;
                //}
            }
        }

        public int Save()
        {
            _context.Database.Log = c => WriteResult(c);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 判断entity是否存在上下文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool IsHasObject(TEntity entity, out object obj)
        {
            var context = ((IObjectContextAdapter)Context).ObjectContext;
            EntityKey key = GetEntityKey(entity);
            return context.TryGetObjectByKey(key, out obj);
            //ObjectStateEntry entry = null;
            //return context.ObjectStateManager.TryGetObjectStateEntry(GetEntityKey(entity), out entry);
        }
        /// <summary>
        /// 通过反射获取实体对象的EntityKey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private EntityKey GetEntityKey(TEntity entity)
        {
            var wrapper = entity.GetType().GetField("_entityWrapper");
            if (wrapper != null)
            {
                var entityWrapper = wrapper.GetValue(entity);//获取字段_entityWrapper的值
                var entityWrapperType = entityWrapper.GetType();//获取字段的类型
                var entityKey = entityWrapperType.GetProperty("EntityKey").GetValue(entityWrapper, null);//获取EntityKey属性的值
                return (EntityKey)entityKey;
            }
            var context = ((IObjectContextAdapter)Context).ObjectContext;
            EntityKey key = context.CreateEntityKey(context.DefaultContainerName + "." + entity.GetType().Name, entity);
            return key;
        }
        #endregion

        #region 其它
        public int Count
        {
            get { return DbSet.Count(); }
        }

        public IQueryable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return Context.Database.SqlQuery<TEntity>(query, parameters).AsQueryable();
        }

        public override string ToString()
        {
            //if(_resetSet!=null)return _resetSet.ToString();
            //if (_query != null) return _query.ToString();
            return _resultSql;
        }

        private void WriteResult(string message)
        {
            _resultSql = message;
            _logger.WriteInfo(message);
        }

        #endregion

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
    public static class DbContextExtensions
    {
        public static EntityKey GetEntityKey(this DbContext context, object entity)
        {
            var adapter = context as IObjectContextAdapter;
            var entry = adapter.ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            return entry.EntityKey;
        }
    }
}
