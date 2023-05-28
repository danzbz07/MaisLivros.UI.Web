using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisLivros.Models.Factory
{
    public class UsuarioFactory
    {
        public UsuarioMOD CriarUsuario(string txNome, string txEndereco, string txTelefone, string txSenha, string txEmail)
        {
            // Validações podem ser adicionadas

            var usuario = new UsuarioMOD();
            usuario.setTxNome(txNome);
            usuario.setTxEndereco(txEndereco);
            usuario.setTxTelefone(txTelefone);
            usuario.setTxSenha(txSenha);
            usuario.setTxEmail(txEmail);

            return usuario;
        }
    }
}
