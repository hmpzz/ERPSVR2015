using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContrals
{
    public class ToExcel
    {

        /// <summary>
        /// 将ExDataGridView中的数据导出到Excel文件中
        /// </summary>
        /// <param name="gridview">要导出的ExDataGridView</param>
        /// <returns></returns>
        public static bool ExDataGridViewToExcel(ExDataGridView gridview)
        {

            System.Windows.Forms.SaveFileDialog SFD = new System.Windows.Forms.SaveFileDialog();

            string FileName = "";

            if (gridview.Columns.Count==0)
            {
                throw new Exception("没有可以导出的数据！");
            }

            SFD.Filter = "Excel文件(*.xls)|*.xls";
            SFD.Title = "导出Excel表";

            if (SFD.ShowDialog()==System.Windows.Forms.DialogResult.Cancel)
            {
                return false;
            }


            FileName = SFD.FileName.ToString().Trim();

           

      

            
         Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                if (app==null)
                {
                    return false;
                }

                app.Visible = false;
                app.Workbooks.Add();
                Worksheet sheet1;



               sheet1= app.Worksheets["sheet1"];
                


                object[,] RC = new object[gridview.Rows.Count+1 , gridview.Columns.Count ];


                int col=0;

                for (int i = 0; i < gridview.Columns.Count; i++)
                {
                    //如果列头的名称为空则不导出这列 
                    if (gridview.Columns[i].HeaderText.ToString().Length == 0 || gridview.Columns[i].Visible == false)
                    {
                        continue;
                    }
                    

                    RC[0, col] = gridview.Columns[i].HeaderText.ToString();
                    string FormatString;
                    
                    FormatString = gridview.Columns[i].DefaultCellStyle.Format;

                    if (FormatString.Trim().Length==0)
                    {
                        FormatString = gridview.Columns[i].CellTemplate.Style.Format;
                    }

                    string ColumnType = "";

                    if (gridview.Columns[i].ValueType == null)
                    {
                        ColumnType = gridview.Columns[i].CellTemplate.ValueType.Name;
                    }
                    else
                    {
                        ColumnType = gridview.Columns[i].ValueType.Name;
                    }
                    
                    switch (ColumnType)
                    {
                        case "Decimal":
                        case "Int32":
                        case "Int16":
                        case "Int":
                        case "Int64":
                            if (FormatString.Length>0)
                            {
                                sheet1.Columns[col+1].NumberFormatLocal = FormatString;
                            }
                            break;
                        case "String":
                        case "Boolean":
                            sheet1.Columns[col+1].NumberFormatLocal = "@";
                            break;
                        case "DateTime":
                            sheet1.Columns[col+1].NumberFormatLocal = "yyyy-M-d";
                            break;


                            }

                    col = col + 1;


                }

                

                for (int i = 0; i < gridview.Rows.Count; i++)
                {
                    col = 0;
                    for (int j = 0; j < gridview.Columns.Count; j++)
                    {
                        if (gridview.Columns[j].HeaderText.ToString().Length!=0 &&  gridview.Columns[i].Visible == true)
                        {
                            RC[i+1, col] = gridview.Rows[i].Cells[j].Value;
                            col = col + 1;
                        }
                        
                    }
                }


                sheet1.Range[app.Cells[1, 1], app.Cells[gridview.Rows.Count + 1, gridview.Columns.Count ]].Value2 = RC;
                app.ActiveWorkbook.SaveCopyAs(FileName);
                app.ActiveWorkbook.Saved = true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                
            }


        
            return true;
        }
    }
}
