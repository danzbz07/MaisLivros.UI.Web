using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class SolicitacaoMOD
    {
        public SolicitacaoMOD ()
        {
            Usuario = new UsuarioMOD();
            Status = new SolicitacaoStatusMOD();
            ListaLivro = new List<LivroMOD>();
            Livro = new LivroMOD();
        }

        public Int32 CdSolicitacao { get; set; }

        public String TxMotivo { get; set; }

        public DateTime DtCadastro { get; set; }

        //Composicao
        public UsuarioMOD Usuario { get; set; }

        //Composicao
        public SolicitacaoStatusMOD Status { get; set; }

        //Composicao
        public DoacaoMOD Doacao { get; set; }

        //Composicao
        public LivroMOD Livro { get; set; }

        //Composicao
        public List<LivroMOD> ListaLivro { get; set; }

    }
}
