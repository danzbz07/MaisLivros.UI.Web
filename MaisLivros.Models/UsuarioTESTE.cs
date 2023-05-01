using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class UsuarioTESTE
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

        public UsuarioTESTE()
        {
            CdUsuario = 100;
            TxNome = "Comitê de Sustentabilidade FACENS";
            TxEndereco = "Rodovia Senador José Ermírio de Moraes, 1425 - Jardim Constantino Matucci, Sorocaba";
            TxTelefone = "(15) 3238-1188";
            TxEmail = "e-mail@exemplo.com.br";
        }

        public UsuarioTESTE(int CdUsuario, String TxNome, String TxEndereco, String TxTelefone, String TxEmail)
        {
            this.CdUsuario = CdUsuario;
            this.TxNome = TxNome;
            this.TxEndereco = TxEndereco;
            this.TxTelefone = TxTelefone;
            this.TxEmail = TxEmail;
        }



    }
}
