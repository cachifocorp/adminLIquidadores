<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="projects.aspx.cs" Inherits="mods_publications_projects" %>

<%@ Register Src="~/mods/Controls/ucMultiFileUpload.ascx" TagPrefix="uc1" TagName="ucMultiFileUpload" %>
<%@ Register Src="~/mods/Controls/ucMultiFileUpload.ascx" TagPrefix="uc2" TagName="ucMultiFileUpload" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Publicaciones</a></li>
			    <li><a href="#">Projectos</a></li>
		    </ol>
	    </div>
    </div>
    <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Proyectos</span>
				    </div>
				    <div class="box-icons">
					    <a class="collapse-link">
						    <i class="fa fa-chevron-up"></i>
					    </a>
					    <a class="expand-link">
						    <i class="fa fa-expand"></i>
					    </a>
					    <a class="close-link">
						    <i class="fa fa-times"></i>
					    </a>
				    </div>
				    <div class="no-move"></div>
			    </div>
			    <div class="box-content">
				    <h4 class="page-header">Publication de Proyectos</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
						    <label class="col-sm-2 control-label">Nombre</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtName" runat="server" class="form-control" placeholder="Nombre del proyecto" data-toggle="tooltip" data-placement="bottom" title="Ingrese el Nombre del Proyecto">
						    </div>
						    <label class="col-sm-2 control-label">Autor/res del proyecto</label>
						    <div class="col-sm-4">
							    <input type="text" id="txt_autor" runat="server"  class="form-control" placeholder="Nombre Autor" data-toggle="tooltip" data-placement="bottom" title="Ingrese el/los Nombre/s de el/los Autor/res">
						    </div>
					    </div>
 
					    <div class="form-group">
						    <label class="col-sm-2 control-label" for="form-styles">Descripción</label>
						    <div class="col-sm-10">
								    <textarea   runat="server"   class="form-control" rows="5" id="wysiwig_full"></textarea>
						    </div>
					    </div>
                        <div class="form-group has-feedback">
                             <label class="col-sm-2 control-label" for="form-styles">¿Destacado?</label>
                             <div class="col-sm-1">
						        <div class="toggle-switch toggle-switch-success">
							        <label>
								        <input id="chkfeatured" runat="server"  type="checkbox" checked>
								        <div class="toggle-switch-inner"></div>
								        <div class="toggle-switch-switch"><i class="fa fa-check"></i></div>
							        </label>
						        </div>
					        </div> 
                            <label class="col-sm-2 control-label">Fecha Culminación Proyecto </label>
						    <div class="col-sm-2">
							    <input type="text" runat="server" id="txtDate" class="form-control" placeholder="Date">
							    <span class="fa fa-calendar txt-danger form-control-feedback"></span>
						    </div>
                            <label class="col-sm-1  control-label">Cetegoria del proyecto </label>
						    <div class="col-sm-2">
                                <asp:DropDownList ID="ddlcatProject" runat="server" DataSourceID="projCatSource" DataTextField="name" DataValueField="id"></asp:DropDownList>
						        <asp:SqlDataSource ID="projCatSource" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [pro_category]"></asp:SqlDataSource>
						        <asp:Button ID="Agregar" runat="server" OnClick="Agregar_Click" Text="+" />
						    </div>
                        </div>   
                         <div class="form-group has-feedback">
                            <label class="col-sm-2 control-label">Pais</label>
                               <div class="col-sm-2">        
                                   <asp:DropDownList ID="ddlContry" runat="server" DataSourceID="ContrySrc" DataTextField="name" DataValueField="id" AutoPostBack="True"></asp:DropDownList>                          
						           <asp:SqlDataSource ID="ContrySrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [contry]"></asp:SqlDataSource>
						       </div>

                             <label class="col-sm-2 control-label">Departamento</label>
                               <div class="col-sm-2">    
                                   <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" DataSourceID="stateSrc" DataTextField="name" DataValueField="id"></asp:DropDownList>                              
						           <asp:SqlDataSource ID="stateSrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [state] WHERE ([id_contry] = @id_contry)">
                                       <SelectParameters>
                                           <asp:ControlParameter ControlID="ddlContry" DefaultValue="1" Name="id_contry" PropertyName="SelectedValue" Type="Int32" />
                                       </SelectParameters>
                                   </asp:SqlDataSource>
						       </div>

                             <label class="col-sm-2 control-label">Ciudad</label>
                               <div class="col-sm-2"> 
                                   <asp:DropDownList ID="ddlCity" runat="server" DataSourceID="CitySource" DataTextField="name" DataValueField="id"></asp:DropDownList>                                 
						           <asp:SqlDataSource ID="CitySource" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [city] WHERE ([id_state] = @id_state)">
                                       <SelectParameters>
                                           <asp:ControlParameter ControlID="ddlState" DefaultValue="1" Name="id_state" PropertyName="SelectedValue" Type="Int32" />
                                       </SelectParameters>
                                   </asp:SqlDataSource>
						       </div>
                        </div> 
                         <div class="form-group has-feedback">
                             <label class="col-sm-2 control-label" for="form-styles">¿Activo?</label>
                             <div class="col-sm-1">
						        <div class="toggle-switch toggle-switch-success">
							        <label>
								        <input id="cbxstate" runat="server"  type="checkbox" checked>
								        <div class="toggle-switch-inner"></div>
								        <div class="toggle-switch-switch"><i class="fa fa-check"></i></div>
							        </label>
						        </div>
					        </div> 
                             </div>
                        <div class="form-group has-feedback">
                             <label class="col-sm-2 control-label">Imagen Identificativa del proyecto</label>
                               <div class="col-sm-2">
                                   <!--<asp:FileUpload ID="PicProject" runat="server" /> -->
                                   <uc2:ucMultiFileUpload runat="server" ID="ucMultiFileUpload" />
						       </div>                              
                        </div>  
                        <div class="form-group has-feedback">
                             <label class="col-sm-2 control-label"></label>
                               <div class="col-sm-2" ID="tableImages" runat="server">
						       </div>                              
                        </div>  
                       
					    <div class="clearfix"></div>
					    <div class="form-group">
						    <div class="col-sm-2">
                                <asp:Button ID="btnSaveInfo" runat="server" Text="Publicar" class="btn btn-primary btn-label-left" OnClick="btnSaveInfo_Click"  />
						    </div>
                            <div class="col-sm-2">
                                <asp:Button ID="UpdateInfo" runat="server" Text="Actualizar" class="btn btn-primary btn-label-left" OnClick="updateSaveInfo_Click"  Enabled="False" />
						    </div>
					    </div>
                    </div>
                </div>
             </div>
        </div>
    </div>

     <div class="row">
	        <div class="col-xs-12">
		        <div class="box">
			        <div class="box-header">
				        <div class="box-name">
					        <i class="fa fa-usd"></i>
					        <span>Lista de proyectos</span>
				        </div>
				        <div class="box-icons">
					        <a class="collapse-link">
						        <i class="fa fa-chevron-up"></i>
					        </a>
					        <a class="expand-link">
						        <i class="fa fa-expand"></i>
					        </a>
					        <a class="close-link">
						        <i class="fa fa-times"></i>
					        </a>
				        </div>
				        <div class="no-move"></div>
			        </div>
			        <div class="box-content no-padding">
                      <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Opciones</th>
							        <th>Nombre</th>
							        <th>Auto</th>
							        <th>Descripcion</th>
						        </tr>
					        </thead>
					        <tbody id="list_projects" runat="server">
					        <!-- Start: list_row -->
                            </tbody>
                        </table>
                         <div id="actions" runat="server"></div>
                    </div>
                    </div>
                </div>
            </div>
</form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="customScripts" Runat="Server">

    <script>
        $(".delPhoto").on("click", function () {
            var datastring = $(this).attr("href").replace("#", "");
            var id_img = datastring.split("|")[0];
            var img = datastring.split("|")[1];
            var id_project = datastring.split("|")[2];
            //alert(id_img + " - " + img + " - " + id_project);

            $.ajax({
                url: "projects.aspx/deletePhoto",
                type: 'post',
                data: "{id_img:" + id_img + ",img:'" + img + "',id_project:"+id_project+"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == true) {
                        alert("Exito!! la Operación se ha realizado Correctamente");                        
                    } else {
                        alert("Ups! Ha ocurrido un error al realizar la operación");
                    }
                },
                failure: function (response) {
                    console.log(response.d);
                }
            });
        });
    </script>
</asp:Content>

