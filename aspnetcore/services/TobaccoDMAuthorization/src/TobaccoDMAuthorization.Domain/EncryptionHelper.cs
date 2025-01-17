using System.Security.Cryptography;
using System.Text;

namespace TobaccoDMAuthorization;

/// <summary>
/// 加密解密
/// </summary>
public class EncryptionHelper
{
    public EncryptionHelper(string key, string iv)
    {
        _key = Encoding.UTF8.GetBytes(key);
        _iv = Encoding.UTF8.GetBytes(iv);
    }

    private static byte[] _key = null!;
    private static byte[] _iv = null!;
 
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
 
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
 
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        using var streamWriter = new StreamWriter(cryptoStream);
        streamWriter.Write(plainText);
        streamWriter.Flush();
        cryptoStream.FlushFinalBlock();
 
        return Convert.ToBase64String(memoryStream.ToArray());
    }
 
    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    public string Decrypt(string cipherText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
 
        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
 
        byte[] bytes = Convert.FromBase64String(cipherText);
 
        using var memoryStream = new MemoryStream(bytes);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);
 
        return streamReader.ReadToEnd();
    }
}