using System.Security.Cryptography;
using System.Text;
using Rg.Web.Api.Settings;

namespace Rg.Web.Api.Services;

public class HashService : IHashService
{
    private readonly string _salt;
    private readonly MD5 _md5;

    public HashService(HashSettings settings)
    {
        _salt = settings.Salt;
        _md5 = MD5.Create();
    }

    public string GetHash(string input)
    {
        var bytes = _md5.ComputeHash(Encoding.ASCII.GetBytes(_salt + input));
        return BitConverter.ToString(bytes).ToLower().Replace("-", "");
    }
}