<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="emailConfiguration.aspx.cs" Inherits="mods_general_emailConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="Form1" runat="server">
         <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Clientes</a></li>
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
				    <h4 class="page-header">Configuracion  de correos Pagina AMV</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
						    <label  class="col-sm-2 control-label">Email</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtName" runat="server" class="form-control" placeholder="Ingresa un correo Electronico" data-toggle="tooltip" data-placement="bottom" title="Nombre del Cliente">
						    </div>
					    </div>    
                         <div class="form-group">
						    <label  class="col-sm-2 control-label">Tipo</label>
						    <div class="col-sm-4">
                                <asp:DropDownList ID="ddltipo" runat="server">
                                    <asp:ListItem Value="1">Contacto</asp:ListItem>
                                    <asp:ListItem Value="2">Proveedor</asp:ListItem>
                                    <asp:ListItem Value="3">Trabajo</asp:ListItem>
                                </asp:DropDownList>
						    </div>
					    </div>                       
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
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
					        <span>Lista de  correos</span>
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
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EmailsSource" CssClass="table">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Editar" HeaderText="Opciones" UpdateText="Actualizar" ControlStyle-CssClass="ui-button"></asp:CommandField>
                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email"></asp:BoundField>
                                <asp:BoundField DataField="type" HeaderText="Tipo" SortExpression="type"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource runat="server" ID="EmailsSource" ConnectionString='<%$ ConnectionStrings:AMVConnectionString %>' DeleteCommand="DELETE FROM [emailcontact] WHERE [id] = @id"  SelectCommand="SELECT [type], [email], [id] FROM [emailcontact]" UpdateCommand="UPDATE [emailcontact] SET [type] = @type, [email] = @email WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
                            </DeleteParameters>                          
                            <UpdateParameters>
                                <asp:Parameter Name="type" Type="Int32"></asp:Parameter>
                                <asp:Parameter Name="email" Type="String"></asp:Parameter>
                                <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
                            </UpdateParameters>
                        </asp:SqlDataSource>

                        <hr />
                    </div>
                    </div>
                </div>
            </div>

    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

