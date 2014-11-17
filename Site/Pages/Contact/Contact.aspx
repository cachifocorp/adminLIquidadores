<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Pages_Contact_Contact" %>

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
				<span class="main_t_1">Contactenos </span>
				<span class="main_t_2"> Póngase en contacto con nuestra empresa </span>
				<span class="breadcrumb"> <a href="#">Inicio </a> / Contactenos </span>
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
    	 
	    	<div class="container content_wrapper_section">  
	  	  		
      <div class="row">
               <div class="span12">        	
					<div class="contact_title">
						<!--<h2><i class="icon-flag"></i>Contacto</h2>-->
					</div>
                     <h2 class="contact_text">¡Escríbenos!</h2>                					
		       
                <div class="contact_inner span12">	
                    <div class="one_fourth contact_inner_text">
                        <div class="contact_icon_holder">
                            <i class="icon-map-marker"></i>
                        </div>
                        <div class="contact_text_info">
                            <span>Dirección :</span>  <%=dpm.Name_city+"  | "+dpm.Address %></div>
                        </div>
                    <div class="one_fourth contact_inner_text">
                        <div class="contact_icon_holder">
                            <i class="icon-phone"></i>
                        </div>
                        <div class="contact_text_info"><span>Telefono : </span><%=dpm.Phone %>
                        </div>
                    </div>					
                   
                    <div class="one_fourth lastcolumn contact_inner_text">
                        <div class="contact_icon_holder">
                            <i class="icon-envelope-alt"></i>
                        </div>
                        <div class="contact_text_info"><span>Email :</span><%=dpm.Email %></div>
                        </div>
                    <div class="clear"></div>
                </div>
               </div>
				<div class="clear"></div>
         <div id="label_Message" runat="server">              
        </div>
		<form id="Form1" class="contact_form contact_form_h"   style="margin-bottom: 10px;" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
			<div class="span12">  	
				<div class="input_holder">
                    <h5>Nombre</h5>
						<input class="field-name" type="text" placeholder="Nombre (requerido)" id="name" runat="server">
					</div>
					
					<div class="input_holder">
                        <h5>Telefono</h5>
						<input class="phone_field" type="tel" placeholder="Telefono" id="phone" runat="server">
					</div>
					<div class="input_holder">
                        <h5>Dirección</h5>
						<input class="subject_field" type="text" placeholder="Dirección" id="address" runat="server">
					</div>

	        </div> 
	        <div class="span12">  	
				<div class="input_holder" id="contrys" runat="server">
                    <h5>Pais</h5>
                    <asp:DropDownList class="input-xxlarge" ID="Contry" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id"  AutoPostBack="true" OnSelectedIndexChanged="Contry_SelectedIndexChanged"></asp:DropDownList>
				    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [contry]" ></asp:SqlDataSource>
				</div>				
                	
				<div class="input_holder" id="citys" runat="server">
                    <h5>Ciudad</h5>
                    <asp:DropDownList class="input-xxlarge" ID="City" runat="server"   DataTextField="name" DataValueField="id"></asp:DropDownList>
				   
				</div>

				<div class="input_holder" id="states" runat="server">
                    <h5>Departamento</h5>
                    <asp:DropDownList class="input-xxlarge" ID="state" runat="server"   DataTextField="name" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="state_SelectedIndexChanged"></asp:DropDownList>
				    
				</div>

	        </div> 
	        <div class="span12">  	
							
					<div class="input_holder">
                        <h5>Correo Electronico</h5>
						<input class="email_field" type="email" placeholder="Correo Electronico ej: ejemplo@ejemplo.com " id="email" runat="server">
					</div>
					 
									 

	        </div> 
	        <div class="span12">  	
						
					<div class="textarea_holder">
						<textarea class="comment_field" placeholder="Mensaje de Contacto" id="comment" runat="server"></textarea>
					</div>
                <asp:Button ID="saveData" runat="server" Text="Enviar Información" class="button" OnClick="saveData_Click"/> 
					
	        </div>  
		</form>
    <div class="clear"></div>
    <br>
    <hr>
 	<p style="margin:10px; text-align:center">
 		La LEY ESTATUTARIA 1581 DE 2012 de Protección de Datos Personales reconoce y protege el derecho que tienen todas las personas a conocer, actualizar y rectificar las informaciones que se hayan recogido sobre ellas en bases de datos o archivos que sean susceptibles de tratamiento por entidades de naturaleza pública o privada.
 	</p>
 	
  </div> <!-- End row -->
				
	  </div>  <!-- End content wrapper section -->
	<div class="clear"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Content_down" runat="server">
    <div class="goo_wrapper">
	      <div id="googlemaps"><div id="googlemap"></div></div>	   
    </div>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts_down" Runat="Server">

</asp:Content>

