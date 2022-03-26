using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Infrastructure.Tools
{
    public class JwtTokenSettings
    {
        /*
          ValidAudience = "http://localhost",
            ValidIssuer = "http://localhost",
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("carcarcarpart.")),
            ValidateIssuerSigningKey=true
         */

        public const string Issuer = "https://localhost";
        public const string Audience = "https://localhost";
        public const string Key = "yavuzyavuzyavuz1.";
        public const int Expire = 30;

    }
}
