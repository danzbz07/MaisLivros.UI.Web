using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaisLivros.Models.ValueObject
{
    public class Cnpj
    {
        private string _cnpj;

        public Cnpj(string cnpj)
        {
            _cnpj = Regex.Replace(cnpj, @"[^0-9]", "");
        }

        public string Valor => _cnpj;
    }
}
