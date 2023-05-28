using MaisLivros.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.Factory
{
    public class PessoaJuridicaFactory
    {
        public PessoaJuridicaMOD CriarPessoaJuridica(string cnpj)
        {
            Cnpj cnpjObj = new Cnpj(cnpj);
            return new PessoaJuridicaMOD(cnpjObj);
        }
    }
}
