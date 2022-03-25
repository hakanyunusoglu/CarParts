using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Infrastructure.Tools
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }

        public JwtTokenResponse(string token)
        {
            Token = token;
        }
    }
}
