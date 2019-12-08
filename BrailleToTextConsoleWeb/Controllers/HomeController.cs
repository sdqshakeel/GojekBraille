using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BrailleToTextConsoleWeb.Models;
using Newtonsoft.Json;

namespace BrailleToTextConsoleWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public string GetEntities(string msg)
        {

            if (string.IsNullOrWhiteSpace(msg))
                return "empty";
            string url = "https://eastus.api.cognitive.microsoft.com/text/analytics/v2.1/entities";
            var body = new
            {
                documents = new[]
                {
                    new {id="1" , text = msg}
                }
            };

            string json = JsonConvert.SerializeObject(body);

            byte[] bytedata = Encoding.UTF8.GetBytes(json);
            var res = "";
            using (var content = new ByteArrayContent(bytedata))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d02a12785c2246d296e6aecdb829eab3");
                    var response = client.PostAsync(url, content).GetAwaiter();
                    res = response.GetResult().Content.ReadAsStringAsync().Result;
                }
            }
            return JsonConvert.DeserializeObject<RootObject2>(res).documents[0].entities[0].type;
        }
        [HttpPost]
        public string GetSentiment(string msg)
        {

            if (string.IsNullOrWhiteSpace(msg))
                return "empty";
            string url = "https://eastus.api.cognitive.microsoft.com/text/analytics/v2.1/sentiment";
            var body = new
            {
                documents = new[]
                {
                    new {id="1" , text = msg}
                }
            };

            string json = JsonConvert.SerializeObject(body);

            byte[] bytedata = Encoding.UTF8.GetBytes(json);
            var res = "";
            using (var content = new ByteArrayContent(bytedata))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d02a12785c2246d296e6aecdb829eab3");
                    var response = client.PostAsync(url, content).GetAwaiter();
                    res = response.GetResult().Content.ReadAsStringAsync().Result;
                }
            }
            return Convert.ToInt32( Math.Round(JsonConvert.DeserializeObject<RootObject2>(res).documents[0].score)) < 1? "Sad" : "Appears happy";
        }
        [HttpPost]
        public string GetLanguage(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
                return "empty";
            string url = "https://eastus.api.cognitive.microsoft.com/text/analytics/v2.1/languages";
            var body = new
            {
                documents = new[]
                {
                    new {id="1" , text = msg}
                }
            };

            string json = JsonConvert.SerializeObject(body);

            byte[] bytedata = Encoding.UTF8.GetBytes(json);
            var res = "";
            using (var content = new ByteArrayContent(bytedata))
            {
                using (var client= new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d02a12785c2246d296e6aecdb829eab3");
                    var response = client.PostAsync(url, content).GetAwaiter();
                    res = response.GetResult().Content.ReadAsStringAsync().Result;
                }
            }
            return JsonConvert.DeserializeObject<RootObject>( res).documents[0].detectedLanguages[0].name;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}