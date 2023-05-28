using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.ValueObject
{
    public class Email
    {
        private readonly string _endereco;

        public Email(string enderecoEmail)
        {
            if (string.IsNullOrEmpty(enderecoEmail))
            {
                throw new ArgumentException("O endereço de e-mail não pode ser vazio ou nulo.", nameof(enderecoEmail));
            }

            _endereco = enderecoEmail;
        }

        public string Endereco => _endereco;

    }
}
