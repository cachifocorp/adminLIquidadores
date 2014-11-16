using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for man_genericData
/// </summary>
public class man_genericData
{
    clsDb db = new clsDb();
	public man_genericData()
	{
	}

    public void cbxCitybyState(DropDownList cbx,int id_state)
    {
        String SQL = "select id, name from  city where id_state= "+id_state;
       
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(com.CommandText, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cbx.DataSource = ds;
            cbx.DataValueField = "id";
            cbx.DataTextField = "name";
            cbx.DataBind();
            cbx.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            con.Close();

           
        }
        catch (Exception e)
        {
           
        }
    }


    public String cbxCity() {
        String SQL = "select c.id, c.name from  city c inner join offices offi on c.id = offi.id_city ";
        String select = "";
         try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();           
             select+="<select name=\"Sedes\" id=\"Sedes\" class=\"input-xxlarge\">";
            while (reader.Read())
            {
                select+="<option value=\""+reader["id"]+"\">"+reader["name"]+"</option>";
            }
            select += "</select>";
            con.Close();
        }
        catch(Exception e) {
            return e.Message+"";
        }
        return select;
    }

    public void cbxState(DropDownList cbx ,int id_Contry)
    {
        String SQL = "select id, name from  state where id_contry = "+id_Contry;
       
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(com.CommandText, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cbx.DataSource = ds;
            cbx.DataValueField = "id";
            cbx.DataTextField = "name";
            cbx.DataBind();
            cbx.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            con.Close();

           
        }
        catch (Exception e)
        {
           
        }

        
           
       
    }


    public String cbxContry()
    {
        String SQL = "select id, name from  contry";
        String select = "<h5>Pais</h5>";
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            select += "<select name=\"Sedes\" id=\"Sedes\" class=\"input-xxlarge\">";
            while (reader.Read())
            {
                select += "<option value=\"" + reader["id"] + "\">" + reader["name"] + "</option>";
            }
            select += "</select>";
            con.Close();
        }
        catch (Exception e)
        {
            return e.Message + "";
        }
        return select;
    }


    
}