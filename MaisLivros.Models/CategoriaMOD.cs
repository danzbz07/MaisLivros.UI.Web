using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class CategoriaMOD
    {
        public Int32 CdCategoria { get; set; }

        public String TxNome { get; set; }

        public String TxDetalhes { get; set; }

        private DateTime DtCadastro;

        public StatusSimNaoENUM AoAtivo { get; set; }
    }
}
