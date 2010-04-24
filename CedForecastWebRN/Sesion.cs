using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    class Sesion
    {
        public void Login(string IdUsuario, string Password, string Dominio, string CnnStr, string IdAcceso, string VersionActual, string VersionParaControl, CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.Sesion.Crear(IdUsuario, Password, Dominio, CnnStr, IdAcceso, VersionActual, VersionParaControl, Sesion);
        }
    }
}
