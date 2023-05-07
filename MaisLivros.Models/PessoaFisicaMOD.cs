using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaisLivros.Models
{
    public class PessoaFisicaMOD : UsuarioMOD
    {
        private String Cpf;


        //Intanciar Pessoa Fisica
        public PessoaFisicaMOD (String cpf)
        {
            //Remover os caracteres especial
            cpf = Regex.Replace(cpf, @"[^0-9]", "");
            Cpf = cpf;
        }

        public String getCPF()
        {
            return Cpf;
        }

    }
}
