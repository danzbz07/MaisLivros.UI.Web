﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public sealed class LivroDTO
    {
        [JsonProperty("cdlivro")]
        public Int32 CdLivro { get; set; }

        [JsonProperty("cdusuario")]
        public Int32 CdUsuario { get; set; }

        [JsonProperty("cdsolicitacao")]
        public Int32 CdSolicitacao { get; set; }

        [JsonProperty("cdstatuslivro")]
        public Int32 CdStatusLivro { get; set; }

        [JsonProperty("cdcategoriaprincipal")]
        public Int32 CdCategoriaPrincipal { get; set; }

        [JsonProperty("nomecategoria")]
        public String TxCategoriaPrincipal { get; set; }

        [JsonProperty("txedicao")]
        public String TxEdicao { get; set; }

        [JsonProperty("txidioma")]
        public String TxIdioma { get; set; }

        [JsonProperty("txautor")]
        public String TxAutor { get; set; }

        [JsonProperty("txurlfoto")]
        public String TxUrlFoto { get; set; }

        [JsonProperty("txnome")]
        public String TxNome { get; set; }

        [JsonProperty("txdetalhes")]
        public String TxDetalhes { get; set; }

        [JsonProperty("tpconfirmacao")]
        public String TpConfirmacao { get; set; }

        [JsonProperty("txstatus")]
        public Boolean Status { get; set; }

    }
}
