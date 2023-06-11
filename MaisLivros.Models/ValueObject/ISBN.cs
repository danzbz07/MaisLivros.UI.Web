using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.ValueObject
{
    public class ISBN
    {
        public string Value { get; }

        public ISBN(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("O valor do ISBN não pode ser vazio ou nulo.");
            }

            Value = value;
        }

    }
}
