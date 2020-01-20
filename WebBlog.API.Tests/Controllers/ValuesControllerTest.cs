using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBlog.API;
using WebBlog.API.Controllers;
using WebBlogModel;

namespace WebBlog.API.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // 排列
            UserController controller = new UserController();
            int id = 205;
            // 操作
            blg_user result = controller.Get(id);

            // 断言

        }
    }
}
