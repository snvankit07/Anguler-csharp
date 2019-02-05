using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace sweetnes18.Models
{
    [Table("Language")]
    public class Language
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        public String Keys { get; set; }

        public String en { get; set; }

        public String ar { get; set; }

    } 

    [Table("countries")]
    public class countries
    {
        [Key]
        public int id { get; set; }
        public String sortname { get; set; }
        public String name { get; set; }
        public int phonecode { get; set; }
        
    }

    [Table("states")]
    public class states
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public int country_id { get; set; }
    }

    [Table("cities")]
    public class cities
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public int state_id { get; set; }
    }


    [Table("CMS")]
    public class CMS
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }
        [Display(Name = "Page Title")]
        public String PageTitle { get; set; }
        [AllowHtml]
        [Display(Name = "Page Description")]
        public String PageDec { get; set; }
        [Display(Name = "Page Status")]
        public int PageStatus { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public DateTime UpdateDate { get; set; }
    }


    [Table("CustomerProfile")]
    public class CustomerProfile
    {
        [Key]
        [Column(Order = 1)]
        public int CustomerID { get; set; }
        
        [Display(Name = "CustomerFullName")]
        public String CustomerFullName { get; set; }
        [Display(Name = "Billing Address")]
        public String CustomerBillingAdd { get; set; }
        [Display(Name = "Shipping Address")]
        public String CustomerShippingAdd { get; set; }
        [Display(Name = "Customer Email")]
        public String CustomerEmailID { get; set; }
        [Display(Name = "Mobile Number")]
        public String CustomerMobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    [Table("EmailTemplates")]
    public class EmailTemplates
    {
        [Key]
        [Column(Order = 1)]
        public int TemplateId { get; set; }
        [AllowHtml]
        [Display(Name = "Template Name")]
        public String TemplateName { get; set; }
        [AllowHtml]
        [Display(Name = "Template Data")]
        public String TemplateData { get; set; }
        [Display(Name = "Notification Type")]
        public String NotificationType { get; set; }
        [NotMapped]
        public String CreatedDate { get; set; }
        [NotMapped]
        public String UpdateDate { get; set; }
    }


    [Table("Event")]
    public class Event
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }
        [Display(Name = "Start Date")]
        public String StartDate { get; set; }
        [Display(Name = "End Date")]
        public String EndDate { get; set; }
        [AllowHtml]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Status")]
        public int status { get; set; }
        [NotMapped]
        public int UserID { get; set; }
        [NotMapped]
        public String CreatedDate { get; set; }
        [NotMapped]
        public String UpdateDate { get; set; }
    }

    [Table("Order")]
    public class Order
    {
        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }
        [Display(Name = "Shipping Address")]
        public String Shipping { get; set; }
        [Display(Name = "Billing Address")]
        public String Billing { get; set; }
        [Display(Name = "Transaction Id")]
        public String TransactionId { get; set; }
        [Display(Name = "Mode Of Payment")]
        public String ModeOfPayment { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime UpdateDate { get; set; }
        
        public String orderDetail { get; set; } 
        public String userID { get; set; }
        public int orderstatus { get; set; }
        public int customerID { get; set; }
        public int reviews { get; set; }
        public int TransactionIdPayment { get; set; }
    }

    [Table("ProductBrand")]
    public class ProductBrand
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Brand Name")]
        public String BrandName { get; set; }
        [Display(Name = "Brand Slug")]
        public String Brandslug { get; set; }
        [Display(Name = "Brand Image")]
        public String BrandImage { get; set; }
        [Display(Name = "Brand Background Image")]
        public String BrandBgImage { get; set; }
        public int BrandStatus { get; set; }
        public int UserID { get; set; }
        public DateTime Createddate { get; set; } 
        public DateTime UpdateDate { get; set; }
    }

    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Category Name")]
        public String CategoryName { get; set; }
        [Display(Name = "Category Slug")]
        public String CategorySlug { get; set; }
        [Display(Name = "Parent Category")]
        public String ParentCategoryID { get; set; } 
        public String CategoryImage { get; set; }
        public String CategoryImg { get; set; }
        public int UserID { get; set; }
        [Display(Name = "Category Status")]
        public int CategoryStatus { get; set; } 
        public DateTime Createddate { get; set; } 
        public DateTime UpdateDate { get; set; }
    }

    [Table("ProductMeta")]
    public class ProductMeta
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Product Type Key")]
        public String ProductTypeKey { get; set; }
        [Display(Name = "Product Key")]
        public String ProductKey { get; set; }
        [AllowHtml]
        [Display(Name = "Key Value")]
        public String ProductValue { get; set; }
        [NotMapped]
        public String Createddate { get; set; }
        [NotMapped]
        public String UpdateDate { get; set; }
    }



    [Table("ProductOffer")]
    public class ProductOffer
    {
        [Key]
        [Display(Name = "Offer ID")]
        public int OfferID { get; set; }
        [Display(Name = "Offer Title")]
        public string OfferTitle { get; set; }
        [Display(Name = "Offer Product")]
        public int productID { get; set; }
        [Display(Name = "Offer Code")]
        public String OfferCode { get; set; }
        [Display(Name = "Offer Type")]
        public String OfferType { get; set; }
        [Display(Name = "Offer Amount")]
        public String OfferAmount { get; set; }
        [Display(Name = "Offer Start Date")]
        public String OfferStartDate { get; set; }
        [Display(Name = "Offer Description")]
        public String OfferDescription { get; set; }
        [Display(Name = "Offer End Date")]
        public String OfferEndDate { get; set; }
        [Display(Name = "Add User")]
        public int OfferAddUserID { get; set; }
        [Display(Name = "Offer Status")]
        public String OfferStatus { get; set; }
        [NotMapped]
        public String Createddate { get; set; }
        [NotMapped]
        public String UpdateDate { get; set; }
        [Display(Name = "Offer Type")]
        public String OfferUseType { get; set; }
        [Display(Name = "Offer Uses Count")]
        public int numberofuse { get; set; }
    }



    [Table("ProductReview")]
    public class ProductReview
    {
        [Key]
        [Display(Name = "Review ID")]
        public int ReviewID { get; set; }
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Product ID")]
        public String Token { get; set; }
        [Display(Name = "Star Rating")]
        public int StarRating { get; set; }
        public int StarRatingdelivery { get; set; }
        [Display(Name = "Review Messages")]
        public String Reviewmsg { get; set; }
        [NotMapped]
        public String Createddate { get; set; }
        [NotMapped]
        public String UpdateDate { get; set; }
    }

    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public String ProductTitle { get; set; }
        [AllowHtml]
        public String ProductDec { get; set; }
        public String ProductSalePrice { get; set; }
        public String ProductRegulerPrice { get; set; }
        public int ProductQun { get; set; }
        public String SKU { get; set; }
        public String productimage { get; set; }
        public String productimg { get; set; }
        public int CatID { get; set; }
        public int UserID { get; set; }
        public int BrandID { get; set; }
        public int productStatus { get; set; } 
        public DateTime CreatedDate { get; set; }
        
        public DateTime UpdateDate { get; set; }
        public int NumberofVisit { get; set; }
        public int adminoffer { get; set; }
        public int vendoroffer { get; set; }
        public String ActualAmount { get; set; }
        public int IsCustomized { get; set; }
        public int PreperationTime { get; set; }
    }
     


    [Table("ProductWishlist")]
    public class ProductWishlist
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        
    }



    [Table("user")]
    [FluentValidation.Attributes.Validator(typeof(userValidator))]
    public class user
    {
        [Key]
        [Column(Order = 1)]
        public int id { get; set; }
        public String fname { get; set; }
        public String lname { get; set; }
        public String password { get; set; }
        public String mobileno { get; set; }
        public int status { get; set; }
        public int usertype { get; set; }
        public String username { get; set; }
        public String Country { get; set; } 
        public String State { get; set; }
        public String City { get; set; }
        public String Postalcode { get; set; }
        public String billing { get; set; }
        public int shipping { get; set; }
        
        public String mobiletoken { get; set; }
        public String devicetype { get; set; }
         
        public DateTime Createddate { get;  } 
        public DateTime UpdateDate { get;  }
    }

    [Table("Usersmeta")]
    public class Usersmeta
    {
        [Key]
        [Column(Order = 1)]
        public int id { get; set; }
        public int userid { get; set; }
        public String metakey { get; set; }
        public String metavalue { get; set; }
        [NotMapped]
        public String Createddate { get; set; }
        [NotMapped]
        public String UpdateDate { get; set; }
    }




    [Table("Product_coupons")]
    public class Product_coupons
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public String ProductCouponCode { get; set; }
        public String ProductCouponDec { get; set; }
        public int ProductOffterType { get; set; }
        public String ProductOffetAmount { get; set; }
    }
    /*
    
            [Id]          INT           NOT NULL,
    [Token]       VARCHAR (50)  NULL,
    [ProductID]   INT           NULL,
    [Rating]      INT           NULL,
    [userID]      INT           NULL,
    [Createddate] DATETIME2 (7) DEFAULT (getdate()) NULL,
    [updatedate]  DATETIME2 (7) DEFAULT (getdate()) NULL,
        
        */

    [Table("Rating")]
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        public String Token { get; set; }
        public int ProductID { get; set; }
        public int RatingPoint { get; set; }
        public int userID { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime updatedate { get; }
    }
    [Table("ProductBundle")]
    public class ProductBundle
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public String OrderSummary { get; set; }
        public Double ProductPricing { get; set; }
        public String ProductOrderID { get; set; }
        public int ShippingCompanyID { get; set; }
        public int VendorID { get; set; }
        public int OrderID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime updatedate { get; set; }
        public int payable { get; set; }
        public int pickanddeliverStatus { get; set; }
        public int cancelby { get; set; }
        public String cancelMsg { get; set; }
        public String cancelImage { get; set; }
        public int iscustomization { get; set; }
        public String customizationmsg { get; set; }
        public String customizationImage { get; set; }
    }
    [Table("MoneyRecord")]
    public class MoneyRecord
    {
        [Key]
        public int Id { get; set; }
        public String Payment { get; set; }
        public Double VendorID { get; set; }
        public DateTime CreatedDate { get; }
    }

    [Table("PaymentgatewayData")]
    public class PaymentgatewayData
    {
        [Key]
        public int ID { get; set; }
        public String Gatewaydata { get; set; }
        
    }

    [Table("Company")]
    public class Company
    {
        [Key]
        public int ID { get; set;  }
        public String name { get; set; }
        public String logo { get; set; }
        public String description { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public String shippingemail { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime updatedate { get; }
    }

    [Table("CompanyRate")]
    public class CompanyRate
    {
        [Key]
        public int ID { get; set; }
        public int CID { get; set; }
        public int sourcecode { get; set; }
        public String source { get; set; }
        public int destinationcode { get; set; }
        public String destination { get; set; }
        public String price { get; set; }
        public int ExtraQuntityprice { get; set; }
        public int SameCity { get; set; }
        public int DifferentCity { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime updatedate { get; }
    }


    [Table("ShippingAddress")]
    public class ShippingAddress
    {
        [Key]
        public int Id { get; set; }

        public int userid { get; set; }

        public int City { get; set; }

        public String Fname { get; set; }
        public String Lname { get; set; }
        public String StreetName { get; set; }

        public String BuildingName { get; set; }

        public String Location { get; set; }

        public String Mobile { get; set; }
        public String email { get; set; }
        public String ShoppingNote { get; set; }
        public String CityName { get; set; }
        public String Address { get; set; }
        public int status { get; set; }
    }


    public class conn : DbContext
    {
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<cities> cities { get; set; }
        public DbSet<PaymentgatewayData> PaymentgatewayData { get; set; }
        public DbSet<countries> countries { get; set; }
        public DbSet<states> states { get; set; }
        public DbSet<ProductOffer> ProductOffer { get; set; }

        public DbSet<ProductMeta> ProductMeta { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<Usersmeta> Usersmeta { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductWishlist> ProductWishlist { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<conn>(null);
            base.OnModelCreating(modelBuilder);
        } 

        public System.Data.Entity.DbSet<sweetnes18.Models.CMS> CMS { get; set; }
        public System.Data.Entity.DbSet<sweetnes18.Models.CustomerProfile> CustomerProfiles { get; set; }
        


        public System.Data.Entity.DbSet<sweetnes18.Models.EmailTemplates> EmailTemplates { get; set; }
        public System.Data.Entity.DbSet<sweetnes18.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<sweetnes18.Models.Rating> Rating { get; set; }
        public System.Data.Entity.DbSet<sweetnes18.Models.ProductBundle> ProductBundle { get; set; }
        public System.Data.Entity.DbSet<sweetnes18.Models.MoneyRecord> MoneyRecord { get; set; }
        public System.Data.Entity.DbSet<sweetnes18.Models.Language> Language { get; set; }


        public System.Data.Entity.DbSet<sweetnes18.Models.Company> Company { get; set; }
        public System.Data.Entity.DbSet<sweetnes18.Models.CompanyRate> CompanyRate { get; set; }








    }
}
