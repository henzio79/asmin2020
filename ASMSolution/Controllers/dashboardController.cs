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
            //RedirectToAction("Dashboard_Chart1");
            return View();
        }

        public JsonResult Dashboard_Chart1(int? data = null)
        {
            var _qry = new object();
            try
            {
                var _asOfDate = new SqlParameter("@AsOfDate", DateTime.Now);
                var _chart1 = db.Database.SqlQuery<dashboard_chart01_ViewModel>("DASHBOARD_CHART01", _asOfDate).ToList<dashboard_chart01_ViewModel>();

                if (data == null || data < 0)
                    data = 0;

                if (data > 2)
                    data = 2;


                if (data == 1)
                {
                    _qry = _chart1.Select(a => new
                    {
                        a.department_id,
                        a.department_code,
                        a.asset_qty,
                    });

                }
                else if (data == 2)
                {
                    _qry = _chart1.Select(a => new
                    {
                        a.department_id,
                        a.department_code,
                        a.asset_value
                    });

                }
                else
                {
                    _qry = _chart1.Select(a => new
                    {
                        a.department_id,
                        a.department_code,
                        a.asset_qty,
                        a.asset_value
                    });
                }


            }
            catch (Exception _exc){
                string str_message = _exc.Message;
            }
            return Json(new { data = _qry }, JsonRequestBehavior.AllowGet);

        }

    }
}