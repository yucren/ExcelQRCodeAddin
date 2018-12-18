using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
using ExcelQRCodeAddin;
using System;

public static class Qrcode
{
    public static void PrintQrcode(Graphics g, ItemMaster itemMaster)
    {
        Graphics gg = Graphics.FromHwnd(new IntPtr(Globals.ThisAddIn.Application.Hwnd));
        var dpiY = gg.DpiY; var dpiX = gg.DpiX; var width = Math.Floor(4 / 2.54 * dpiX);
        var height = Math.Floor(3 / 2.54 * dpiY);
        QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
        qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        //二维码编码方式
        qRCodeEncoder.QRCodeScale = 4;
        //每个小方格的预设宽度（像素），正整数
        qRCodeEncoder.QRCodeVersion = 0;
        //二维码版本号 0-40
        qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
        //纠错码等级
        g.DrawImage(qRCodeEncoder.Encode(itemMaster.fInfo, Encoding.UTF8), 10, 20, 80, 80);
        g.DrawString(itemMaster.料号, new Font("微软雅黑", 5), new SolidBrush(Color.Black), new Point(90, 20));
        StringFormat stringFormat = new StringFormat();
        stringFormat.LineAlignment = StringAlignment.Near;stringFormat.FormatFlags = StringFormatFlags.LineLimit;
        string printString = string.Format("[{0}]", itemMaster.品名);
        System.Drawing.Rectangle r = new Rectangle(90, 30, 60, 40);
        Rectangle rr = new Rectangle(90, 80, 60, 30);
        g.DrawString(printString, new Font("宋体", 6), new SolidBrush(Color.Black), r, stringFormat);
        g.DrawString(string.Format("[{0}]", itemMaster.供应商编码), new Font("微软雅黑", 5), new SolidBrush(Color.Black), new Point(90, 70));
        g.DrawString("SN:\n" + string.Format("[{0}]", string.IsNullOrEmpty(itemMaster.序列号)?"N/A":itemMaster.序列号), new Font("微软雅黑", 5), new SolidBrush(Color.Black), rr, stringFormat);
        g.DrawRectangle(new Pen(new SolidBrush(System.Drawing.Color.Black), 0.3F), new Rectangle(new Point(5, 5), new Size((int)width - 5, (int)height - 5)));
        g.Dispose();
    }
}