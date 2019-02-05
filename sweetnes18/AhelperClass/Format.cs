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

namespace sweetnes18.AhelperClass
{ 
    public class Format
    { 
        IDictionary<string, string> keys = new Dictionary<string, string>(); 
        private conn db = new conn();
        private int a;
        private CMS Email_data = new CMS();
        private String to;
        private String Subject;

        public String LanguageCh(String data) {
            data = data.Trim();
            return data;
        }


  




        public Format(int a , IDictionary<string, string> keys ,String to )
        {
            this.a = a;
            this.to = to;
            this.Subject = "";
            if (String.IsNullOrEmpty(this.to) || String.IsNullOrWhiteSpace(this.to))
            {
                this.Subject = "Email Id Blank";
                this.to = "snv.ankit@gmail.com";
            }
            this.keys = keys;
            this.Email_data = this.Formaxt();
            this.Email();
        }

        public CMS Formaxt()
        {
            String[] key_list = { };
            var temp = db.user;
            CMS res = db.CMS.Where(x => x.ID == this.a).First();
            foreach (KeyValuePair<string,string> key in this.keys)
            {
                res.PageTitle = res.PageTitle.Replace(key.Key, key.Value);
                res.PageDec = res.PageDec.Replace(key.Key , key.Value );
            } 
            return res;
        }

        public JsonResult Email()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("snv.ankit@gmail.com", "ANKIT@123"); 
            MailMessage mm = new MailMessage("snv.ankit@gmail.com", this.to , this.Email_data.PageTitle+" "+this.Subject, this.Email_data.PageDec );
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.IsBodyHtml = true; 
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
            String json = String.Empty;
            json = JsonConvert.SerializeObject(json);
            return new JsonResult { Data = json }; 
        }

    }
}
    
