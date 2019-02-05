using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using sweetnes18.AhelperClass;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace sweetnes18.Controllers
{
    public class UserInfoController : Controller
    {

        public ActionResult Index(String str)
        {
            Response.Write("notworking"+ str );
            DatabaseConnection abcd = new DatabaseConnection();//Exec dbo.userGetAddress @Address="indore"
            DataSet ds = abcd.Select("Exec dbo.userGetAddress @Address='"+str+"'");
            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                Response.Write(ds.Tables[0].Rows[x]["Name"].ToString() + "<br/>");
                Response.Write(ds.Tables[0].Rows[x]["Address"].ToString() + "<br/>");
                Response.Write(ds.Tables[0].Rows[x]["Mobile"].ToString() + "<br/><br/><br/><br/>");
            }
            return View("UserInfo");
        }

    }
}