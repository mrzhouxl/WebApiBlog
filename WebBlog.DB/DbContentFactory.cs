using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using WebBlog.Model;

namespace WebBlog.DB
{
    public partial class DbContentFactory
    {
        // 创建ef上下文工具
        public static DbContext Create()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext; //获取具有DbContext的ef数据集
            if (dbContext == null)
            {
                dbContext = new WebBlog.Model.WebBlog();
                CallContext.SetData("DbContext", dbContext);
            }
            dbContext.Configuration.ProxyCreationEnabled = false;// 解决外键问题
            return dbContext;
        }
    }
}
