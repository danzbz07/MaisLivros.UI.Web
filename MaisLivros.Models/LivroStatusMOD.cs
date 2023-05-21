using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class LivroStatusMOD
    {
        public Int32 CdStatusLivro { get; set; }

        public String TxNome { get; set; }

        public String TxDetalhes { get; set; }

        public DateTime DtCadastro { get; set; }

        public StatusSimNaoENUM AoAtivo { get; set; }
    }
}
