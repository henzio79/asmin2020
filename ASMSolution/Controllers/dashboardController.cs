using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM_UI.Models;
using System.Data.SqlClient;
using System.Web.Configuration;
using ASM_UI.App_Helpers;

namespace ASM_UI.Controllers
{
    [Authorize]
    public class dashboardController : BaseController
    {
        private ModelAsmRemote db = new ModelAsmRemote();

        // GET: dashboard
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Dashboard_Chart1()
        {
            var _qry = new object();
            try
            {



            }
            catch { }
            return Json(new { data = _qry }, JsonRequestBehavior.AllowGet);

        }

    }
}