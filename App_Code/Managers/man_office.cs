using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_office
/// </summary>
public class man_office
{
    clsDb db = new clsDb();
	public man_office()
	{}


    private offices[] getOffices(int id_dependence, int id_city) 
    {
        String SQL = "select o.* "+
                      "from offices o  inner join city c on c.id = o.id_city  inner join dependence dp on dp.id = o.id_dependence"+
                      " where o.id_dependence = " + id_dependence + "order by o.id_city ";
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
                        office.Lat = (reader["lat"]).ToString();
                        office.Lon = (reader["long"]).ToString();
                        office.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                        office.Address = reader["address"].ToString();
                        office.Phone = reader["phone"].ToString();
                        office.Fax = reader["fax"].ToString();
                        office.Id_city = Convert.ToInt32(reader["id_city"]);
                        office.Icon = reader["icon"].ToString();
                        offi.Add(office);
                    }
                    con.Close();
                }
                catch {
                    offices office = new offices();
                    offi.Add(office);
                }
                return offi.ToArray();
    }


    public String getScriptsMap(int id_dependence, int id_city, String pathImage){
        offices[] of = getOffices(id_dependence,  id_city);
        String mapPlaces ="";
        mapPlaces += "$(\"#Sedes\").change(function () {\n";
        mapPlaces += "$(\"#direcciones\").html(\"\");";
        mapPlaces+="var valor = $(\"#Sedes\").val();\n";
        mapPlaces += "switch (valor) {\n";
        for (int i = 0; i < of.Length; i++) {             
            if (i == 0)
            {
                mapPlaces += "case '" + of[i].Id_city + "' : \n" +
               "  var markeroptions = { values: [  ";
						       
                for (int j = 0; j < of.Length; j++)
                {
                    if (of[i].Id_city == of[j].Id_city)
                    {
                        mapPlaces += "{ latLng: [" + of[j].Lat.ToString().Replace(",", ".") + ", " + of[j].Lon.ToString().Replace(",", ".") + "], options: { icon: \"" + pathImage + of[j].Icon + "\" },\n" +
                                "events: {click: function () {\n alert("+"Hello"+"); " +
                                  " $(\"#direcciones\").html(direcciones(\" " + of[j].Address + " \", \"" + of[j].Phone + "\", \"" + of[j].Fax + "\", \"" + of[j].Email + "\"));\n" +
                               " }}},\n";
                    }
                }
                mapPlaces += "]};\n";
                //mapPlaces += "  alert(JSON.stringify(markeroptions));  ";
                mapPlaces += "getMapa(markeroptions);\n";
                mapPlaces += "break;\n";
            }
            else {
                if (of[i].Id_city != of[(i - 1)].Id_city)
                {
                    mapPlaces += "case '" + of[i].Id_city + "' :\n" +
                        "  var markeroptions = { values: [    \n";
                                
                    for (int j = 0; j < of.Length; j++)
                    {
                        if (of[i].Id_city == of[j].Id_city)
                        {
                            mapPlaces += "{ latLng: [" + of[j].Lat.ToString().Replace(",", ".") + ", " + of[j].Lon.ToString().Replace(",", ".") + "], options: { icon: \"" + pathImage + of[j].Icon + "\"  },\n" +
                                    "events: {click: function () {\n" +
                                      " $(\"#direcciones\").html(direcciones(\" " + of[j].Address + " \", \"" + of[j].Phone + "\", \"" + of[j].Fax + "\", \"" + of[j].Email + "\"));\n" +
                                   " }}},";
                        }                       
                    }
                    mapPlaces += "]};\n";
                    //mapPlaces += "  alert(JSON.stringify(markeroptions)); \n ";
                    mapPlaces += "getMapa(markeroptions);\n";                  
                    mapPlaces += "break;\n";
                }
               
            }
           
        }
        mapPlaces += "}";
        
        mapPlaces += "});";
            return mapPlaces;
    }



}