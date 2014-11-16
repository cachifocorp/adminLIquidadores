<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="pub.aspx.cs" Inherits="Pages_About_pub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {
            $("#a0").tab('show');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
    <!-- Start Main title wrapper  -->	   
		   
	<div class="main_title_wrapper">
		    
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1"> Informacion sobre AMV </span>
				<span class="main_t_2"> Energia Y Comunicaciones </span>
				<span class="breadcrumb"> <a href="../Default.aspx">inicio </a> / <a href="#">Sobre Nosotros</a> / <span id="titulo2"></span></span>
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
    <!-- Start About us block --> 

 <div class="container content_wrapper_section"> 
    <div class="container">
	  <div class="row">        							    
      
	  <div class="about_us_page"> 
			        					                			 		
      <div class="span6">
        	<div class="h4_ab_wrapper">		       		 
	     <p style="text-align:center;" id="image_pub" runat="server"> 
	     	
		 </p>		 
     	</div>	
       <div class="clear"></div>		  
      </div>  	<!-- End span6 --> 
      <div class="span6">
        	<div class="h4_ab_wrapper">	
         <ul class="tabs" id="languages" runat="server">
         </ul>        
	     <ul class="tabs-content clearfix" id="description_pub" runat="server">	     	
		 </ul> 
                            		 
     	</div>	
       <div class="clear"></div>		  
      </div>  	<!-- End span6 --> 		   		   	    				
			 				  
      </div> 
    <div class="clear"></div>	

	</div>  <!-- End port wrapper -->
    </div>	
   </div> <!-- End content wrapper section --> 
 
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
        <ul class="client_inner_top" id="client_photo" runat="server">       
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

