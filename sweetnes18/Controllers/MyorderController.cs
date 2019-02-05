using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Sweetnes18.Controllers
{
    [LaunchingAction]
    public class MyorderController : Controller
    {
        private Payment pay = new Payment();
        private conn db = new conn();


        public ActionResult Paynowformobile()
        {
            ViewData["PaySession"] = Request["session"];
            return View();
        }

        public ActionResult PaynowCompleteformobile()
        {
            
            return View();
        }
        public ActionResult PaynowCancelformobile()
        {

            return View();
        }



        public ActionResult CancelOrder()
        {
            return View();
        }

        public ActionResult updatepay()
        {
            return View();
        }

        [CartClearRedirectingAction]
        public async Task<ActionResult> Index()
        {
            var d = await CreatePaySession();
            dynamic data = JsonConvert.DeserializeObject(d);
            
            //Get Data Dynamic 
            Session["PAYsuccessIndicator"] = data.successIndicator;
            Session["PAYSession"] = data.session.id;
            ViewData["PaySession"] = data.session.id;
            ViewData["PAYsuccessIndicator"] = data.successIndicator;
            return View();
        }


        public async Task<ActionResult> paymentactionAsync() {
            String PayNows = Convert.ToString(Request["PayNow"]);
            if (PayNows == "Continue to Pay")
            {
                String Err;
                String TU = Convert.ToString(Request["termsanduse"]);
                if (TU != "on")
                {
                    Err = "<br>Please Read Term and Condition And Checked";
                    return RedirectToRoute(new
                    {
                        controller = "Myorder",
                    });
                }
                else
                {
                    var d = await CreatePaySession();
                    var data=JsonConvert.DeserializeObject(d);
                    // Response.Write(d.error);
                    JObject jObj = (JObject)data; //initialized somewhere, perhaps in your foreach
                    var msgProperty = jObj.Property("error");

                    var a =String.Empty;
                    if (msgProperty == null)
                    {
                        a = (string)jObj["response"]["gatewayCode"];
                    } 
                   if (msgProperty != null)
                    {
                        Session["CardError"] = d;
                    }
                    else if (!a.Equals("APPROVED"))
                    {
                        Session["CardError"] = d;
                    }
                    else
                    { 
                        PaymentgatewayData p = new PaymentgatewayData();
                        p.Gatewaydata = d;
                        db.PaymentgatewayData.Add(p);
                        db.SaveChanges();

                        Session["Paymentdata"] = p.ID;
                        Response.Write(false);
                        //there is no "msg" property, compensate somehow.
                        return RedirectToRoute(new
                        {
                            controller = "Myorder",
                            action = "Paynowdone"
                        });
                    }
                }
            }
            return RedirectToRoute(new
            {
                controller = "Myorder",
                action = "index"
            });
        }

        public ActionResult CustomizedProduct()
        {
            String Sub = Convert.ToString(Request["savedata"]);
            if (!String.IsNullOrEmpty(Sub)){
                string[] orderid = Request.Form.GetValues("orderid[]");
                string[] ordercomment = Request.Form.GetValues("ordercomment[]");
                string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");
                Int32 i;
                i = 0;
                foreach (String x in orderid) {
                    String IDs = orderid[i];
                    var pb = db.ProductBundle.Where(h => h.ProductOrderID == IDs).FirstOrDefault();
                    HttpPostedFileBase file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        
                        var fileName = Path.GetFileName(file.FileName);
                        file.SaveAs(Path.Combine(directory, fileName));
                        pb.customizationImage = "/images/" + fileName;
                        
                    }
                    pb.iscustomization = 2;
                    pb.customizationmsg = ordercomment[i];
                    db.SaveChanges();
                    i++;

                }
                return RedirectToRoute(new
                {
                    controller = "Myorder",
                    action = "savedCustomized"
                });
            }
                var OrderID=Convert.ToString(Request["id"]);
                var orderidd=db.Order.Where(h => h.TransactionId == OrderID).FirstOrDefault();
                var bandle=db.ProductBundle.Where(h => h.OrderID == orderidd.OrderID && h.iscustomization==1 && (h.pickanddeliverStatus==0 || h.pickanddeliverStatus == -1)).ToList();
            if (bandle.Count() == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "Myorder",
                    action = "NoCustomized"
                });
            }
            ViewData["OrderData"] = bandle;
            return View();
        }

        //[PaynowchkAction]
        [CartClearRedirectingAction]
        public ActionResult Paynowdone()
        {
            return View();
        }

        public ActionResult NoCustomized()
        {
            return View();
        }
        public ActionResult savedCustomized()
        {
             return View();
        }

        public ActionResult MyTrackOrder()
        {
            
            return View();
        }


        public ActionResult TrackOrder()
        {
            ViewData["orderid"] = Request["orderid"];
            return View();
        }
        public ActionResult Review()
        {
            ViewData["Token"] = Request["token"];
            return View();
        }


        private string GenerateRandomText(int v)
        {

            const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, v)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result;

        }

        private string GenerateRandom_Trns(int v, Boolean flag = false)
        {
            TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.UtcNow;
            DateTime zone = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);


            Int64 now = zone.Ticks;
            String Chars;
            Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
            if (flag == true)
            {
                Chars = "0123456789";
            }
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, v)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result + now;

        }


        public async Task<String> CreatePaySession()
        {
            String Order    = this.GenerateRandom_Trns(2);
            String URL;
            Double AMOUNT = Convert.ToDouble(Session["amount"]);
            String CURR = "AED";
            
            String EMAIL = Session["PayEmail"].ToString();
            String PHONE = Session["PayPhone"].ToString();
            String FNAME = Session["PayfName"].ToString();
            String LNAME = Session["PaylName"].ToString();

            URL = "https://eu-gateway.mastercard.com/api/rest/version/49/merchant/TEST4003464/session/";
            String username = "merchant.TEST4003464";
            String password = "da55f77d0fdcab48ac9cda2901a8e0ba";
            var data = await pay.PaymentMethodSession(URL, username, password, Order, AMOUNT, CURR,EMAIL,PHONE, FNAME,LNAME);
            return (data);
        }

        public async Task<String> PayNow()
        {
            String Trns = this.GenerateRandom_Trns(8);
            String Order = this.GenerateRandom_Trns(2);
            String URL;
            String CardNO = Convert.ToString(Session["cardNo"]);
            Int32 Month = Convert.ToInt32(Session["month"]);
            Int32 Year = Convert.ToInt32(Session["year"]);
            Int32 CVV = Convert.ToInt32(Session["cvv"]);
            Double AMOUNT = Convert.ToDouble(Session["amount"]);


            URL = "https://eu-gateway.mastercard.com/api/rest/version/49/merchant/TEST4003464/order/" + Order + "/transaction/" + Trns;
            //Response.Write(URL);
            String username = "merchant.TEST4003464";
            String password = "da55f77d0fdcab48ac9cda2901a8e0ba";
            var data = await pay.PaymentMethod(URL, username, password, CardNO, Month, Year, CVV, AMOUNT);
            //Response.Write((data));
            //Response.Write(JsonConvert.SerializeObject(data));
            return (data);
        }
    }
}
