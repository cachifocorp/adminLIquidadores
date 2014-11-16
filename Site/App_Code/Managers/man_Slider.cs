using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for man_Slider
/// </summary>
public class man_Slider
{
    clsDb db = new clsDb();
	public man_Slider(){}

    public slider[] getSliders(int id_dependence)
    {
        String SQL = "select * from  slider where  id_dependence = " + id_dependence;
        List<slider> lslide = new List<slider>();
        try
        {

            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                slider sl = new slider();
                sl.Id = Convert.ToInt32(reader["id"]);
                sl.Slide = reader["slide"].ToString();
                sl.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                sl.Date_register = Convert.ToDateTime(reader["date_register"]);
                sl.Name = reader["name"].ToString();
                lslide.Add(sl);
            }
        }
        catch (Exception e)
        {
            return lslide.ToArray();
        }

        return lslide.ToArray();
    }


    public String formatedSlider(int idDependence) {
        slider[] sl = getSliders(idDependence);
        String sli = "";
        for (int i = 0; i <sl.Length; i++)
        {
            sli += WebUtility.HtmlDecode(sl[i].Slide);
        }

        return sli;
    }
}