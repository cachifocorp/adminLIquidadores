using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_offices : System.Web.UI.Page
{

    private static Users usr;
    private static profile pf;
    man_offices off = new man_offices();

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

                        assignDataFields(off.getOffice(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        off.deleteOffice(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
        list_offices.InnerHtml = off.TableDataOptions(usr.Id_dependence, usr, pf, "offices.aspx");
        
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void SaveData_Click(object sender, EventArgs e)
    {
        offices off = new offices();
        man_offices moff = new man_offices();
        if (flIcon.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(flIcon.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
                    off.Lat = latitude.Value;
                    off.Lon = longitude.Value;
                    off.Id_dependence = usr.Id_dependence;
                    off.Address = txtAddress.Value;
                    off.Phone = txtPhone.Value;
                    off.Fax = txtFax.Value;
                    off.Email = txtEmail.Value;
                    off.Id_city = Convert.ToInt32(ddlCity.SelectedValue);

                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                   off.Icon = newName;
                    if (moff.saveOffice(off))
                    {
                        //flIcon.SaveAs(Resources.patchDependence.uploadGeneral + newName);
                        flIcon.SaveAs(genericFunctions.paths(usr.Id_dependence,4) + newName);
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
        offices off = new offices();
        man_offices moff = new man_offices();
        if (flIcon.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(flIcon.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
                    off.Lat = latitude.Value;
                    off.Lon = longitude.Value;
                    off.Id_dependence = usr.Id_dependence;
                    off.Address = txtAddress.Value;
                    off.Phone = txtPhone.Value;
                    off.Fax = txtFax.Value;
                    off.Email = txtEmail.Value;
                    off.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
                    off.Id = Convert.ToInt32(Request.QueryString["idItem"]);

                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    off.Icon = newName;
                    if (moff.UpdateOffice(off,1))
                    {
                        //flIcon.SaveAs(Resources.patchDependence.uploadGeneral + newName);
                        flIcon.SaveAs(genericFunctions.paths(usr.Id_dependence,4) + newName);
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                        // clear()
                        Response.Redirect("offices.aspx");
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
            off.Lat = latitude.Value;
            off.Lon = longitude.Value;
            off.Id_dependence = usr.Id_dependence;
            off.Address = txtAddress.Value;
            off.Phone = txtPhone.Value;
            off.Fax = txtFax.Value;
            off.Email = txtEmail.Value;
            off.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
            off.Id = Convert.ToInt32(Request.QueryString["idItem"]);
            off.Icon = "";
            if (moff.UpdateOffice(off,2))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Actualizada</p>";
                Response.Redirect("offices.aspx");
                UpdateData.Enabled = false;
                SaveData.Enabled = true;
                Response.Redirect("offices.aspx");

                // clear();
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }
        }
    }

    private void assignDataFields(offices offi) {
        txtAddress.Value = offi.Address;
        txtPhone.Value = offi.Phone;
        txtFax.Value = offi.Fax;
        txtEmail.Value = offi.Email;
        //ddlCity.Items.FindByValue(offi.Id_city.ToString()).Selected = true; 
        latitude.Value = offi.Lat+"";
        longitude.Value = offi.Lon+"";
        UpdateData.Enabled = true;
        SaveData.Enabled = false;
    }

}