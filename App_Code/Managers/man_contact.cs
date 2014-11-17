using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;


/// <summary>
/// Summary description for man_contact
/// </summary>
public class man_contact
{
    clsDb db = new clsDb();
    private String error;

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

    public Boolean saveInfoContact(contact[] contact)
    {
        Boolean ch = false;
        for (int i = 0; i < contact.Length; i++)
        {
            String SQL = "INSERT INTO contact(name, address, phone, id_city, email, file_name, comment, type, id_dependence) " +
                         "VALUES('" + contact[i].Name + "','" + contact[i].Address + "','" + contact[i].Phone + "'," + contact[i].Id_city + ",'" + contact[i].Email + "','" + contact[i].File_name + "','" + contact[i].Comment + "','" + contact[i].Type + "', " + contact[i].Id_dependence + ")";
            if (db.ejecutar(SQL))
            {
                ch = true;
            }
        }
        return ch;
    }



    public Boolean sendMail(contact contact)
    {
        try
        {
            //Configuración del Mensaje
            MailMessage mail = new MailMessage();

            //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            mail.From = new MailAddress("senderamv@estigioportal.com", "AMV S.A.", Encoding.UTF8);
            //Aquí ponemos el asunto del correo
            mail.Subject = "Alerta de Contacto";
            //Aquí ponemos el mensaje que incluirá el correo 
            String mensaje1 = "<!DOCTYPE html><html lang=\"en\"><head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"><title>Email De Contacto</title><style>a:hover{text-decoration: underline !important;}td.promocell p{color:#e1d8c1;font-size:16px;line-height:26px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:14px;font-weight:normal;}td.contentblock h4{color:#444444 !important;font-size:16px;line-height:24px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:10px;padding-top:0;padding-bottom:0;font-weight:normal;}td.contentblock h4 a{color:#444444;text-decoration:none;}td.contentblock p{color:#888888;font-size:13px;line-height:19px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:12px;padding-top:0;padding-bottom:0;font-weight:normal;}td.contentblock p a{color:#3ca7dd;text-decoration:none;}@media only screen and (max-device-width: 480px){div[class=\"header\"]{font-size: 16px !important;}table[class=\"table\"], td[class=\"cell\"]{width: 300px !important;}table[class=\"promotable\"], td[class=\"promocell\"]{width: 325px !important;}td[class=\"footershow\"]{width: 300px !important;}table[class=\"hide\"], img[class=\"hide\"], td[class=\"hide\"]{display: none !important;}img[class=\"divider\"]{height: 1px !important;}td[class=\"logocell\"]{padding-top: 15px !important;padding-left: 15px !important;width: 300px !important;}img[id=\"screenshot\"]{width: 325px !important;height: 127px !important;}img[class=\"galleryimage\"]{width: 53px !important;height: 53px !important;}p[class=\"reminder\"]{font-size: 11px !important;}h4[class=\"secondary\"]{line-height: 22px !important;margin-bottom: 15px !important;font-size: 18px !important;}}</style></head><body bgcolor=\"#e4e4e4\" topmargin=\"0\" leftmargin=\"0\" marginheight=\"0\" marginwidth=\"0\" style=\"-webkit-font-smoothing: antialiased;width:100% !important;background:#e4e4e4;-webkit-text-size-adjust:none;\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" bgcolor=\"#e4e4e4\"><tr><td bgcolor=\"#e4e4e4\" width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"center\" class=\"table\"><tr><td width=\"600\" class=\"cell\" align=\"center\" ><table width=\"600\" cellpadding=\"25\" cellspacing=\"0\" border=\"0\" class=\"promotable\"><tr><td bgcolor=\"#456265\" width=\"600\" class=\"promocell\"><multiline label=\"Main feature intro\"><p style=\"color:white; font-size:10px;\">Email de Contacto</p></multiline></td></tr></table><repeater><layout label=\"New feature\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td bgcolor=\"#85bdad\" nowrap></td><td width=\"100%\" bgcolor=\"#ffffff\"><table width=\"100%\" cellpadding=\"20\" cellspacing=\"0\" border=\"0\"><tr><td bgcolor=\"#ffffff\" class=\"contentblock\"><h4 class=\"secondary\"><strong><singleline label=\"Title\">Informacion recolectada</singleline></strong></h4><multiline label=\"Description\"><p>Nombre: " + contact.Name + "</p><p>Direccion: " + contact.Address + "</p><p>Telefono: " + contact.Phone + "</p><p>Email: " + contact.Email + "</p><hr><p>Mensaje<br>" + contact.Comment + "</p></multiline></td></tr></table></td></tr></layout></repeater></td></tr></table></td></tr></table></body></html>";
            String mensaje2 = "<!DOCTYPE html><html lang=\"en\"><head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"><title>Email De Contacto</title><style>a:hover{text-decoration: underline !important;}td.promocell p{color:#e1d8c1;font-size:16px;line-height:26px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:14px;font-weight:normal;}td.contentblock h4{color:#444444 !important;font-size:16px;line-height:24px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:10px;padding-top:0;padding-bottom:0;font-weight:normal;}td.contentblock h4 a{color:#444444;text-decoration:none;}td.contentblock p{color:#888888;font-size:13px;line-height:19px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:12px;padding-top:0;padding-bottom:0;font-weight:normal;}td.contentblock p a{color:#3ca7dd;text-decoration:none;}@media only screen and (max-device-width: 480px){div[class=\"header\"]{font-size: 16px !important;}table[class=\"table\"], td[class=\"cell\"]{width: 300px !important;}table[class=\"promotable\"], td[class=\"promocell\"]{width: 325px !important;}td[class=\"footershow\"]{width: 300px !important;}table[class=\"hide\"], img[class=\"hide\"], td[class=\"hide\"]{display: none !important;}img[class=\"divider\"]{height: 1px !important;}td[class=\"logocell\"]{padding-top: 15px !important;padding-left: 15px !important;width: 300px !important;}img[id=\"screenshot\"]{width: 325px !important;height: 127px !important;}img[class=\"galleryimage\"]{width: 53px !important;height: 53px !important;}p[class=\"reminder\"]{font-size: 11px !important;}h4[class=\"secondary\"]{line-height: 22px !important;margin-bottom: 15px !important;font-size: 18px !important;}}</style></head><body bgcolor=\"#e4e4e4\" topmargin=\"0\" leftmargin=\"0\" marginheight=\"0\" marginwidth=\"0\" style=\"-webkit-font-smoothing: antialiased;width:100% !important;background:#e4e4e4;-webkit-text-size-adjust:none;\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" bgcolor=\"#e4e4e4\"><tr><td bgcolor=\"#e4e4e4\" width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"center\" class=\"table\"><tr><td width=\"600\" class=\"cell\" align=\"center\" ><table width=\"600\" cellpadding=\"25\" cellspacing=\"0\" border=\"0\" class=\"promotable\"><tr><td bgcolor=\"#456265\" width=\"600\" class=\"promocell\"><multiline label=\"Main feature intro\"><p style=\"color:white; font-size:10px;\">Email de Contacto Proveedor</p></multiline></td></tr></table><repeater><layout label=\"New feature\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td bgcolor=\"#85bdad\" nowrap></td><td width=\"100%\" bgcolor=\"#ffffff\"><table width=\"100%\" cellpadding=\"20\" cellspacing=\"0\" border=\"0\"><tr><td bgcolor=\"#ffffff\" class=\"contentblock\"><h4 class=\"secondary\"><strong><singleline label=\"Title\">Informacion recolectada</singleline></strong></h4><multiline label=\"Description\"><p>Nombre: " + contact.Name + "</p><p>Direccion: " + contact.Address + "</p><p>Telefono: " + contact.Phone + "</p><p>Email: " + contact.Email + "</p><hr><p>Mensaje<br>" + contact.Comment + "</p></multiline></td></tr></table></td></tr></layout></repeater></td></tr></table></td></tr></table></body></html>";
            String mensaje3 = "<!DOCTYPE html><html lang=\"en\"><head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"><title>Email De Contacto</title><style>a:hover{text-decoration: underline !important;}td.promocell p{color:#e1d8c1;font-size:16px;line-height:26px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:14px;font-weight:normal;}td.contentblock h4{color:#444444 !important;font-size:16px;line-height:24px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:10px;padding-top:0;padding-bottom:0;font-weight:normal;}td.contentblock h4 a{color:#444444;text-decoration:none;}td.contentblock p{color:#888888;font-size:13px;line-height:19px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;margin-top:0;margin-bottom:12px;padding-top:0;padding-bottom:0;font-weight:normal;}td.contentblock p a{color:#3ca7dd;text-decoration:none;}@media only screen and (max-device-width: 480px){div[class=\"header\"]{font-size: 16px !important;}table[class=\"table\"], td[class=\"cell\"]{width: 300px !important;}table[class=\"promotable\"], td[class=\"promocell\"]{width: 325px !important;}td[class=\"footershow\"]{width: 300px !important;}table[class=\"hide\"], img[class=\"hide\"], td[class=\"hide\"]{display: none !important;}img[class=\"divider\"]{height: 1px !important;}td[class=\"logocell\"]{padding-top: 15px !important;padding-left: 15px !important;width: 300px !important;}img[id=\"screenshot\"]{width: 325px !important;height: 127px !important;}img[class=\"galleryimage\"]{width: 53px !important;height: 53px !important;}p[class=\"reminder\"]{font-size: 11px !important;}h4[class=\"secondary\"]{line-height: 22px !important;margin-bottom: 15px !important;font-size: 18px !important;}}</style></head><body bgcolor=\"#e4e4e4\" topmargin=\"0\" leftmargin=\"0\" marginheight=\"0\" marginwidth=\"0\" style=\"-webkit-font-smoothing: antialiased;width:100% !important;background:#e4e4e4;-webkit-text-size-adjust:none;\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" bgcolor=\"#e4e4e4\"><tr><td bgcolor=\"#e4e4e4\" width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"center\" class=\"table\"><tr><td width=\"600\" class=\"cell\" align=\"center\" ><table width=\"600\" cellpadding=\"25\" cellspacing=\"0\" border=\"0\" class=\"promotable\"><tr><td bgcolor=\"#456265\" width=\"600\" class=\"promocell\"><multiline label=\"Main feature intro\"><p style=\"color:white; font-size:10px;\">Email de Contacto - Trabajo</p></multiline></td></tr></table><repeater><layout label=\"New feature\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td bgcolor=\"#85bdad\" nowrap></td><td width=\"100%\" bgcolor=\"#ffffff\"><table width=\"100%\" cellpadding=\"20\" cellspacing=\"0\" border=\"0\"><tr><td bgcolor=\"#ffffff\" class=\"contentblock\"><h4 class=\"secondary\"><strong><singleline label=\"Title\">Informacion recolectada</singleline></strong></h4><multiline label=\"Description\"><p>Nombre: " + contact.Name + "</p><p>Direccion: " + contact.Address + "</p><p>Telefono: " + contact.Phone + "</p><p>Email: " + contact.Email + "</p><hr><p>Mensaje<br>" + contact.Comment + "</p></multiline></td></tr></table></td></tr></layout></repeater></td></tr></table></td></tr></table></body></html>";
            switch (contact.Type)
            {
                case 1:
                    mail.Body = mensaje1;

                    break;
                case 2:
                    mail.Body = mensaje2;
                    if (contact.File_name.Length > 3)
                    {
                        mail.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath("~/Pages/uploads/supplier/") + contact.File_name));
                    }
                    break;
                case 3:
                    mail.Body = mensaje3;
                    if (contact.File_name.Length > 3)
                    {
                        mail.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath("~/Pages/uploads/jobs/") + contact.File_name));
                    }
                    break;
            }

            mail.IsBodyHtml = true;
            //Especificamos a quien enviaremos el Email,
            String contactos = getMailUser(contact.Type);
            mail.To.Add(contactos.Substring(0, (contactos.Length - 1)));
            //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran



            //Configuracion del SMTP
            SmtpClient SmtpServer = new SmtpClient("estigioportal.com");
            //SmtpServer.Port = 25; //Puerto
            //Especificamos las credenciales con las que enviaremos el mail
            SmtpServer.Credentials = new System.Net.NetworkCredential("senderamv@estigioportal.com", "admin123");
            // SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
            return true;
        }
        catch (System.Net.Mail.SmtpException ex)
        {
            setError(ex.Message);
            return false;
        }
    }

    private String getMailUser(int id_type)
    {
        String SQL = "SELECT [email] FROM [emailcontact] where id_dependence = " + Resources.Base.dependence + " and [type] = " + id_type;
        String emails = "";
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                emails += reader["email"] + ",";
            }
            reader.Close();

            return emails;
        }
        catch (Exception ex)
        {

            return emails;
        }
    }

    public void setError(String Error)
    {
        this.error = Error;
    }

    public String getError()
    {
        return this.error;
    }

}