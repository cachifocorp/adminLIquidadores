using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Commnet
/// </summary>
public class Commnet
{

    private int id;
    private String commnet;
    private DateTime date_commnet;
    private int id_publication;   
	public Commnet(){}

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Commnet1
    {
        get { return commnet; }
        set { commnet = value; }
    }

    public DateTime Date_commnet
    {
        get { return date_commnet; }
        set { date_commnet = value; }
    }

    public int Id_publication
    {
        get { return id_publication; }
        set { id_publication = value; }
    }
}