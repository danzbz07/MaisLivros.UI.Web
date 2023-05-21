using MaisLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Repository
{
    public sealed class DoacaoREP
    {
        public SolicitacaoMOD CadastrarDoacao(SolicitacaoMOD Solicitacao)
        {
            var client = new HttpClient();

            DoacaoDTO dto = new DoacaoDTO
            {
                CdUsuario = Solicitacao.Usuario.getCdUsuario(),
                TpConfirmacao = Solicitacao.Livro.Doacao.TpConfirmacao,
                TxDetalhes = Solicitacao.Livro.Doacao.TxDetalhes,
                CdLivro = Solicitacao.Livro.CdLivro,
                Status = false
            };
            var ser = System.Text.Json.JsonSerializer.Serialize(dto);

            var conteudo = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/SolicitacaoLivroDoacao");

            request.Content = conteudo;
            var resposta = client.SendAsync(request);
            Task.Delay(1000).Wait();
            var conteudoResposta = resposta.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusResponse = System.Text.Json.JsonSerializer.Deserialize<DoacaoDTO>(conteudoResposta);

            Solicitacao.Livro.Doacao.CdDoacao = statusResponse.CdDoacao;

            return Solicitacao;
        }
    }
}
