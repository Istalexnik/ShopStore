using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ShopStore.Tools
{
    public class Encryption
    {

        public string EncryptIt(string clearText)
        {
            return Encrypt(clearText);
        }

        public string DecryptIt(string cipherText)
        {
            return Decrypt(cipherText);
        }

        //Example how to call
        //lblEncryptedText.Text = this.Encrypt(txtOriginalText.Text.Trim());
        //string name = HttpUtility.UrlEncode(Encrypt(txtName.Text.Trim()));
        //string technology = HttpUtility.UrlEncode(Encrypt(ddlTechnology.SelectedItem.Value));
        //Response.Redirect(string.Format("~/CS2.aspx?name={0}&technology={1}", name, technology));

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "X3KH2SKBF59D7A4";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        //Example how to call
        //lblDecryptedText.Text = this.Decrypt(txtEncryptedText.Text.Trim());
        //lblName.Text = Decrypt(HttpUtility.UrlDecode(Request.QueryString["name"]));

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "X3KH2SKBF59D7A4";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}