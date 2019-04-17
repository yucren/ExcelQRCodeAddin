using ExcelQRCodeAddin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialNumber
{
 
  public   class Tools : ITools
    {
        public static DateTime updateTime;
        private static SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
        internal static void SavePrint()
        {
            var file = AppDomain.CurrentDomain.BaseDirectory + "\\qrcodes.db";
            if (!File.Exists(file))
            {
                SQLiteConnection.CreateFile(file);
                
            }
            
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source="+ file +";Pooling=true;FailIfMissing=false"))
            {
               
              
                sqlite.Open();
                string sql = "";
                //SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                //command.ExecuteNonQuery();
                string sql1 = "insert into highscores (name, score) values ('Me', 3000)";
                SQLiteCommand command = new SQLiteCommand();
                

                sql = "insert into highscores (name, score) values ('Myself', 6000)";
                command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                sql = "insert into highscores (name, score) values ('And I', 9001)";
                command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
                sql = "select * from highscores order by score desc";
                command = new SQLiteCommand(sql, sqlite);
                SQLiteDataReader reader = command.ExecuteReader();
                var result = "";
                while (reader.Read())
                    result += "Name: " + reader["name"] + "\tScore: " + reader["score"];
                MessageBox.Show(result);
            }
            
           
        }
        public  string Encode(string data, string KEY_64, string IV_64)

        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            int i = cryptoProvider.KeySize;

            MemoryStream ms = new MemoryStream();

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);



            StreamWriter sw = new StreamWriter(cst);

            sw.Write(data);

            sw.Flush();

            cst.FlushFinalBlock();

            sw.Flush();

            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);



        }

        public  string Encrypto(string Source)

        {

            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);

            MemoryStream ms = new MemoryStream();

            mobjCryptoService.Key = GetLegalKey();

            mobjCryptoService.IV = GetLegalIV();

            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();

            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

            cs.Write(bytIn, 0, bytIn.Length);

            cs.FlushFinalBlock();

            ms.Close();

            byte[] bytOut = ms.ToArray();

            return Convert.ToBase64String(bytOut);

        }
        public  string Decrypto(string Source)

        {

            byte[] bytIn = Convert.FromBase64String(Source);

            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);

            mobjCryptoService.Key = GetLegalKey();

            mobjCryptoService.IV = GetLegalIV();

            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();

            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();

        }
        public  string Decode(string data, string key, string iv)

        {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);



            byte[] byEnc;

            try

            {

                byEnc = Convert.FromBase64String(data);

            }

            catch

            {

                return null;

            }



            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(byEnc);

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cst);

            return sr.ReadToEnd();

        }
        /// 获得密钥     

        /// </summary>     

        /// <returns>密钥</returns>     
        static string Key = "6515114";
        private static byte[] GetLegalKey()

        {

            string sTemp = Key;

            mobjCryptoService.GenerateKey();

            byte[] bytTemp = mobjCryptoService.Key;

            int KeyLength = bytTemp.Length;

            if (sTemp.Length > KeyLength)

                sTemp = sTemp.Substring(0, KeyLength);

            else if (sTemp.Length < KeyLength)

                sTemp = sTemp.PadRight(KeyLength, ' ');

            return ASCIIEncoding.ASCII.GetBytes(sTemp);

        }

        /// <summary>     

        /// 获得初始向量IV     

        /// </summary>     

        /// <returns>初试向量IV</returns>     

        private static byte[] GetLegalIV()

        {

            string sTemp = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";

            mobjCryptoService.GenerateIV();

            byte[] bytTemp = mobjCryptoService.IV;

            int IVLength = bytTemp.Length;

            if (sTemp.Length > IVLength)

                sTemp = sTemp.Substring(0, IVLength);

            else if (sTemp.Length < IVLength)

                sTemp = sTemp.PadRight(IVLength, ' ');

            return ASCIIEncoding.ASCII.GetBytes(sTemp);

        }

        public  string GetUpDate()
        {
            return updateTime.ToLongTimeString();
        }

        public  string GetComputerInfo()
        {
            return new  ComputerInfo().GetComputerInfo();
        }

        public string AppPath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory ;           
            return path;
        }
    }
}

