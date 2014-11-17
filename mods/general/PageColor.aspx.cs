using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_PageColor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String header = genericFunctions.leerArchivo(Server.MapPath("~/mods/records/header.txt"));
            header = header.Substring(0, 6);
            String menu = genericFunctions.leerArchivo(Server.MapPath("~/mods/records/menu.txt"));
            menu = menu.Substring(0, 6);
            txtHeaderFooter.Value = header;
            TxtMenu.Value = menu;
        }
    }
    protected void SaveData_Click(object sender, EventArgs e)
    {
        try
        {
            String css = genericFunctions.leerArchivo(Server.MapPath("~/Site/Pages/src/css/style.css"));
            String header = genericFunctions.leerArchivo(Server.MapPath("~/mods/records/header.txt"));
            String menu = genericFunctions.leerArchivo(Server.MapPath("~/mods/records/menu.txt"));
            header = header.Substring(0, 6);
            menu = menu.Substring(0, 6);
            css = css.Replace(header, txtHeaderFooter.Value);
            css = css.Replace(menu, TxtMenu.Value);
           bool result= genericFunctions.escribirArchivo(css, Server.MapPath("~/Site/Pages/src/css/style.css"));
            genericFunctions.escribirArchivo(txtHeaderFooter.Value, Server.MapPath("~/mods/records/header.txt"));
            genericFunctions.escribirArchivo(TxtMenu.Value, Server.MapPath("~/mods/records/menu.txt"));
            if (result)
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }
        }
        catch
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
        }
    }
}