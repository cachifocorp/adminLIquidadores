<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="gestion.aspx.cs" Inherits="Pages_About_policies" %>

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
				<span class="main_t_1"> SISTEMAS DE GESTION </span>
				<span class="main_t_2"> AMV | Energia Y Comunicaciones </span>
				<span class="breadcrumb"> <a href="#"> INICIO </a> / GESTION </span>
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
    <!-- End Main title wrapper --> 
    
	
    <div class="content">		
				
	 <div class="page_wrapper">	
	  <div class="page_wrapper_inner">
<!-- Start About us block --> 
<div class="container content_wrapper_section"> 
    <div class="container">
	  <div class="row">        							    
		<ul id="Content_page_post_policies" class="portfolio group">
            <div class="row"> 
                <ul class="portfolio group">
                    <li class="span4" data-id="id-1" data-type="advertising">
                        <div class="view"><div class="h_port_image_p">
                            <a href="../uploads/publications/20140704101318IMG_0900.jpg" title="" data-rel="prettyPhoto[portfolio]" class="view_image">
                                <img src="../uploads/publications/20140704101318IMG_0900.jpg"  alt="">
                                <div class="link_overlay icon-search"></div>
                            </a>
                        </div>
                            <span class="clear"></span>

                        </div>
                        <div class="view_title_port_p">
                            <a href="pub.aspx?idp=4">
                                <h4 style="color: rgb(77, 77, 77);"> Políticas de Calidad de Cliente y Servicio</h4></a>
                            <span class="clear"></span>
                        </div>
                        <div class="port_read_more_p">
                            <a href="pub.aspx?idp=4">Mas Información <i class="icon_port_more_p"></i> </a>
                        </div>
                    </li>
                    <li class="span4" data-id="id-1" data-type="advertising">
                    <div class="view"><div class="h_port_image_p">
                    <a href="../src/images/images/IMG_9961.jpg" title="" data-rel="prettyPhoto[portfolio]" class="view_image">
                        <img src="../src/images/images/IMG_9961.jpg" alt="">
                        <div class="link_overlay icon-search">
                        </div>
                    </a>
                    </div>
                        <span class="clear"></span>
                    </div>
                   <div class="view_title_port_p">
                       <a href="pub.aspx?idp=6">
                           <h4 style="color: rgb(77, 77, 77);">Políticas de Seguridad, Salud Ocupacional y Medio Ambiente</h4></a>
                       <span class="clear"></span>
                   </div>
                        <div class="port_read_more_p">
                            <a href="pub.aspx?idp=6">Mas Información  <i class="icon_port_more_p"></i></a>
                        </div>
                    </li>

                    <li class="span4" data-id="id-1" data-type="advertising">
                        <div class="view"><div class="h_port_image_p">
                            <a href="../src/images/large/logosCertificados.jpg" title="" data-rel="prettyPhoto[portfolio]" class="view_image">
                                <img src="../src/images/large/logosCertificados.jpg" alt=""/>
                                <div class="link_overlay icon-search"></div>
                            </a>
                       </div>
                            <span class="clear"></span>
                        </div>
                        <div class="view_title_port_p">
                            <a href="certifications.aspx">
                                <h4 style="color: rgb(77, 77, 77);">Certificaciones</h4></a>
                             <span class="clear"></span>
                        </div>
                        <div class="port_read_more_p"><a href="certifications.aspx">Mas Información <i class="icon_port_more_p"></i> </a>
                        </div>
                    </li>
                </ul>
                <div class="clear">
                </div>	
            </div>  
		</ul>
	 
    <div class="clear"></div>	

	</div>  <!-- End port wrapper -->
    </div>	
   </div>
<!-- End About us block --> 
<!-- Start Client block -->  
   <div class="container">
   <div class="content_wrapper_section">
     <div class="port_wrapper_home">
        <i class="icon_cli"></i>
		  <div class="block_tile_wrapper">	 
	       <span class="block_tile_1"> Nuestros Clientes </span>
	       <span class="block_tile_2"> &nbsp; | &nbsp;  Estos Son algunos de nuestros Clientes  </span>
		  </div>
		<div class="readmore_holder"><a href="Client/Clients.aspx"><i class="icon_plus"></i></a></div>
        <div class="clear"></div>		
     </div>  
    <div class="container">
	  <div class="row">
	        					
     <div class="client_h_inner">   
       <div class="client_h_holder_bottom">	
        <ul class="client_inner_top" id="imageClient" runat="server">       
        </ul>  <!-- End client inner -->
          <div class="clear"></div>		
        </div>
	 </div><!-- End client h inner -->

	</div>  <!-- End row -->
    </div>	
   </div> <!-- End content wrapper section --> 
	<div class="clear"></div>
   </div>
<!-- End client block -->
<!-- Start testimonials block  
 <div class="container content_wrapper_section">
      
    <div class="container">
	  <div class="row">        							    
      
	  <div class="faq_holder"> 
	        <div class="testi_inner_wrapper_holder_4" id="commet_client" runat="server">

			  <div class="clear"></div>
		  </div>  
			<span class="clear"></span>
        </div>	
	 
    <div class="clear"></div>	

	</div>   
    </div>	
   </div>  
 End testimonials block -->     
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts_down" Runat="Server">
    <script>
        $(function () {
            $(".in").attr("class", "span4");
        });
    </script>
</asp:Content>

