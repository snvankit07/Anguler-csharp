using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace sweetnes18.AhelperClass
{
    public class ErrorHandling
    {
        public JsonResult SendJson;        
        public ErrorHandling(System.Web.Mvc.ModelStateDictionary m)
        {
            IEnumerable<ModelError> AllErrors = m.Values.SelectMany(v => v.Errors);
            List<string> Error = new List<string>();
            String result = String.Empty;
            foreach (ModelError Errorx in AllErrors)
            {
                Error.Add(Errorx.ErrorMessage);
            }
            this.SendJson = new JsonResult { Data = new { Message = JsonConvert.SerializeObject(Error) , Status = "false" } };
        }
    }
}