<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="addCategory.aspx.cs" Inherits="mods_publications_projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Publicaciones</a></li>
			    <li><a href="#">Categorias</a></li>
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
				    <h4 class="page-header">Categorias de proyectos</h4>
                    <div id="Messages" runat="server">
                        <asp:FormView ID="FormView1" runat="server" DataKeyNames="id" DataSourceID="categoria">
                            <EditItemTemplate>
                                id:
                                <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                                <br />
                                name:
                                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                                <br />
                                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                Nombre:
                                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                                <br />
                                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Guardar" />
                                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                id:
                                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                                <br />
                                Nombre:
                                <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("name") %>' />
                                <br />
                                &nbsp;&nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Crear Nueva Categoria" />
                            </ItemTemplate>
                        </asp:FormView>
                    </div>
				    <div class="form-horizontal" role="form">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="categoria">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                <asp:BoundField DataField="name" HeaderText="Nombre" SortExpression="name" />
                            </Columns>
                        </asp:GridView>
					    <asp:SqlDataSource ID="categoria" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" DeleteCommand="DELETE FROM [pro_category] WHERE [id] = @id" InsertCommand="INSERT INTO [pro_category] ([name]) VALUES (@name)" SelectCommand="SELECT [id], [name] FROM [pro_category]" UpdateCommand="UPDATE [pro_category] SET [name] = @name WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="name" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="name" Type="String" />
                                <asp:Parameter Name="id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
					    <div class="clearfix"></div>					    
                    </div>
                </div>
             </div>
        </div>
    </div>
</form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

