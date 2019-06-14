using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSeminar.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}