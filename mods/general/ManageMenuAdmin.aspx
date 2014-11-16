<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="ManageMenuAdmin.aspx.cs" Inherits="mods_general_ManageMenu" %>

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
					    <span>Configuracion del Menu (Admin <smal>Root</smal>)</span>
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
				    <h4 class="page-header">Menu (Max 3 niveles)</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label  class="col-sm-2 control-label">Nombre</label>
						        <div class="col-sm-6">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
						        </div>   
                        </div>
                        <div class="form-group">
                                  <label  class="col-sm-2 control-label">Padre</label>
						        <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlParent" runat="server" DataSourceID="parentSrc" DataTextField="name" DataValueField="id" AppendDataBoundItems="true">
                                         <asp:ListItem Value="0">&lt;Item Padre&gt;</asp:ListItem>
                                    </asp:DropDownList>
						            <asp:SqlDataSource ID="parentSrc" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [Menu] WHERE ([id_dependence] = @id_dependence)">
                                        <SelectParameters>
                                            <asp:SessionParameter DefaultValue="0" Name="id_dependence" SessionField="dependence" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
						        </div>						                                 
					    </div>
                        <div class="form-group">
                            <label  class="col-sm-2 control-label">Nombre</label>
						        <div class="col-sm-6">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
						        </div>   
                        </div>
                        <div class="form-group">
                            <label  class="col-sm-2 control-label">Url </label>
						        <div class="col-sm-6">
                                    <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
						        </div>   
                        </div>

                        <div class="clearfix"></div>
					    <div class="form-group">
						    <div class="col-sm-2">
                                <asp:Button ID="btnCreateMenu" runat="server" Text="Asignar Permiso" class="btn btn-primary btn-label-left" OnClick="btnCreateMenu_Click"   />
						    </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnUpdate" runat="server" Text="Asignar Permiso" class="btn btn-primary btn-label-left" Enabled="False" OnClick="btnUpdate_Click"    />
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
					        <span>Lista de Menus Creados</span>
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
                                    <th>Nombre Item</th>
                                    <th>URL</th>
						        </tr>
					        </thead>
					        <tbody id="List_menus" runat="server">
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

