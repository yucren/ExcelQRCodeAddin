namespace ExcelQRCodeAddin
{
    partial class QrPanel : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public QrPanel()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QrPanel));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.qrGroup = this.Factory.CreateRibbonGroup();
            this.PrintQrBtn = this.Factory.CreateRibbonButton();
            this.printViewBtn = this.Factory.CreateRibbonButton();
            this.template = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.openMesBtn = this.Factory.CreateRibbonButton();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.supplierDp = this.Factory.CreateRibbonDropDown();
            this.generateQrData = this.Factory.CreateRibbonButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tab1.SuspendLayout();
            this.qrGroup.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.qrGroup);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "二维码功能";
            this.tab1.Name = "tab1";
            // 
            // qrGroup
            // 
            this.qrGroup.Items.Add(this.PrintQrBtn);
            this.qrGroup.Items.Add(this.printViewBtn);
            this.qrGroup.Items.Add(this.template);
            this.qrGroup.Label = "二维码组";
            this.qrGroup.Name = "qrGroup";
            // 
            // PrintQrBtn
            // 
            this.PrintQrBtn.Label = "打印二维码";
            this.PrintQrBtn.Name = "PrintQrBtn";
            this.PrintQrBtn.OfficeImageId = "FilePrint";
            this.PrintQrBtn.ShowImage = true;
            this.PrintQrBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.PrintQrBtn_Click);
            // 
            // printViewBtn
            // 
            this.printViewBtn.Label = "打印预览";
            this.printViewBtn.Name = "printViewBtn";
            this.printViewBtn.OfficeImageId = "FilePrintPreview";
            this.printViewBtn.ShowImage = true;
            this.printViewBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.printViewBtn_Click);
            // 
            // template
            // 
            this.template.Label = "二维码数据模板";
            this.template.Name = "template";
            this.template.OfficeImageId = "FileNewDefault";
            this.template.ShowImage = true;
            this.template.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.template_Click);
            // 
            // group2
            // 
            this.group2.DialogLauncher = ribbonDialogLauncherImpl1;
            this.group2.Items.Add(this.generateQrData);
            this.group2.Items.Add(this.editBox1);
            this.group2.Items.Add(this.supplierDp);
            this.group2.Items.Add(this.openMesBtn);
            this.group2.Label = "group2";
            this.group2.Name = "group2";
            // 
            // openMesBtn
            // 
            this.openMesBtn.Label = "打开MES";
            this.openMesBtn.Name = "openMesBtn";
            this.openMesBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openMesBtn_Click);
            // 
            // editBox1
            // 
            this.editBox1.Label = "料号";
            this.editBox1.Name = "editBox1";
            this.editBox1.SizeString = "中华人民共和国祝神穸";
            this.editBox1.Text = null;
            this.editBox1.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editBox1_TextChanged);
            // 
            // supplierDp
            // 
            this.supplierDp.Label = "供应商";
            this.supplierDp.Name = "supplierDp";
            // 
            // generateQrData
            // 
            this.generateQrData.Label = "生成二维码数据";
            this.generateQrData.Name = "generateQrData";
            this.generateQrData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.generateQrData_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint_1);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // QrPanel
            // 
            this.Name = "QrPanel";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.QrPanel_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.qrGroup.ResumeLayout(false);
            this.qrGroup.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup qrGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton PrintQrBtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton printViewBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton template;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openMesBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton generateQrData;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown supplierDp;
    }

    partial class ThisRibbonCollection
    {
        internal QrPanel QrPanel
        {
            get { return this.GetRibbon<QrPanel>(); }
        }
    }
}
