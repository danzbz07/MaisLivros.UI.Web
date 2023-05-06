using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisLivros.UI.Web.Models
{
    public class UsuarioViewMOD
    {
        public Int32 CdUsuario { get; set; }

        public String TxNome { get; set; }

        public String TxEndereco { get; set; }

        public String TxTelefone { get; set; }

        public String TxLogin { get; set; }

        public String TxSenha { get; set; }

        public String TxEmail { get; set; }

        public String AoAtivo { get; set; }

        public String AoAdmin { get; set; }

        public DateTime DtCadastro { get; set; }

        public String TxCpf { get; set; }

        public String TxCnpj { get; set; }

        public String ChkTpPessoa { get; set; }
    }
}