using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for man_slider
/// @autor: Walther Smith franco otero
/// </summary>
public class man_slider
{
    clsDb db = new clsDb();
	public man_slider()	{}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <returns></returns>
    public slider[] getSliders(int id_dependence) {
        String SQL = "select * from  slider where  id_dependence = "+id_dependence;
        List<slider> lslide = new List<slider>();
        try {
        
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
        catch (Exception e) {
            return lslide.ToArray();
        }

        return lslide.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_slider"></param>
    /// <returns></returns>
    public slider getSlider(int id_slider)
    {
        String SQL = "select * from  slider where  id = " + id_slider;
        slider sl = new slider();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                sl.Id = Convert.ToInt32(reader["id"]);
                sl.Slide = reader["slide"].ToString();
                sl.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                sl.Date_register = Convert.ToDateTime(reader["date_register"]);
                sl.Name = reader["name"].ToString();
            }
        }
        catch (Exception e)
        {
            return sl;
        }
        return sl;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_slide"></param>
    /// <returns></returns>
    public Boolean deleteSlide(int id_slide) {
        String SQL = "delete from slider where id = " + id_slide;
        return db.ejecutar(SQL);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="slide"></param>
    /// <returns></returns>
    public Boolean SaveSlide(slider slide) {
        String SQL = "INSERT INTO  slider"+
          " ([name],[slide],[id_dependence],[date_register])" +
          "  VALUES ('"+slide.Name+"','"+WebUtility.HtmlEncode(slide.Slide)+"',"+slide.Id_dependence+",GETDATE() )";
        return db.ejecutar(SQL);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="slide"></param>
    /// <returns></returns>
    public Boolean updateSlide( slider slide) {
        String SQL = "UPDATE  slider SET [slide] ='" + WebUtility.HtmlEncode(slide.Slide) + "', [name] = '"+slide.Name+"'"+
                    " WHERE id = "+slide.Id;
        return db.ejecutar(SQL);
    }


    public String TableDataOptions(int id, Users usr, profile pf, String page)
    {
        slider[] sli = getSliders(id);
        String ListData = "";
        for (int i = 0; i < sli.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, sli[i].Id) + "</td>" +
                            "<td>" + sli[i].Name + "</td>" +
                            "<td>" + sli[i].Date_register.ToString("yyyy - MM - dd") + "</td>" +
                        "</tr>";
        }

        return ListData;
    }



    public String formatedSlider(int idDependence)
    {
        slider[] sl = getSliders(idDependence);
        String sli = "";
        for (int i = 0; i < sl.Length; i++)
        {
            sli += WebUtility.HtmlDecode(sl[i].Slide);
        }

        return sli;
    }

}