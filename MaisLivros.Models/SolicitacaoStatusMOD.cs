using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class SolicitacaoStatusMOD
    {
        public Int32 CdStatusSolicitacao { get; set; }

        public String TxNome { get; set; }

        public String TxDetalhes { get; set; }

        public DateTime DtCadastro { get; set; }

        public StatusSimNaoENUM AoAtivo { get; set; }
    }
}
