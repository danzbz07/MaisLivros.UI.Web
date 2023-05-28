using MaisLivros.Models;
using MaisLivros.Models.Factory;
using MaisLivros.Models.Util;
using MaisLivros.Models.ValueObject;
using MaisLivros.Repository;
using MaisLivros.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MaisLivros.UI.Web.Controllers
{
    [AllowAnonymous]
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
                dadosTela.TxCpf = Regex.Replace(dadosTela.TxCpf, @"[^0-9]", "");
                IValidadorCPF validador = new ValidadorCPF();
                PessoaFisicaMOD PessoaFisica = new PessoaFisicaMOD(dadosTela.TxCpf, validador);
                PessoaFisica.setTxEmail(dadosTela.TxEmail);

                //Se nao exister o usuario com o CPF
                if (!_repositorioUsuario.VerificarExistePessoaFisica(PessoaFisica.getCPF(), PessoaFisica.getTxEmail()))
                {
                    PessoaFisica.setTxEndereco(dadosTela.TxEndereco);
                    PessoaFisica.setTxSenha(dadosTela.TxSenha);
                    PessoaFisica.setTxLogin(dadosTela.TxLogin);
                    PessoaFisica.setTxTelefone(dadosTela.TxTelefone);
                    PessoaFisica.setTxNome(dadosTela.TxNome);

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
                    TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar motivo: o CPF e/ou E-mail já estão cadastrados ";
                    return View(dadosTela); 
                }
            }

            if (dadosTela.ChkTpPessoa == "J")
            {

                PessoaJuridicaFactory factoryPessoaJuridica = new PessoaJuridicaFactory();
                PessoaJuridicaMOD PessoaJuridica = factoryPessoaJuridica.CriarPessoaJuridica(dadosTela.TxCnpj);

                PessoaJuridica.setTxEmail(dadosTela.TxEmail);

                //Se nao exister o usuario com o CPF
                if (!_repositorioUsuario.VerificarExistePessoaJuridica(PessoaJuridica.Cnpj.Valor, PessoaJuridica.getTxEmail()))
                {
                    PessoaJuridica.setTxEndereco(dadosTela.TxEndereco);
                    PessoaJuridica.setTxSenha(dadosTela.TxSenha);
                    PessoaJuridica.setTxLogin(dadosTela.TxLogin);
                    PessoaJuridica.setTxTelefone(dadosTela.TxTelefone);
                    PessoaJuridica.setTxNome(dadosTela.TxNome);

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
                    TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar motivo: o CNPJ e/ou E-mail já estão cadastrados ";
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
            UsuarioDTO UsuarioDto = new UsuarioDTO();

            UsuarioDto = _repositorioUsuario.AutenticarUsuario(dadosTela.TxEmail, dadosTela.TxSenha);

            if (UsuarioDto.CdUsuario != 0)
            {
                Session["CdUsuario"] = UsuarioDto.CdUsuario;
                Session["TpUsuario"] = UsuarioDto.TpUsuario;
                Session["TxIdentificador"] = UsuarioDto.TxIdentificador;
                Session["TxNome"] = UsuarioDto.TxNome;
                FormsAuthentication.SetAuthCookie(UsuarioDto.CdUsuario.ToString(), false);
                return RedirectToAction("EditarUsuario", "MeuPerfil");
            }
            else
            {
                TempData["MensagemErro"] = "Email e/ou Senha Inválido";
                //return RedirectToAction("Entrar", "Login");

            }

            return View();
        }

        public ActionResult Sair()
        {
            // Limpar autenticação do Forms Authentication
            FormsAuthentication.SignOut();

            // Limpar a sessão e os cookies, se necessário
            Session.Clear();
            Session.Abandon();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);
            }

            // Redirecionar para a página de login
            return RedirectToAction("Entrar", "Login");
        }
    }
}