using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sweetnes18.AhelperClass;
using System.Web.Mvc;
using System.Data;

namespace sweetnes18.Areas.administrator.Controllers
{
    public class LoginController : Controller
    {
        // GET: administrator/Login
        public ActionResult Index()
        {
            string u = Request["username"];
            string p = Request["password"];

            string whr = " ([USERNAME]='" + u + "' or [MOBILENO]='" + u + "') and [PASSWORD]='" + p + "' and [usertype]='0' and [status]='1'";
            DatabaseConnection dbs = new DatabaseConnection();
            DataSet ds = dbs.Select("select * from [dbo].[user] where " + whr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["adminlogin"] = "y";

                return RedirectToRoute(new
                {
                    controller = "/Dashboard",

                });

            }
return View();
        }
        public RedirectToRouteResult Logout() {
            Session["adminlogin"] = "";
            return RedirectToRoute(new
            {
                controller = "/Dashboard",

            });
           
        }
    }
}