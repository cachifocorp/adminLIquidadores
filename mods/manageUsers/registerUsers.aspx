<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="registerUsers.aspx.cs" Inherits="mods_mangeUsers_registerUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<form id="Form1" runat="server">
        <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">registro de usuarios</a></li>
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
				    <h4 class="page-header">Registro de Usuarios</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                                  <label  class="col-sm-2 control-label">Nombre de usuario</label>
						        <div class="col-sm-4">
							        <input type="text" id="txtUsername" runat="server" class="form-control" placeholder="Nombre del Usuario" data-toggle="tooltip" data-placement="bottom" title="Ingrese el nombre del Usuario" required>
						        </div>
						        <label  class="col-sm-2 control-label">Dependencia</label>
						        <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlDependence" runat="server" DataSourceID="depSource" DataTextField="name" DataValueField="id"></asp:DropDownList>
						            <asp:SqlDataSource ID="depSource" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [dependence]"></asp:SqlDataSource>
						        </div>                            
					        </div>

                            <div class ="form-group">
                               <label  class="col-sm-2 control-label">Contraseña</label>
						        <div class="col-sm-4">
							        <input type="text" id="txtPassword" runat="server"   class="form-control" placeholder="Contraseña" data-toggle="tooltip" data-placement="bottom" title="Ingrese la contraseña">
						        </div>
                                 <label class="col-sm-2 control-label" for="form-styles">¿Activo?</label>
                                 <div class="col-sm-4">
						            <div class="toggle-switch toggle-switch-success">
							            <label>
								            <input id="chkState" runat="server"  type="checkbox" checked>
								            <div class="toggle-switch-inner"></div>
								            <div class="toggle-switch-switch"><i class="fa fa-check"></i></div>
							            </label>
						            </div>
                                  </div>
                            </div>

                            <div class ="form-group">
                                <label  class="col-sm-2 control-label">Repetir Contraseña</label>
						        <div class="col-sm-4">
							        <input type="text" id="txtRepeatPassword" runat="server"   class="form-control" placeholder="Repita la Contraseña" data-toggle="tooltip" data-placement="bottom" title="Ingrese nuevamente la contraseña">
						        </div>
                                <label  class="col-sm-2 control-label">Rol</label>
						        <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlRole" runat="server" DataSourceID="ddlrolesrc" DataTextField="name" DataValueField="id"></asp:DropDownList>
						            <asp:SqlDataSource ID="ddlrolesrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [role]"></asp:SqlDataSource>
						        </div>
                            </div>

                          <div class="clearfix"></div>
					    <div class="form-group">
						    <div class="col-sm-2">
                                <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click"  />
						    </div>
                            <div class="col-sm-2">
                                <asp:Button ID="UpdateData" runat="server" Text="Actualizar" class="btn btn-primary btn-label-left"  Enabled="False" OnClick="UpdateData_Click" />
						    </div>
                             <div class="col-sm-2" id="permissions" runat="server">     
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
                        <label  class="control-label">Mostrar Usuarios Activos Y no Activos</label>
						 <div class="toggle-switch toggle-switch-success">
							        <label>
                                        <asp:CheckBox ID="showActive" runat="server"  OnCheckedChanged="showActive_CheckedChanged" AutoPostBack="true" checked/>								         
								        <div class="toggle-switch-inner"></div>
								        <div class="toggle-switch-switch"><i class="fa fa-check"></i></div>
							        </label>
                             </div>
                      <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Opciones</th>
                                    <th>Nombre de usuario </th>
                                    <th>Rol</th>							       
							        <th>Estado (activo/inactivo)</th>
						        </tr>
					        </thead>
					        <tbody id="list_Users" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

