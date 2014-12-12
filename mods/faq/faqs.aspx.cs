using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_faq_faqs : System.Web.UI.Page
{
    man_faqs faqs = new man_faqs();

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
                    
                }
                else
                {
                    String[] resul = faqs.getFaq(Request.Params["idfaqs"]);
                    HfId.Value = resul[0];
                    TxtTitulo.Value = resul[1];
                    txtDescripcion.Value = resul[2];
                    ddlTipo.SelectedIndex = Convert.ToInt16(resul[3])-1;
                    

                    opcionesBoton(false, true, true, true);
                }

            }
            catch
            {
                
                opcionesBoton(true, false, false, false);
            }
        }
        GetGuardados();
    }

    protected void opcionesBoton(bool guardar, bool actualizar, bool eliminar, bool cancelar)
    {
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
        TxtTitulo.Value = "";
        txtDescripcion.Value = "";
        HfArchivo.Value = "";
        HfId.Value = "";
    }

    protected bool Enviar(String opcion)
    {


        if (faqs.AddFaqs(TxtTitulo.Value,txtDescripcion.Value,opcion,HfId.Value,ddlTipo.SelectedValue ))
        {
            limpiar();
            Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
        }

        else
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
        }
        GetGuardados();
        return true;
    }

    public void GetGuardados()
    {
        List_menus.InnerHtml = faqs.GetFaqs(Request.RawUrl);
        

    }
    protected void UpdateData_Click(object sender, EventArgs e)
    {
        try
        {
            Enviar("update");
           
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
            
        }
        catch
        {

        }
    }
}