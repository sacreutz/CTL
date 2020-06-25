using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CTLtest1
{
    public class ApiInteractor
    {

        public static async Task<System.IO.Stream> Upload(string actionUrl, string data)
        {
            HttpContent stringContent = new StringContent(data);

            using (var client = new HttpClient())

            {
                //add headers with authorization info
                client.DefaultRequestHeaders.Add("X-Ctl-ClientId", "xxxxxxxxx");
                client.DefaultRequestHeaders.Add("X-Ctl-UserId", "");
                //store api key in web.config ideally
                var response = await client.PostAsync(actionUrl, stringContent);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStreamAsync();
            }
        }
    }
}