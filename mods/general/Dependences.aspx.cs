using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_Dependences : System.Web.UI.Page
{
    private static Users usr;
    private static profile pf;
    man_dependences dep = new man_dependences();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["idItem"] != null)
            {

                switch (Request.QueryString["action"])
                {
                    case "1":
                        
                        break;

                    case "2":
                        LoadinfoFields(dep.getDependenceInfo(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        dep.deleteDependence(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
        
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }
    protected void SaveData_Click(object sender, EventArgs e)
    {
        dependences dep = new dependences();
        man_dependences mdep = new man_dependences();
        if (flIcon.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(flIcon.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
                    dep.Lat = Convert.ToDouble(latitude.Value);
                    dep.Lon = Convert.ToDouble(longitude.Value);
                    dep.Address = txtAddress.Value;
                    dep.Phone = txtPhone.Value;
                    dep.Url = txturl.Value;
                    dep.Email = txtEmail.Value;
                    dep.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
                    
                    //actions upload File
                    String newName = "dependence_"+DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    dep.Dependence_logo = newName;
                    if (mdep.saveDependence(dep))
                    {
                        flIcon.SaveAs(Resources.patchDependence.uploadDependence + newName);
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                        // clear();
                    }
                    else
                    {
                        Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
                    }


                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">Tipo de dato No Aceptado</p>";
                }
            }
            catch (Exception ex)
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error! Información no guardada  error:(" + ex.Message + ")</p>";
            }
        }
        else
        {
            Messages.InnerHtml = "<p class=\"bg-warning\">No ha seleccionado ningun archivo para enviar</p>";
        }
    }

    protected void UpdateData_Click(object sender, EventArgs e)
    {
        dependences dep = new dependences();
        man_dependences mdep = new man_dependences();
        if (flIcon.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(flIcon.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
                    dep.Lat = Convert.ToDouble(latitude.Value);
                    dep.Lon = Convert.ToDouble(longitude.Value);
                    dep.Address = txtAddress.Value;
                    dep.Name = txtName.Value;
                    dep.Phone = txtPhone.Value;
                    dep.Url = txturl.Value;
                    dep.Email = txtEmail.Value;
                    dep.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
                    dep.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                    dependences depe = mdep.getDependenceInfo(Convert.ToInt32(Request.QueryString["idItem"]));

                    //actions upload File
                    String newName = "dependence_" + DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    dep.Dependence_logo = newName;
                    if (mdep.updateDependece(dep,1))
                    {
                        flIcon.SaveAs(Resources.patchDependence.uploadDependence+ newName);
                        String archivo = Server.MapPath("../../../"+Resources.Resource.pathUploadDependence + depe.Dependence_logo);
                        eliminarArchivo(archivo);
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                        UpdateData.Enabled = false;
                        SaveData.Enabled = true;
                        // clear();
                    }
                    else
                    {
                        Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
                    }
                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">Tipo de dato No Aceptado</p>";
                }
            }
            catch (Exception ex)
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error! Información no guardada  error:(" + ex.Message + ")</p>";
            }
        }
        else
        {
            dep.Lat = Convert.ToDouble(latitude.Value);
            dep.Lon = Convert.ToDouble(longitude.Value);
            dep.Address = txtAddress.Value;
            dep.Name = txtName.Value;
            dep.Phone = txtPhone.Value;
            dep.Url = txturl.Value;
            dep.Email = txtEmail.Value;
            dep.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
            dep.Id = Convert.ToInt32(Request.QueryString["idItem"]);
            dep.Dependence_logo = "";
            if (mdep.updateDependece(dep,2))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                UpdateData.Enabled = false;
                SaveData.Enabled = true;
                // clear();
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }
        }
    
    }

    public void LoadinfoFields(dependences deps) {
        txtName.Value = deps.Name;
        txtAddress.Value = deps.Address;
        txtPhone.Value = deps.Phone;
        txturl.Value = deps.Url;
        txtEmail.Value = deps.Email;
        latitude.Value = deps.Lat.ToString();
        longitude.Value = deps.Lon.ToString() ;
        dep.configddls(ddlContry, ddlState, ddlCity, deps.Id_city);
        //SetDDLs(ddlContry, "1");
        //ddlState.DataBind();
        //SetDDLs(ddlState, "1");
        //ddlCity.DataBind();
        //SetDDLs(ddlCity, "2");
        UpdateData.Enabled = true;
        SaveData.Enabled = false;
    }


    private void SetDDLs(DropDownList d, String val)
    {
        try
        {
            ListItem li;
            for (int i = 0; i < d.Items.Count; i++)
            {
                li = d.Items[i];
                if (li.Value == val)
                {
                    d.SelectedIndex = i;
                    i = d.Items.Count;
                    break;
                }
            }
        }
        catch (Exception ext)
        {
            String error = ext.Message;

        }

    }


     /// <summary>
   /// este metodo elimina archivos del servidor segun una ruta especifica
   /// </summary>
   /// <param name="aliminar"></param>
   public void eliminarArchivo(String eliminar)
   {
       try
       {            
           System.IO.File.Delete(eliminar);
       }
       catch
       {
           Response.Write("<script languaje='javascript'>alert('Archivo no existe');</script>");
       }
   }
//archivo = Server.MapPath("../../Archivos/Procesos/" + archivo);
//                   eliminarArchivo(archivo);
}

