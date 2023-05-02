using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MaisLivros.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var url = "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/upx/DadosUpx";
            var httpClient = new HttpClient();

            String resultado = "";

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(content);

                Console.WriteLine(result);

                resultado = result.Count;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

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