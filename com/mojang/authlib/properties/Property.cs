using System.Security.Cryptography;
using System.Text;

namespace Minecraft1_8_9Port.com.mojang.authlib.properties;

public class Property
{
    private readonly string name;
    private readonly string value;
    private readonly string signature;

    public Property(string value, string name) : this(name, value, null) { }

    public Property(string name, string value, string signature)
    {
        this.name = name;
        this.value = value;
        this.signature = signature;
    }

    public string getName()
    {
        return this.name;
    }

    public string getValue()
    {
        return this.value;
    }

    public string getSignature()
    {
        return this.signature;
    }

    public bool hasSignature()
    {
        return this.signature != null;
    }

    public bool isSignatureValid(RSA publicKey)
    {
        try
        {
            var sha1 = SHA1.Create();
            var data = Encoding.UTF8.GetBytes(this.value);
            var signatureBytes = Convert.FromBase64String(this.signature);
            return publicKey.VerifyData(data, signatureBytes, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e);
        }

        return false;
    }
}