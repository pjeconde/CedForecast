using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class PlanillaInfoEmbarque : db
    {
        public PlanillaInfoEmbarque(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }

        public string Leer()
        {
            DataView dv = WF_Parm_get("DirectorioPlanillaInfoEmbarque");
            return Convert.ToString(dv.Table.Rows[0]["ValorStr"]);
        }
        public void Guardar(string DirectorioPlanillaInfoEmbarque)
        {
            WF_ParmValorStr_upd("DirectorioPlanillaInfoEmbarque", DirectorioPlanillaInfoEmbarque);
        }
    }
}
