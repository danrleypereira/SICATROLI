using System;
using System.Security.Cryptography;

public static class TokenUtils
{
    private const int TokenLength = 32;

    public static string GenerateToken()
    {
        byte[] randomBytes = new byte[TokenLength];
        using (RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(randomBytes);
        }

        return Convert.ToBase64String(randomBytes);
    }
}
//  string token = TokenUtils.GenerateToken();
//  Console.WriteLine(token);
