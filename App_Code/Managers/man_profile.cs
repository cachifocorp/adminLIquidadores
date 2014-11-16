using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_profile
/// </summary>
public class man_profile
{
    clsDb db =new  clsDb();
	public man_profile()
	{}

    public Boolean UpdateInfoProfile(profile profile) {
        String SQL = "UPDATE profile"+
                    " SET name ='" + profile.Name + "' ,last_name = '" + profile.Last_name + "' ,identification ='" + profile.Identification + "'  ,born_date =  '"+profile.Born_date.ToString("dd/MM/yyyy")+
                   "' ,city_id = " + profile.City_id + " ,address ='" + profile.Address + "' ,phone = '" + profile.Phone + "'  WHERE user_id = "+profile.User_id;

        SqlConnection con = db.conexion();
        con.Open();
        SqlCommand com = new SqlCommand(SQL, con);
        com.ExecuteNonQuery();
        if (com.ExecuteNonQuery() != 0)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }      

    }

     

}