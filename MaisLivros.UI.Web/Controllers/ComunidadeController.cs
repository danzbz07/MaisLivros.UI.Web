using MaisLivros.Models;
using MaisLivros.Repository;
using MaisLivros.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisLivros.UI.Web.Controllers
{
    public class ComunidadeController : Controller
    {
        #region Repositorios

        private SolicitacaoREP _repositorioSolicitacao = new SolicitacaoREP();

        #endregion

        // GET: Comunidade
        public ActionResult ListaDoacao()
        {
            SolicitacaoViewMOD Solicitacao = new SolicitacaoViewMOD();
            Solicitacao.ListaSolicitacao = _repositorioSolicitacao.ObterTodasSolicitacoes();

            return View(Solicitacao);
        }

        public ActionResult MinhasDoacoes()
        {
            List<LivroMOD> ListaLivro = new List<LivroMOD>();
            ListaLivro = _repositorioSolicitacao.ObterTodosLivrosPorUsuario(Convert.ToInt32(User.Identity.Name));

            return View(ListaLivro);
        }
    }
}