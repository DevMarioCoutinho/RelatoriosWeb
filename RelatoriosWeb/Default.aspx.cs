using RelatoriosWeb.Classe;
using System;
using System.Security.Cryptography;
using System.Web.UI;

namespace RelatoriosWeb
{
    public partial class Default : System.Web.UI.Page
    {
        #region Variaveis Global
        Usuario objUsuario = new Usuario();
        Criptografia objCriptografia = new Criptografia(SHA512.Create());
        string retorno = null;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
            }
        }
        #endregion

        #region Popula Objeto Usuario se os campos de Login e Senha estiverem Preenchidos
        public Usuario PopulaUsuario(string Login, string Senha)
        {
            var usuario = new Usuario();

            if(!string.IsNullOrWhiteSpace(Login) || !string.IsNullOrWhiteSpace(Senha))
            {
                usuario.Login = Login;
                usuario.Senha = Senha;

                return usuario;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Limpa TextBox
        public void LimparCampos()
        {
            txtPassword.Text = null;
            txtUsername.Text = null;
        }
        #endregion

        #region Evento de Click -> Valida Usuario e redireciona a outra pagina Web
        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            objUsuario = PopulaUsuario(txtUsername.Text, objCriptografia.CriptografarSenha(txtPassword.Text));
            
            if(objUsuario is object)
            {
                retorno = objUsuario.ValidaUsuario(objUsuario);

                if (retorno.Equals("Ok"))
                {
                    Session["Usuario"] = objUsuario;

                    Response.Redirect("~/View/RelatorioVenda.aspx");
                }
                else if(retorno.Equals("Invalido"))
                {
                    txtErro.ForeColor = System.Drawing.Color.Red;
                    txtErro.Text = "Usuario e/ou Senha invalido";
                }else if (retorno.Equals("Erro"))
                {
                    txtErro.ForeColor = System.Drawing.Color.Red;
                    txtErro.Text = "Usuario Inexistente";
                }
                else
                {
                    txtErro.ForeColor = System.Drawing.Color.Red;
                    txtErro.Text = "Falha ao Validar Login {Erro interno}";
                }
            }

            LimparCampos();
        }
        #endregion
    }
}