using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.administrator.Models;
using System.IO;
using sweetnes18.AhelperClass;

namespace sweetnes18.Areas.administrator.Controllers
{
    public class UploadController : Controller
    {
        private conn db = new conn();

        [HttpPost]
        public void ProcessRequest()
        {

            if (ModelState.IsValid)
            {
                
                    string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");

                    if (Request.Files.Count > 0)
                    {

                        HttpPostedFileBase file = Request.Files[0];
                        string CKEditorFuncNum =  Request["CKEditorFuncNum"];
                        CKEditorFuncNum = "1";
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            file.SaveAs(Path.Combine(directory, fileName));  
                            Response.Write("<script type = 'text/javascript'>window.parent.CKEDITOR.tools.callFunction('" + CKEditorFuncNum +
"','" + "http://localhost:59256/images/" + fileName + "','"+"Uploaded"+"');</script>");
                            Response.End();
                            //productimg = Path.Combine(directory, fileName);
                        }
                    }

                 
            }

            Response.Write("<script type = 'text/javascript'>window.parent.CKEDITOR.tools.callFunction('1','','error');</script>");
            Response.End();

        }
        public void ProcessRequest1(HttpContext context)
        {
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = System.IO.Path.GetFileName(uploads.FileName);
            uploads.SaveAs(context.Server.MapPath(".") + "\\Images\\" + file);
            //provide direct URL here
            string url = "http://localhost/CKeditorDemo/" + file;

            context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum +
            ",\"" + url + "\");</script>");
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}