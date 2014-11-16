using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


public partial class mods_publications_projects : System.Web.UI.Page
{
    private static Users usr;
    private static profile pf;
    public man_projects proj = new man_projects();
    private int dependence = Convert.ToInt32(Resources.Resource.depedence);
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
                        loadDataFields(proj.getdataProject(Convert.ToInt32(Request.QueryString["idItem"])));
                        tableImages.InnerHtml = proj.getPhotosSliderFormat(Convert.ToInt32(Request.QueryString["idItem"]), Resources.patchDependence.DomainDependence+Resources.Resource.pathUploadProject);
                        break;
                    case "3":
                        proj.deleteProject(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                    
                }
            }
        }
        assign();
        ucMultiFileUpload.Titulo = "Subir imágenes";
        ucMultiFileUpload.Comment = "Hasta 5 archivos .png, .gif ó .jpg (máx. 4 MB en total).";
        ucMultiFileUpload.MaxFilesLimit = 5;
        //ucMultiFileUpload.DestinationFolder = Resources.patchDependence.uploadProjects; // única propiedad obligatoria.
        ucMultiFileUpload.DestinationFolder = genericFunctions.paths(usr.Id_dependence,7); // única propiedad obligatoria.
        ucMultiFileUpload.FileExtensionsEnabled = ".png|.jpg|.gif";
        
        
        list_projects.InnerHtml = proj.TableDataOptions(usr.Id_dependence, usr, pf, "projects.aspx");

    }
    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }

    protected void btnSaveInfo_Click(object sender, EventArgs e)
    {
        man_projects pro = new man_projects();
        projects pj = new projects();

        if (ucMultiFileUpload.UploadFiles(true)) {
          
            pj.Name = txtName.Value;
            pj.Description = wysiwig_full.Value;
            pj.Autor_project = txt_autor.Value;
            pj.Made_date = Convert.ToDateTime(txtDate.Value);
            pj.Posted_by_id = pf.Id;
            pj.Id_tag = Convert.ToInt32(ddlcatProject.SelectedValue);
            pj.Id_dependence = usr.Id_dependence;
            pj.Featured = Convert.ToInt32(chkfeatured.Checked);
            pj.State = Convert.ToInt32(cbxstate.Checked);
            pj.Lat = 0;
            pj.Lon = 0;
            pj.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
            pj.Id_client = 0;
            pj.Pic = ucMultiFileUpload.NameFiles[0];
            if (pro.saveProject(pj)) {
                pro.saveImagesSlider(ucMultiFileUpload.NameFiles, pro.getIdLastProject(Convert.ToInt32(Session["dependence"])));
            }           

        }
        
#region old logic
        /* if (PicProject.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(PicProject.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {

                    pj.Name = txtName.Value;
                    pj.Description = wysiwig_full.Value;
                    pj.Autor_project = txt_autor.Value;
                    pj.Made_date = Convert.ToDateTime(txtDate.Value);
                    pj.Posted_by_id = pf.Id;
                    pj.Id_tag = Convert.ToInt32(ddlcatProject.SelectedValue);
                    pj.Id_dependence = usr.Id_dependence;
                    pj.Featured =  Convert.ToInt32(chkfeatured.Checked);
                    pj.Lat = 0;
                    pj.Lon = 0;
                    pj.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
                    pj.Id_client = 0;


                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    pj.Pic = newName;
                    if (pro.saveProject(pj))
                    {   
                        //PicProject.SaveAs(Resources.patchDependence.uploadProjects + newName);
                        PicProject.SaveAs(Server.MapPath("\\AMV\\Pages\\uploads\\projects\\" + newName));
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
        */

#endregion
    }

    

    protected void updateSaveInfo_Click(object sender, EventArgs e)
    {
        man_projects pro = new man_projects();
        projects pj = new projects();
        ucMultiFileUpload.amountF();
        if (ucMultiFileUpload.AmountFiles > 0)
        {
            if (ucMultiFileUpload.UploadFiles(true))
            {
                pj.Name = txtName.Value;
                pj.Description = wysiwig_full.Value;
                pj.Autor_project = txt_autor.Value;
                pj.Made_date = Convert.ToDateTime(txtDate.Value);
                pj.Posted_by_id = pf.Id;
                pj.Id_tag = Convert.ToInt32(ddlcatProject.SelectedValue);
                pj.Id_dependence = usr.Id_dependence;
                pj.Featured = Convert.ToInt32(chkfeatured.Checked);
                pj.State = Convert.ToInt32(cbxstate.Checked);
                pj.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                pj.Lat = 0;
                pj.Lon = 0;
                pj.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
                pj.Id_client = 0;
                pj.Pic = ucMultiFileUpload.NameFiles[0];

                if (pro.updateProject(pj, 1))
                {
                    pro.saveImagesSlider(ucMultiFileUpload.NameFiles, pj.Id);
                    clear();
                    UpdateInfo.Enabled = false;
                    btnSaveInfo.Enabled = true;
                    Response.Redirect("projects.aspx");
                }
                else {
                    Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
                }
            }
        }
        else {
            pj.Name = txtName.Value;
            pj.Description = wysiwig_full.Value;
            pj.Autor_project = txt_autor.Value;
            pj.Made_date = Convert.ToDateTime(txtDate.Value);
            pj.Posted_by_id = pf.Id;
            pj.Id_tag = Convert.ToInt32(ddlcatProject.SelectedValue);
            pj.Id_dependence = usr.Id_dependence;
            pj.Featured = Convert.ToInt32(chkfeatured.Checked);
            pj.State = Convert.ToInt32(cbxstate.Checked);
            pj.Id = Convert.ToInt32(Request.QueryString["idItem"]);
            pj.Lat = 0;
            pj.Lon = 0;
            pj.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
            pj.Id_client = 0;
            pj.Pic = "";
            if (pro.updateProject(pj, 2))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                UpdateInfo.Enabled = false;
                btnSaveInfo.Enabled = true;
                clear();
                Response.Redirect("projects.aspx");
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }
        }
        #region old logic
        /*
        if (PicProject.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(PicProject.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {

                    pj.Name = txtName.Value;
                    pj.Description = wysiwig_full.Value;
                    pj.Autor_project = txt_autor.Value;
                    pj.Made_date = Convert.ToDateTime(txtDate.Value);
                    pj.Posted_by_id = pf.Id;
                    pj.Id_tag = Convert.ToInt32(ddlcatProject.SelectedValue);
                    pj.Id_dependence = usr.Id_dependence;
                    pj.Featured = Convert.ToInt32(chkfeatured.Checked);
                    pj.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                    pj.Lat = 0;
                    pj.Lon = 0;
                    pj.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
                    pj.Id_client = 0;
                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    pj.Pic = newName;
                    if (pro.updateProject(pj,1))
                    {
                        PicProject.SaveAs(Resources.patchDependence.uploadProjects + newName);
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                       clear();
                        UpdateInfo.Enabled = false;
                        btnSaveInfo.Enabled = true;
                        Response.Redirect("projects.aspx");
                         
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
            pj.Name = txtName.Value;
            pj.Description = wysiwig_full.Value;
            pj.Autor_project = txt_autor.Value;
            pj.Made_date = Convert.ToDateTime(txtDate.Value);
            pj.Posted_by_id = pf.Id;
            pj.Id_tag = Convert.ToInt32(ddlcatProject.SelectedValue);
            pj.Id_dependence = usr.Id_dependence;
            pj.Featured = Convert.ToInt32(chkfeatured.Checked);
            pj.Id = Convert.ToInt32(Request.QueryString["idItem"]);
            pj.Lat = 0;
            pj.Lon = 0;
            pj.Id_city = Convert.ToInt32(ddlCity.SelectedValue);
            pj.Id_client = 0;
            pj.Pic = "";
            if (pro.updateProject(pj,2))
            {
                Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                UpdateInfo.Enabled = false;
                btnSaveInfo.Enabled = true;              
                clear();
                Response.Redirect("projects.aspx");
            }
            else
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Guardo La entrada</p>";
            }
        }
        */
        #endregion

    }
    private void loadDataFields( projects pro) {
        txt_autor.Value = pro.Autor_project;
        txtDate.Value = pro.Made_date.ToString("yyyy/MM/dd");
        txtName.Value = pro.Name;
        wysiwig_full.Value = pro.Description;
        chkfeatured.Checked = Convert.ToBoolean(pro.Featured);
        cbxstate.Checked = Convert.ToBoolean(pro.State);
        UpdateInfo.Enabled = true;
        btnSaveInfo.Enabled = false;

    }

    private void clear()
    {
        txt_autor.Value ="";
        txtDate.Value = "";
        txtName.Value = "";
        wysiwig_full.Value = "";
        chkfeatured.Checked = false;
    }

    protected void Agregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("addCategory.aspx");
    }

    [WebMethod]
    public static Boolean deletePhoto(int id_img, String img, int id_project) {
        man_projects proj = new man_projects();
        return proj.deleteAndUpdatePhoto(id_img, img, id_project);
    }
}