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

    public class SolicitacaoREP
    {
        public SolicitacaoMOD CadastrarSolicitacao(SolicitacaoMOD Solicitacao)
        {
            var client = new HttpClient();

            SolicitacaoDTO dto = new SolicitacaoDTO
            {
                CdUsuario = Solicitacao.Usuario.getCdUsuario(),
                CdStatus = 2,
                TxMotivo = Solicitacao.TxMotivo,
                Status = false,
                TxNome = Solicitacao.TxNome,
                TxUrlFoto = Solicitacao.TxUrlFoto
            };
            var ser = System.Text.Json.JsonSerializer.Serialize(dto);

            var conteudo = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/DadosSolicitacao");

            request.Content = conteudo;
            var resposta = client.SendAsync(request);
            Task.Delay(1000).Wait();
            var conteudoResposta = resposta.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusResponse = System.Text.Json.JsonSerializer.Deserialize<SolicitacaoDTO>(conteudoResposta);

            Solicitacao.CdSolicitacao = statusResponse.CdSolicitacao;

            return Solicitacao;
        }

        public LivroMOD CadastrarLivroSolicitacao(LivroMOD Livro, Int32 CdSolicitacao)
        {
            var client = new HttpClient();

            LivroDTO dto = new LivroDTO
            {
                CdSolicitacao = CdSolicitacao,
                CdStatusLivro = 2,
                CdCategoriaPrincipal = Livro.Categoria.CdCategoria,
                TxEdicao = Livro.TxEdicao,
                TxIdioma = Livro.TxIdioma,
                TxAutor = Livro.TxAutor,
                TxUrlFoto = Livro.TxUrlFoto,
                TxNome = Livro.TxNome,
                Status = false,
            };
            var ser = System.Text.Json.JsonSerializer.Serialize(dto);

            var conteudo = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/SolicitacaoLivro");

            request.Content = conteudo;
            var resposta = client.SendAsync(request);
            Task.Delay(1500).Wait();
            var conteudoResposta = resposta.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var statusResponse = System.Text.Json.JsonSerializer.Deserialize<LivroDTO>(conteudoResposta);

            Livro.CdLivro = statusResponse.CdLivro;

            return Livro;
        }

        public SolicitacaoMOD ObterSolicitacaoPorCdSolicitacao(Int32 CdSolicitacao)
        {
            SolicitacaoMOD Solicitacao = new SolicitacaoMOD();
            SolicitacaoDTO SolicitacaoDto = new SolicitacaoDTO();

            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/DadosSolicitacao?CdSolicitacao=" + CdSolicitacao;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            SolicitacaoDto = JsonConvert.DeserializeObject<SolicitacaoDTO>(content);


            Solicitacao.Usuario.setCdUsuario(SolicitacaoDto.CdUsuario);
            Solicitacao.TxMotivo = SolicitacaoDto.TxMotivo;
            Solicitacao.CdSolicitacao = SolicitacaoDto.CdSolicitacao;
            Solicitacao.Status.CdStatusSolicitacao = SolicitacaoDto.CdStatus;
            Solicitacao.DtCadastro = SolicitacaoDto.DtCadastro;
            Solicitacao.Usuario.setTxNome(SolicitacaoDto.TxNomeUsuario);

            return Solicitacao;

        }

        public List<LivroMOD> ObterLivrosPorCdSolicitacao(Int32 CdSolicitacao)
        {
            List<LivroDTO> ListaLivroDto = new List<LivroDTO>();
            List<LivroMOD> ListaLivro = new List<LivroMOD>();

            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/SolicitacaoLivro?CdSolicitacao=" + CdSolicitacao;
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            JObject json = JObject.Parse(content);
            var items = json["items"];

            ListaLivroDto = items.ToObject<List<LivroDTO>>();

            foreach (var livroDto in ListaLivroDto)
            {
                LivroMOD livro = new LivroMOD();

                livro.CdLivro = livroDto.CdLivro;
                livro.TxAutor = livroDto.TxAutor;
                livro.TxEdicao = livroDto.TxEdicao;
                livro.TxNome = livroDto.TxNome;
                livro.Status.CdStatusLivro = livroDto.CdStatusLivro;
                livro.Categoria.CdCategoria = livroDto.CdCategoriaPrincipal;
                livro.Categoria.TxNome = livroDto.TxCategoriaPrincipal;
                livro.TxUrlFoto = livroDto.TxUrlFoto;
                livro.TxIdioma = livroDto.TxIdioma;
                livro.Doacao.TpConfirmacao = livroDto.TpConfirmacao;
                livro.Doacao.TxDetalhes = livroDto.TxDetalhes;

                ListaLivro.Add(livro);
            }

            return ListaLivro;

        }

        public List<LivroMOD> ObterTodosLivrosPorUsuario(Int32 CdUsuario)
        {
            List<LivroDTO> ListaLivroDto = new List<LivroDTO>();
            List<LivroMOD> ListaLivro = new List<LivroMOD>();

            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/ObterDoacoes";
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            JObject json = JObject.Parse(content);
            var items = json["items"];

            ListaLivroDto = items.ToObject<List<LivroDTO>>();

            foreach (var livroDto in ListaLivroDto.Where(x => x.CdUsuario == CdUsuario))
            {
                LivroMOD livro = new LivroMOD();

                livro.CdLivro = livroDto.CdLivro;
                livro.TxAutor = livroDto.TxAutor;
                livro.TxEdicao = livroDto.TxEdicao;
                livro.TxNome = livroDto.TxNome;
                livro.Status.CdStatusLivro = livroDto.CdStatusLivro;
                livro.Categoria.CdCategoria = livroDto.CdCategoriaPrincipal;
                livro.Categoria.TxNome = livroDto.TxCategoriaPrincipal;
                livro.TxUrlFoto = livroDto.TxUrlFoto;
                livro.TxIdioma = livroDto.TxIdioma;
                livro.Doacao.TpConfirmacao = livroDto.TpConfirmacao;
                livro.Doacao.TxDetalhes = livroDto.TxDetalhes;
                livro.CdUsuario = livroDto.CdUsuario;

                ListaLivro.Add(livro);
            }

            return ListaLivro;

        }

        public List<SolicitacaoMOD> ObterTodasSolicitacoes()
        {
            List<SolicitacaoDTO> ListaSolicitacaoDto = new List<SolicitacaoDTO>();
            List<SolicitacaoMOD> ListaSolicitacao = new List<SolicitacaoMOD>();

            var url = "https://g58346c3a996906-producao.adb.sa-saopaulo-1.oraclecloudapps.com/ords/devuser/solicitacao/DoacaoComunidade";
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            Task.Delay(1000).Wait();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            JObject json = JObject.Parse(content);
            var items = json["items"];

            ListaSolicitacaoDto = items.ToObject<List<SolicitacaoDTO>>();

            foreach (var solicitacaoDto in ListaSolicitacaoDto)
            {
                SolicitacaoMOD solicitacao = new SolicitacaoMOD();

                solicitacao.CdSolicitacao = solicitacaoDto.CdSolicitacao;
                solicitacao.TxNome = solicitacaoDto.TxNome;
                solicitacao.QtdRecebida = solicitacaoDto.QtdRecebida;
                solicitacao.QtdSolicitada = solicitacaoDto.QtdSolicitada;
                solicitacao.TxMotivo = solicitacaoDto.TxMotivo;
                solicitacao.TxUrlFoto = solicitacaoDto.TxUrlFoto;
                solicitacao.Usuario.setTxNome(solicitacaoDto.TxNomeUsuario);
                solicitacao.DtCadastro = solicitacaoDto.DtCadastro;
                solicitacao.Status.CdStatusSolicitacao = solicitacaoDto.CdStatus;
                solicitacao.QtdRecebida = solicitacaoDto.QtdRecebida;
                solicitacao.QtdSolicitada = solicitacaoDto.QtdSolicitada;

                ListaSolicitacao.Add(solicitacao);
            }

            return ListaSolicitacao;

        }


    }
}
