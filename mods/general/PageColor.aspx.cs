using System;
using System.Collections.Generic;
using System.IO;
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
            String pHeader=txtHeaderFooter.Value;
            String pMenu=TxtMenu.Value;
            bool resultColor=false;
            if (pHeader.Length == 6 && pMenu.Length == 6)
            {
                String header = genericFunctions.leerArchivo(Server.MapPath("~/mods/records/header.txt"));
                String menu = genericFunctions.leerArchivo(Server.MapPath("~/mods/records/menu.txt"));
                header = header.Substring(0, 6);
                menu = menu.Substring(0, 6);
                if (flIcon.HasFile)
                {
                    String fileName = Path.GetFileName(flIcon.FileName);
                    if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                    {
                        //pt101.jpg
                        String newName = "pt101.jpg";
                        flIcon.SaveAs(Server.MapPath("~/Site/Pages/src/images/pattern/") + newName);
                        resultColor = true;
                    }
                }
                if (!pHeader.Equals(header) || !pMenu.Equals(menu))
                {
                    String css = genericFunctions.leerArchivo(Server.MapPath("~/Site/Pages/src/css/style.css"));

                    css = css.Replace(header, txtHeaderFooter.Value);
                    css = css.Replace(menu, TxtMenu.Value);
                    resultColor = genericFunctions.escribirArchivo(css, Server.MapPath("~/Site/Pages/src/css/style.css"));
                    genericFunctions.escribirArchivo(txtHeaderFooter.Value, Server.MapPath("~/mods/records/header.txt"));
                    genericFunctions.escribirArchivo(TxtMenu.Value, Server.MapPath("~/mods/records/menu.txt"));
                    
                }
                if (resultColor)
                {
                    Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
                }

            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! El tamaño del Color no es el Adecuado, Deben tener 6 caracteres</p>";
            }
        }
        catch
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
        }
    }
}