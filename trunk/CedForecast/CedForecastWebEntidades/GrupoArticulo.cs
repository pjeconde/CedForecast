using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class GrupoArticulo
    {
        private string idGrupoArticulo;
        private string descrGrupoArticulo;
        private CedForecastWebEntidades.Division division;

        public GrupoArticulo()
        {
        }
        public string IdGrupoArticulo
        {
            set
            {
                idGrupoArticulo = value;
            }
            get
            {
                return idGrupoArticulo;
            }
        }
        public string DescrGrupoArticulo
        {
            set
            {
                descrGrupoArticulo = value;
            }
            get
            {
                return descrGrupoArticulo;
            }
        }
        public CedForecastWebEntidades.Division Division
        {
            set
            {
                division = value;
            }
            get
            {
                return division;
            }
        }
    }
}