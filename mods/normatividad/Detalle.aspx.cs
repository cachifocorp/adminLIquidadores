using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_normatividad_Detalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public String getTitulo()
    {
        try
        {
            return Request.Params["tipo"];
        }
        catch
        {
            return "";
        }
    }
    protected void SaveData_Click(object sender, EventArgs e)
    {
        try
        {
            if (Enviar("insert"))
            {
                limpiar();
            }

        }
        catch
        {

        }
    }

    private void limpiar()
    {
        txtAsunto.Value = "";
        txtAutoridadExpide.Value = "";
        txtFecha.Value = "";
        txtFechaPublicacion.Value = "";
        txtNumero.Value = "";
        HfArchivo.Value = "";
        HfId.Value = "";
    }

    protected bool Enviar(String opcion)
    {
        String fileName = HfArchivo.Value;
        if (flIcon.HasFile)
        {
             fileName = "Normatividad_"+DateTime.Now.ToString("yyyyMMddHHmmss")+Path.GetFileName(flIcon.FileName);
             flIcon.SaveAs(Server.MapPath("~/Site/Pages/normatividad/")  + fileName);
                
            
        }
        normatividad objNormatividad = new normatividad();
        objNormatividad.Numero = txtNumero.Value;
        objNormatividad.Fecha = txtFecha.Value;
        objNormatividad.FechaPublicacion = txtFechaPublicacion.Value;
        objNormatividad.EntidadEmite = txtAutoridadExpide.Value;
        objNormatividad.Archivo = fileName;
        objNormatividad.Asunto = txtAsunto.Value;
        objNormatividad.Id = HfId.Value;
        objNormatividad.Tipo = "4";

        man_normatividad Normatividad = new man_normatividad();
        return Normatividad.AddNormatividad(objNormatividad, opcion);
    }
}