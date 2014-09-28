using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraGrid;

namespace WCFDbService

{
    public class ReportDB
    {

        static public bool exportDataToExcel(string tieude, DataTable dt)
        {
            bool result = false;
            //khoi tao cac doi tuong Com Excel de lam viec
            Excel.ApplicationClass xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
            object missValue = System.Reflection.Missing.Value;
            //khoi tao doi tuong Com Excel moi
            xlApp = new Excel.ApplicationClass();
            xlBook = xlApp.Workbooks.Add(missValue);
            //su dung Sheet dau tien de thao tac
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
            xlApp.Visible = false;
            int socot=dt.Columns.Count;
            int sohang=dt.Rows.Count;
            int i,j;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {


                //set thuoc tinh cho tieu de
                xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1").Merge(false);
                Excel.Range caption = xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1");
                caption.Select();
                caption.FormulaR1C1 = tieude;
				//căn lề cho tiêu đề
                caption.HorizontalAlignment = Excel.Constants.xlCenter;
                caption.Font.Bold = true;
                caption.VerticalAlignment = Excel.Constants.xlCenter;
                caption.Font.Size = 15;
				//màu nền cho tiêu đề
                caption.Interior.ColorIndex = 20;
                caption.RowHeight = 30;
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A2", Convert.ToChar(socot + 65) + "2");
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < socot; i++)
                    xlSheet.Cells[2, i + 2] = dt.Columns[i].ColumnName;
                //dien cot stt
                xlSheet.Cells[2, 1] = "STT";
                for (i = 0; i < sohang; i++)
                    xlSheet.Cells[i + 3, 1] = i + 1;
                //dien du lieu vao sheet


                for (i = 0; i < sohang; i++)
                    for (j = 0; j < socot; j++)
                    {
                        xlSheet.Cells[i + 3, j + 2] = dt.Rows[i][j];

                    }
                //autofit độ rộng cho các cột 
                for (i = 0; i < sohang; i++)
                    ((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();

                //save file
                xlBook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();
                
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                result = true;
            }
            return result;
        }
     static  public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
               throw new  Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    
      
         
        public static void ExportToXls(string fileName, GridControl grid)
        {
            if (grid.DefaultView.RowCount == 0)
            { 
                MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // if there is data to export

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = fileName;
            dialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            if (dialog.ShowDialog() != DialogResult.OK)
                return; 
            try
            {
                // if file is readonly error will be thrown here
                grid.DefaultView.GetRow(0); 
                string tmpDirectoryName = string.Concat(Path.GetTempPath(), Guid.NewGuid(), @"\");
                if (!Directory.Exists(tmpDirectoryName))
                    Directory.CreateDirectory(tmpDirectoryName);

                string tmpFilename = string.Concat(tmpDirectoryName, Path.GetFileName(dialog.FileName));

                if (File.Exists(tmpFilename))
                    File.Delete(tmpFilename); 
                // user was already asked for replace existing file via file open dialog.
                if (File.Exists(dialog.FileName))
                    File.Delete(dialog.FileName);

                // old method exports all columns as text, new one - as represented
                // (i.e. checkboxes represented as images).
                #pragma warning disable 0618
                grid.ExportToExcelOld(tmpFilename);
                #pragma warning restore 0618
                File.Move(tmpFilename, dialog.FileName); 
                if (Directory.Exists(tmpDirectoryName))
                    Directory.Delete(tmpDirectoryName);
                MessageBox.Show("Export thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Trong quá trình export xảy ra lỗi : {0}", ex.Message));
            }
        }
    }
}
