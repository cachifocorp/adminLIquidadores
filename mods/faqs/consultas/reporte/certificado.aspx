<%@ Page Language="C#" AutoEventWireup="true" CodeFile="certificado.aspx.cs" Inherits="Site_Pages_consultas_reporte_certificado" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Certificado de Afiliación EPS  y PAC </title>
    <style>
        body{
            font-family: Arial;
        }
        #contenedor{            
            padding: 30px 20px 20px 0;
            width: 600px;
            margin: 0 auto;
            text-align: center;
        }
        #contenedor img{
            width: 40%;
            
        }
        #contenedor h2{
             font-family: Arial;
            font-size: 15px;
            margin: 30px;
            padding: 10px;
            
        }
        p{
            text-align: justify;
        }
        #tabla#{
          
            
        }
        table{
            width: 100%;  
            margin: 40px 0 30px 0;
        }
        table > thead{
            font-weight: bold;
        }
        
        #desp{
            text-align: left;
            margin-top: 4em;
        }
 
    </style>
   <script>
       window.print();
    </script>
</head>
<body>
    <div id="contenedor">
        <img src="http://liquidadores.estigioportal.com/Site/Pages/uploads/dependences/logoEmpresa.png" />
        
            <h2>CAJA DE COMPENSACION FAMILIAR COMFENALCO ANTIOQUIA
                COMFENALCO ANTIOQUIA EPS
                NIT. 890.900.842-6
            </h2>
       
        <strong>CERTIFICA</strong>

<p>Que el (la) señor(a) <%=afi[0].AtdNomPri+" "+afi[0].AtdNomSeg+" "+afi[0].AtdApePri+" "+afi[0].AtdApeSeg %> identificado(a) con Cédula de Ciudadanía <%=afi[0].AtdAfiIde %>, se encuentra retirado(a) del Plan Obligatorio de Salud, POS, según información relacionada a continuación.
</p>

<div id="tabla">
      <table>
           <thead>
               <tr>
                   <td>PLAN</td>
                   <td>FECHA APFILIACION</td>
                 <%--  <td>FECHA RETIRO</td>--%>
               </tr>
           </thead>
            <tbody>
                <tr>
                    <td>Plan Obligatorio de Salud POS</td>
                    <td><%=Convert.ToDateTime(afi[0].AtdfecEps).ToString("dd/MM/yyyy") %></td>
                   <%-- <td>09/12/2013</td>--%>
                </tr>
            </tbody>
        </table>
</div>

<p>
    <% DateTime d = DateTime.Today; %>
Se expide el presente certificado a solicitud del (la) interesado(a), el <%=d.ToString("dd 'de', MMMM 'del año', yyyy") %>
 </p>
<p>
    <strong>Observaciones:</strong><br>
Información sujeta a verificación por parte de Comfenalco Antioquia EPS, cualquier aclaración con gusto será atendida en la línea 44534435.
 </p>


<div id="desp">
Cordialmente,<br><br>

Comfenalco Antioquia EPS.
        </div>
    </div>
</body>
</html>