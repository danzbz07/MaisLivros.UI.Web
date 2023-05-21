using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class PessoaJuridicaDTO
    {
        public Int32 CdUsuario { get; set; }

        public String TxNome { get; set; }

        public String TxEndereco { get; set; }

        public String TxTelefone { get; set; }

        public String TxSenha { get; set; }

        public String TxEmail { get; set; }

        public String AoAtivo { get; set; }

        public String AoAdmin { get; set; }

        public String Cnpj { get; set; }

        public Boolean Status { get; set; }
    }
}
