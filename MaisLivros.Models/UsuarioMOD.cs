using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class UsuarioMOD
    {
        public Int32 CdUsuario { get; set; }

        public String TxNome { get; set; }

        public String TxEndereco { get; set; }

        public String TxTelefone { get; set; }

        public String TxLogin { get; set; }

        public String TxSenha { get; set; }

        public String TxEmail { get; set; }

        public String AoAtivo { get; set; }

        public String AoAdmin { get; set; }

        public String links { get; set; }

        public DateTime DtCadastro { get; set; }

        public PessoaFisicaMOD PessoaFisica { get; set; }

        public void getNome(String txNome)
        {
            TxNome = txNome;
        }

        public Boolean getCdUsuarioSequence(String TxEmail)
        {
            var url = "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/EngenhariaSoftware/SeqUsuario";
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


        public UsuarioMOD getUsuario(String TxEmail)
        {
            UsuarioMOD Usuario = new UsuarioMOD();

            var url = "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/EngenhariaSoftware/Usuario?TxEmail=" + TxEmail;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Usuario = JsonConvert.DeserializeObject<UsuarioMOD>(content);
                
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return Usuario;
        }

        public Int32 AutenticarUsuario(String TxEmail, String TxSenha)
        {
            Int32 CdUsuario = 0;
            var url = "https://g309596e50a65a4-upxcidadesinteligentes.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/EngenhariaSoftware/Usuario?TxEmail=" + TxEmail + "&TxSenha=" + TxSenha;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;

            var content = response.Content.ReadAsStringAsync().Result;

            JObject responseJson = JObject.Parse(content);
            CdUsuario = (int)responseJson["cdusuario"];

            return CdUsuario;

        }

    }
}
