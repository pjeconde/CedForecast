using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace CedForecast.WS
{
    [WebService(Namespace = "http://cedeira.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Sincronizacion : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola mundo";
        }
    }
}