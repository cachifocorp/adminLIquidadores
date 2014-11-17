<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="whereWeAre.aspx.cs" Inherits="Pages_About_whereWeAre" %>

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
				<span class="main_t_1"> Donde estamos </span>
				<span class="main_t_2"> Nuestras Oficinas en todo el Pais </span>
				<span class="breadcrumb"> <a href="#">Inicio </a> / Donde Estamos </span>
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
	    <div class="row"  >
	        <div class="span12">        	
	            <h2 class="contact_text">Seleccione una ciudad  para visulizar en el mapa las oficinas</h2>	
			</div>
			<div class="clear"></div>			
			<div class="span12" >  	
					<div class="input_holder" style="text-align:center;" id="cit" runat="server">							
					</div>
			</div>		
	    	<div class="clear"></div>   
			<div id="direcciones"></div>
	  </div> <!-- End row -->
	  <h5>Para mas detalles haga click en el marcador dentro del mapa</h5>
		  <div class="goo_wrapper">
      <div id="googlemaps" ><div id="googlemap"></div></div>	   
	</div> 
	</div>  <!-- End content wrapper section -->
	<div class="clear"></div>   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts_down" runat="server">

<script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
<script src="../src/js/gmap3.js" type="text/javascript" ></script> 


<script type="text/javascript">
    $(document).ready(function () {
        var iconMarker = "../src/img/markerMapAMV.png";
        var markeroptions = {
            values: [{
                address: "Carrera 29 #45 - 45 bucaramanga",
                options: { icon: iconMarker },
                events: {
                    click: function () {
                       $("#direcciones").html(direcciones(" Carrera 29 No. 45 - 45 Piso 15 Metropolitan Bussines Park ", " ", "(57) (7) 697 03 07", ""));
                    }
                }
            }
            ]
        };
        getMapa(markeroptions);
         <%
            man_office off = new man_office();
            Response.Write(off.getScriptsMap(3, 1, "../src/img/"));
             %>
    });
        
            
            
        

    function getMapa(markeroptions) {
        $('#googlemap').gmap3({
            action: 'destroy'
        });

            $("#googlemaps").html(' <div id="googlemap"></div>');
            $('#googlemap').gmap3({
                action: 'init',
                marker: markeroptions,
                map: {
                    options: {
                        zoom: 15,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    }
                }
            });
        }

        function direcciones(dir, tel, fax, email) {
            var mensaje = '<div class="contact_inner span12">\
						<div class="one_fourth contact_inner_text">\
							<div class="contact_icon_holder">\
								<i class="icon-map-marker"></i></div>\
							<div class="contact_text_info">\
								<span>Dirección :</span> '+ dir + '	</div>\
						</div>\
						<div class="one_fourth contact_inner_text">\
							<div class="contact_icon_holder">\
								<i class="icon-phone"></i>\
							</div>\
							<div class="contact_text_info">\
								<span>Telefono :</span>'+ tel + '</div>\
						</div>\
						<div class="one_fourth contact_inner_text">\
							<div class="contact_icon_holder">\
								<i class="icon-print"></i>\
							</div>\
							<div class="contact_text_info">\
								<span>Fax :</span>'+ fax + '</div>\
						</div>\
						<div class="one_fourth lastcolumn contact_inner_text">\
							<div class="contact_icon_holder">\
								<i class="icon-envelope-alt"></i>\
							</div>\
							<div class="contact_text_info">\
								<span>Email :</span>'+ email + '</div>\
						</div>\
						<div class="clear"></div></div>';

            return mensaje;
        }

    


</script>

<!-- google webfont font replacement  -->
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,400italic,700,700italic,300,300italic' rel='stylesheet' type='text/css'>
</asp:Content> 


