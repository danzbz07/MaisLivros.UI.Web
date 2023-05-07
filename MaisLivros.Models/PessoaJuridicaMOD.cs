using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class PessoaJuridicaMOD : UsuarioMOD
    {
        private String Cnpj;

        //Intanciar Pessoa Fisica
        public PessoaJuridicaMOD(String cnpj)
        {
            //Remover os caracteres especial
            cnpj = Regex.Replace(cnpj, @"[^0-9]", "");
            Cnpj = cnpj;
        }

        public String getCnpj()
        {
            return Cnpj;
        }

    }
}
