using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_reporte_AfiliacionEPS : System.Web.UI.Page
{
    public AfiliadosAsignados[] afiliado ;
    protected void Page_Load(object sender, EventArgs e)
    {
        man_AfiliadosAsignados mafi = new man_AfiliadosAsignados();
        afiliado = mafi.getAfiliadosEmpleador(Request.QueryString["id"].ToString(),"");

        
    }
}