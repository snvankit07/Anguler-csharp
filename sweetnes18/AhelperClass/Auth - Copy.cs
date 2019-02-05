using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace sweetnes18.AhelperClass
{

    public class Template
    { 
        public String ReplaceText(String data , int i )
        {
            String a = String.Empty; 

            Dictionary<string, string> replacements = new Dictionary<string, string>(){
                {"{username}", "user.username"},
                {"{password}", ""},
            };
            //String[] a = Array("rerw");
            //foreach (string key in replacements.Keys)
            //{
            //    if( data.IndexOf(key) >= 0  )
            //    {
                      
            //    }                
            //}
            //data = data.Replace(key, replacements[key]);
            return data;
        } 
    }
     

}