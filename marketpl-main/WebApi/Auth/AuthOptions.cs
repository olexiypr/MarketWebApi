using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Auth;

public class AuthOptions
{
    public const string ISSUER = "TradeMarketAuthServer";
    public const string AUDIENCE = "TradeMarket"; 
    const string KEY = "mysupersecret_secretkey!123";   
    public const int LIFETIME = 10;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}