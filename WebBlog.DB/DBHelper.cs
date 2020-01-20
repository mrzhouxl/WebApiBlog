using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace WebBlog.DB
{
    //数据库帮助类
    public class DBHelper
    {
        public DbContext GetDb()
        {
            return DbContentFactory.Create();
        }

        #region 增
        public bool Insert<T>(T t) where T : class
        {

            using (var conn = DbContentFactory.Create())
            {
                conn.Set<T>().Add(t);
                int result = conn.SaveChanges();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> InsertAsync<T>(T t) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                conn.Set<T>().Add(t);
                int result = await conn.SaveChangesAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 删
        public bool Delete<T>(T t) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                conn.Set<T>().Remove(t);
                int result = conn.SaveChanges();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> DeleteAsync<T>(T t) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                conn.Set<T>().Remove(t);
                int result = await conn.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T">当前的类</typeparam>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public bool Delete<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (var conn = DbContentFactory.Create())
                    {
                        var entity = conn.Set<T>().Where(whereLambda).FirstOrDefault();
                        if (entity != null)
                        {
                            conn.Set<T>().Remove(entity);
                            int result = conn.SaveChanges();
                            scope.Complete();
                            if (result >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
            } catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public bool Delete<T>(int id) where T : class
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (var conn = DbContentFactory.Create())
                {
                    var entity = Get<T>(id);
                    conn.Entry(entity).State = System.Data.Entity.EntityState.Deleted;//标记为可以删除的状态
                    int result = conn.SaveChanges();
                    if (result >= 0)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

        #region 改
        public bool Update<T>(T t) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                conn.Set<T>().AddOrUpdate(t);
                int result = conn.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async Task<bool> UpdateAsync<T>(T t) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                conn.Set<T>().AddOrUpdate(t);
                int result = await conn.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool Update2<TModel>(TModel entity) where TModel : class
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (var conn = DbContentFactory.Create())
                {
                    conn.Entry(entity).State = System.Data.Entity.EntityState.Modified;//标记为修改
                    int result = conn.SaveChanges();
                    scope.Complete();//提交事务
                    if (result >= 0)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }

            }
        }
        #endregion

        #region 查
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get<T>(int id) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                return conn.Set<T>().Find(id);
            }
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> whereLambda = null) where T : class
        {
            using(var conn = DbContentFactory.Create())
            {
                if (whereLambda != null)
                {
                    return conn.Set<T>().Where(whereLambda) ?? null;
                }
                else
                {
                    return conn.Set<T>();
                }
              
            }
        } 

        /// <summary>
        /// 判断对象是否存在
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public bool GetAny<T>(Expression<Func<T,bool>> whereLambda) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                return whereLambda != null ? conn.Set<T>().Where(whereLambda).Any() : conn.Set<T>().Any();
            }
        }

        /// <summary>
        /// 查询当前条件对象的总条数
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public int GetWhereCount<T>(Expression<Func<T,bool>> whereLambda) where T : class
        {
            using(var conn = DbContentFactory.Create())
            {
                return whereLambda != null ? conn.Set<T>().Where(whereLambda).Count() : conn.Set<T>().Count();
            }
        }

        /// <summary>
        /// 获取根据条件获取单条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T GetFistDefault<T>(Expression<Func<T,bool>> whereLambda) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                return whereLambda != null ? conn.Set<T>().FirstOrDefault(whereLambda) ?? null : conn.Set<T>().FirstOrDefault() ?? null;
            }
        }
        /// <summary>
        /// 根据条件查询分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="PageIndex">当前页码数</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="TotalCount">总条数</param>
        /// <param name="OrderBy">分页条件</param>
        /// <param name="whereLambda">查询调价</param>
        /// <param name="IsOrder">是否分页(默认分页)</param>
        /// <returns></returns>
        public List<T> Pagination<T, Tkey>(int PageIndex,int PageSize,out int TotalCount,Expression<Func<T,Tkey>> OrderBy,Expression<Func<T,bool>> whereLambda = null,bool IsOrder = true) where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                IQueryable<T> QueryList = IsOrder == true ? conn.Set<T>().OrderBy(OrderBy) : conn.Set<T>().OrderByDescending(OrderBy);
                if (whereLambda != null) 
                {
                    QueryList = QueryList.Where(whereLambda);
                }
                TotalCount = QueryList.Count();
                return QueryList.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList() ?? null;
            }
        }
        #endregion

        #region sql执行增删改
        /// <summary>
        /// SQL执行增删改
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <param name="parms">参数数组</param>
        /// <returns></returns>
        public int SqlCommand(string sql, params object[] parms) {
            using (var conn = DbContentFactory.Create())
            {
                return conn.Database.ExecuteSqlCommand(sql, parms);
            } 
        }
        /// <summary>
        /// SQL执行增删改
        /// </summary>
        /// <returns></returns>
        public int SqlCommand(string sql) {
            using (var conn = DbContentFactory.Create())
            {
                return conn.Database.ExecuteSqlCommand(sql);
            }
        }

        /// <summary>
        /// SQL执行查询
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <param name="parms">参数数组</param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parms)
        {
            using (var conn = DbContentFactory.Create())
            {
                return conn.Database.SqlQuery<T>(sql, parms);
            }
        }
        /// <summary>
        /// SQL执行查询
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql)
        {
            using (var conn = DbContentFactory.Create())
            {
                return conn.Database.SqlQuery<T>(sql);
            }
        } 
        /// <summary>
        /// 进行回滚
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RollBackChanges<T>() where T : class
        {
            using (var conn = DbContentFactory.Create())
            {
                var Query = conn.ChangeTracker.Entries().ToList();
                Query.ForEach(p => p.State = EntityState.Unchanged);
            }
            
        }

        #endregion
    }
}
