using MaisLivros.Models.Strategy;
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
            // Criar as instâncias das estratégias de acesso
            IAcessoStrategy membroStrategy = new MembroAcessoStrategy(txEmail);
            // Para um usuário com nível de acesso "Membro"
            UsuarioMOD usuario = new UsuarioMOD();
            usuario.DefinirEstrategiaAcesso(membroStrategy);
            // Verificar o acesso e obter as abas liberadas
            bool acessoPermitido = usuario.VerificarAcesso();

            usuario.setTxNome(txNome);
            usuario.setTxEndereco(txEndereco);
            usuario.setTxTelefone(txTelefone);
            usuario.setTxSenha(txSenha);
            usuario.setTxEmail(txEmail);

            return usuario;
        }
    }
}
