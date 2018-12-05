using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelQRCodeAddin
{

    internal class ExcelTool
    {
        //[DllImport("User32.dll", CharSet = CharSet.Auto)]
        //public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public static List<ItemMaster> ReadExcelAll()
        {
          //  int ProcIdXL = 0;
            Excel.Application application = Globals.ThisAddIn.Application;
            Excel.Worksheet worksheet = application.Sheets[1];
            Excel.Range dd = worksheet.Range["a1"].CurrentRegion.Offset[1, 0].Resize;
            var ddd = dd.Resize[dd.Rows.Count - 1, dd.Columns.Count];
            List<ItemMaster> itemMasters = new List<ItemMaster>();

            foreach (Excel.Range item in ddd.Rows)
            {
                ItemMaster itemMaster = new ItemMaster();
                for (int i = 1; i <= 5; i++)
                {

                    switch (i)
                    {
                        case 1:
                            try
                            {


                                itemMaster.行号 = Convert.ToString(application.Cells[item.Row, i].Value);
                            }
                            catch (RuntimeBinderException)
                            {

                                itemMaster.行号 = "";
                            }

                            break;
                        case 2:
                            try
                            {


                                itemMaster.料号 = Convert.ToString(application.Cells[item.Row, i].Value);
                            }
                            catch (RuntimeBinderException)
                            {

                                itemMaster.料号 = "";
                            }

                            break;
                        case 3:
                            try
                            {


                                itemMaster.品名 = application.Cells[item.Row, i].Value;
                            }
                            catch (RuntimeBinderException)
                            {

                                itemMaster.品名 = "";
                            }
                            break;
                        case 4:
                            try
                            {


                                itemMaster.序列号 = Convert.ToString(application.Cells[item.Row, i].Value);
                            }
                            catch (RuntimeBinderException)
                            {

                                itemMaster.序列号 = "";
                            }
                            break;
                        case 5:
                            try
                            {


                                itemMaster.供应商编码 = Convert.ToString(application.Cells[item.Row, i].Value);
                            }
                            catch (RuntimeBinderException)
                            {

                                itemMaster.供应商编码 = "";
                            }
                            break;


                        default:
                            break;
                    }
                }
                itemMasters.Add(itemMaster);

            }
            //GetWindowThreadProcessId(new IntPtr(application.Hwnd), out ProcIdXL);
            //Process xproc = Process.GetProcessById(ProcIdXL);
            //xproc.Kill();
            //workbook.Close(SaveChanges: false);
            //dd = null;
            //ddd = null;
            //workbook = null;
            //worksheet = null;
            //application.Quit();
            //application = null;
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();

            //GC.WaitForPendingFinalizers();
            //int getneration = System.GC.GetGeneration(application);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
            //GC.Collect(getneration);

            return itemMasters;
            //   Console.Read();
        }


    }

}

