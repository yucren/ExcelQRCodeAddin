using System.Collections.Generic;

namespace ExcelQRCodeAddin
{
    public interface IExcelTool
    {
     dynamic ReadExcelAll();
        void PrintQrCode();
    }
}