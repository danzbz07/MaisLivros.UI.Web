using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class DoacaoMOD
    {
        public Int32 CdDoacao { get; set; }

        public String TxConfirmacao { get; set; }

        public String TpConfirmacao { get; set; }
    }
}
