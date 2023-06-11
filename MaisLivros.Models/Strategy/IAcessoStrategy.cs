using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.Strategy
{
    // Interface que define o contrato para as estratégias de validação
    public interface IAcessoStrategy
    {
        bool VerificarAcesso();
    }
}
