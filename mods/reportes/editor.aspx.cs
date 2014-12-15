using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_reportes_editor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void SaveData_Click(object sender, EventArgs e)
    {
        try
        {

            String path = Server.MapPath("");
            var dict = new Dictionary<string, string>
            {
                { "titulo", txtTitulo.Value },
                { "resolucion", txresolucion.Value },
                { "footer", txtfooter.Value }  
            };
           
            
            string[] lines = dict.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(path+"\\rep1.txt",lines);

        }catch (Exception ez) {
            Response.Write("<script>alert('Exception " + ez.Message+"'); </script>");
        }
        
    }




    protected void btnCargar_Click(object sender, EventArgs e)
    {
        try {
            String path = Server.MapPath("");
             var dict = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(path + "\\rep1.txt");
             dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);

            txtTitulo.Value     = dict["titulo"];
            txresolucion.Value  = dict["resolucion"];
            txtfooter.Value     = dict["footer"];

        }
        catch (Exception ex) { }
    }
    protected void btngarCertif_Click(object sender, EventArgs e)
    {

        try
        {
            String path = Server.MapPath("");
            var dict = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(path + "\\rep2.txt");
            dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);

            txtCertTitulo.Value = dict["titulo"];
            txtCerCuerpo.Value = dict["cuerpo"];
            txtAtt.Value = dict["att"];

        }
        catch (Exception ex) { }
    }
    protected void btnCertif_Click(object sender, EventArgs e)
    {
        try
        {

            String path = Server.MapPath("");
            var dict = new   Dictionary<string, string>
            {
                { "titulo", txtCertTitulo.Value },                
                { "cuerpo", txtCerCuerpo.Value },
                { "att", txtAtt.Value }
            };


            string[] lines = dict.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(path + "\\rep2.txt", lines);

        }
        catch (Exception ez)
        {
            Response.Write("<script>alert('Exception " + ez.Message + "'); </script>");
        }
    }
}