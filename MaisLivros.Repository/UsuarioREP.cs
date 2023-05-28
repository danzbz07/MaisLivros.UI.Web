using MaisLivros.Models;
using Newtonsoft.Json;
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
        #region Login

        public UsuarioDTO AutenticarUsuario(String TxEmail, String TxSenha)
        {

            UsuarioDTO UsuarioDto = new UsuarioDTO();

            try
            {
                var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/Login?TxEmail=" + TxEmail + "&TxSenha=" + TxSenha;
                var httpClient = new HttpClient();

                var response = httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                Task.Delay(1000).Wait();
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                UsuarioDto = JsonConvert.DeserializeObject<UsuarioDTO>(content);
            }
            catch
            {
                ;
            }
        
            return UsuarioDto;

        }

        public UsuarioDTO BuscarDadosUsuario(Int32 CdUsuario)
        {
            UsuarioDTO UsuarioDto = new UsuarioDTO();
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/Usuario?CdUsuario=" + CdUsuario;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            UsuarioDto = JsonConvert.DeserializeObject<UsuarioDTO>(content);
            return UsuarioDto;

        }

        public Boolean EditarUsuario(UsuarioDTO Usuario)
        {
            var client = new HttpClient();
            var conteudo = new StringContent(System.Text.Json.JsonSerializer.Serialize(Usuario), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/Usuario");
            request.Content = conteudo;

            var resposta = client.SendAsync(request);
            Task.Delay(1000).Wait();
            var conteudoResposta = resposta.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusResponse = System.Text.Json.JsonSerializer.Deserialize<UsuarioDTO>(conteudoResposta);
            return statusResponse.Status;

        }
        #endregion

        #region PessoaFisica

        public Boolean CadastrarPessoaFisica(PessoaFisicaMOD Usuario)
        {
            PessoaFisicaDTO dto = new PessoaFisicaDTO
            {
                CdUsuario = Usuario.getCdUsuario(),
                TxNome = Usuario.getTxNome(),
                TxEndereco = Usuario.getTxEndereco(),
                TxTelefone = Usuario.getTxTelefone(),
                TxSenha = Usuario.getTxSenha(),
                TxEmail = Usuario.getTxEmail(),
                AoAtivo = Usuario.getAoAtivo(),
                AoAdmin = Usuario.getAoAdmin(),
                Cpf = Usuario.getCPF(),
                Status = false
            };
            var ser = System.Text.Json.JsonSerializer.Serialize(dto);

            var client = new HttpClient();
            var conteudo = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaFisica");

            request.Content = conteudo;
            var resposta = client.SendAsync(request);
            Task.Delay(3000).Wait();
            var conteudoResposta = resposta.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusResponse = System.Text.Json.JsonSerializer.Deserialize<PessoaFisicaDTO>(conteudoResposta);
            return statusResponse.Status;
        }

        public Boolean VerificarExistePessoaFisica(String Cpf, String TxEmail)
        {
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaFisica?TxCpf=" + Cpf + "&TxEmail=" + TxEmail;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseContent))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region PessoaJuridica


        public Boolean CadastrarPessoaJuridica(PessoaJuridicaMOD Usuario)
        {
            var client = new HttpClient();

            PessoaJuridicaDTO dto = new PessoaJuridicaDTO
            {
                CdUsuario = Usuario.getCdUsuario(),
                TxNome = Usuario.getTxNome(),
                TxEndereco = Usuario.getTxEndereco(),
                TxTelefone = Usuario.getTxTelefone(),
                TxSenha = Usuario.getTxSenha(),
                TxEmail = Usuario.getTxEmail(),
                AoAtivo = Usuario.getAoAtivo(),
                AoAdmin = Usuario.getAoAdmin(),
                Cnpj = Usuario.Cnpj.Valor,
                Status = false
            };

            var ser = System.Text.Json.JsonSerializer.Serialize(dto);
            var conteudo = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaJuridica");

            request.Content = conteudo;
            var resposta = client.SendAsync(request);
            Task.Delay(3000).Wait();
            var conteudoResposta = resposta.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusResponse = System.Text.Json.JsonSerializer.Deserialize<PessoaJuridicaDTO>(conteudoResposta);

            return statusResponse.Status;
        }

        public Boolean VerificarExistePessoaJuridica(String Cnpj, String TxEmail)
        {
            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/usuario/PessoaJuridica?TxCnpj=" + Cnpj + "&TxEmail=" + TxEmail;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseContent))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
