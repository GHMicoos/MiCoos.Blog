using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiCoos.Blog.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Login(UserLoginInfo info)
		{

			return Json(new { success=true,error=""});
		}
	}

	public class UserLoginInfo
	{
		public string UserName { get; set; }

		public string Password { get; set; }
	}
}