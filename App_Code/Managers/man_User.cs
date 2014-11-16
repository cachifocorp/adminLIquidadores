using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_User
/// </summary>
public class man_User
{
    clsDb db = new clsDb();
	public man_User()
	{	
	}

public Users[] getInfoUsers(int State) {
        String SQL = "select u.*, r.name as role_name, d.name as dependence_name"+ 
                    " from users u inner join role r on r.id = u.id_role inner join dependence d on d.id = u.id_dependence"+
                    " where u.state =  " + State;
                List<Users> lUses = new List<Users>();
                try
                {
                    SqlConnection con = db.conexion();
                    con.Open();
                    SqlCommand com = new SqlCommand(SQL, con);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Users user = new Users();
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.Username = reader["username"].ToString();
                        user.Password = reader["password"].ToString();
                        user.Id_role = Convert.ToInt32(reader["id_role"]);
                        user.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                        user.State = Convert.ToInt32(reader["state"]);
                        user.RoleName = reader["role_name"].ToString();
                        user.DependenceName = reader["dependence_name"].ToString() ;                        
                        lUses.Add(user);
                    }
                }
                catch (Exception e) {
                    return lUses.ToArray();
                }
                return lUses.ToArray();
    }



public Users getInfoUser(int id_user)    {
    String SQL = "select u.*, r.name as role_name, d.name as dependence_name" +
                " from users u inner join role r on r.id = u.id_role inner join dependence d on d.id = u.id_dependence" +
                " where u.id =  " + id_user;
        Users user = new Users();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["id"]);
                user.Username = reader["username"].ToString();
                user.Password = reader["password"].ToString();
                user.Id_role = Convert.ToInt32(reader["id_role"]);
                user.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                user.State = Convert.ToInt32(reader["state"]);
                user.RoleName = reader["role_name"].ToString();
                user.DependenceName = reader["dependence_name"].ToString();                 
            }
        }
        catch (Exception e)
        {
            return user;
        }
        return user;
    }


    public Boolean saveUser(Users user) {
        String SQL = "INSERT INTO  users ([username], [password], [id_role], [date_register], [id_dependence], [state],[lastmod])"+
                     " VALUES ('" + user.Username + "', '" + user.Password + "', " + user.Id_role + ", GetDate(), " + user.Id_dependence + ", " + user.State + ", GetDate() )";
        if (db.ejecutar(SQL))
        {
            db.ejecutar("INSERT INTO  profile ([name],[last_name],[identification],[user_id],[born_date],[city_id],[address],[phone])" +
                        " VALUES ('','','',(select max(id) from users), GetDate() ,1,'','')");
            return true;
        }
        else {
            return false;
        }
    }

    /// <summary>
    /// The used never will be deleted  only id a update of  their state  to unactive
    /// </summary>
    /// <param name="id_user"></param>
    /// <returns></returns>
    public Boolean DeleteUser(int id_user) {
        String SQL = "UPDATE users set [state] = 0 where id = " + id_user;
        return db.ejecutar(SQL);
    }

    public Boolean updatePassword(String pass, int id) {
        String SQL = "UPDATE users"+
                     " SET [password] = '"+man_Login.EncodePassword(pass)+"', [lastmod] = GetDate() where id = "+id;
        return db.ejecutar(SQL);
    }

    public Boolean updateUser( Users user) {
        String SQL = "UPDATE users"+
                     " SET [username] = '" + user.Username + "',[id_role] = " + user.Id_role + ",[lastmod] = GetDate(), [password] = '" + user.Password + "', [id_dependence] = " + user.Id_dependence + ",[state] = " + user.State +
                     " WHERE id = "+user.Id;
        return db.ejecutar(SQL);
    }

    public Boolean updateUserwhidoutPass(Users user)
    {
        String SQL = "UPDATE users" +
                     " SET [username] = '" + user.Username + "',[id_role] = " + user.Id_role + ",[lastmod] = GetDate(),  [id_dependence] = " + user.Id_dependence + ",[state] = " + user.State +
                     " WHERE id = " + user.Id;
        return db.ejecutar(SQL);
    }

    public String TableDataOptions(int state,Users usr, profile pf, String page)
    {
        Users[] usrs = getInfoUsers(state);
        String ListData = "";
        for (int i = 0; i < usrs.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, usrs[i].Id) + "</td>" +
                            "<td>" + usrs[i].Username + "</td>" +
                             "<td>" + usrs[i].RoleName + "</td>" +
                            "<td>" + usrs[i].DependenceName + "</td>";
            if (usrs[i].State == 1)
            {
                ListData += "<td><h3>Activo</h2></td>";
            }
            else {
                ListData += "<td><h3>Inactivo</h2></td>";
            }
             ListData+= "</tr>";
        }

        return ListData;
    }
}