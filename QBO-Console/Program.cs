using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.DataService;
using Intuit.Ipp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using Intuit.Ipp.OAuth2PlatformClient;
using Intuit.Ipp.QueryFilter;

namespace QBO_Console
{
    class Program
    {
        private static String realmId, accessToken, accessTokenSecret, consumerKey, consumerSecret;
        private static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            //var accessToken = GetAccessToken().GetAwaiter().GetResult();
            //Console.WriteLine(accessToken);

            //var code = GetCode().GetAwaiter().GetResult();

            var purchases = GetExpenses(100);

            foreach (var p in purchases)
            {
                Console.WriteLine($"Date: {p.TxnDate} Amt: {p.TotalAmt} Merchant: {p.EntityRef?.name ?? string.Empty}");
            }

            //GetInvoice();

            //var purchases = GetExpenses2(100);

            //foreach (var p in purchases)
            //{
            //    Console.WriteLine($"Date: {p.TxnDate} Amt: {p.TotalAmt} Merchant: {p.EntityRef?.name ?? string.Empty}");
            //}

            Console.ReadLine();
        }
        
        static List<Purchase> GetExpenses(int n)
        {
            consumerKey = "qyprdmVtxDr9NCiZ296Wnw77hon440"; // sandbox
            consumerSecret = "qDd2Y7KM9motf3JqqjbtM58ACP1qDXkhNQUfEMD7"; // sandbox

            realmId = "123146024163879"; // sandbox
            accessToken = "<replace with access token>";
            accessTokenSecret = "<replace with access token secret>";
           
            IntuitServicesType intuitServicesType = IntuitServicesType.QBO;
            OAuthRequestValidator oauthValidator = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret);
            ServiceContext context = new ServiceContext(realmId, intuitServicesType, oauthValidator);
            context.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/";

            DataService dataService = new DataService(context);
            List<Purchase> expenses = dataService.FindAll(new Purchase(), 1, n).ToList();
            return expenses;
        }

        static async Task<string> GetCode()
        {
            //var path = "https://appcenter.intuit.com/connect/oauth2?client_id=Q0MxxCmmzWl9iir93U32zyK1ZloDVktKnbaNP9QIl3d2GTVunh&response_type=code&scope=com.intuit.quickbooks.accounting&redirect_uri=http%3A%2F%2Flocalhost%3A59785%2FDefault.aspx&state=test";

            //HttpResponseMessage response = await client.GetAsync(path);

            //var content = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(content);

            //if (response.IsSuccessStatusCode)
            //{
            //    //product = await response.Content.ReadAsAsync<Product>();
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var path = "https://appcenter.intuit.com/connect/oauth2?client_id=Q0MxxCmmzWl9iir93U32zyK1ZloDVktKnbaNP9QIl3d2GTVunh&response_type=code&scope=com.intuit.quickbooks.accounting&redirect_uri=http%3A%2F%2Flocalhost%3A59785%2FDefault.aspx&state=test&grant_type=client_credentials";
            //Process.Start($"microsoft-edge:{path}");

            ////We need to find the most recent MicrosoftEdgeCP process that is active
            //Process[] edgeProcessList = Process.GetProcessesByName("MicrosoftEdgeCP");
            //Process newestEdgeProcess = null;

            //foreach (Process theprocess in edgeProcessList)
            //{
            //    if (newestEdgeProcess == null || theprocess.StartTime > newestEdgeProcess.StartTime)
            //    {
            //        newestEdgeProcess = theprocess;
            //    }
            //}

            //newestEdgeProcess.WaitForExit();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var path = "https://appcenter.intuit.com/connect/oauth2";
            //client.BaseAddress = new Uri(path);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

            //postData.Add(new KeyValuePair<string, string>("redirect_uri", "http://localhost:59785/Default.aspx"));
            //postData.Add(new KeyValuePair<string, string>("state", "test"));
            //postData.Add(new KeyValuePair<string, string>("response_type","code"));
            //postData.Add(new KeyValuePair<string, string>("scope","com.intuit.quickbooks.accounting"));

            //postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
            //postData.Add(new KeyValuePair<string, string>("client_id", "Q0MxxCmmzWl9iir93U32zyK1ZloDVktKnbaNP9QIl3d2GTVunh"));
            //postData.Add(new KeyValuePair<string, string>("client_secret", "H8wcmdaknPzQBVYyBbDMfy9GHUreVTfE7thzU7WJ"));
            //postData.Add(new KeyValuePair<string, string>("username", "mike.dumlao@neudesic.com"));
            //postData.Add(new KeyValuePair<string, string>("password", "Cl1ft0ncl1ft0n!!!"));

            //FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            //HttpResponseMessage response = await client.PostAsync(path, content);

            //var result = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(result);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            return string.Empty;
        }

        //static string GetAccessToken()
        //{
        //    //NameValueCollection appSettings = WebConfigurationManager.AppSettings;

        //    string requestUrl = "https://consent.live.com/AccessToken.aspx";

        //    // Request the access token.
        //    string postData = string.Format("{0}?wrap_client_id={1}&wrap_client_secret={2}&wrap_callback={3}&wrap_verification_code={4}&idtype={5}",
        //            requestUrl,
        //            appSettings["wll_appid"],
        //            appSettings["wll_secret"],
        //            "http://www.fabrikam.com",
        //            verificationCode,
        //            "CID");
        //    byte[] postDataEncoded = System.Text.Encoding.UTF8.GetBytes(postData);

        //    WebRequest req = HttpWebRequest.Create(requestUrl);
        //    req.Method = "POST";
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.ContentLength = postDataEncoded.Length;

        //    Stream requestStream = req.GetRequestStream();
        //    requestStream.Write(postDataEncoded, 0, postDataEncoded.Length);

        //    WebResponse res = req.GetResponse();

        //    string responseBody = null;

        //    using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
        //    {
        //        responseBody = sr.ReadToEnd();
        //    }

        //    // Process FORM POST.
        //    //NameValueCollection responseCollection = System.Web.HttpUtility.ParseQueryString(responseBody);

        //    //return responseCollection["wrap_access_token"];

        //    return string.Empty;
        //}

        static async Task<string> GetAccessToken()
        {
            var code = "Q0115241858129ngIkecrd7o2j3amfKx4hOscJvpdiX3lxDzno";
            var tokenEndpoint = "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer";
            var clientId = "Q0MxxCmmzWl9iir93U32zyK1ZloDVktKnbaNP9QIl3d2GTVunh";
            var clientSecret = "H8wcmdaknPzQBVYyBbDMfy9GHUreVTfE7thzU7WJ";
            var redirectUri = "http://localhost:59785/Default.aspx";

            var tokenClient = new TokenClient(tokenEndpoint, clientId, clientSecret);

            TokenResponse accesstokenCallResponse = await tokenClient.RequestTokenFromCodeAsync(code, redirectUri);

            return accesstokenCallResponse.AccessToken ?? "null access token";
        }

        static void GetInvoice()
        {
            var access_token = "eyJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwiYWxnIjoiZGlyIn0..LwSTn4HRGxVVQwYR8gCKCA.CgUGG49Xm9AL33-FLxErp8PCWysuLdVhWKVWOsXAdD32ogoZws0hwicnQwgoeI_NuBPOZsEv-TjFxDMblx42udGfW74bfAb9JUr9m94miOSPCuZGsw7LlnOaAEXp4JHQka8SEStVWlGQ_3jGzwygIyaoVF9QmVuExfFBnE0ZXG1AEatZscqLke_BAq-hyi_8hIm5JihrUpVq6qHXfp6XotH4ucakDC8z4U-KORYSVYWgRStQFQy9W2z_-hA1xg-kA1j3vMP4UkfE0292ORpPp_NU-__ZnRyj42OMP71pjTZpCB87dWXPZX9Vt8P7icxnaYQ2ZQL_z_VxDFbRnlOCzxwN7e6ukmZLbo7FTsZjuIgevYE46dF7cHwWJKqnRTsL7addty6DXcscOoM_q5qswlz8So_Klrnn6xNZVcJpF20QdKMK01GPDRyDBciAS1kq-U8CvESKa13F_LKM7_c-6Lmmw0OdMlomLRSc_ljwpuooQmI6GcAl-RZkoiuLR7UtFgdk6L0X99triME1aggWo5hZ0iMPNuUj9SHd-gMMvQl4IyqcZ7MAqNkxVeEDxkPUsgAiHX78eEHBkcfYhrxBEaTf6NEoztKrV8NaATJkLFEifwqy_xc2gKLZdoVpD0t787VDiMhGvlOFi_fSdSPrCrucU0jPR2zhKzfnXjNasXYP3RdxngRtlNO8GGuMvvqf.havdNFIRyLJ2ocADbZtpdg";
            realmId = "123146024163879";
            OAuth2RequestValidator oauthValidator = new OAuth2RequestValidator(access_token);

            ServiceContext serviceContext = new ServiceContext(realmId, IntuitServicesType.QBO, oauthValidator);
            serviceContext.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/";//sandbox
                                                                                                       //serviceContext.IppConfiguration.BaseUrl.Qbo = "https://quickbooks.api.intuit.com/";//prod

            serviceContext.IppConfiguration.Message.Request.SerializationFormat = Intuit.Ipp.Core.Configuration.SerializationFormat.Xml;
            serviceContext.IppConfiguration.Message.Response.SerializationFormat = Intuit.Ipp.Core.Configuration.SerializationFormat.Xml;
            serviceContext.IppConfiguration.MinorVersion.Qbo = "8";
            
            //serviceContext.IppConfiguration.Logger.RequestLog.EnableRequestResponseLogging = true;
            //serviceContext.IppConfiguration.Logger.RequestLog.ServiceRequestLoggingLocation = @"C:\Users\nshrivastava\Documents\Logs";
            //serviceContext.RequestId = "897kjhjjhkh9";

            DataService commonServiceQBO = new DataService(serviceContext);
            Intuit.Ipp.Data.Item item = new Intuit.Ipp.Data.Item();
            List<Item> results = commonServiceQBO.FindAll<Item>(item, 1, 1).ToList<Item>();
            QueryService<Invoice> inService = new QueryService<Invoice>(serviceContext);
            Invoice In = inService.ExecuteIdsQuery("SELECT * FROM Invoice").FirstOrDefault();
        }

        static List<Purchase> GetExpenses2(int n)
        {
            var access_token = "eyJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwiYWxnIjoiZGlyIn0..LwSTn4HRGxVVQwYR8gCKCA.CgUGG49Xm9AL33-FLxErp8PCWysuLdVhWKVWOsXAdD32ogoZws0hwicnQwgoeI_NuBPOZsEv-TjFxDMblx42udGfW74bfAb9JUr9m94miOSPCuZGsw7LlnOaAEXp4JHQka8SEStVWlGQ_3jGzwygIyaoVF9QmVuExfFBnE0ZXG1AEatZscqLke_BAq-hyi_8hIm5JihrUpVq6qHXfp6XotH4ucakDC8z4U-KORYSVYWgRStQFQy9W2z_-hA1xg-kA1j3vMP4UkfE0292ORpPp_NU-__ZnRyj42OMP71pjTZpCB87dWXPZX9Vt8P7icxnaYQ2ZQL_z_VxDFbRnlOCzxwN7e6ukmZLbo7FTsZjuIgevYE46dF7cHwWJKqnRTsL7addty6DXcscOoM_q5qswlz8So_Klrnn6xNZVcJpF20QdKMK01GPDRyDBciAS1kq-U8CvESKa13F_LKM7_c-6Lmmw0OdMlomLRSc_ljwpuooQmI6GcAl-RZkoiuLR7UtFgdk6L0X99triME1aggWo5hZ0iMPNuUj9SHd-gMMvQl4IyqcZ7MAqNkxVeEDxkPUsgAiHX78eEHBkcfYhrxBEaTf6NEoztKrV8NaATJkLFEifwqy_xc2gKLZdoVpD0t787VDiMhGvlOFi_fSdSPrCrucU0jPR2zhKzfnXjNasXYP3RdxngRtlNO8GGuMvvqf.havdNFIRyLJ2ocADbZtpdg";
            realmId = "123146024163879";
            OAuth2RequestValidator oauthValidator = new OAuth2RequestValidator(access_token);

            ServiceContext serviceContext = new ServiceContext(realmId, IntuitServicesType.QBO, oauthValidator);
            serviceContext.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/";//sandbox
                                                                                                       //serviceContext.IppConfiguration.BaseUrl.Qbo = "https://quickbooks.api.intuit.com/";//prod

            serviceContext.IppConfiguration.Message.Request.SerializationFormat = Intuit.Ipp.Core.Configuration.SerializationFormat.Xml;
            serviceContext.IppConfiguration.Message.Response.SerializationFormat = Intuit.Ipp.Core.Configuration.SerializationFormat.Xml;
            serviceContext.IppConfiguration.MinorVersion.Qbo = "8";

            DataService dataService = new DataService(serviceContext);
            List<Purchase> expenses = dataService.FindAll(new Purchase(), 1, n).ToList();

            return expenses;
        }
    }
}