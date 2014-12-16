using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_manageUsers_permissionsUser : System.Web.UI.Page {
    public static profile pf;
    public static Users usr;
    man_Module mMod = new man_Module();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {

            if (Request.QueryString["action"] != null && Request.QueryString["id"] != null)
            {
                
                switch (Request.QueryString["action"])
                {
                    case "1":

                        break;

                    case "2":
                        //loadDataClient(clien.getinfoCLient(Convert.ToInt32(Request.QueryString["idItem"])));
                        break;
                    case "3":
                        mMod.deletePermissions(Convert.ToInt32(Request.QueryString["idd"]), Convert.ToInt32(Request.QueryString["id"]));
                        break;
                }
            }
        }
        assign();
        list_permissions.InnerHtml = mMod.TableDataOptions(Convert.ToInt32(Request.QueryString["id"]), usr, pf, "permissionsUser.aspx");
        
        
    }

    public void assign()
    {
        usr = (Users)Session["User"];
        pf = (profile)Session["Profile"];
    }
    protected void btnAssigPermission_Click(object sender, EventArgs e)
    {
        
        int item = Convert.ToInt32(ddlItemModule.SelectedValue);
       // int option = Convert.ToInt32(options.SelectedValue);
        mMod.savePermission(item, Convert.ToInt32(Request.QueryString["id"]), 0);
        list_permissions.InnerHtml = mMod.TableDataOptions(Convert.ToInt32(Request.QueryString["id"]), usr, pf, "permissionsUser.aspx");
    }
}