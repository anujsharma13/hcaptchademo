using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace hcaptchademo.Models
{
    public class GoogleCaptchaService
    {
        public async Task<bool> verifycaptcha(string _Token)
        {
            
            using(var client = new HttpClient())
            {
              var values=new Dictionary<string, string>
                {
                  { "response" , _Token },
                  { "secret" , "0x0000000000000000000000000000000000000000" }
                };
                var content = new FormUrlEncodedContent(values);
                var verify = await client.PostAsync("https://hcaptcha.com/siteverify", content);
                var captcharesponsejson=await verify.Content.ReadAsStringAsync();
                var captcharesult=JsonConvert.DeserializeObject<GoogleCaptchaRespo>(captcharesponsejson);
                return captcharesult.success;
            }
        }
    }

    public class GoogleCaptchaData
    {
        public string response { get; set; }
        public string secret { get; set; }
    }
    public class GoogleCaptchaRespo
    {
        public bool success { get; set; }
        public double score { get; set; }
        public string action { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
    }
}
