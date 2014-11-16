using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_integrators : System.Web.UI.Page
{
    private static profile pf;
    private static Users usr;
    man_integrator min = new man_integrator();
    private integrators integrator;
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
                        LoadDataFileds(min.getDataIntegrator(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        min.deleteIntegrator(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assignDataSession();
        //String path = Resources.patchDependence.DomainDependence + Resources.Resource.pathUploadintegrators;
        String path = genericFunctions.paths(usr.Id_dependence,1)+ Resources.Resource.pathUploadintegrators;
        list_inte.InnerHtml = min.TableDataOptions(3, path, usr, pf, "integrators.aspx");
        

    }

    public   void assignDataSession()
    {
        usr = (Users) Session["User"];
        pf = (profile) Session["Profile"];
    }


    protected void SaveData_Click(object sender, EventArgs e)
    {
        integrators integ = new integrators();
        man_integrator mint = new man_integrator();

        if (flIntegrator.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(flIntegrator.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
        integ.Name = txtName.Text;
        integ.Description = taDescription.Value;
        integ.Id_dependence = usr.Id_dependence;
        integ.DateRegister = DateTime.Now;
        integ.State = Convert.ToInt32(chkstate.Checked);
        //actions upload File
        String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
        integ.Photo = newName;
        if (mint.saveIntegrator(integ))
        {
            
            //flIntegrator.SaveAs(Server.MapPath(Resources.patchDependence.uploadIntegrators) + newName);
            flIntegrator.SaveAs(Server.MapPath(genericFunctions.paths(usr.Id_dependence,5)) + newName);
           // flIntegrator.SaveAs(Server.MapPath("\\AMV\\Pages\\uploads\\integrators\\") + newName);
            Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
            //clear();
            String path = genericFunctions.paths(usr.Id_dependence, 1) + Resources.Resource.pathUploadintegrators;
            list_inte.InnerHtml = min.TableDataOptions(3, path, usr, pf, "integrators.aspx");
        }
        else
        {
            Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se publico el Archivo</p>";
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

    protected void UpdateData_Click(object sender, EventArgs e) {
        integrators integr = new integrators();
        man_integrator mint = new man_integrator();

        if (flIntegrator.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(flIntegrator.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
                    integrators integ= new integrators();
                    integ.Name = txtName.Text;
                    integ.Description = taDescription.Value;
                    integ.Id_dependence = usr.Id_dependence;
                    integ.DateRegister = DateTime.Now;
                    integ.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                    integ.State = Convert.ToInt32(chkstate.Checked);
                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    integ.Photo = newName;
                    if (mint.updateIntegrador(integ,1))
                    {
                        integrator = min.getDataIntegrator(Convert.ToInt32(Request.QueryString["idItem"]));
                        //System.IO.File.Delete(Server.MapPath(Resources.patchDependence.uploadIntegrators) + integrator.Photo);
                        FileInfo files = new FileInfo(Server.MapPath(Resources.patchDependence.uploadIntegrators) + integrator.Photo);
                        if (files.Exists) {
                            files.Delete();
                        }
                        //flIntegrator.SaveAs(Server.MapPath(Resources.patchDependence.uploadIntegrators) + newName);
                        flIntegrator.SaveAs(Server.MapPath(genericFunctions.paths(usr.Id_dependence, 5)) + newName);
                        
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada  </p>";
                        //clear();
                        String path = genericFunctions.paths(usr.Id_dependence, 1) + Resources.Resource.pathUploadintegrators;
                        list_inte.InnerHtml = min.TableDataOptions(usr.Id_dependence, path, usr, pf, "integrators.aspx");
                        Response.Redirect("integrators.aspx");
                    }
                    else
                    {
                        Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo la informacion</p>";
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

            integr.Name = txtName.Text;
            integr.Description = taDescription.Value;
            integr.Id_dependence = usr.Id_dependence;
            integr.DateRegister = DateTime.Now;
            integr.State = Convert.ToInt32(chkstate.Checked);
            integr.Photo = "";
            integr.Id = Convert.ToInt32(Request.QueryString["idItem"]);
            if (mint.updateIntegrador(integr, 2))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                //clear();
                String path = genericFunctions.paths(usr.Id_dependence, 1) + Resources.Resource.pathUploadintegrators;
                list_inte.InnerHtml = min.TableDataOptions(usr.Id_dependence, path, usr, pf, "integrators.aspx");
                updateData.Enabled = false;
                SaveData.Enabled = true;
                Response.Redirect("integrators.aspx");
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo la informacion</p>";
            }
        }
    }


    private void LoadDataFileds(integrators integrator) {
        
        txtName.Text = integrator.Name;
        taDescription.Value = integrator.Description;
        String path = genericFunctions.paths(usr.Id_dependence, 1) + Resources.Resource.pathUploadintegrators + integrator.Photo;
        imgeInte.InnerHtml = "<img src=\"" +path+ "\" widht=\"110px\" height=\"110px\">";
        updateData.Enabled = true;
        SaveData.Enabled = false;
        chkstate.Checked = Convert.ToBoolean(integrator.State);
    }
}