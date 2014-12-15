using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site_Pages_consultas_reporte_certificado : System.Web.UI.Page
{
    public AfiliadosAsignados[] afi;
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarDatos();
         afi = new man_AfiliadosAsignados().getAfiliado(Request.QueryString["id"], "");
    }


    public void cargarDatos()
    {
        try
        {
            String path = Server.MapPath("~/mods/reportes/");
            var dict = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(path + "\\rep2.txt");
            dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
            titulo.InnerHtml = dict["titulo"];
            contenido.InnerHtml = dict["cuerpo"];
            desp.InnerHtml = dict["att"];
        }
        catch (Exception ex) { }
    }
}