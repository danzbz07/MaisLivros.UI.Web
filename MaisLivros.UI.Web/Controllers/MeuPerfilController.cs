using MaisLivros.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisLivros.UI.Web.Controllers
{
    public class MeuPerfilController : Controller
    {
        // GET: MeuPerfil
        public ActionResult Index()
        {
            UsuarioTESTE UsuarioDeTeste = new UsuarioTESTE();
            return View(UsuarioDeTeste);
        }

        public ActionResult editaUsuario(int CdUsuario, String TxNome, String TxEndereco, String TxTelefone, String TxEmail)
        {
            UsuarioTESTE UsuarioDeTeste = new UsuarioTESTE(CdUsuario, TxNome, TxEndereco, TxTelefone, TxEmail);
            return View(UsuarioDeTeste);
        }

    }
}