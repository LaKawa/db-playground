using System.Security.Cryptography;

namespace MusicDBPlayground.DiscogsIntegration.Services;

public class EncryptionService
{
   public string GenerateRandomSalt(int size = 16)
   {
      var saltBytes = RandomNumberGenerator.GetBytes(size);
      return Convert.ToBase64String(saltBytes);
   }

   private (byte[] key, byte[] iv) DeriveKeyAndIv(string passphrase, string base64Salt)
   {
      var saltBytes = Convert.FromBase64String(base64Salt);
      using var deriveBytes = new Rfc2898DeriveBytes(passphrase, saltBytes, 100_000, HashAlgorithmName.SHA256);
      var key = deriveBytes.GetBytes(32);
      var iv = deriveBytes.GetBytes(16);
      return (key, iv);
   }

   public string Encrypt(string plainText, string passphrase, string base64Salt)
   {
      var (key, iv) = DeriveKeyAndIv(passphrase, base64Salt);
      
      using var aes = Aes.Create();
      aes.Key = key;
      aes.IV = iv;
      
      using var encryptor = aes.CreateEncryptor();
      using var memoryStream = new MemoryStream();
      using var cs = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
      using(var sw = new StreamWriter(cs))
      {
         sw.Write(plainText);
      }
      
      return Convert.ToBase64String(memoryStream.ToArray());
   }

   public string Decrypt(string cipherText, string passphrase, string base64Salt)
   {
      var (key, iv) = DeriveKeyAndIv(passphrase, base64Salt);
      var cipherBytes = Convert.FromBase64String(cipherText);

      using var aes = Aes.Create();
      aes.Key = key;
      aes.IV = iv;
      
      using var decryptor = aes.CreateDecryptor();
      using var memoryStream = new MemoryStream(cipherBytes);
      using var cs = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
      using var sr = new StreamReader(cs);
      
      return sr.ReadToEnd();
   }
}