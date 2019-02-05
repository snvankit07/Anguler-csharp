using sweetnes18.AhelperClass;
using sweetnes18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sweetnes18.Controllers
{
    public class MyaccountController : Controller
    {
        private conn db = new conn();
        [CustomerAction]
        public ActionResult Index()
        {
           
                user u = new user();
                u = (user)Session["userdetail"];
                int userID = u.id;
                ViewData["myaccount"] = "1";
                ViewData["userdata"] = userID;
                return View();
           
        }
        [CustomerAction]
        public ActionResult Setting()
        {
            if (Request["submit"] != null)
            {
                Int32 UID       = Convert.ToInt32(Request["UID"]);
                String Fn       = Request["FN"];
                String Ln       = Request["LN"];
                String email    = Request["email"];
                String mobile   = Request["mobile"];
                user usersd =db.user.Where(h => h.id == UID).FirstOrDefault();
                usersd.fname = Fn;
                usersd.lname = Ln;
                db.SaveChanges();
                return RedirectToRoute(new
                {
                    controller = "Myaccount",
                    action = "Setting"
                });
            }
            user u = new user();
            u = (user)Session["userdetail"];
            int userID = u.id;
            var users=db.user.Where(h => h.id == u.id).FirstOrDefault();
            ViewData["fname"] = users.fname;
            ViewData["lname"] = users.lname;
            ViewData["mobile"] = users.mobileno;
            ViewData["email"] = users.username;
            ViewData["myaccount"] = "1";
            ViewData["userdata"] = userID;
            return View();

        }


        [CustomerAction]
        public ActionResult ResetPassword()
        {
            ViewData["Errormsg"] = "";
            if (Request["submit"] != null)
            {
                Int32 UID = Convert.ToInt32(Request["UID"]);
                String oldp = Request["OldPassword"];
                String np = Request["NewPassword"];
                String cnp = Request["cNewPassword"];
                user usersd = db.user.Where(h => h.id == UID && h.password== oldp).FirstOrDefault();
                ViewData["Errormsg"] = "Old PassWord Is Wrong";
                if (usersd != null)
                {
                    if (np == cnp)
                    {
                        ViewData["Errormsg"] = "";
                        usersd.password = np;
                        db.SaveChanges();
                        return RedirectToRoute(new
                        {
                            controller = "Myaccount",
                            action = "ResetPassword"
                        });

                    }
                    else {
                        ViewData["Errormsg"] = "New Password and Confirm password not matched";

                    }
                }
            }
            user u = new user();
            u = (user)Session["userdetail"];
            int userID = u.id;
            var users = db.user.Where(h => h.id == u.id).FirstOrDefault();
            ViewData["userdata"] = userID;
            return View();
        }


        [CustomerAction]
        public ActionResult UserAddress()
        {
            user u = new user();
            u = (user)Session["userdetail"];
            int userID = u.id;
            ViewData["userdata"] = userID;
            return View();
        }

        [CustomerAction]
        public ActionResult Favourites()
        {
            user u = new user();
            u = (user)Session["userdetail"];
            int userID = u.id;
            ViewData["userdata"] = userID;
            return View();
        }



        [CustomerAction]
        public ActionResult addnewAddress()
        {
            if (Request["submit"] == "Save Address")
            {
                int ID=Convert.ToInt32(Request["userID"]);
                String FN=(Request["fname"]);
                String LN = (Request["lname"]);
                int City = Convert.ToInt32(Request["city"]);
                String street = (Request["StreetName"]);
                String building = (Request["BuildingName"]);
                String location = (Request["Location"]);
                String mobile = (Request["Mobile"]);
                String email = (Request["email"]);
                ShippingAddress s = new ShippingAddress();
                s.Fname = FN;
                s.userid = ID;
                s.Lname = LN;
                s.StreetName = street;
                s.BuildingName = building;
                s.City = City;
                s.CityName = db.cities.Where(h=>h.id==City).FirstOrDefault().name;
                s.Mobile = mobile;
                s.email = email;
                db.ShippingAddress.Add(s);
                db.SaveChanges();
                return RedirectToRoute(new
                {
                    controller = "Myaccount",
                    action = "UserAddress"
                });

            }


            user u = new user();
            u = (user)Session["userdetail"];
            int userID = u.id;
            ViewData["userdata"] = userID;
            ViewData["mobile"] = u.mobileno;
            ViewData["email"] = u.username;
            return View();
        }
        
    }
}
