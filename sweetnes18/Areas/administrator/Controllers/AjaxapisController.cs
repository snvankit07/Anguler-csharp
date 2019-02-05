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
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace sweetnes18.Areas.administrator.Controllers
{
  
    public class AjaxapisController : Controller
    {
        private Mobilemsg MOBILE = new Mobilemsg();
        private conn db = new conn();
        private Payment pay = new Payment();
        private Common cfn = new Common();
        private DatabaseConnection abcd = new DatabaseConnection();


        /*-------------------Comon Response Data--------------*/
        private Object Responsedata(bool flag = false, String msg = "No Data Found",Object rts = null)
        {

            List<Response> APIRES = new List<Response>();
            Response r = new Response();
            
            
            r.flag = flag;
            r.message = msg;
            r.result = rts;
            APIRES.Add(r);
            return APIRES.FirstOrDefault();
        }

        

        [AllowJsonGet]
        public JsonResult getAllUsers()
        {
            Int32 type;
            type = 1;
            String msg="";
            msg = "All Customer List";
            if (Request["type"] != null)
            {
                type = Convert.ToInt32(Request["type"]);
                if (type == 2)
                {
                    msg = "All Vendor List";
                }

            }
            if(type==2 || type == 1) {
                int p = 0;
                if (Request["page"] != null)
                {
                    p = Convert.ToInt32(Request["page"]);
                }
                int c = 10;
                if (Request["count"] != null)
                {
                    c = Convert.ToInt32(Request["count"]);
                }
                var u = db.user.Where(h => h.usertype == type && h.status!=-2).OrderBy(h=>h.id).Skip(p*c).Take(c).ToList();
                return new JsonResult { Data = this.Responsedata(true, msg, u) };
            }
            else {
                return new JsonResult { Data = this.Responsedata(false, "Please Enter Valid UserType", 0) };
            }
        }

        [AllowJsonGet]
        public JsonResult getSingleDetails()
        {
            Int32 ID = Convert.ToInt32(Request["id"]);


            var u = db.user.Where(h => h.id == ID).FirstOrDefault();
            return new JsonResult { Data = this.Responsedata(true, "UserDetails", u) };
        }

        [HttpPost]
        public String ProductUploadImage()
        {
            String fileName = "No-image";
            String path = "231232" ;
            String Ext = "jpg";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                 fileName = Path.GetFileName(file.FileName);
                fileName=DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss")+ DateTime.Now.ToString("HHmmss");
                Ext = Path.GetExtension(file.FileName);
                fileName = fileName  + Ext;
                path = Path.Combine(Server.MapPath("~/img/Product"), fileName);
                 this.CreateThumbnail(0,0,"/img/Product/"+ fileName);
                try {
                    file.SaveAs(path);
                }catch(Exception E)
                {
                    
                }
                this.CreateThumbnail(0, 0, "/img/Product/" + fileName);
            }
            return fileName;
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