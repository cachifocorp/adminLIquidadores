using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_normatividad_Detalle : System.Web.UI.Page
{
    man_normatividad Normatividad = new man_normatividad();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HfCodigo.Value = Request.RawUrl;
            try
            {
                String accion = Request.Params["accion"];
                if (accion.Equals(""))
                {
                    opcionesBoton(true, false, false, false);
                    Divguardado.Visible = false;
                }
                else
                {
                    String[] resul = Normatividad.getNormatividad(Request.Params["tipo"], Request.Params["idNormatividad"]);
                    HfId.Value = resul[0];
                    txtNumero.Value = resul[1];
                    txtFecha.Value = resul[2];
                    txtAutoridadExpide.Value = resul[3];
                    txtAsunto.Value = resul[4];
                    txtFechaPublicacion.Value = resul[6];
                    Divguardado.Visible = true;
                    hfLink.NavigateUrl = Server.MapPath("~/normatividad/") + resul[5];
                    HfArchivo.Value = resul[5];

                    opcionesBoton(false, true, true, true);
                }
                
            }
            catch
            {
                Divguardado.Visible = false;
                opcionesBoton(true, false, false, false);
            }
        }
    }

    protected void opcionesBoton(bool guardar,bool actualizar,bool eliminar,bool cancelar){
        SaveData.Enabled = guardar;
        UpdateData.Enabled = actualizar;
        DeleteData.Enabled = eliminar;
        //CancelData.Enabled = cancelar;

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
            Enviar("insert");
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
             flIcon.SaveAs(Server.MapPath("~/normatividad/")  + fileName);
                
            
        }
        normatividad objNormatividad = new normatividad();
        objNormatividad.Numero = txtNumero.Value;
        objNormatividad.Fecha = txtFecha.Value;
        objNormatividad.FechaPublicacion = txtFechaPublicacion.Value;
        objNormatividad.EntidadEmite = txtAutoridadExpide.Value;
        objNormatividad.Archivo = fileName;
        objNormatividad.Asunto = txtAsunto.Value;
        objNormatividad.Id = HfId.Value;
        objNormatividad.Tipo = Request.Params["Codigo"];

        if (Normatividad.AddNormatividad(objNormatividad, opcion))
        {
            limpiar();
            Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
        }

        else
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
        }
        return true;
    }

    public String GetGuardados()
    {
       return Normatividad.GetNormatividad(Request.Params["Codigo"],Request.RawUrl);
       
    }
    protected void UpdateData_Click(object sender, EventArgs e)
    {
        try
        {
            Enviar("update");
            Response.Redirect("Detalle.aspx?tipo=" + Request.Params["tipo"] + "&Codigo=" + Request.Params["Codigo"]);
        }
        catch
        {

        }
    }
    protected void DeleteData_Click(object sender, EventArgs e)
    {
        try
        {
            Enviar("delete");
            Response.Redirect("Detalle.aspx?tipo=" + Request.Params["tipo"] + "&Codigo=" + Request.Params["Codigo"]);
        }
        catch
        {

        }
    }
}