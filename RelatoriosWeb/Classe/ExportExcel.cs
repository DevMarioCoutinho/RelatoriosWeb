using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace RelatoriosWeb.Classe
{
    public class ExportExcel
    {
        
        public byte[] ExportToExcel(DataSet ds, string NomeArquivo)
        {
            Excel.Application excelApp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            excelApp.DisplayAlerts = true;


            foreach (DataTable table in ds.Tables)
            {
                int[] teste = { 0, 1, 2 };

                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            string tempPath = TempPathFile(NomeArquivo);

            excelWorkBook.SaveAs(tempPath, excelWorkBook.FileFormat);
            excelWorkBook.Close(true, misValue, misValue);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            byte[] result = File.ReadAllBytes(tempPath);
            File.Delete(tempPath);

            return result;
        }


        public string TempPathFile(string NomeArquivo)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + NomeArquivo;
        }

    }   
}
