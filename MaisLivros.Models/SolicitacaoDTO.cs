using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class SolicitacaoDTO
    {
        [JsonProperty("cdsolicitacao")]
        public Int32 CdSolicitacao { get; set; }

        [JsonProperty("dtcadastro")]
        public DateTime DtCadastro { get; set; }

        [JsonProperty("cdusuariosolicitacao")]
        public Int32 CdUsuario { get; set; }

        [JsonProperty("cdstatus")]
        public Int32 CdStatus { get; set; }

        [JsonProperty("txmotivo")]
        public String TxMotivo { get; set; }
        
        [JsonProperty("txnome")]
        public String TxNomeUsuario { get; set; }

        [JsonProperty("status")]
        public Boolean Status { get; set; }
    }
}
