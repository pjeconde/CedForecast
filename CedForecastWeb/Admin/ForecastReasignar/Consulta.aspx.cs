using System;
using System.Data;
using System.Globalization;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Xml;

namespace CedForecastWeb.Admin.ForecastReasignar
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("AdministracionLinkButton")).ForeColor = System.Drawing.Color.DarkBlue;
        }
    }
}
