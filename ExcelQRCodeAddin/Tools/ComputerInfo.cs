using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace ExcelQRCodeAddin.Tools
{
    public class ComputerInfo : IComputerInfo
    {
        public  string GetComputerInfo() {
            

        string cpuId = "";
        string biosId = "";
        string computerInfo = "";

        SelectQuery query = new SelectQuery("Select ProcessorId From Win32_Processor");
        SelectQuery queryBios = new SelectQuery("Select SerialNumber From Win32_Bios");
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
        ManagementObjectSearcher managementObjectSearcherBios = new ManagementObjectSearcher(queryBios);
            foreach (var item in managementObjectSearcher.Get())
            {
                cpuId += item["ProcessorId"]+";";
            }
            foreach (var item in managementObjectSearcherBios.Get())
            {
                biosId += item["SerialNumber"] + ";";
            }

         computerInfo = cpuId + biosId;
            computerInfo = computerInfo.Replace(" ", "").Replace(";","");
            return computerInfo;




         }  
               
    }
}
