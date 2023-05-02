using MaisLivros.Models;
using MaisLivros.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisLivros.UI.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioViewMOD dadosTela)
        {

            UsuarioMOD Usuario = new UsuarioMOD();
            Usuario.TxEmail = dadosTela.TxEmail;
            Usuario.TxEndereco = dadosTela.TxEndereco;
            Usuario.TxSenha = dadosTela.TxSenha;
            Usuario.TxLogin = dadosTela.TxLogin;
            Usuario.TxTelefone = dadosTela.TxTelefone;
            Usuario.TxNome = dadosTela.TxNome;

            //Se nao exister o usuriao com o CPF
            if (!Usuario.PessoaFisica.VerificarExiste(dadosTela.TxCpf))
            {
                Usuario.CadastrarUsuario(Usuario);
                Usuario.CdUsuario = Usuario.AutenticarUsuario(Usuario.TxEmail, Usuario.TxSenha);
                Usuario.PessoaFisica.Cadastrar(dadosTela.TxCpf, Usuario.CdUsuario);
            }


            return View();
        }

        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(UsuarioViewMOD dadosTela)
        {
            UsuarioMOD Usuario = new UsuarioMOD();

            Int32 Cdusuario = Usuario.AutenticarUsuario(dadosTela.TxEmail, dadosTela.TxSenha);

            if (Cdusuario != 0)
            {
                return RedirectToAction("Index", "MeuPerfil");
            }

            return View();
        }
    }
}