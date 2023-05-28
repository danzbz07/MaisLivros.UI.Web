using MaisLivros.Models.Util;
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
        private readonly IValidadorCPF validador;

        private String Cpf;

        public PessoaFisicaMOD(string cpf, IValidadorCPF validador)
        {
            this.validador = validador;

            if (validador.ValidarCPF(cpf))
            {
                Cpf = cpf;
            }
            else
            {
                throw new ArgumentException("CPF inválido.");
            }
        }

        public String getCPF()
        {
            return Cpf;
        }

    }
}
