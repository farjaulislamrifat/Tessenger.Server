
using System.Security.Cryptography;
using System.Text;

namespace Tessenger.Server.Algorithoms
{
    public class Algorithoms : IAlgorithoms
    {
        public async Task<string> Encryption(string text, string publickey, string secretkey)
        {
            return await Task.Run(() =>
            {
                try
                {
                    string ToReturn = "";
                    byte[] secretkeyByte = { };
                    secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                    byte[] publickeybyte = { };
                    publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                    MemoryStream ms = null;
                    CryptoStream cs = null;
                    byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(text);
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateEncryptor( publickeybyte ,secretkeyByte),
                                              CryptoStreamMode.Write);
                        cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                        cs.FlushFinalBlock();
                        ToReturn = Convert.ToBase64String(ms.ToArray());
                    }
                    return ToReturn;
                }
                catch (Exception ex)
                {
                    return null;

                }
            });

        }

        public async Task<string> Decryption(string text, string publickey, string secretkey)
        {
            return await Task.Run(() =>
            {
                try
                {
                    string ToReturn = "";
                    byte[] privatekeyByte = { };
                    privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                    byte[] publickeybyte = { };
                    publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                    MemoryStream ms = null;
                    CryptoStream cs = null;
                    byte[] inputbyteArray = new byte[text.Replace(" ", "+").Length];
                    inputbyteArray = Convert.FromBase64String(text.Replace(" ", "+"));
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte),
                                              CryptoStreamMode.Write);
                        cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                        cs.FlushFinalBlock();
                        Encoding encoding = Encoding.UTF8;
                        ToReturn = encoding.GetString(ms.ToArray());
                    }
                    return ToReturn;
                }
                catch (Exception ae)
                {
                    return null;
                }
            });
        }
    }
}
