using RelatoriosWeb.AcessoDados;
using RelatoriosWeb.Classe;
using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;

namespace RelatoriosWeb.View
{
    public partial class RelatorioVenda : System.Web.UI.Page
    {
        #region Variaveis Global
        Usuario objUsuario = new Usuario();
        Configuracao objConfiguracao = new Configuracao();
        ExportExcel objExportExcel = new ExportExcel();
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

        }
        #endregion

        #region Exporta DataGrid para Excel
        protected void btnGerar_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            string sArquivo = @"Relatorio Venda " + DateTime.Today.ToString("dd-MM-yyyy") + ".xlsx";

            try
            {
                ds = objConfiguracao.TodasVendas();

                if (ValidaDataSet(ds))
                {
                    var Arq = objExportExcel.ExportToExcel(ds, sArquivo);
                    DownloadArquivo(Arq, sArquivo);
                }
                else
                {
                    string txtInfo = "Não Há Registro de Vendas na Base de Dados";
                    OpenMessageBox(txtInfo, "Informação", System.Windows.MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                string txtWarning = "Falha na Consulta ao Banco de Dados -> " + ex.Message;
                OpenMessageBox(txtWarning, "Warning", System.Windows.MessageBoxImage.Warning);
            }


        }
        #endregion

        #region Download Arquivo ArrayByte Browser
        public void DownloadArquivo(byte[] Arquivo, string NomeArquivo)
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.CacheControl = "public";
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            HttpContext.Current.Response.AddHeader("Cache-Control", "must-revalidate, post-check=0, pre-check=0");
            HttpContext.Current.Response.AddHeader("Content-Description", "Excel File Download");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + NomeArquivo + "\"");

            HttpContext.Current.Response.BinaryWrite(Arquivo);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        #endregion

        #region Abre MessageBox com Alerta sobre Geração do Relatorio
        public void OpenMessageBox(string sInfo, string sTitulo, System.Windows.MessageBoxImage Icon)
        {
            System.Windows.MessageBox.Show(sInfo, sTitulo, System.Windows.MessageBoxButton.OK, Icon);
        }
        #endregion

        #region Valida se possui dados no DataSet
        public bool ValidaDataSet(DataSet ds)
        {
            bool existe = false;
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    existe = true;
                }
            }
            catch
            {
                existe = false;
            }
            return existe;
        }
        #endregion

    }
}