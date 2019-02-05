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
    public class Credentialsnew
    {
        public string apiOperation { get; set; }
        public orderjson order { get; set; }
        public customerdata customer { get; set; }
    }
    public class Credentials
    {
        public string apiOperation { get; set; }
        public sourceOfFundsC sourceOfFunds { get; set; }
        public orderjson order { get; set; }
    }

    public class sourceOfFundsC
    {        
        public string type { get; set; }     
        public providedC provided { get; set; }
    }
    public class providedC
    {        
        public cardC card { get; set; }
    }

    public class cardC
    {        
        public string number { get; set; }
       
        public expiryC expiry { get; set; }
      
        public Int32 securityCode { get; set; }
    }
    public class customerdata {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobilePhone { get; set; }
    }
    public class expiryC
    {
        public Int32 month { get; set; }
        public Int32 year { get; set; }
    }
    public class orderjson
    {
        public String id { get; set; }
        public String amount { get; set; }
        public String currency { get; set; }
    }
    /*-----------------Result--------*/
    public class Result
    {
        public authorizationResponse authorizationResponse { get; set; }
        public String gatewayEntryPoint { get; set; }
        public String merchant { get; set; }
        public OrderData order { get; set; }
        public Response response { get; set; }
        public String result { get; set; }
        public String risk { get; set; }
        public String sourceOfFunds { get; set; }
        public String timeOfRecord { get; set; }
        public String transaction { get; set; }
        public String version { get; set; }
    }
   public class authorizationResponse {
        public String cardSecurityCodeError { get; set; }
        public String commercialCard { get; set; }
        public String commercialCardIndicator { get; set; }
        public String financialNetworkCode { get; set; }
        public String processingCode { get; set; }
        public String responseCode { get; set; }
        public String stan { get; set; }
        public String transactionIdentifier { get; set; }
    }
    public class OrderData {
        public String amount { get; set; }
        public chargeback chargeback { get; set; }
        public String creationTime { get; set; }
        public String currency { get; set; }
        public String fundingStatus { get; set; }
        public String id { get; set; }
        public String merchantCategoryCode { get; set; }
        public String status { get; set; }
        public String totalAuthorizedAmount { get; set; }
        public String totalCapturedAmount { get; set; }
        public String totalRefundedAmount { get; set; }
    }
    public class chargeback {
        public String amount { get; set; }
        public String currency { get; set; }
    }
    public class Response {
        public String acquirerCode { get; set; }
        public String acquirerMessage { get; set; }
        public CardSecurityCode cardSecurityCode { get; set; }
        public String gatewayCode { get; set; }
        public String gatewayRecommendation { get; set; }
    }
    public class CardSecurityCode
    {
        public String acquirerCode { get; set; }
        public String gatewayCode { get; set; }
    }
    /*-----------------Result--------*/

    public class Payment
    {

        public async Task<String> PaymentMethod(String Url, String username, String password, String CardNO= "5123450000000008", Int32 MONTH=05, Int32 YEAR=21, Int32 CVV=100, Double AMOUNT=20.50,String CURR="AED")
        {
            String data;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));

            var payload = new Credentials
            {
                apiOperation = "PAY",
                sourceOfFunds = new sourceOfFundsC
                {
                    type = "CARD",
                    provided = new providedC
                    {
                        card = new cardC
                        {
                            number = CardNO,
                            expiry = new expiryC
                            {
                                month = MONTH,
                                year = YEAR
                            },
                            securityCode = CVV
                        },
                    },
                },


                order = new orderjson
                {

                    amount = AMOUNT.ToString(),
                    currency = CURR
                }

            };

            // Serialize our concrete class into a JSON String
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(payload));
            
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var requestContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; 

            // Get the response.
            HttpResponseMessage httpResponseMessage = await client.PutAsync(Url, requestContent);
            HttpResponseMessage response = httpResponseMessage;

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                data = (await reader.ReadToEndAsync());
            }

            return data; 
        }
        public async Task<String> PaymentMethodSession(String Url, String username, String password, String Order = "5123450000000008",Double AMOUNT=0.00,String CURR = "AED", String EMAIL = "hr@snvinfotech.com", String PHONE = "9755185946", String FNAME = "Test", String LNAME = "Test")
        {
            String data;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));

            var payload = new Credentialsnew
            {
                apiOperation = "CREATE_CHECKOUT_SESSION",
                order = new orderjson
                {
                    id = Order,
                    amount = AMOUNT.ToString(),
                    currency = CURR
                },
                customer = new customerdata
                {
                    firstName = FNAME,
                    lastName=LNAME,
                    email= EMAIL,
                    mobilePhone= PHONE
                }

            };

            // Serialize our concrete class into a JSON String
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(payload));

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var requestContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; 

            // Get the response.
            HttpResponseMessage httpResponseMessage = await client.PostAsync(Url, requestContent);
            HttpResponseMessage response = httpResponseMessage;

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                data = (await reader.ReadToEndAsync());
            }

            return data;
        }


    }
}
    
