using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Shop.Business.Data;
using Shop.Business.Repository;
using Shop.Business.Repository.Contracts;
using Shop.DataAccess.ContextFactory;
using Shop.DataAccess.ContextFactory.Contracts;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;
using Shop.Infrastructure.Factory;
using Shop.Infrastructure.Logger;
using Shop.Infrastructure.Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
