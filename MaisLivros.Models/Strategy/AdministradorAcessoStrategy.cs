using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.Strategy
{
    public class AdministradorAcessoStrategy : IAcessoStrategy
    {
        private readonly string emailUsuario;

        public AdministradorAcessoStrategy(string emailUsuario)
        {
            this.emailUsuario = emailUsuario;
        }

        public bool VerificarAcesso()
        {
            int nivelAcesso = ObterNivelAcesso();
            return nivelAcesso >= 10;
        }

        public IEnumerable<string> ObterAbasLiberadas()
        {
            int nivelAcesso = ObterNivelAcesso();

            if (nivelAcesso >= 10)
            {
                return new List<string> { "ListaLivro", "ExcluirLivro", "Relatorio" };
            }
            else
            {
                return new List<string>();
            }
        }

        private int ObterNivelAcesso()
        {
            UsuarioDTO UsuarioDto = new UsuarioDTO();
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/nivelacesso?TxEmail=" + emailUsuario;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            int nivelAcesso = Int32.Parse(content);

            return nivelAcesso;
        }
    }
}
