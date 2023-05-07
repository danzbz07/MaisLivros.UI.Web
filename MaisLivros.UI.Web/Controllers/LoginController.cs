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
                PessoaJuridicaMOD PessoaJuridica = new PessoaJuridicaMOD(dadosTela.TxCnpj);
                PessoaJuridica.setTxEmail(dadosTela.TxEmail);

                //Se nao exister o usuario com o CPF
                if (!_repositorioUsuario.VerificarExistePessoaJuridica(PessoaJuridica.getCnpj(), PessoaJuridica.getTxEmail()))
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
                return RedirectToAction("EditarUsuario", "MeuPerfil");
            }
            else
            {
                TempData["MensagemErro"] = "Email e/ou Senha Inválido";
            }

            return View();
        }
    }
}