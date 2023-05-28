using MaisLivros.Models.ValueObject;
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
        private Cnpj _cnpj;

        public PessoaJuridicaMOD(Cnpj cnpj)
        {
            _cnpj = cnpj;
        }

        public Cnpj Cnpj => _cnpj;

    }
}
