using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class DoacaoDTO
    {
        [JsonProperty("cddoacao")]
        public Int32 CdDoacao { get; set; }

        [JsonProperty("cdusuario")]
        public Int32 CdUsuario { get; set; }

        [JsonProperty("cdlivro")]
        public Int32 CdLivro { get; set; }

        [JsonProperty("tpconfirmacao")]
        public String TpConfirmacao { get; set; }

        [JsonProperty("txdetalhes")]
        public String TxDetalhes { get; set; }

        [JsonProperty("status")]
        public Boolean Status { get; set; }
    }
}
