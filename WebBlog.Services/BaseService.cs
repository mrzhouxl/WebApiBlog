using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBlog.DB;

namespace WebBlog.Services
{
    public class BaseService
    {
        public DBHelper db = new DBHelper();

        public bool Add<T>(T t) where T : class => db.Insert<T>(t);

        //根据id删除
        public bool Del<T>(int id) where T : class => db.Delete<T>(id);
        //根据对象删除
        public bool Del<T>(T t) where T : class => db.Delete<T>(t);
        //根据对象修改
        public bool Upd<T>(T t) where T : class => db.Update<T>(t);
        //根据对象修改(事务)
        public bool Upd2<TModel>(TModel t) where TModel : class => db.Update2<TModel>(t);

        public T Get<T>(int id) where T : class => db.Get<T>(id);
        //根据条件查询 自己调用 自己查dbhelp里面已经封装好了 在写的话没有意义 直接调用就亏了 这里面只写一些简单的 访问方式
        //public IEnumerable<T> Get<T>(Expression<Func<T, bool>> whereLambda) => db.Get<T>(whereLambda);
        public T Find<T>(params object[] para) where T : class => db.GetDb().Set<T>().Find(para);
        public bool Exist<T>(Expression<Func<T, bool>> exp) where T : class => db.GetAny<T>(exp);
        public List<T> GetListByConditions<T>(Expression<Func<T, bool>> exp) where T : class => db.GetDb().Set<T>().AsNoTracking().Where(exp).ToList();
        public T GetSingleByConditions<T>(Expression<Func<T, bool>> exp) where T : class => db.GetDb().Set<T>().AsNoTracking().Where(exp).SingleOrDefault();
        public T GetFirstByConditions<T>(Expression<Func<T, bool>> exp) where T : class => db.GetDb().Set<T>().AsNoTracking().Where(exp).FirstOrDefault();
        public T GetLastByConditions<T>(Expression<Func<T, bool>> exp) where T : class => db.GetDb().Set<T>().AsNoTracking().Where(exp).LastOrDefault();
    }
}
