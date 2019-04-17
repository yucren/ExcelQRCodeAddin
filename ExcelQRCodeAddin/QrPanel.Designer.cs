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
            this.qrcodeTab = this.Factory.CreateRibbonTab();
            this.qrGroup = this.Factory.CreateRibbonGroup();
            this.PrintQrBtn = this.Factory.CreateRibbonButton();
            this.printViewBtn = this.Factory.CreateRibbonButton();
            this.template = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.supplierDp = this.Factory.CreateRibbonDropDown();
            this.generateQrData = this.Factory.CreateRibbonButton();
            this.findBtn = this.Factory.CreateRibbonButton();
            this.DatabaseSetBtn = this.Factory.CreateRibbonButton();
            this.openMesBtn = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.editCpName = this.Factory.CreateRibbonEditBox();
            this.editCpCode = this.Factory.CreateRibbonEditBox();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.RegisterBtn = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.qrcodeTab.SuspendLayout();
            this.qrGroup.SuspendLayout();
            this.group2.SuspendLayout();
            this.group4.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // qrcodeTab
            // 
            this.qrcodeTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.qrcodeTab.Groups.Add(this.group2);
            this.qrcodeTab.Groups.Add(this.group4);
            this.qrcodeTab.Groups.Add(this.group3);
            this.qrcodeTab.Groups.Add(this.qrGroup);
            this.qrcodeTab.Label = "二维码插件";
            this.qrcodeTab.Name = "qrcodeTab";
            // 
            // qrGroup
            // 
            this.qrGroup.Items.Add(this.PrintQrBtn);
            this.qrGroup.Items.Add(this.printViewBtn);
            this.qrGroup.Items.Add(this.template);
            this.qrGroup.Label = "打印二维码";
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
            this.group2.Items.Add(this.editBox1);
            this.group2.Items.Add(this.supplierDp);
            this.group2.Items.Add(this.generateQrData);
            this.group2.Items.Add(this.findBtn);
            this.group2.Items.Add(this.DatabaseSetBtn);
            this.group2.Items.Add(this.openMesBtn);
            this.group2.Label = "生成二维码";
            this.group2.Name = "group2";
            // 
            // editBox1
            // 
            this.editBox1.Label = "料号";
            this.editBox1.Name = "editBox1";
            this.editBox1.SizeString = "中华人民共和国祝神穸谢a";
            this.editBox1.Text = null;
            this.editBox1.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editBox1_TextChanged);
            // 
            // supplierDp
            // 
            this.supplierDp.Label = "供应商";
            this.supplierDp.Name = "supplierDp";
            this.supplierDp.SizeString = "华人民共和国祝神穸";
            this.supplierDp.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.supplierDp_SelectionChanged);
            // 
            // generateQrData
            // 
            this.generateQrData.Label = "生成二维码数据";
            this.generateQrData.Name = "generateQrData";
            this.generateQrData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.generateQrData_Click);
            // 
            // findBtn
            // 
            this.findBtn.Label = "查询";
            this.findBtn.Name = "findBtn";
            this.findBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.findBtn_Click);
            // 
            // DatabaseSetBtn
            // 
            this.DatabaseSetBtn.Label = "设置数据库";
            this.DatabaseSetBtn.Name = "DatabaseSetBtn";
            this.DatabaseSetBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DatabaseSetBtn_Click);
            // 
            // openMesBtn
            // 
            this.openMesBtn.Label = "打开MES";
            this.openMesBtn.Name = "openMesBtn";
            this.openMesBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openMesBtn_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.editCpName);
            this.group4.Items.Add(this.editCpCode);
            this.group4.Items.Add(this.button2);
            this.group4.Label = "公司信息配置";
            this.group4.Name = "group4";
            // 
            // editCpName
            // 
            this.editCpName.Label = "公司名称";
            this.editCpName.Name = "editCpName";
            this.editCpName.SizeString = "中华人民共和国中央人民广播电台";
            this.editCpName.Text = null;
            // 
            // editCpCode
            // 
            this.editCpCode.Label = "公司编码";
            this.editCpCode.Name = "editCpCode";
            this.editCpCode.SizeString = "中华人民共和国中央人民广播电台";
            this.editCpCode.Text = null;
            // 
            // button2
            // 
            this.button2.Label = "保存";
            this.button2.Name = "button2";
            this.button2.OfficeImageId = "FileSave";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.RegisterBtn);
            this.group3.Items.Add(this.button1);
            this.group3.Items.Add(this.button3);
            this.group3.Label = "注册";
            this.group3.Name = "group3";
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Label = "注册软件";
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.RegisterBtn_Click);
            // 
            // button1
            // 
            this.button1.Label = "关于";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Label = "button3";
            this.button3.Name = "button3";
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
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
            this.Tabs.Add(this.qrcodeTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.QrPanel_Load);
            this.qrcodeTab.ResumeLayout(false);
            this.qrcodeTab.PerformLayout();
            this.qrGroup.ResumeLayout(false);
            this.qrGroup.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DatabaseSetBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RegisterBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editCpName;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editCpCode;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton findBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        public Microsoft.Office.Tools.Ribbon.RibbonTab qrcodeTab;
    }

    partial class ThisRibbonCollection
    {
        internal QrPanel QrPanel
        {
            get { return this.GetRibbon<QrPanel>(); }
        }
    }
}
