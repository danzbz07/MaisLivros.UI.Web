using MaisLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisLivros.UI.Web.Models
{
    public class SolicitacaoViewMOD
    {
        public SolicitacaoViewMOD()
        {
            ListaSolicitacao = new List<SolicitacaoMOD>();
        }

        public List<SolicitacaoMOD> ListaSolicitacao { get; set; }
    }
}