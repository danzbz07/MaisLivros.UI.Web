using MaisLivros.Models.Strategy;
using MaisLivros.Models.ValueObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class UsuarioMOD
    {
        #region Strategy
        
        private IAcessoStrategy acessoStrategy;

        public bool VerificarAcesso()
        {
            return acessoStrategy.VerificarAcesso();
        }

        public void DefinirEstrategiaAcesso(IAcessoStrategy estrategia)
        {
            acessoStrategy = estrategia;
        }

        #endregion

        #region Prop

        private Int32 CdUsuario;

        private String TxNome;

        private String TxEndereco;

        private String TxTelefone;

        private String TxSenha;

        private Email _email;

        private String AoAtivo;

        private String AoAdmin;

        private DateTime DtCadastro;

        #endregion

        #region Set

        public void setCdUsuario(Int32 cdUsuario)
        {
            CdUsuario = cdUsuario;
        }

        public void setTxNome(String txNome)
        {
            TxNome = txNome;
        }
        
        public void setTxEndereco(String txEndereco)
        {
            TxEndereco = txEndereco;
        }

        public void setTxTelefone(String txTelefone)
        {
            TxTelefone = txTelefone;
        }

        public void setTxLogin(String txLogin)
        {
            TxTelefone = txLogin;
        }

        public void setTxSenha(String txSenha)
        {
            TxSenha = txSenha;
        }

        public void setTxEmail(string txEmail)
        {
            _email = new Email(txEmail);
        }

        public void setAoAtivo(String aoAtivo)
        {
            AoAtivo = aoAtivo;
        }

        public void setAoAdmin(String aoAdmin)
        {
            AoAdmin = aoAdmin;
        }


        public void setDtCadastro(DateTime dtCadastro)
        {
            DtCadastro = dtCadastro;
        }
        #endregion

        #region Get
        public Int32 getCdUsuario()
        {
            return CdUsuario;
        }

        public String getTxNome()
        {
            return TxNome;
        }

        public String getTxEndereco()
        {
            return TxEndereco;
        }

        public String getTxTelefone()
        {
            return TxTelefone;
        }

        public String getTxSenha()
        {
            return TxSenha;
        }

        public string getTxEmail()
        {
            return _email?.Endereco;
        }

        public String getAoAtivo()
        {
            return AoAtivo;
        }

        public String getAoAdmin()
        {
            return AoAdmin;
        }

        public DateTime getDtCadastro()
        {
            return DtCadastro;
        }

        public UsuarioMOD()
        {

        }
        #endregion
    }
}
