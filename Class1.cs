using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public class Class1
    {
        public static string token()
        {
            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", "e8a37aca-bd40-46e1-a333-95ab0437150f"),
                    new KeyValuePair<string, string>("client_secret", "xThGr~TG7VI.4aXhie9cZQJKY.5TC8kd0_"),
                    new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"),
                    new KeyValuePair<string, string>("userName", "Vikram@hardikpatil3333gmail.onmicrosoft.com"),
                    new KeyValuePair<string, string>("password", "Hardik1997")

                });

                HttpResponseMessage response = client.PostAsync(
                    "https://login.microsoftonline.com/b1ecd08f-82d3-4841-b5f2-0d1826ea598c/oauth2/v2.0/token",
                    requestContent).Result;

                HttpContent responseContent = response.Content;
                //System.Diagnostics.Debug.WriteLine(responseContent.ReadAsStringAsync().Result);
                string Response = responseContent.ReadAsStringAsync().Result;
                TokenResponse tr = JsonConvert.DeserializeObject<TokenResponse>(Response);
                var AccessToken = tr.access_token;
                //System.Diagnostics.Debug.WriteLine(AccessToken);
                return AccessToken;
            }
        }
            public class TokenResponse
            {
                public string access_token { get; set; }
            }    
    }
}

    