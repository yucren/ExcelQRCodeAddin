using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using ThoughtWorks.QRCode.Codec;
using Newtonsoft.Json;
using Excel= Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;
using ExcelQRCodeAddin.Tools;

namespace ExcelQRCodeAddin
{
    public partial class QrPanel
    {
        private int alreadyPrintCout = 0;
        private int remainCout = 0;

        private void QrPanel_Load(object sender, RibbonUIEventArgs e)
        {

        }
        private void DrawQrcode(Graphics g, ItemMaster itemMaster)
        {
            Graphics gg = Graphics.FromHwnd(new IntPtr(Globals.ThisAddIn.Application.Hwnd));
           var  dpiY = gg.DpiY;
           var  dpiX = gg.DpiX;
           var  width = Math.Floor(4 / 2.54 * dpiX);
           var  height = Math.Floor(3 / 2.54 * dpiY);
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE; //二维码编码方式
            qRCodeEncoder.QRCodeScale = 4; //每个小方格的预设宽度（像素），正整数
            qRCodeEncoder.QRCodeVersion = 0; //二维码版本号 0-40
            qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M; //纠错码等级
            g.DrawImage(qRCodeEncoder.Encode(itemMaster.fInfo, Encoding.UTF8), 10, 20, 80, 80);
            g.DrawString(itemMaster.料号, new Font("微软雅黑", 5), new SolidBrush(Color.Black), new Point(90, 20));
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Near;
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;
            string printString = string.Format("[{0}]", itemMaster.品名);
            System.Drawing.Rectangle r = new Rectangle(90, 30, 60, 40);
            Rectangle rr = new Rectangle(90, 80, 60, 30);
            g.DrawString(printString, new Font("宋体", 6), new SolidBrush(Color.Black), r, stringFormat);
            g.DrawString(string.Format("[{0}]", itemMaster.供应商编码), new Font("微软雅黑", 5), new SolidBrush(Color.Black), new Point(90, 70));
            g.DrawString("SN:\n" + string.Format("[{0}]", string.IsNullOrEmpty(itemMaster.序列号)?"N/A":itemMaster.序列号), new Font("微软雅黑", 5), new SolidBrush(Color.Black), rr, stringFormat);
            //  g.DrawString(VC, new Font("宋体", 5), new SolidBrush(Color.Black), new Point(90, 30 + 10 * (cout + 2)));
            g.DrawRectangle(new Pen(new SolidBrush(System.Drawing.Color.Black), 0.3F), new Rectangle(new Point(5, 5), new Size((int)width - 5, (int)height - 5)));
            g.Dispose();

        }
        ItemMaster[] itemMasters = null;
        private void PrintQrBtn_Click(object sender, RibbonControlEventArgs e)
        {
            itemMasters = ExcelTool.ReadExcelAll().ToArray();
            remainCout =itemMasters.Count();          
         //   printDialog1.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            if (printDialog1.ShowDialog()== DialogResult.OK)
            {
                printDialog1.Document = printDocument1;
                printDocument1.EndPrint += PrintDocument1_EndPrint;
                printDocument1.Print();

            }
            else
            {
                return;
            }
            
           
            //pageSetupDialog1.PrinterSettings = printDialog1.PrinterSettings;
            //pageSetupDialog1.PageSettings = printDialog1.PrinterSettings.DefaultPageSettings;
            //pageSetupDialog1.AllowMargins = true;
            //pageSetupDialog1.AllowOrientation = true;
            //pageSetupDialog1.AllowPaper = true;
            //pageSetupDialog1.AllowPrinter = true;
          //  pageSetupDialog1.ShowDialog();
          //  pageSetupDialog1.Document = printDocument1;
            //  pageSetupDialog1.PageSettings.PaperSize = new PaperSize("40*30", 157, 118);
           
            //pageSetupDialog1.ShowDialog();

            //   MessageBox.Show(pageSetupDialog1.PageSettings.Margins.Top.ToString());

           


        }

        private void PrintDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        
            var g = e.Graphics;
            //var source = (dataGridView1.DataSource as List<ItemMaster>).ToList();

            //  DrawQrcode(g, source[alreadyPrintCout]);
            DrawQrcode(g, itemMasters[alreadyPrintCout]);
            alreadyPrintCout += 1;
            // remainCout = source.Count() - alreadyPrintCout;
            remainCout = itemMasters.Count()  - alreadyPrintCout;
            e.HasMorePages = remainCout > 0;
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            alreadyPrintCout = 0;
            remainCout = 0;
        }

        private void printDocument1_EndPrint_1(object sender, PrintEventArgs e)
        {
           // MessageBox.Show("打印完成");
        }

        private void printViewBtn_Click(object sender, RibbonControlEventArgs e)
        {
            itemMasters = ExcelTool.ReadExcelAll().ToArray();
            remainCout = itemMasters.Count();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void template_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Globals.ThisAddIn.Application.Sheets["打印模板"].Select();
            }
            catch (Exception)
            {

                Globals.ThisAddIn.Application.Sheets.Add().Name = "打印模板";

            }
            
            Globals.ThisAddIn.Application.Range["a1"].Value = "行号";
            Globals.ThisAddIn.Application.Range["b1"].Value = "料号";
            Globals.ThisAddIn.Application.Range["c1"].Value = "品名";
            Globals.ThisAddIn.Application.Range["d1"].Value = "序列号";
            Globals.ThisAddIn.Application.Range["e1"].Value = "供应商编码";
            Globals.ThisAddIn.Application.Range["a2"].Value = "1";
            Globals.ThisAddIn.Application.Range["b2"].Value = "16606030010";
            Globals.ThisAddIn.Application.Range["c2"].Value = "铲斗油缸~LG6065W.31~组合件";
            Globals.ThisAddIn.Application.Range["d2"].Value = "0318120007";
            Globals.ThisAddIn.Application.Range["e2"].Value = "100011";
            Globals.ThisAddIn.Application.Columns["A:E"].EntireColumn.AutoFit();
             



        }

        private void openMesBtn_Click(object sender, RibbonControlEventArgs e)
        {
    
            Process.Start("http://ldmes.lonking.cn");
        }
        System.Data.DataTable dataTable = new DataTable();
        private void editBox1_TextChanged(object sender, RibbonControlEventArgs e)
        {
            if (editBox1.Text.Length >10)
            {
                using (SqlConnection sqlconn = new SqlConnection("data source=192.168.1.22;database=test_LonKingMES_FJJX;uid=sa;pwd=lonking"))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    SqlCommand sqlCommand = new SqlCommand("select a.fItemCode,a.fItemName,b.fSupplierCode,b.fSupplierName from lkm_Materials a left join lkm_srm_sm_relation b on a.fItemCode =b.fItemCode where a.fItemCode='" + editBox1.Text + "'", sqlconn);
                    sqlconn.Open();
                    dataAdapter.SelectCommand = sqlCommand;
                    dataTable.Clear();
                    dataAdapter.Fill(dataTable);
                    supplierDp.Items.Clear();
                    foreach (var item in dataTable.AsEnumerable())
                    {
                        RibbonDropDownItem ribbonDropDownItem = this.Factory.CreateRibbonDropDownItem();
                        ribbonDropDownItem.Label = item["fSupplierName"] + ":" + item["fSupplierCode"];
                        supplierDp.Items.Add(ribbonDropDownItem);

                    }
                }
            }

            
            
        }
        
        private void generateQrData_Click(object sender, RibbonControlEventArgs e)
        {
            
            
            try
            {
                
                    
                    var rangeB1 = Globals.ThisAddIn.Application.Range["b1"];
                    Excel.Range insertBegin = null;
                   
                        
                        
                        if (string.IsNullOrEmpty(rangeB1.Value))
                        {
                            Globals.ThisAddIn.Application.Range["a1"].Value = "行号";
                            Globals.ThisAddIn.Application.Range["b1"].Value = "料号";
                            Globals.ThisAddIn.Application.Range["c1"].Value = "品名";
                            Globals.ThisAddIn.Application.Range["d1"].Value = "序列号";
                            Globals.ThisAddIn.Application.Range["e1"].Value = "供应商编码";

                            insertBegin = rangeB1;
                        }
                        else
                        {
                        
                            insertBegin = Globals.ThisAddIn.Application.Range["b1"].End[Excel.XlDirection.xlDown];

                    
                    if (insertBegin.Row==Globals.ThisAddIn.Application.Rows.Count)
                    {

                        Globals.ThisAddIn.Application.Range["a2"].Value = string.IsNullOrEmpty(rangeB1.Value) ? (insertBegin.Offset[0, -1].Row) : insertBegin.Offset[0, -1].Row - 1;
                        Globals.ThisAddIn.Application.Range["b2"].Value = editBox1.Text;
                        Globals.ThisAddIn.Application.Range["c2"].Value = dataTable.AsEnumerable().First()["fItemName"];
                        //  insertBegin.Offset[3, 0].Value = item["fItemCode"];
                        Globals.ThisAddIn.Application.Range["e2"].Value = supplierDp.SelectedItem.Label.Split(':')[1];

                    }
                    else
                    {
                        insertBegin.Offset[1, -1].Value = string.IsNullOrEmpty(rangeB1.Value) ? (insertBegin.Offset[1, -1].Row) : insertBegin.Offset[1, -1].Row - 1;
                        insertBegin.Offset[1, 0].Value = editBox1.Text;
                        insertBegin.Offset[1, 1].Value = dataTable.AsEnumerable().First()["fItemName"];
                        //  insertBegin.Offset[3, 0].Value = item["fItemCode"];
                        insertBegin.Offset[1, 3].Value = supplierDp.SelectedItem.Label.Split(':')[1];

                    }

                }
                       
                        Globals.ThisAddIn.Application.Columns["A:E"].EntireColumn.AutoFit();


                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  Globals.ThisAddIn.Application.Cells[1, 7].value = ex.Message;
            }
           


            }

        private void supplierDp_SelectionChanged(object sender, RibbonControlEventArgs e)
        {

        }

        private void DatabaseSetBtn_Click(object sender, RibbonControlEventArgs e)
        {
            DbConnForm dbConnForm = new DbConnForm();
            
            dbConnForm.ShowDialog();
             


        }

      
    }
    }

