using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using sweetnes18.AhelperClass;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json; 
using System.Data.Entity; 
using System.Threading.Tasks;
using System.Net; 
using sweetnes18.Models;
using System.Web.Script.Serialization;

namespace sweetnes18.Controllers {
    
    public class CreateaccountAPIController : Controller
    {
        private conn db = new conn();  
        [AllowJsonGet]
        public async Task<JsonResult> Create([Bind(Include = "id,fname,lname,password,mobileno,status,usertype,username")] user user)
        {

            if (ModelState.IsValid)
            { 
                db.user.Add(user);

                try
                {
                    await db.SaveChangesAsync();
                    return new JsonResult { Data = new { Message = "Success", Status = "true" } };
                }
                catch (Exception ex)
                {
                    return  new JsonResult { Data = new { Message = "Product Save failed! Please try again! " + ex.Message, Status = "false" } }; 
                } 
            }
            ErrorHandling e1 = new ErrorHandling(ModelState);
            return e1.SendJson;
           
        }

        [AllowJsonGet]
        public async Task<ActionResult> Edit([Bind(Include = "id,fname,lname,password,mobileno,status,usertype,username")] user user)
        {

            if (user.id == 0   )
            {
                return new JsonResult { Data = new { Message = "Id missing ", Status = "false" } };
            }
            //  if(string.IsNullOrEmpty(user.id)  )
            {
                //      return new JsonResult { Data = new { Message = "Id missing ", Status = "false" } };
            }
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Added;
                try
                {
                    await db.SaveChangesAsync();
                    return new JsonResult { Data = new { Message = "Success", Status = "true" } };
                }
                catch(Exception ex)
                {
                    return new JsonResult { Data = new { Message = "Product Save failed! Please try again! " + ex.Message, Status = "false" } };
                }

            }
            ErrorHandling e1 = new ErrorHandling(ModelState);
            return e1.SendJson;
        }
        [AllowJsonGet]
        public  JsonResult Login()
        { 
            string u = Request["username"];
            string p = Request["password"];
            var exist =   db.user.Where( x => x.username == u && x.password == p && x.status == 1 ).FirstOrDefault();
            if (exist == null)
                return new JsonResult { Data = new { Status = "false" , Message = "Invalid Login details" } };

            var json = new JavaScriptSerializer().Serialize(exist);
            return new JsonResult { Data = new { Status = "true", Message = json } };
        }
 

    }
}
