using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_publications_publications : System.Web.UI.Page
{
    public static profile pf;
    public static Users usr;
    man_Publication pub = new man_Publication();
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
                        loadDataFields(pub.getItemPub(Convert.ToInt32(Request.QueryString["idItem"])),pub.getPub(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        pub.deletePubLang(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                    case "4":
                        pub.deletePublication(Convert.ToInt32(Request.QueryString["idItem"]));
                        break;
                }
            }
        }
        assign();
        List_Publ.InnerHtml =  pub.TableDataOptions(Convert.ToInt32(Session["dependence"]),usr,pf,"publications.aspx");
    }

    public void assign() {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        publications pub = new publications();
        man_Publication manPub = new man_Publication();
        //content
        pub.Id_tag = Convert.ToInt32(tags.SelectedValue);
        pub.Id_dependence = Convert.ToInt32(usr.Id_dependence);
        pub.Multilanguage = 0;
        List<int> idlang = new List<int>();
        idlang.Add(Convert.ToInt32(ddlLanguage.SelectedValue));
        pub.Id_language = idlang.ToArray();
        List<String> lispost = new List<String>();
        lispost.Add(wysiwig_full.Value);
        pub.Description = lispost.ToArray();
        List<String> titleList = new List<String>();
        titleList.Add(title.Value);
        pub.Title = titleList.ToArray();
        pub.Posted_by = pf.Id;
        pub.State = Convert.ToInt32(chkstate.Checked);

        if (FilePublication.HasFile)
        {
            try
            {
                String fileName = Path.GetFileName(FilePublication.FileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
                {
                    
                    //actions upload File
                    String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                    pub.Image = newName;
                    //FilePublication.SaveAs(Resources.patchDependence.uploadPublications + newName);
                    FilePublication.SaveAs(genericFunctions.paths(usr.Id_dependence, 8) + newName);
                    if (File.Exists(genericFunctions.paths(usr.Id_dependence, 8) + newName))
                    {
                        manPub.SavePublication(pub, pf.Id);
                        
                        
                        //FilePublication.SaveAs(Server.MapPath("\\AMV\\Pages\\uploads\\publications\\") + newName);
                        Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada</p>";
                        clear();
                    }
                    else {
                        Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se publico el Articulo</p>";
                    }    
                   
                }
                else
                {
                    Messages.InnerHtml = "<p class=\"bg-warning\">Tipo de dato No Aceptado</p>";
                }
            }
            catch (Exception ex)
            {
                Messages.InnerHtml = "<p class=\"bg-danger\">Error! Información no guardada  error:("+ex.Message+")</p>";
            }
        }
        else
        {
           // Messages.InnerHtml = "<p class=\"bg-warning\">No ha seleccionado ningun archivo para enviar</p>";
            pub.Image = "AMVGeneric.jpg";
            manPub.SavePublication(pub, pf.Id);           
            Messages.InnerHtml = "<p class=\"bg-success\">Información Guardada [SIN IMAGEN]</p>";
            clear();
        }
        
    }

   private void clear(){
       wysiwig_full.Value = "";
       title.Value = "";
   }
   protected void otherLanguage_Click(object sender, EventArgs e)
   {
       pubLang pl = new pubLang();
       pl.Title = title.Value;
       pl.Description = wysiwig_full.Value;
       pl.Id_publication = Convert.ToInt32(Request.QueryString["idItem"]);
       pl.Id_language = Convert.ToInt32(ddlLanguage.SelectedValue);
       if (pub.saveNewVersion(pl))
       {
           Response.Write("<script>alert('Una nueva version agregada');</script>");
       }
       else {
           Response.Write("<script>alert('Nueva version no guardada');</script>");
       }
   }


   private void loadDataFields(pubLang pub, publications pu) {
       title.Value = pub.Title;
       wysiwig_full.Value = pub.Description;
       pubId.Value = pub.Id_publication.ToString() ;
       otherLanguage.Enabled = true;
       btnSaveInfo.Enabled  = false;
       btnUpdate.Enabled = true;
       chkstate.Checked = Convert.ToBoolean(pub.State);
       tags.DataBind();
       tags.Items.FindByValue(pu.Id_tag.ToString()).Selected = true;

   }
   protected void btnUpdate_Click(object sender, EventArgs e)
   {
       publications pubs = new publications();
       pubLang pl = new pubLang();
       man_Publication manPub = new man_Publication();
       if (FilePublication.HasFile)
       {
           try
           {
               String fileName = Path.GetFileName(FilePublication.FileName);
               if (fileName.Contains(".jpg") || fileName.Contains(".JPG") || fileName.Contains(".png") || fileName.Contains(".PNG") || fileName.Contains(".gif"))
               {
                   pubs.Id_tag = Convert.ToInt32(tags.SelectedValue);
                   pubs.Id_dependence = Convert.ToInt32(usr.Id_dependence);
                   pubs.Multilanguage = 0;
                   pubs.Posted_by = pf.Id;
                   pubs.Id = Convert.ToInt32(Request.QueryString["idItem"]);
                   pubs.State = Convert.ToInt32(chkstate.Checked);
                   //actions upload File
                   String newName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                   pubs.Image = newName;

                   pl.Id_language = Convert.ToInt32(ddlLanguage.SelectedValue);
                   pl.Description = wysiwig_full.Value;
                   pl.Title = title.Value;
                   //FilePublication.SaveAs(Resources.patchDependence.uploadPublications + newName);
                   FilePublication.SaveAs(genericFunctions.paths(usr.Id_dependence, 8) + newName);
                   if (File.Exists(genericFunctions.paths(usr.Id_dependence, 8) + newName))
                   {
                      manPub.updatePublication(pubs);
                       //FilePublication.SaveAs(Server.MapPath("\\AMV\\Pages\\uploads\\publications\\"+ newName));
                       Messages.InnerHtml = "<p class=\"bg-success\">Información Actualizada</p>";
                       manPub.updatePubLang(pl);
                       List_Publ.InnerHtml = pub.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "publications.aspx");
                       clear();
                   }
                   else
                   {
                       Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Actualizo la Publicacion</p>";
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
           pubs.Id_tag = Convert.ToInt32(tags.SelectedValue);
           pubs.Id_dependence = Convert.ToInt32(usr.Id_dependence);
           pubs.Multilanguage = 0;
           pubs.Posted_by = pf.Id;
           pubs.Id = Convert.ToInt32(Request.QueryString["idItem"]);
           pubs.Image = "";
           pl.Id_language = Convert.ToInt32(ddlLanguage.SelectedValue);
           pl.Description = wysiwig_full.Value;
           pl.Title = title.Value;
           pl.Id = Convert.ToInt32(Request.QueryString["idItem"]);
           pubs.State = Convert.ToInt32(chkstate.Checked);
           
           if (manPub.updatePublication(pubs))
           {
              
               Messages.InnerHtml = "<p class=\"bg-success\">Información Actualizada</p>";
               manPub.updatePubLang(pl);
               clear();
               List_Publ.InnerHtml = pub.TableDataOptions(Convert.ToInt32(Session["dependence"]), usr, pf, "publications.aspx");
           }
           else
           {
               Messages.InnerHtml = "<p class=\"bg-danger\">Error!! No se Actualizo la Publicacion</p>";
           }

       }
   }
}