using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_offices
/// </summary>
public class man_offices
{
    clsDb db = new clsDb();
	public man_offices()
	{
	
	}

    public Boolean saveOffice(offices off) {
        String SQL = "INSERT INTO offices ([lat], [long], [id_dependence], [address], [phone], [fax], [email], [id_city], [icon])"+
                      "VALUES(" + off.Lat.Replace(",", ".") + ", " + off.Lon.Replace(",", ".") + ", " + off.Id_dependence + ", '" + off.Address + "', '" + off.Phone + "', '" + off.Fax + "', '" + off.Email + "', " + off.Id_city + ", '" + off.Icon + "' )";
        return db.ejecutar(SQL);
       
    }
    public Boolean deleteOffice(int id_office) {
        String SQL = "DELETE FROM offices where id = "+ id_office;
        return db.ejecutar(SQL);
    }

    public Boolean UpdateOffice(offices office, int ver) {

        if (ver == 1)
        {
            String SQL = "UPDATE  offices" +
                        "  SET [lat] = " + office.Lat.Replace(",", ".") + ",[long] = " + office.Lon.Replace(",", ".") + " ,[id_dependence] = " + office.Id_dependence + ",[address] = '" + office.Address + "' ,[phone] = '" + office.Phone + "' ,[fax] = '" + office.Fax + "' ,[email] = '" + office.Email + "' ,[id_city] = " + office.Id_city + " ,[icon] = '" + office.Icon +
                        "' WHERE id = " + office.Id;
            return db.ejecutar(SQL);
        }
        else {
            String SQL = "UPDATE  offices" +
                        "  SET [lat] = " + office.Lat.Replace(",", ".") + ",[long] = " + office.Lon.Replace(",", ".") + " ,[id_dependence] = " + office.Id_dependence + ",[address] = '" + office.Address + "' ,[phone] = '" + office.Phone + "' ,[fax] = '" + office.Fax + "' ,[email] = '" + office.Email + "' ,[id_city] = " + office.Id_city +  
                        " WHERE id = " + office.Id;
            return db.ejecutar(SQL);
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <returns> array Object from office class</returns>
    private offices[] getOffices(int id_dependence)
    {
        String SQL = "select o.*, dp.lat as dplat, dp.lon as dplon, c.name as name_city " +
                      "from offices o  inner join city c on c.id = o.id_city  inner join dependence dp on dp.id = o.id_dependence" +
                      " where o.id_dependence = " + id_dependence + " order by o.id_city ";
        List<offices> offi = new List<offices>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                offices office = new offices(); 
                office.Id = Convert.ToInt32(reader["id"]);
                office.Lat = reader["lat"].ToString();
                office.Lon = reader["long"].ToString();
                office.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                office.Address = reader["address"].ToString();
                office.Phone = reader["phone"].ToString();
                office.Fax = reader["fax"].ToString();
                office.Email = reader["email"].ToString();
                office.Id_city = Convert.ToInt32(reader["id_city"]);
                office.City_name = reader["name_city"].ToString();
                office.Icon = reader["icon"].ToString();
                offi.Add(office);
            }
            con.Close();
        }
        catch (Exception ex)
        {
            offices office = new offices();
            offi.Add(office);
        }
        return offi.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <returns>information of once office</returns>
    public offices getOffice(int id_office)
    {
        String SQL = "select o.*, dp.lat as dplat, dp.lon as dplon, c.name as name_city " +
                      "from offices o  inner join city c on c.id = o.id_city  inner join dependence dp on dp.id = o.id_dependence" +
                      " where o.id = " + id_office + " order by o.id_city ";
        offices office = new offices();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                
                office.Id = Convert.ToInt32(reader["id"]);
                office.Lat = reader["lat"].ToString();
                office.Lon = reader["long"].ToString();
                office.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                office.Address = reader["address"].ToString();
                office.Phone = reader["phone"].ToString();
                office.Fax = reader["fax"].ToString();
                office.Email = reader["email"].ToString();  
                office.Id_city = Convert.ToInt32(reader["id_city"]);
                office.City_name = reader["name_city"].ToString();
                office.Icon = reader["icon"].ToString();
                
            }
            con.Close();
        }
        catch (Exception ex)
        {
            return office;
        }
        return office;
    }



    #region actions Table 
    public String TableDataOptions(int id_dependence, Users usr, profile pf, String page)
    {
        offices[] office = getOffices(id_dependence);
        String ListData = "";
        for (int i = 0; i < office.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, office[i].Id) + "</td>" +
                            "<td>" + office[i].City_name + "</td>" +
                             "<td>" + office[i].Address + "</td>" +
                            "<td>" + office[i].Phone + "</td>" +
                            "<td>" + office[i].Email + "</td>" +
                        "</tr>";
        }

        return ListData;
    }
    #endregion

}