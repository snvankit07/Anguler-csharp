using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace sweetnes18.Controllers
{
    public class CompanyController : Controller
    {
        private conn db = new conn();
        private DatabaseConnection abcd = new DatabaseConnection();
        // GET: Company
        public ActionResult Index()
        {
            var u=db.user.Where(h => h.status == 1 && h.usertype==2).ToList();
            foreach (user u1 in u) {
                var datas=db.Usersmeta.Where(h => h.userid == u1.id && h.metakey == "add").FirstOrDefault();
                if (datas != null) { 

                    //String d = "UPDATE [dbo].[user] SET [shipping] = '"+ datas.metavalue+ "' WHERE [id] = "+ u1.id;
                    //abcd.Select(d);
                }
            }
            return View();
        }

        [RedirectingShipping]
        public ActionResult productshow()
        {
            ViewData["dataorder"] = Session["company"];
            return View();
        }

        [RedirectingShipping]
        public ActionResult canceleresion()
        {
            if (Request["save"] == "submit")
            {
                String Comment=Request["Comment"];
                String Image = Request["image"];
                Int16 Otype = Convert.ToInt16(Request["ordertype"]);
                String OrderID = Request["orderID"];

                var Order=db.ProductBundle.Where(h => h.ProductOrderID == OrderID).FirstOrDefault();
                string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        file.SaveAs(Path.Combine(directory, fileName));
                        Order.cancelImage = this.CreateThumbnail(0, 0, "/images/" + fileName);
                        Path.Combine(directory, fileName);
                        Order.cancelMsg = Comment;
                        Order.pickanddeliverStatus = Otype;
                        if (Order.pickanddeliverStatus == -3)
                        { Order.cancelby = 3; }
                        if (Order.pickanddeliverStatus == -4)
                        { Order.cancelby = 4; }
                        db.SaveChanges();
                        return RedirectToRoute(new
                        {
                            controller = "Company",
                            action = "productshow"
                        });

                    }
                }
            }


            String ORDERID = Request["OrderID"];
            int v = db.ProductBundle.Where(h => h.cancelby != 0 && h.ProductOrderID == ORDERID).ToList().Count();
            if (v > 0)
            {
                return RedirectToRoute(new
                {
                    controller = "Company",
                    action = "productshow"
                });
            }
            ViewData["Order"] = Request["OrderID"];
            ViewData["type"] = Request["OrderType"];
            return View();
        }

        [RedirectingShipping]
        public ActionResult Logout()
        {
            Session["company"] = "";
            Session["companydata"] = "";
            Session["companylogin"] = "";
            return RedirectToRoute(new
            {
                controller = "Company",
                action = "productshow"
            });
            
        }

        public string CreateThumbnail(int maxWidth, int maxHeight, string path)
        {
            string directory = System.Web.HttpContext.Current.Server.MapPath("~/");
            String npath = path;
            if (System.IO.File.Exists(directory + path))
            {

                path = (directory + path);
                maxWidth = 500;
                maxHeight = 500;
                var image = System.Drawing.Image.FromFile(path);
                var ratioX = (double)maxWidth / image.Width;
                var ratioY = (double)maxHeight / image.Height;
                var ratio = Math.Min(ratioX, ratioY);
                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);
                var newImage = new Bitmap(newWidth, newHeight);
                Graphics thumbGraph = Graphics.FromImage(newImage);

                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);
                image.Dispose();

                string fileRelativePath = "newsizeimages/" + maxWidth + "/" + Path.GetFileName(path);
                newImage.Save(Server.MapPath(npath), newImage.RawFormat);
            }

            return npath;
        }
    }
}
