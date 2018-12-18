using System;

namespace SerialNumber
{
    public interface ITools
    {
        string GetComputerInfo();
        string GetUpDate();
        string Decode(string data, string key, string iv);
        string Decrypto(string Source);
        string Encode(string data, string KEY_64, string IV_64);
        string Encrypto(string Source);
    }
}