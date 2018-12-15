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
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;
using ExcelQRCodeAddin.Tools;
using System.Management;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections.ObjectModel;

namespace ExcelQRCodeAddin
{
    public partial class QrPanel : IQrPanel
    {

        private int alreadyPrintCout = 0;
        private int remainCout = 0;

        private void QrPanel_Load(object sender, RibbonUIEventArgs e)
        {

        }
        private void DrawQrcode(Graphics g, ItemMaster itemMaster)
        {
            ExceladdinRegister.Register register = new ExceladdinRegister.Register();
            if (register.GenereQrCode() == "未注册")
            {
                MessageBox.Show("请先注册");
                return;
            }
            //    MessageBox.Show(register.GenereQrCode());
            string returnData = null;
            CompilerResults results = null;
            using (var provider = new CSharpCodeProvider())
            {
                var options = new CompilerParameters();
                options.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\ThoughtWorks.QRCode.dll");
                options.ReferencedAssemblies.Add("System.Drawing.dll");
                options.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\ExcelQRCodeAddin.dll");
                options.GenerateInMemory = true;
                results = provider.CompileAssemblyFromSource(options, register.GenereQrCode());
                //   Globals.ThisAddIn.Application.Cells[9, 1].Value = class1.Qrcode();
            }
            if (results.Errors.HasErrors)
            {
                var errorMesage = new StringBuilder();
                foreach (CompilerError item in results.Errors)
                {
                    errorMesage.AppendFormat("{0},{1}", item.Line, item.ErrorText);
                }
                returnData = errorMesage.ToString();
                Globals.ThisAddIn.Application.Cells[8, 1].Value = returnData;
            }
            else
            {
                Type QrcodeType = results.CompiledAssembly.GetType("Qrcode");
                QrcodeType.GetMethod("PrintQrcode").Invoke(null, new object[] { g, itemMaster, Globals.ThisAddIn.Application.Hwnd });
            }


        }
        ItemMaster[] itemMasters = null;
        public void PrintQrCode()
        {


            //   printDialog1.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                printDialog1.Document = printDocument1;
                printDocument1.EndPrint += PrintDocument1_EndPrint;
                printDocument1.Print();

            }
            else
            {
                return;
            }

        }
        private void PrintQrBtn_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {



                ExceladdinRegister.Register register2 = new ExceladdinRegister.Register();
                switch (register2.PrintQrCode())
                {

                    case "注册码不正确":
                        MessageBox.Show("请重新注册软件");
                        break;
                    case "未注册":
                        MessageBox.Show("请先注册软件,再使用");
                        break;

                    default:
                        string returnData = null;
                        CompilerResults results = null;
                        using (var provider = new CSharpCodeProvider())
                        {
                            var options = new CompilerParameters();
                            options.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                            options.ReferencedAssemblies.Add("System.Drawing.dll");
                            options.ReferencedAssemblies.Add("System.dll");
                            options.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\ExcelQRCodeAddin.dll");
                            options.GenerateInMemory = true;
                            results = provider.CompileAssemblyFromSource(options, register2.StartPrint());
                            //   Globals.ThisAddIn.Application.Cells[9, 1].Value = class1.Qrcode();
                        }
                        if (results.Errors.HasErrors)
                        {
                            var errorMesage = new StringBuilder();
                            foreach (CompilerError item in results.Errors)
                            {
                                errorMesage.AppendFormat("{0},{1}", item.Line, item.ErrorText);
                            }
                            returnData = errorMesage.ToString();

                        }
                        else
                        {
                            Type QrcodeType = results.CompiledAssembly.GetType("Qrcode");
                            itemMasters = new ExcelTool().ReadExcelAll().ToArray();
                            remainCout = itemMasters.Count();
                            QrcodeType.GetMethod("StartPrin").Invoke(null, new object[] { itemMasters, printDialog1, printDocument1 });
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message, "错误提示");
            }
        }
        private void PrintDocument1_EndPrint(object sender, PrintEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            var g = e.Graphics;
            DrawQrcode(g, itemMasters[alreadyPrintCout]);
            alreadyPrintCout += 1;
            remainCout = itemMasters.Count() - alreadyPrintCout;
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
            try
            {
                ExceladdinRegister.Register register = new ExceladdinRegister.Register();
                if (register.IsRegister())
                {
                    itemMasters = new ExcelTool().ReadExcelAll().ToArray();
                    remainCout = itemMasters.Count();
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();

                }
                else
                {
                    MessageBox.Show("请先注册", "提示");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("发生错误：" + ex.Message, "错误提示");
            }


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
            if (editBox1.Text.Length > 10)
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


                    if (insertBegin.Row == Globals.ThisAddIn.Application.Rows.Count)
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

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void RegisterBtn_Click(object sender, RibbonControlEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.Show();
        }
    }
}

