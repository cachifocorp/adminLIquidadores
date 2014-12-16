<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="permissionsUser.aspx.cs" Inherits="mods_manageUsers_permissionsUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form runat="server">
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
				    <h4 class="page-header">Asignación de permisos</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                                  <label  class="col-sm-2 control-label">Modulo</label>
						        <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlModules" runat="server" DataSourceID="moduleSrc" DataTextField="name" DataValueField="id" AutoPostBack="true"></asp:DropDownList>
						            <asp:SqlDataSource ID="moduleSrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [name], [id] FROM [module]"></asp:SqlDataSource>
						        </div>						                                 
					    </div>
                        <div class="form-group">
                            <label  class="col-sm-2 control-label">Accion Modulo </label>
						        <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlItemModule" runat="server" DataSourceID="itemModuleSrc" DataTextField="name" DataValueField="id">
                                    </asp:DropDownList>
						            <asp:SqlDataSource ID="itemModuleSrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [itemsModule] WHERE ([id_module] = @id_module)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlModules" DefaultValue="1" Name="id_module" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
						        </div>   
                        </div>
                        <div class="clearfix"></div>
					    <div class="form-group">
						    <div class="col-sm-2">
                                <asp:Button ID="btnAssigPermission" runat="server" Text="Asignar Permiso" class="btn btn-primary btn-label-left" OnClick="btnAssigPermission_Click"  />
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
					        <span>Permisos de ingreso a modulos asignados al usuario</span>
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
                                    <th>Acciones</th>
                                    <th>Modulo</th>
                                    <th>Accion Modulo </th>
							        <th>Fecha Registro</th>
							        <th>URL</th>
						        </tr>
					        </thead>
					        <tbody id="list_permissions" runat="server">
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

