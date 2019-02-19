using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bastis.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult Error404()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ViewResult Error500()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}