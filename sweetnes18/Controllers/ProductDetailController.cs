using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Models;
using System.IO;
using sweetnes18.AhelperClass;

namespace Sweetnes18.Controllers
{
    [LaunchingAction]
    public class ProductDetailController : Controller
    {
        private conn db = new conn();

        public ActionResult Product(int? id)
        {

            DatabaseConnection abcd = new DatabaseConnection();
            DataSet dsc = abcd.Select("update [dbo].[Products] set [NumberofVisit]=[NumberofVisit]+1 where [ProductID]=" + id);
            DataSet specf = abcd.Select("select * from [dbo].[ProductMeta] where [ProductTypeKey] like '%specifications%' and [ProductID]=" + id);
            DataSet addi = abcd.Select("select * from [dbo].[ProductMeta] where [ProductTypeKey] like '%AdditionalInformation%' and [ProductID]=" + id);
            DataSet images = abcd.Select("select * from [dbo].[ProductMeta] where [ProductTypeKey] like '%Images%' and [ProductID]=" + id);


            IList<ProductMeta> SpecificationsList = new List<ProductMeta>();
            for (int x = 0; x < specf.Tables[0].Rows.Count; x++)
            {
                SpecificationsList.Add(new ProductMeta()
                {
                    ProductKey =   specf.Tables[0].Rows[x]["ProductKey"].ToString(),
                    ProductValue = specf.Tables[0].Rows[x]["ProductValue"].ToString(),
                });
            }

            IList<ProductMeta> imagesList = new List<ProductMeta>();
            for (int x = 0; x < images.Tables[0].Rows.Count; x++)
            {

                imagesList.Add(new ProductMeta()
                {
                    ProductKey = images.Tables[0].Rows[x]["ProductKey"].ToString(),
                    ProductValue = images.Tables[0].Rows[x]["ProductValue"].ToString(),
                });
            }



            IList<ProductMeta> AdditionalInformation = new List<ProductMeta>();
            for (int x = 0; x < addi.Tables[0].Rows.Count; x++)
            {

                AdditionalInformation.Add(new ProductMeta()
                {
                    ProductKey = addi.Tables[0].Rows[x]["ProductKey"].ToString(),
                    ProductValue = addi.Tables[0].Rows[x]["ProductValue"].ToString(),
                });
            }


            ViewData["Addinfo"] = AdditionalInformation;
            ViewData["Speinfo"] = SpecificationsList;
            ViewData["imginfo"] = imagesList;


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewData["IDS"] = id;
            return View(products);
        }
    }
}
