<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="notificaciones.aspx.cs" Inherits="Site_Pages_Notificaciones_notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
     <!-- Start Main title wrapper  -->	   
		   
	<div class="main_title_wrapper">
		    
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1"> Notificaciones Electronicas</span>
				
		  </div>
		  </div>
		 </div>
        </div>			
      </div> <!-- End page title wrapper -->
	  <div class="clear"></div>	
    </div> 	

<!-- End Main title wrapper --> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server">
    <form runat="server">
        <div class="row">
            <div class="span12 text_header" style="padding-left:30px;">
                <h2 class="text-center">Notificaciones electrónicas</h2>
                <p>Los Artículos 68 y 69 de la Ley 1437 de 2011 (Nuevo Código Contencioso Administrativo), señalan  que cuando  se desconozca la información del destinatario se publicara la citación  en la página electrónica o en un lugar de acceso al público de la respectiva entidad por el término de 5 días quedando constancia en el expediente  de la fecha en la que quedó surtida la notificación personal. En el caso de la notificación por Aviso se realizara la publicación conforme a lo anteriormente descrito, con la advertencia de que la notificación se considerará  surtida al finalizar el día siguiente al retiro del aviso.</p>
            </div>
            <hr />
            <div class="span12">
                <table style="color:black; margin-left:20px" class="table table-bordered text-center">
                   <tr>
                        <td >No. DE LA RESOLUCI&#211;N </td>
                        <td >FECHA</td>
                        <td >ASUNTO</td>
                        <td >AUTORIDAD QUE LA EXPIDE</td>
                        <td >FECHA DE PUBLICACI&#211;N EN LA WEB</td>
                    </tr>
                </table>
                
            </div>
        </div>

  </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

