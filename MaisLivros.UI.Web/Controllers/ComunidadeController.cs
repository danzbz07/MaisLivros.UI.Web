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
    }
}