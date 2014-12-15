using System;
using System.Collections.Generic;
using System.IO;
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
        cargarDatos();
        afiliado = mafi.getAfiliadosEmpleador(Request.QueryString["id"].ToString(),"");

        
    }


    public void cargarDatos() {
        try
        {
            String path = Server.MapPath("~/mods/reportes/");
            var dict = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(path + "\\rep1.txt");
            dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);           
            titulo.InnerHtml = dict["titulo"];
            resolucion.InnerHtml = dict["resolucion"];
            footer.InnerHtml = dict["footer"];
        }
        catch (Exception ex) { }
    }
}