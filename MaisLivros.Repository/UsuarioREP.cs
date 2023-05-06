using MaisLivros.Models;
using Newtonsoft.Json.Linq;
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

        #region PessoaFisica

        public bool CadastrarPessoaFisica(PessoaFisicaMOD Usuario)
        {
            var client = new HttpClient();

            var str = JsonSerializer.Serialize(Usuario);

            var conteudo = new StringContent(JsonSerializer.Serialize(Usuario), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaFisica");

            request.Content = conteudo;

            var resposta = client.SendAsync(request);
            Task.Delay(3000).Wait();
            return resposta.IsCompleted;
        }

        public Boolean VerificarExistePessoaFisica(String Cpf)
        {
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaFisica?TxCpf=" + Cpf;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseContent))
                {
                    // Processar o conteúdo retornado aqui
                    return true;
                }
                else
                {
                    // Tratar o caso em que o conteúdo retornado está vazio
                    return false;
                }
            }
            else
            {
                // Tratar o caso em que a requisição falhou
                return false;
            }
        }

        #endregion

        #region PessoaJuridica


        public bool CadastrarPessoaJuridica(PessoaJuridicaMOD Usuario)
        {
            var client = new HttpClient();

            var str = JsonSerializer.Serialize(Usuario);

            var conteudo = new StringContent(JsonSerializer.Serialize(Usuario), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaJuridica");

            request.Content = conteudo;

            var resposta = client.SendAsync(request);
            Task.Delay(3000).Wait();
            return resposta.IsCompleted;
        }

        public Boolean VerificarExistePessoaJuridica(String Cnpj)
        {
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaJuridica?TxCnpj=" + Cnpj;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseContent))
                {
                    // Processar o conteúdo retornado aqui
                    return true;
                }
                else
                {
                    // Tratar o caso em que o conteúdo retornado está vazio
                    return false;
                }
            }
            else
            {
                // Tratar o caso em que a requisição falhou
                return false;
            }
        }

        #endregion

    }
}
