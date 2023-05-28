using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaisLivros.Models.Util
{
    public class ValidadorCPF : IValidadorCPF
    {
        public bool ValidarCPF(string cpf)
        {
            // Remover caracteres especiais e espaços em branco
            cpf = Regex.Replace(cpf, @"[^0-9]", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            // Verificar se todos os dígitos são iguais (caso inválido, mas não lança exceção)
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Cálculo do primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            // Verificar o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
            {
                return false;
            }

            // Cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            // Verificar o segundo dígito verificador
            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
            {
                return false;
            }

            return true;
        }
    }
}
