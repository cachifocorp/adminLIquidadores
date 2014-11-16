<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="publications.aspx.cs" Inherits="mods_publications_publications" ValidateRequest="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <form id="form1" runat="server">
    <div class="row">
	<div id="breadcrumb" class="col-md-12">
		<ol class="breadcrumb">
			<li><a href="../Default.aspx">Dashboard</a></li>
			<li><a href="#">Publication</a></li>
			<li><a href="#">Generales</a></li>
		</ol>
	</div>
</div>
<div class="row">
	<div class="col-xs-12 col-sm-12">
		<div class="box">
			<div class="box-header">
				<div class="box-name">
					<i class="fa fa-book"></i>
					<span>Entradas</span>
				</div>
				<div class="box-icons   ">
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
				<h4 class="page-header">Creacion de Publicación</h4>
                <div id="Messages" runat="server"></div>
				<div class="form-horizontal " role="form" >
                     <div class="form-group">
						<label class="col-sm-2 control-label">Categoria</label>
						<div class="col-sm-4">
                            <asp:DropDownList class="populate placeholder" ID="tags" runat="server" DataSourceID="tagsDS" DataTextField="name" DataValueField="id">
                                <asp:ListItem Value="0">Noticias</asp:ListItem>
                                <asp:ListItem Value="1">About</asp:ListItem>
                            </asp:DropDownList>
						    <asp:SqlDataSource ID="tagsDS" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [tag]"></asp:SqlDataSource>
						</div>

                         <label class="col-sm-2 control-label">Idioma</label>
						<div class="col-sm-4">
                            <asp:DropDownList ID="ddlLanguage" runat="server" DataSourceID="sourceLanguage" DataTextField="name" DataValueField="id"></asp:DropDownList>
                            <asp:SqlDataSource ID="sourceLanguage" runat="server" ConnectionString="<%$ ConnectionStrings:AMVConnectionString %>" SelectCommand="SELECT [id], [name] FROM [language]"></asp:SqlDataSource>
                         </div>

					</div>
                    <div class="form-group">
						<label class="col-sm-2 control-label">Titulo</label>
						<div class="col-sm-4">
							<input id="title" runat="server" type="text" class="form-control" placeholder="Titulo" data-toggle="tooltip" data-placement="bottom" title="Titulo para la entrada">
						</div>
					</div>
                    <div class="form-group">
						<label class="col-sm-2 control-label" for="form-styles">Descripción</label>
						<div class="col-sm-10">
								<textarea class="form-control" rows="5" id="wysiwig_full" runat="server"></textarea>
						</div>
					</div>
                     <div class="form-group">
                             <label class="col-sm-2 control-label" for="form-styles">¿Activo?</label>
                             <div class="col-sm-1">
						        <div class="toggle-switch toggle-switch-success">
							        <label>
								        <input id="chkstate" runat="server"  type="checkbox" checked>
								        <div class="toggle-switch-inner"></div>
								        <div class="toggle-switch-switch"><i class="fa fa-check"></i></div>
							        </label>
						        </div>
					        </div> 
                             </div>
                    <div class="form-group">
						<label class="col-sm-2 control-label" for="form-styles">Imagen de la publicación</label>
						<div class="col-sm-10">
							<asp:FileUpload ID="FilePublication" runat="server" />
						</div>
					</div>
                    <input type="hidden" runat="server"  id="pubId"/>
                    <div class="clearfix"></div>
					<div class="form-group">						 
						<div class="col-sm-2">
                            <asp:Button ID="btnSaveInfo" runat="server" Text="Guardar Entrada" class="btn btn-primary btn-label-left" OnClick="Button1_Click" />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar Entrada" class="btn btn-primary btn-label-left" Enabled="False" OnClick="btnUpdate_Click"  />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="otherLanguage" runat="server" Text="Guardar Version en otro Idioma" class="btn btn-primary btn-label-left" Enabled="False" OnClick="otherLanguage_Click"  />
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
					<i class="fa fa-linux"></i>
					<span>Lista de Publicaciones</span>
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
			<div class="box-content no-padding table-responsive">
                  <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Opciones</th>
							        <th>titulo</th>
							        <th>Descripcion</th>
							        <th>Idioma</th>
						        </tr>
					        </thead>
					        <tbody id="List_Publ" runat="server">
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
    <script type="text/javascript">
        // Run Select2 plugin on elements
        function DemoSelect2() {
            $('#tags').select2( );
            $('#s2_country').select2();
        }      
        
        $(document).load(function () {
            TinyMCEStart('#wysiwig_full', 'extreme');
            // Initialize datepicker           
            $('.form-control').tooltip();
            LoadSelect2Script(DemoSelect2);
            
            WinMove();
        });
</script>

</asp:Content>

