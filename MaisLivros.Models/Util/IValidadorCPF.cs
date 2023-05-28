using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.Util
{
    public interface IValidadorCPF
    {
        bool ValidarCPF(string cpf);

    }
}
