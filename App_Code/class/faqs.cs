using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for faqs
/// </summary>
public class faqs
{
    private int id;
    private String titulo;
    private String descripcion;
    private int tipo;
    private DateTime timestamp;

	public faqs()	{}

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }
    public String Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public int Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public DateTime Timestamp
    {
        get { return timestamp; }
        set { timestamp = value; }
    }

}