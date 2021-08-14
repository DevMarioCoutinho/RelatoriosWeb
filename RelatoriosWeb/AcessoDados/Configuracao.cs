using RelatoriosWeb.Classe;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RelatoriosWeb.AcessoDados
{
    public class Configuracao
    {
        #region String de Conexao
        string Conexao = ConfigurationManager.AppSettings.Get("Banco").ToString();
        #endregion

        #region Retorna Dados de Venda
        public DataSet TodasVendas()
        {
            //conexão com banco de dados
            SqlConnection conexao = new SqlConnection(Conexao);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            comando.Connection = conexao;
            comando.CommandText = "SELECT C.Nome As 'Nome Cliente', P.Descricao As 'Descricao', " +
                                          "P.Preco As 'Valor Unitario', V.Quantidade As 'Quantidade', " +
                                          "(P.Preco * V.Quantidade) As 'Valor Total'," + 
                                          "V.Datahora As 'DataVenda' " +
                                  "FROM Cliente C WITH(NOLOCK) " +
                                  "INNER JOIN Venda V WITH(NOLOCK) " +
                                  "ON (C.idCliente = V.fkCliente) " +
                                  "INNER JOIN Produto P WITH(NOLOCK) " +
                                  "ON (P.idProduto = V.fkProduto)";
            comando.CommandTimeout = 3000;

            //popula a variavel do tipo Dataset com retorno do select
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();
            return ds;
        }
        #endregion

        #region Valida Login e Senha do Usuario
        public DataSet ValidaLogin(Usuario usuario)
        {
            //conexão com banco de dados
            SqlConnection conexao = new SqlConnection(Conexao);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            comando.Connection = conexao;
            comando.CommandText = "DECLARE @SENHAUSU VARCHAR(128) \n" +
                                  "IF EXISTS(SELECT Login FROM Usuario WHERE Login = @USUARIO) BEGIN \n" +
                                    "SELECT @SENHAUSU = Senha " +
                                    "FROM Usuario " +
                                    "WHERE Login = @USUARIO \n" +
                                    "IF(@SENHAUSU <> @SENHA)BEGIN \n" +
                                        "SELECT 'Invalido' AS Retorno \n" +
                                    "END ELSE BEGIN \n" +
                                        "SELECT 'Ok' AS 'Retorno' \n" +
                                    "END \n" +                  
                                  "END ELSE BEGIN \n" +
                                    "SELECT 'Erro' AS 'Retorno' \n" +
                                  "END";
            comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario.Login;
            comando.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = usuario.Senha;
            comando.CommandTimeout = 3000;

            //popula a variavel do tipo Dataset com retorno do select
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();
            return ds;
        }
#endregion
    }
}