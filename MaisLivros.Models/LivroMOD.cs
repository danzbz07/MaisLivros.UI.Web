using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class LivroMOD
    {

        public LivroMOD()
        {
            Categoria = new CategoriaMOD();
            Status = new LivroStatusMOD();
        }

        public Int32 CdLivro { get; set; }

        public String TxEdicao { get; set; }

        public String TxIdioma { get; set; }

        public String TxAutor { get; set; }

        public String TxUrlFoto { get; set; }

        public String TxNome { get; set; }

        //Composicao
        public LivroStatusMOD Status { get; set; }

        //Composicao
        public CategoriaMOD Categoria { get; set; }
    }
}
