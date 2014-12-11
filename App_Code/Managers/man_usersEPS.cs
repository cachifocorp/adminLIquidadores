using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_usersEPS
/// </summary>
public class man_usersEPS
{
    public man_usersEPS()
    {
    }

  

    public  bool login(String nit, String pass)
    {
        clsDb db = new clsDb();

        String SQL = "SELECT [id],[username],[password],[epscode],[timestamp] " +
                   " FROM [liquidadoresweb].[liquidadoresweb].[usuariosEPS] " +
                   " where  username = '" + nit + "' and [password] = '" + pass + "' ";
        bool ch = false;
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);          
            int cantidad = Convert.ToInt32(com.ExecuteScalar());
            if (cantidad != 0)
            {
                SqlDataReader reader = com.ExecuteReader();
                Users user = new Users();

                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.codeEPS = reader["epscode"].ToString();
                }
                HttpContext.Current.Session["User"] = user;
                HttpContext.Current.Session["epscode"] = user.codeEPS;
                ch = true;
            }
            else
            {
                ch = false;
            }

            con.Close();

        }
        catch (Exception ex)
        {
            ch = false;

        }

        return ch;
    }

}