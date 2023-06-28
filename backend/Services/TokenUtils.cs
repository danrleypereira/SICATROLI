using System;
using System.Security.Cryptography;

public static class TokenUtils
{
    private const int TokenLength = 32;

    public static string GenerateToken()
    {
        byte[] randomBytes = new byte[TokenLength];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        return Convert.ToBase64String(randomBytes);
    }
}
