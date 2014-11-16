using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_general_Contact : System.Web.UI.Page
{
    public static profile pf;
    public static Users usr;
    man_contact mCont = new man_contact();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["idItem"] != null)
            {

                switch (Request.QueryString["action"])
                {
                    case "1":
                        if (mCont.deleteContact(Convert.ToInt32(Request.QueryString["idItem"])))
                        {
                            list_Contact.InnerHtml = mCont.TableDataOptions(Convert.ToInt32(Session["dependence"]), 1, "Contact.aspx", Resources.patchDependence.DomainDependence + Resources.Resource.pathUploadJobs);
                        }
                        else {
                            Response.Write("<script>alert(\"Erro no se ha eliminado el Item\")</script>");
                        }
                            break;
                }
            }
        }
        assign();
        list_Contact.InnerHtml = mCont.TableDataOptions(Convert.ToInt32(Session["dependence"]), 1, "Contact.aspx",Resources.patchDependence.DomainDependence+ Resources.Resource.pathUploadJobs);

    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }
    protected void btnContact_Click(object sender, EventArgs e)
    {
        list_Contact.InnerHtml = mCont.TableDataOptions(Convert.ToInt32(Session["dependence"]), 1, "Contact.aspx", Resources.patchDependence.DomainDependence + Resources.Resource.pathUploadJobs);
    }
    protected void btnprov_Click(object sender, EventArgs e)
    {
        list_Contact.InnerHtml = mCont.TableDataOptions(Convert.ToInt32(Session["dependence"]), 2, "Contact.aspx", Resources.patchDependence.DomainDependence + Resources.Resource.pathUploadJobs);
    }
    protected void btnjob_Click(object sender, EventArgs e)
    {
        list_Contact.InnerHtml = mCont.TableDataOptions(Convert.ToInt32(Session["dependence"]), 3, "Contact.aspx", Resources.patchDependence.DomainDependence + Resources.Resource.pathUploadJobs);
    }
}