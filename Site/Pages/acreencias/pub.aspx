<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="pub.aspx.cs" Inherits="Pages_About_pub" %>

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
				<span class="main_t_1"> Acreencias</span>
				
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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

