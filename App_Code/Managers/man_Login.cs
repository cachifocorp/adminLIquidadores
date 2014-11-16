using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Security.Cryptography;


/// <summary>
/// Summary description for man_Login
/// </summary>
public class man_Login
{

    clsDb db = new clsDb();
	public man_Login()
	{	}


    public static bool login(String username, String password)
    {
        clsDb db = new clsDb();
        String newPass = EncodePassword(password);
        String SQL = "select * from users where username = '" + username + "' and password ='" + newPass + "'";
        bool ch = false;
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            //com.Parameters.Add("@username",username);
           
            //com.Parameters.Add("@password", newPass);
            int cantidad = Convert.ToInt32(com.ExecuteScalar());
            if (cantidad != 0)
            {
                SqlDataReader reader = com.ExecuteReader();
                Users user = new Users();
                
                while (reader.Read()) {
                    user.Id =  Convert.ToInt32(reader["id"]);
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Id_role = Convert.ToInt32(reader["id_role"]);
                    user.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                    user.State = Convert.ToInt32(reader["state"]);
                }
                 HttpContext.Current.Session["User"] = user ;
                 HttpContext.Current.Session["dependence"] = user.Id_dependence;
                ch =  true;
            }
            else
            {
                ch =  false;
            }

            con.Close();

        }
        catch(Exception ex) {
            ch = false;
           
        }

        return ch;
    }


    public static string EncodePassword(string originalPassword)   {       
        string clave = "7f9facc418f74439c5e9709832;0ab8a5:OCOdN5Wl,q8SLIQz8i|8agmu¬s13Q7ZXyno/";       
        SHA512 sha512 = new SHA512CryptoServiceProvider();        
        byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword + clave);        
        byte[] hash = sha512.ComputeHash(inputBytes);      
        return Convert.ToBase64String(hash);

    }
    public static profile getInfoprofile(Users user) {
        String SQL = "select * from profile where user_id = "+user.Id;
        profile pf = new profile();
        clsDb db = new clsDb();
        try { 
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            //com.Parameters.AddWithValue("@userid", );
            
            int cantidad = Convert.ToInt32(com.ExecuteScalar());
            if (cantidad != 0)
            {
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read()){
                    pf.Id = Convert.ToInt32(reader["id"]);
                    pf.Name = reader["name"].ToString();
                    pf.Last_name = reader["last_name"].ToString();
                    pf.Identification = reader["identification"].ToString();
                    pf.User_id = Convert.ToInt32(reader["user_id"]);
                    pf.Born_date = Convert.ToDateTime(reader["born_date"]);
                    pf.City_id = Convert.ToInt32(reader["city_id"]);
                    pf.Address = reader["address"].ToString();
                    pf.Phone = reader["phone"].ToString();
                    //pf.Avatar = reader["avatar"].ToString();
                }
            }
            con.Close();
        }
        catch (Exception ex) {
           
        }
        return pf;
    }
    
}