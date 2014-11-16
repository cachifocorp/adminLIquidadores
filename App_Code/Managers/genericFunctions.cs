using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for genericFunctions
/// </summary>
public static class genericFunctions
{
 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="usr"></param>
    /// <param name="pf"></param>
    /// 
   
    public static void assignDataSession(Users usr, profile pf)
    {
        usr = (Users) HttpContext.Current.Session["User"];
        pf = (profile)HttpContext.Current.Session["Profile"];
    }

    /// <summary>
    /// action 1 create, 2 update, 3 Delete
    /// </summary>
    /// <param name="user">User data from session</param>
    /// <param name="pr">profile data from session</param>
    /// <param name="page">page action </param>
    /// <returns>buttons Actions Delete, update, create</returns>
    public static String OptionsRoleBasicActions(Users user, profile pr, String page,int id_item) {
        String options="";
        switch (user.Id_role) {
            case 1:
                options += " <a  href=\"" + page + "?action=2&idItem="+id_item+"\" class=\"btn btn-warning\">Editar</a> ";
                options += " <a  href=\"" + page + "?action=3&idItem=" + id_item + "\" class=\"btn btn-danger\">Eliminar</a> ";
                break;
            case 2:
                options += " <a  href=\"" + page + "?action=2&idItem=" + id_item + "\" class=\"btn btn-warning\">Editar</a><li>";
                options += " <a  href=\"" + page + "?action=3&idItem=" + id_item + "\" class=\"btn btn-danger\">Eliminar</a><li></ul>";
                break;
        }

        return options;
    }

    public static item_module_profile getitemmodeprof(int id_profile, int id_module) {
        String SQL = "Select * from  item_module_profile where id = " + id_module + " and id_profile = " + id_profile;
         item_module_profile imp = new item_module_profile();
         clsDb db = new clsDb();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
           
            while (reader.Read())
            {
                imp.Id = Convert.ToInt32(reader["id"]);
                imp.Id_item = Convert.ToInt32(reader["id_profile"]);
                imp.Date_register = Convert.ToDateTime(reader["date_register"]);
                imp.Options = Convert.ToInt32(reader["options"]);
            }
            con.Close();
            return imp;
        }
        catch (Exception e)
        {
            return imp;
        }
    }

    public static void optionCreteUpdate(Button create, Button delete, item_module_profile imp ) {

        switch (imp.Options) {
            case 1:
                //create.Visible true;
                break;
        }
        
    }

    public static void SetDDLsValue(DropDownList d, String val)
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

    /*  
     *   1 DomainDependence
     *   2 uploadClients
     *   3 uploadDependence
     *   4 uploadGeneral
     *   5 uploadIntegrators
     *   6 uploadJobs
     *   7 uploadProjects
     *   8 uploadPublications
     *   9 uploadSlider
     */
    public static String paths(int dependence, int path){
       String pt ="";
       if (dependence == 3) {
           switch (path)
           {
               case 1:
                   pt = Resources.patchDependence.DomainDependence;
                   break;
               case 2:
                   pt = Resources.patchDependence.uploadClients;
                   break;
               case 3:
                   pt = Resources.patchDependence.uploadDependence;
                   break;
               case 4:
                   pt = Resources.patchDependence.uploadGeneral;
                   break;
               case 5:
                   pt = Resources.patchDependence.uploadIntegrators;
                   break;
               case 6:
                   pt = Resources.patchDependence.uploadJobs;
                   break;
               case 7:
                   pt = Resources.patchDependence.uploadProjects;
                   break;
               case 8:
                   pt = Resources.patchDependence.uploadPublications;
                   break;
               case 9:
                   pt = Resources.patchDependence.uploadSlider;
                   break;

           }
        
       }
       else if (dependence == 7) {
           switch (path)
           {
               case 1:
                   pt = Resources.patchDependencegas.DomainDependence;
                   break;
               case 2:
                   pt = Resources.patchDependencegas.uploadClients;
                   break;
               case 3:
                   pt = Resources.patchDependencegas.uploadDependence;
                   break;
               case 4:
                   pt = Resources.patchDependencegas.uploadGeneral;
                   break;
               case 5:
                   pt = Resources.patchDependencegas.uploadIntegrators;
                   break;
               case 6:
                   pt = Resources.patchDependencegas.uploadJobs;
                   break;
               case 7:
                   pt = Resources.patchDependencegas.uploadProjects;
                   break;
               case 8:
                   pt = Resources.patchDependencegas.uploadPublications;
                   break;
               case 9:
                   pt = Resources.patchDependencegas.uploadSlider;
                   break;

           }
       }
       return pt;
   }

}