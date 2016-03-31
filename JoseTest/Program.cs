using JosePCL.Keys.Rsa;
using JosePCL.Serialization;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var manager = new ConfigurationManager<OpenIdConnectConfiguration>("https://demo.identityserver.io/.well-known/openid-configuration");
            var config = manager.GetConfigurationAsync().Result;

            var n = config.JsonWebKeySet.Keys.First().N;
            var e = config.JsonWebKeySet.Keys.First().E;

            var nBytes = Base64Url.Decode(n);
            var eBytes = Base64Url.Decode(e);

            var key = PublicKey.New(eBytes, nBytes);

        }
    }
}
