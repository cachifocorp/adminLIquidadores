using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_contact
/// </summary>
public class man_contact
{
    clsDb db = new clsDb();
	public man_contact(){}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public contact[] getContact(int type, int id_dependence) {
        String SQL = "select c.*, ci.name as name_city from contact c inner join city ci on ci.id = c.id_city where  c.type = " + type+" and c.id_dependence = "+ id_dependence;
        List<contact> contacts = new List<contact>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();            
            while (reader.Read())
            {
                contact cont = new contact();
                cont.Id = Convert.ToInt32(reader["id"]);
                cont.Name = reader["name"].ToString();
                cont.Address = reader["address"].ToString();
                cont.Phone = reader["phone"].ToString();
                cont.Id_city = Convert.ToInt32(reader["id_city"]);
                cont.Email = reader["file_name"].ToString();
                cont.Comment = reader["comment"].ToString();
                cont.Type = Convert.ToInt32(reader["type"]);
                cont.City_name = reader["name_city"].ToString() ;
                cont.File_name = reader["file_name"].ToString();
                contacts.Add(cont);
            }
            return contacts.ToArray();
        }catch(Exception e){
            return contacts.ToArray();
        }
        
    }

    public Boolean deleteContact(int id_contact) {
        String SQL = "DELETE FROM contact WHERE id = "+ id_contact;
        return db.ejecutar(SQL);
    }

    public String TableDataOptions(int id_dependence,int id_type, String page, String pathFile)
    {
        contact[] conta = getContact(id_type,id_dependence);
        String ListData = "";
            for (int i = 0; i < conta.Length; i++)
            {
                ListData += "<tr>" +
                                "<td>" + "<a href=\"" + page + "?action=1&idItem=" + conta[i].Id + "\" class=\"btn btn-primary btn-label-left\">Eliminar</a></td>" +
                                "<td>" + conta[i].Name + "</td>" +
                                 "<td>" + conta[i].Comment + "</td>" +
                                "<td>" + conta[i].City_name + "</td>";
                 if (conta[i].Type == 1)
                {
                    ListData += "<td>no file</td>" +
                            "</tr>";
                }
                else {
                    ListData += "<td><a href=\"" + pathFile + conta[i].File_name + "\" class=\"btn btn-primary btn-label-left\">Click para descargar</a></td>" +
                            "</tr>";
                }   
                               
            }
        return ListData;
    }

}