using MaisLivros.Models;
using MaisLivros.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisLivros.UI.Web.Controllers
{
    [Authorize]
    public class SolicitacaoController : Controller
    {
        #region Repositorios

        private SolicitacaoREP _repositorioSolicitacao = new SolicitacaoREP();
        private CategoriaREP _repositorioCategoria = new CategoriaREP();
        private DoacaoREP _repositorioDoacao = new DoacaoREP();

        #endregion

        public ActionResult CriarSolicitacao()
        {
            ObterCategorias();
            SolicitacaoMOD Solicitacao = new SolicitacaoMOD();
            return View(Solicitacao);
        }

        [HttpPost]
        public ActionResult CriarSolicitacao(SolicitacaoMOD dadosTela)
        {

            dadosTela.Usuario.setCdUsuario(Convert.ToInt32(User.Identity.Name));

            if (_repositorioSolicitacao.CadastrarSolicitacao(dadosTela).CdSolicitacao != 0)
            {
                if (_repositorioSolicitacao.CadastrarLivroSolicitacao(dadosTela.Livro, dadosTela.CdSolicitacao).CdLivro != 0)
                {
                    TempData["MensagemSucesso"] = "Solicitação gerada com sucesso !";
                    return RedirectToAction("ConsultarSolicitacao", new { CdSolicitacao = dadosTela.CdSolicitacao });
                }
                else
                {
                    ObterCategorias();
                    TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar ";
                    return View(dadosTela);
                }
            }
            else
            {
                ObterCategorias();
                TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar ";
                return View(dadosTela);
            }
        }

        public ActionResult ConsultarSolicitacao(Int32 CdSolicitacao)
        {
            SolicitacaoMOD Solicitacao = _repositorioSolicitacao.ObterSolicitacaoPorCdSolicitacao(CdSolicitacao);

            Solicitacao.ListaLivro = _repositorioSolicitacao.ObterLivrosPorCdSolicitacao(Solicitacao.CdSolicitacao);

            ViewBag.CdUsuario = Solicitacao.Usuario.getCdUsuario();
            ViewBag.CdSolicitacao = CdSolicitacao;

            return View(Solicitacao);
        }

        public ActionResult AdicionarLivro(Int32 CdSolicitacao)
        {
            SolicitacaoMOD Solicitacao = _repositorioSolicitacao.ObterSolicitacaoPorCdSolicitacao(CdSolicitacao);

            if (!(Solicitacao.Usuario.getCdUsuario() == Convert.ToInt32(User.Identity.Name)))
            {
                TempData["MensagemErro"] = "Essa solicitação pertence a outro usuário !";
                return RedirectToAction("ConsultarSolicitacao", new { CdSolicitacao = CdSolicitacao });
            }
            ObterCategorias();
            return View(Solicitacao);
        }

        [HttpPost]
        public ActionResult AdicionarLivro(SolicitacaoMOD dadosTela)
        {
            if (_repositorioSolicitacao.CadastrarLivroSolicitacao(dadosTela.Livro, dadosTela.CdSolicitacao).CdLivro != 0)
            {
                TempData["MensagemSucesso"] = "Solicitação gerada com sucesso !";
                return RedirectToAction("ConsultarSolicitacao", new { CdSolicitacao = dadosTela.CdSolicitacao });
            }
            else
            {
                ObterCategorias();
                TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar ";
                return View(dadosTela);
            }
        }


        public ActionResult RealizarDoacao(Int32 CdSolicitacao, Int32 CdLivro)
        {
            SolicitacaoMOD Solicitacao = _repositorioSolicitacao.ObterSolicitacaoPorCdSolicitacao(CdSolicitacao);

            if (Solicitacao.Usuario.getCdUsuario() == Convert.ToInt32(User.Identity.Name))
            {
                TempData["MensagemErro"] = "Essa solicitação pertence ao seu usuário !";
                return RedirectToAction("ConsultarSolicitacao", new { CdSolicitacao = CdSolicitacao });
            }
            Solicitacao.ListaLivro = _repositorioSolicitacao.ObterLivrosPorCdSolicitacao(Solicitacao.CdSolicitacao);

            Solicitacao.Livro = Solicitacao.ListaLivro.Where(x => x.CdLivro == CdLivro).ToList()[0];
            ObterFormasConfirmacao();
            return View(Solicitacao);
        }

        [HttpPost]
        public ActionResult RealizarDoacao(SolicitacaoMOD dadosTela)
        {
            dadosTela.Usuario.setCdUsuario(Convert.ToInt32(User.Identity.Name));
            if (_repositorioDoacao.CadastrarDoacao(dadosTela).Livro.Doacao.CdDoacao != 0)
            {
                TempData["MensagemSucesso"] = "Doação cadastrada com sucesso !";
                return RedirectToAction("ConsultarSolicitacao", new { CdSolicitacao = dadosTela.CdSolicitacao });
            }
            else
            {
                ObterCategorias();
                TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar a doação";
                return View(dadosTela);
            }
        }

        public void ObterCategorias()
        {
            List<CategoriaDTO> ListaCategoria = _repositorioCategoria.BuscarListaCategoria();

            ViewBag.Categorias = new SelectList(ListaCategoria, "cdcategoria", "txnome");

        }

        public void ObterFormasConfirmacao()
        {
            // Crie a lista de objetos anônimos para os itens do DropDownList
            var items = new[]
            {
                new { Value = "R", Text = "Rastreamento" },
                new { Value = "F", Text = "Nota Fiscal" },
            };

            // Crie o SelectList com os itens do DropDownList
            ViewBag.FormasConfirmacao = new SelectList(items, "Value", "Text");
        }
    }
}