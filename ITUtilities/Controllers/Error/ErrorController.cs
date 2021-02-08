using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITUtilities.Controllers.Error
{
    public class ErrorController : Controller
    {
        // GET: Error
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Error");
        }
        // GET: NotFound
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View("NotFound");
        }
    }
}