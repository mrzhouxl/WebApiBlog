using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBlog.Services;
using WebBlog.Model;

namespace WebBlog.API.Controllers
{
    public class UserController : BaseController
    {
        UserService u = new UserService();

        [HttpGet]
        public blg_user Get(int id)
        {
            return u.Get<blg_user>(id);
        }
    } 
}
