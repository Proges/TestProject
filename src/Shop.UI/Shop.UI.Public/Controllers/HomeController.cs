using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Shop.Infrastructure.Factory;
using Shop.Infrastructure.Logger;
using Shop.Infrastructure.Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Shop.UI.Public.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
