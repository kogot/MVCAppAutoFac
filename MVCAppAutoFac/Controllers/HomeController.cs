using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MVCAppAutoFac.Controllers
{
    using MVCAppAutoFac.BL;

    public class HomeController : Controller
	{
	    private readonly IMain _main;

	    public HomeController(IMain main)
	    {
	        _main = main;
	    }

	    public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;
		    ViewBag.Name = _main.GetName();
			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";

			return View();
		}
	}
}
