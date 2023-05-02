using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class PessoaFisicaMOD
    {
        public String Cpf { get; set; }


        public Boolean VerificarExiste(String Cpf)
        {
            var url = "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/EngenhariaSoftware/UsuarioPessoaFisica?TxCpf=" + Cpf;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Cadastrar(String Cpf, Int32 CdUsuario)
        {
            bool cadastrou = false;

            var client = new HttpClient();

            var conteudoPost = new
            {
                TxCpf = Cpf,
                CdUsuario = CdUsuario
            };

            var conteudo = JsonConvert.SerializeObject(conteudoPost);
            var stringContent = new StringContent(conteudo, System.Text.Encoding.UTF8, "application/json");
            string caminho = "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/EngenhariaSoftware/UsuarioPessoaFisica";
            var resposta = client.PostAsync(caminho, stringContent);
            var resultado = resposta.Result.Content.ReadAsStringAsync();

            return cadastrou;
        }
    }
}
