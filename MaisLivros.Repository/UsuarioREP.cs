using MaisLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaisLivros.Repository
{
    public class UsuarioREP
    {

        public Boolean CadastrarUsuario(UsuarioMOD Usuario)
        {
            bool cadastrou = false;

            var client = new HttpClient();

            var conteudo = new StringContent(JsonSerializer.Serialize(Usuario), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/EngenhariaSoftware/MaisLivros");

            request.Content = conteudo;

            var resposta = client.SendAsync(request);

            return cadastrou;


        }

    }
}
