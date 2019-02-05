using System;

using Newtonsoft.Json;

using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace sweetnes18.AhelperClass
{
    public class Mobilemsg
    {

        public String  MobileM(String Msg= "test",String Mobile="9584374747", Boolean Flag= false)
        {
            
            String apikey = "d10d50ed-2246-4fd2-9f90-45fda501db6f";
            String clientid = "561d579e-3c45-4881-a002-43804ca7d732";

            String sNumber = "971";
            if (Flag == false)
            {
                sNumber = "971";
            }
            else {
                sNumber = "91";
            }
            sNumber = sNumber + Mobile;
            String SIDs = "SMS+Alert";
            String sMessage = Msg;
            String sURL = "https://my.forwardvaluesms.com/vendorsms/pushsms.aspx?apikey=" + apikey + "&clientid=" + clientid + "&msisdn=" + sNumber + "&sid="+ SIDs + "&msg=" + sMessage + "&fl=0&JobId=123";
            String sResponse = GetResponse(sURL);
            return sResponse;
        }
        public static String GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            String sResponse = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            if (sResponse == null)
            {
                sResponse = 1.ToString();
            }
            return sResponse;

        }

    }
}
    
