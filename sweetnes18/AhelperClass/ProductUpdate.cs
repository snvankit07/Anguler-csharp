using System;
using System.Linq;
using System.Data;
using sweetnes18.Models;
using System.Collections.Generic;

namespace sweetnes18.AhelperClass
{
    public class ProductUpdate
    {
        private conn db = new conn();


        public ProductUpdate() {
            this.productupdateP();
        }

        public void productupdate(int i = 0)
        { }
            public void productupdateP(int i=0)
        {
            int BID;
            int CID;
            List<Products> Productd;
            if (i == 0)
            {
                Productd = db.Products.Where(h => h.productStatus != -2).ToList();
            }
            else {
                Productd = db.Products.Where(h=>h.ProductID==i && h.productStatus!=-2).ToList();
            }
            foreach (Products Vp in Productd)
            {

                var Pro = db.Products.Where(h => h.ProductID == Vp.ProductID).FirstOrDefault();
                Decimal offer = (Pro.adminoffer + Pro.vendoroffer);
                if (offer > 0 && offer <= 100)
                {
                    Pro.ProductSalePrice = Pro.ActualAmount;
                    Pro.ProductRegulerPrice = Convert.ToString(Convert.ToDecimal(Pro.ActualAmount) - ((Convert.ToDecimal(Pro.ActualAmount) * Convert.ToDecimal(offer)) / 100));
                }
                else
                {
                    Pro.ProductSalePrice = 0.ToString();
                    Pro.ProductRegulerPrice = Pro.ActualAmount;
                }
                BID = Pro.BrandID;
                CID = Pro.CatID;
                if (Pro.productStatus != -2)
                {
                    if (Pro.ActualAmount == null)
                    {
                        Pro.productStatus = -2;
                    }
                    else if (db.ProductBrand.Where(h => h.ID == BID).FirstOrDefault().BrandStatus != 1)
                    {
                        Pro.productStatus = 0;
                    }
                    else if (db.ProductCategory.Where(h => h.ID == CID).FirstOrDefault().CategoryStatus != 1)
                    {
                        Pro.productStatus = 0;
                    }
                    else if (db.user.Where(h => h.id == Pro.UserID).FirstOrDefault().status != 1)
                    {
                        Pro.productStatus = 0;
                    }
                    else if (Pro.ProductQun <= 0)
                    {
                        Pro.productStatus = 0;
                    }

                    else if (Convert.ToInt32(db.user.Where(h => h.id == Pro.UserID).FirstOrDefault().City) == 0)
                    {
                        Pro.productStatus = 0;
                    }
                    else
                    {
                        Pro.productStatus = 1;
                    }
                    db.SaveChanges();
                }
            }
        }
        public void UpdateProductMeta(int productID, String ProductKey,String ProductTypeKey,String ProductValue)
        {
            ProductMeta pm = new ProductMeta();

            pm.ProductID = productID;
            pm.ProductKey = ProductKey;
            pm.ProductTypeKey = ProductTypeKey;
            pm.ProductValue = ProductValue;
            db.ProductMeta.Add(pm);
            db.SaveChanges();

        }

        public bool DeleteProductMeta(Int32 ID)
        {
            List<ProductMeta> m1 = new List<ProductMeta>();
            m1 = db.ProductMeta.Where(u => u.ProductID == ID).ToList();
            foreach (var mbox in m1)
            {
                db.ProductMeta.Remove(mbox);
            }
            db.SaveChanges();
            return true;
        }
    }
}
    
