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


    public String cbxCity(int id_state) {
        String SQL = "select id, name from  city where id_state = "+id_state;
        String select = "";
         try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            select += "<select name=\"city\" id=\"city\" class=\"populate placeholder col-sm-1\">";
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
        String select = " ";
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            select += "<select name=\"contry\" id=\"contry\" class=\"populate placeholder col-sm-1\" onchange=\"chargeState()\">";
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

    public String cbxStates(int id_Contry)
    {
        String SQL = "select id, name from  state where id_contry = "+ id_Contry;
        String select = "";
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            select += "<select name=\"state\" id=\"state\" class=\"populate placeholder col-sm-1\" onchange=\"chargeCities()\">";
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