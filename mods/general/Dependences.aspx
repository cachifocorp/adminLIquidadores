<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="Dependences.aspx.cs" Inherits="mods_general_Dependences" %>

<asp:Content ID="content_Head" ContentPlaceHolderID="headContent" runat="server">
    	<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

    <form id="Form1" runat="server">
        <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Oficinas</a></li>
		    </ol>
	    </div>
    </div>
    <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Registro</span>
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
				    <h4 class="page-header">Registro de Dependencias</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                              <label  class="col-sm-2 control-label">Nombre</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtName" runat="server" class="form-control" placeholder="Nombre de la dependencia" data-toggle="tooltip" data-placement="bottom" title="Nombre de la dependencia">
						    </div>
						    <label  class="col-sm-2 control-label">Direccion</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtAddress" runat="server" class="form-control" placeholder="Direccion" data-toggle="tooltip" data-placement="bottom" title="Direccion de la oficina">
						    </div>
                             <label  class="col-sm-2 control-label">Telefono</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtPhone" runat="server" class="form-control" placeholder="Nombre del telefono" data-toggle="tooltip" data-placement="bottom" title="Telefono">
						    </div>
                            <label  class="col-sm-2 control-label">Url</label>
						    <div class="col-sm-4">
							    <input type="text" id="txturl" runat="server" class="form-control" placeholder="Nombre del telefono" data-toggle="tooltip" data-placement="bottom" title="Fax">
						    </div>
					    </div>
					    <div class="form-group">
						    <label  class="col-sm-2 control-label">Email</label>
						    <div class="col-sm-4">
							    <input type="email" id="txtEmail" runat="server" class="form-control" placeholder="ejemplo@ejemplo.com" data-toggle="tooltip" data-placement="bottom" title="Email">
						    </div>
                             <label class="col-sm-2 control-label" for="form-styles">Imagen</label>
						    <div class="col-sm-2">
                                <asp:FileUpload ID="flIcon" runat="server" />
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
                        <div class="form-group">
                             <label class="col-sm-2 control-label" for="form-styles">Ubicación</label>
                           <div class="col-sm-10">
						    <div id="canvas" style="width: 600px; height: 200px;" ></div>
	                            <br />
	                            <label for="latitude">Latitud:</label>
	                            <input id="latitude" type="text" value="" runat="server"/>
	                            <label for="longitude">Longitud:</label>
	                            <input id="longitude" type="text" value=""  runat="server"/>
					        </div>
                       </div>
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="UpdateData" runat="server" Text="Actualizar" class="btn btn-primary btn-label-left" OnClick="UpdateData_Click" Enabled="False" />
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
							        <th>Direccion</th>
							        <th>logo</th>
							        <th>URL</th>
						        </tr>
					        </thead>
					        <tbody id="list_Dependence" runat="server">
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
    <script src="../src/plugins/Gmaps3/gmap.js"></script>
</asp:Content>

