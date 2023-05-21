using MaisLivros.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Repository
{
    public class CategoriaREP
    {
        public List<CategoriaDTO> BuscarListaCategoria()
        {
            List<CategoriaDTO> ListaCategoria = new List<CategoriaDTO>();
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/Categoria";
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            JObject json = JObject.Parse(content);
            var items = json["items"];

            ListaCategoria = items.ToObject<List<CategoriaDTO>>();

            return ListaCategoria;

        }
    }
}
