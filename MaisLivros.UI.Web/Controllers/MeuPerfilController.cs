using MaisLivros.Models;
using MaisLivros.Repository;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisLivros.UI.Web.Controllers
{
    [Authorize]
    public class MeuPerfilController : Controller
    {

        #region Repositorios

        UsuarioREP _repositorioUsuario = new UsuarioREP();

        #endregion

        public ActionResult EditarUsuario()
        {
            UsuarioDTO UsuarioDto = _repositorioUsuario.BuscarDadosUsuario(Convert.ToInt32(Session["CdUsuario"]));
            return View(UsuarioDto);
        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioDTO dadosTela)
        {
            dadosTela.CdUsuario = Convert.ToInt32(Session["CdUsuario"]);

            if (_repositorioUsuario.EditarUsuario(dadosTela))
                TempData["MensagemSucesso"] = "Dados alterado com sucesso!";
            else
                TempData["MensagemErro"] = "Ocorreu um erro ao alterar os dados ! ";

            return View(dadosTela);
        }

    }
}