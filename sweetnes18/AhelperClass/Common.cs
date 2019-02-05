using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using sweetnes18.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Globalization;
using sweetnes18.Controllers;

namespace sweetnes18.AhelperClass
{
    public class Common
    {
        IDictionary<string, string> keys = new Dictionary<string, string>();
        private conn db = new conn();
        private int a;
        private CMS Email_data = new CMS();
        private String to;
        private String Subject; 

        public String ChangeDate(String datetime)
        {
            return datetime;
        }
        public static Double ApplyAdminAmountFormula(Double ProductPricing)
        {
            return (( ProductPricing * 8 / 100) + Convert.ToDouble(0.00));
        }


        public static double ApplyPayableAmountFormula(Double ProductPricing, Double Shipping , Double AdminAmount  )
        {
            return ((Convert.ToDouble(ProductPricing) - (Convert.ToDouble(Shipping) + Convert.ToDouble(AdminAmount))) + Convert.ToDouble(0.00));
        }

        public Int32 RegisterShippingStatus(Int32 userID)
        {
            Int32 UID = Convert.ToInt32(userID);
            if (UID > 0)
            {
                var u = db.user.Where(x => x.id == UID).FirstOrDefault();
                if (u != null)
                {
                    u.shipping = Convert.ToInt32(db.Usersmeta.Where(h => h.metakey == "shipvalue" && h.userid == 1).FirstOrDefault().metavalue);
                    db.SaveChanges();
                }
            }
            return userID;
        }

        public String mobliefilter(String MNO)
        {
            if (MNO!=null)
            {
                var  m = MNO[0];
                if (MNO.Length == 10 && MNO.StartsWith("0"))
                {
                    MNO = MNO.Substring(1);
                }
            }
            return MNO;
        }


    }


    public class ShippingCost
    {
        public float C1 = 0; // NormalPrice
        public float C2 = 0;  // same vendor 
        public float C3 = 0; // same city 
        public float C4 = 0;  // Different city
        private conn db = new conn();
 
        public float cost;
        float costing = 0;
        public IEnumerable<CartData> WholCartData;

        public float getcost(int i=1)
        {
            float returndata;
            returndata = costing;

            if (i == 0)
            {
                returndata=(costing-30);
            }
            else
            {
                returndata= costing;
            }

            if(returndata<0)
            {
                returndata = 0;
            }

            return returndata;
        }



        public void Fillcostbyshippingcompany(int shippingcompanyID)
        {
            CompanyRate shippingCompanys = db.CompanyRate.Where(h => h.CID == shippingcompanyID).FirstOrDefault();
            C1 = float.Parse(shippingCompanys.price, CultureInfo.InvariantCulture.NumberFormat); C2 = shippingCompanys.ExtraQuntityprice; C3 = shippingCompanys.SameCity; C4 = shippingCompanys.DifferentCity;
        }
      
        public  ShippingCost(CartObj CO, int shippingcompanyID)
        {
            WholCartData = CO.WholCartData;
            if (shippingcompanyID != 0 )
            {
                Fillcostbyshippingcompany(shippingcompanyID);
                // we will convert to different list 
                List<CartObj> SCO = getSubOrder(CO);


                foreach (var so in SCO )
                {
                    List<List<CartData>> OrderByCityList = OrderByCity(so);
                    int length_OrderCity = OrderByCityList.Count;
                    for (int ct = 0; ct < length_OrderCity; ct = ct + 1)
                    {
                        List<List<CartData>> List_ListByVendor = ListByVendor(OrderByCityList[ct]);
                        int length_OrderByVendor = List_ListByVendor.Count;
                        float differentcity = 0;
                        
                        for ( int V = 0; V < length_OrderByVendor; V = V + 1 )
                        {
                            var temp = List_ListByVendor[V];
                            costing += fx(ref temp , ct,V);
                            List_ListByVendor[V] = temp;
                            WholeCartDataReplace(List_ListByVendor[V]); 
                        }
                       
                    }

                   // 
                }
            }
             
        }


        public void WholeCartDataReplace(List<CartData> eachVendorList )
        {
            int count = WholCartData.ToList().Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < eachVendorList.Count; j++)
                    if(WholCartData.ToList()[i].Product_id == eachVendorList[j].Product_id)
                    WholCartData.ToList()[i].ShippingCost = eachVendorList[j].ShippingCost;
            }
        }




        //Get Cost For Each Order 
        public List<dynamic> getCostForEachOrder(dynamic l1)
        {
            List<dynamic> L1 = new List<dynamic>();
            return L1;
        }
        // we will convert to different list of city 
        public List<CartObj> getSubOrder(CartObj CO)
        { 
            IEnumerable<CartData> l1 = CO.WholCartData;
            List <CartData>data = l1.ToList(); 
            List<CartObj> dataList = new List<CartObj>();
            List<int> remove = new List<int>();
            for ( int or = 0; or < data.Count; or++)
            { 
                if (CO.WholCartData.ToList()[or].Product.IsCustomized > 0)
                {
                    if (CO.WholCartData.ToList()[or].Product.PreperationTime > 0)
                    {
                        List<CartData> C = new List<CartData>();
                        C = CO.WholCartData.ToList();
                        //List<CartData> a = C.WholCartData.ToList(); 
                        C.RemoveAll(product => (product.Product_id != CO.WholCartData.ToList()[or].Product_id));
                        remove.Add(CO.WholCartData.ToList()[or].Product_id);
                        CartObj a = new CartObj();
                        a.WholCartData = C; 
                        dataList.Add(a);
                    }
                }

            }

            remove.ForEach(r=> {
                var temp = CO.WholCartData.Where(product => (product.Product_id != r)).ToList();
                CO.WholCartData = temp;
            });
            //CO.WholCartData.Where(c => remove.Exists(n=>n.Equals(c.Product_id)));
            //var temp = CO.WholCartData.Where(product => (product. CO.WholCartData.ToList()[or].Product_id)).ToList();
           // CO.WholCartData = temp;
            dataList.Add(CO); 
            return dataList;
        }

        public List<List<CartData>> OrderByCity(CartObj order)
        {
            int c = 0;

            List<List<CartData>> ListofCityList = new List<List<CartData>>();
            List<int> termsList = new List<int>();
            List<CartData>  ProductsInOrderList = order.WholCartData.ToList();   // list of product in single list 
            foreach (var perproduct in ProductsInOrderList)
            {
                int city = Convert.ToInt32(perproduct.Vendor.City);
                int index = termsList.IndexOf(city);
                if ( index == -1 )
                {
                    termsList.Add(city);
                    List<CartData> CD = new List<CartData>();
                    CD.Add(perproduct);
                    ListofCityList.Add(CD);  
                }
                else
                { 
                    ListofCityList = addtolist(perproduct, ListofCityList ); 
                }

            }

            return ListofCityList;
        }
 
        public List<List<CartData>> addtolist( CartData  order , List<List<CartData>> ListofCityList)
        { 
            int city = Convert.ToInt32(order.Vendor.City);
            for (int i = 0; i < ListofCityList.Count; i++)
            { 
                if (Convert.ToInt32(ListofCityList[i][0].Vendor.City) == city)
                { 
                    ListofCityList[i].Add(order);
                    return ListofCityList;
                } 
            }
            return ListofCityList;
        }

        public List<List<CartData>> ListByVendor(List<CartData> ct)
        {
            int c = 0;
            List<List<CartData>> ListofVendorList = new List<List<CartData>>();
            List<int> termsList = new List<int>();
            foreach (var x in ct.ToList())
            {
                int vendor_id = Convert.ToInt32(x.Vendor.id);
                int index = termsList.IndexOf(vendor_id);
                if (index == -1)
                {
                    termsList.Add(vendor_id);
                    List<CartData> CD = new List<CartData>();
                    CD.Add(x);
                    ListofVendorList.Add(CD);

                }
                else
                {
                    ListofVendorList = addtoVlist(x, ListofVendorList);
                }
               
            }
            return ListofVendorList;
        }
        public List<List<CartData>> addtoVlist(CartData order, List<List<CartData>> ListofCityList)
        {
            int vendor_id = Convert.ToInt32(order.Vendor.id);
            for (int i = 0; i < ListofCityList.Count; i++)
            {
                if (Convert.ToInt32(ListofCityList[i][0].Vendor.id) == vendor_id)
                {
                    ListofCityList[i].Add(order);
                    return ListofCityList;
                }
            }
            return ListofCityList;
        }

        public float fx(ref List<CartData> productList ,float differentcity , int V)
        {
            float cost = 0;
            float temp;
            for (int i = 0; i < productList.Count; i++)
            {
                if (i == 0)
                {
                    if( V == 0 )
                    {
                        if(differentcity == 0 )
                        {
                            temp = C1 + (productList[i].ProductPurchaseQun - 1) * C2;
                        }
                        else
                        {
                            temp = C4 + (productList[i].ProductPurchaseQun - 1) * C2;
                            differentcity = 0;
                        } 
                    }
                    else
                    {
                        if (differentcity == 0)
                        {
                            temp = C3 + (productList[i].ProductPurchaseQun - 1) * C2;
                        }
                        else
                        {
                            temp = C4 + (productList[i].ProductPurchaseQun - 1) * C2;
                            differentcity = 0;
                        }
                        V = 0;
                    }
                    
                }
                else
                {
                    if (V == 0)
                    {
                        if (differentcity == 0)
                        {
                            temp = C2 + (productList[i].ProductPurchaseQun - 1) * C2;
                        }
                        else
                        {
                            temp = C4 + (productList[i].ProductPurchaseQun - 1) * C2;
                            differentcity = 0;
                        }
                    }
                    else
                    {
                        if (differentcity == 0)
                        {
                            temp = C3 + (productList[i].ProductPurchaseQun - 1) * C2;
                        }
                        else
                        {
                            temp = C4 + (productList[i].ProductPurchaseQun - 1) * C2;
                            differentcity = 0;
                        }
                        V = 0;
                    }
                }

                productList[i].ShippingCost = temp;
                cost += temp;

            }
                  
            return cost;
        }

        public int shippingCalculateFirstTime(int i=1)
        {
            int j = 1;

            if (i > 0)
            {
                var UID = db.ShippingAddress.Where(h => h.Id == i).FirstOrDefault();
                if (UID != null)
                {
                    
                     if (db.user.Where(h => h.id == UID.userid && h.shipping == 1).ToList().Count() > 0)
                    {
                        j = 0;
                    }
                    else {
                        j = 1;
                    }
                }
                else
                {
                    j = 1;
                }
            }
            else {
                j = 1;
            }
            
            return j;
        }

        public String UpdateUserShippingStatus(String userID)
        {
            Int32 UID = Convert.ToInt32(userID);
            if(UID>0)
            { 
            var u = db.user.Where(x => x.id == UID).FirstOrDefault();
                if (u != null) { 
                    u.shipping = 0; 
                    db.SaveChanges();
                }
            }
            return userID;
        }


         


    }
}

