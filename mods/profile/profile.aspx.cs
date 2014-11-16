using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;

public partial class mods_profile_profile : System.Web.UI.Page
{
    public static profile pr;
    public static Users us;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            else {
                pr = (profile)Session["Profile"];
                us = (Users)Session["User"];
            }
        }
    }
    

    [System.Web.Services.WebMethod]
    public static String chargeContries(String name) {
        man_genericData gd = new man_genericData();
        return gd.cbxContry();
    }

     [System.Web.Services.WebMethod]
    public static String chargeStates(String id_contry) {
        man_genericData gd = new man_genericData();
        return gd.cbxStates(Convert.ToInt32(id_contry));
    }

    [System.Web.Services.WebMethod]
     public static String chargeCities(String id_state) {
         man_genericData gd = new man_genericData();
         return gd.cbxCity(Convert.ToInt32(id_state));
     }
   
    
    [System.Web.Services.WebMethod]
    public static Boolean SaveDataProfile(profile profile )
    {
        man_profile prf = new man_profile();
        if(prf.UpdateInfoProfile(profile)){
          updateProfileInfoSession(profile);
            return true;
        }else{
      return  false;
      }
    }

    private static void updateProfileInfoSession(profile prp){
        HttpContext.Current.Session["Profile"] = prp;
    }

     [System.Web.Services.WebMethod]
    public static Boolean changePass(String pass, String id) {
        man_User mUse = new man_User();
        if (mUse.updatePassword(pass, Convert.ToInt32(id)))
        {
            return true;
        }
        else {
            return false;
        }
    }

}