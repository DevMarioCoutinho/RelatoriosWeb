using RelatoriosWeb.AcessoDados;
using System.Data;

namespace RelatoriosWeb.Classe
{
    public class Usuario
    {
        #region Variaveis Global
        Configuracao objConfiguracao = new Configuracao();
        #endregion

        #region Atributos da Classe Usuario
        public string Login { get; set; }
        public string Senha { get; set; }
        #endregion

        #region Valida Login do Usuario e Retorna String
        public string ValidaUsuario(Usuario usuario)
        {
            var ds = new DataSet();
            ds = objConfiguracao.ValidaLogin(usuario);

            try
            {
                string retorno = ds.Tables[0].Rows[0]["Retorno"].ToString();

                return retorno;
            }
            catch
            {
                return "Falha ao Validar Usuario";
            }

        }
        #endregion

        #region Criptografia de Senha
        public string CriptSenha(string sSenha)
        {
            return null;
        }
        #endregion
    }
}