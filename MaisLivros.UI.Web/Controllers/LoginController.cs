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
    public class LoginController : Controller
    {

        #region Repositorios

        UsuarioREP _repositorioUsuario = new UsuarioREP();

        #endregion

        // GET: Login
        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioViewMOD dadosTela)
        {

            if (dadosTela.ChkTpPessoa == "F")
            {
                PessoaFisicaMOD PessoaFisica = new PessoaFisicaMOD(dadosTela.TxCpf);

                //Se nao exister o usuario com o CPF
                if (!_repositorioUsuario.VerificarExistePessoaFisica(PessoaFisica.Cpf))
                {
                    PessoaFisica.TxEmail = dadosTela.TxEmail;
                    PessoaFisica.TxEndereco = dadosTela.TxEndereco;
                    PessoaFisica.TxSenha = dadosTela.TxSenha;
                    PessoaFisica.TxLogin = dadosTela.TxLogin;
                    PessoaFisica.TxTelefone = dadosTela.TxTelefone;
                    PessoaFisica.TxNome = dadosTela.TxNome;
                    if (_repositorioUsuario.CadastrarPessoaFisica(PessoaFisica))
                    {
                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                        return RedirectToAction("Entrar");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar ";
                        return View(dadosTela);
                    }
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar motivo: o Usuário já possui Cadastro ";
                    return View(dadosTela); 
                }
            }

            if (dadosTela.ChkTpPessoa == "J")
            {
                PessoaJuridicaMOD PessoaJuridica = new PessoaJuridicaMOD(dadosTela.TxCnpj);

                //Se nao exister o usuario com o CPF
                if (!_repositorioUsuario.VerificarExistePessoaJuridica(PessoaJuridica.Cnpj))
                {
                    PessoaJuridica.TxEmail = dadosTela.TxEmail;
                    PessoaJuridica.TxEndereco = dadosTela.TxEndereco;
                    PessoaJuridica.TxSenha = dadosTela.TxSenha;
                    PessoaJuridica.TxLogin = dadosTela.TxLogin;
                    PessoaJuridica.TxTelefone = dadosTela.TxTelefone;
                    PessoaJuridica.TxNome = dadosTela.TxNome;
                    if (_repositorioUsuario.CadastrarPessoaJuridica(PessoaJuridica))
                    {
                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                        return RedirectToAction("Entrar");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar ";
                        return View(dadosTela);
                    }
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar motivo: o Usuário já possui Cadastro ";
                    return View(dadosTela);
                }
            }

            return View(dadosTela);

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