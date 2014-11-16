using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_integrator
/// </summary>
public class man_integrator
{
    clsDb db = new clsDb();
	public man_integrator(){}

    public Boolean saveIntegrator( integrators integaror){
        String SQL = "INSERT INTO  integrators ([name] ,[description] ,[dateRegister] ,[photo] ,[id_dependence],[state])" +
                    " VALUES ('"+integaror.Name+"', '"+integaror.Description+"', '"+integaror.DateRegister.ToString("yyyy/MM/dd")+"', '"+integaror.Photo+"', "+integaror.Id_dependence+", "+integaror.State+")";
        return db.ejecutar(SQL);
    }

    private integrators[] getDataIntegrators(int id_dependence)
    {
        string SQL = "select * from integrators where id_dependence = "+id_dependence;
        List<integrators> inte = new List<integrators>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                integrators integrator = new integrators();
                integrator.Id = Convert.ToInt32(reader["id"]);
                integrator.Name = reader["name"].ToString();
                integrator.Description = reader["description"].ToString();
                integrator.DateRegister = Convert.ToDateTime(reader["dateRegister"]);
                integrator.Photo = reader["photo"].ToString();
                integrator.State = Convert.ToInt32(reader["state"]);

                inte.Add(integrator);
            }
        }
        catch { }
        return inte.ToArray();
    }

    public integrators getDataIntegrator(int id_integrador)
    {
        string SQL = "select * from integrators where id = " + id_integrador;
         integrators integrator = new integrators();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();            
            while (reader.Read())
            {
                integrator.Id = Convert.ToInt32(reader["id"]);
                integrator.Name = reader["name"].ToString();
                integrator.Description = reader["description"].ToString();
                integrator.DateRegister = Convert.ToDateTime(reader["dateRegister"]);
                integrator.Photo = reader["photo"].ToString();
                integrator.State = Convert.ToInt32(reader["state"]);
            }
            return integrator;
        }
        catch {
             return integrator;
        }
         
    }

    public String TableDataOptions(int id_dependence,String pathImage, Users usr, profile pf, String page) {
        integrators[] integrator = getDataIntegrators(id_dependence);
        String ListData="";
        for (int i = 0; i < integrator.Length; i++ ) {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page,integrator[i].Id) +"</td>" +         
                            "<td><img class=\"img-rounded\" src=\"" + pathImage + integrator[i].Photo + "\" alt=\"\">"+integrator[i].Name+"</td>" +
                             "<td>"+integrator[i].Description+"</td>" +
                            "<td>"+integrator[i].DateRegister.ToString("dd/MMMM/yyyy")+"</td>" +
                        "</tr>";
        }

        return ListData;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_integrator"></param>
    /// <returns></returns>
    public Boolean deleteIntegrator(int id_integrator) {
        String SQL = "delete from integrators where id = "+ id_integrator;
        return db.ejecutar(SQL);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="integrator"></param>
    /// <returns></returns>
    public Boolean updateIntegrador(integrators integrator, int version) {       
        if (version == 1)
        {
            String SQL = "UPDATE integrators  SET [name] = '" + integrator.Name + "'   ,[description] =' " + integrator.Description + "'  ,[dateRegister] = '" + integrator.DateRegister.ToString("yyyy/MM/dd") + "'   ,[photo] = '" + integrator.Photo + "'   ,[id_dependence] = " + integrator.Id_dependence +", [state] = "+integrator.State+
                    " WHERE  id = " + integrator.Id;
            return db.ejecutar(SQL);
        }
        else {
            String SQL = "UPDATE integrators  SET [name] = '" + integrator.Name + "'   ,[description] = '" + integrator.Description + "'  ,[dateRegister] = '" + integrator.DateRegister.ToString("yyyy/MM/dd") + "'  ,[id_dependence] = " + integrator.Id_dependence +", [state] = "+integrator.State+
                   " WHERE  id = " + integrator.Id;
            return db.ejecutar(SQL);
        }
    }
}