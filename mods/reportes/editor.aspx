<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="editor.aspx.cs" Inherits="mods_reportes_editor" ValidateRequest = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
        <form id="Form1" runat="server">
        <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">REPORTE </a></li>
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
				    <h4 class="page-header">Informacion de REPORTE DE AFILIACION</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                              <label  class="col-sm-2 control-label">Titulo</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtTitulo" runat="server" class="form-control" data-placement="bottom" >
						    </div>
						    <label  class="col-sm-2 control-label">Resolucion</label>
						    <div class="col-sm-4">
							    <input type="text" id="txresolucion" runat="server" class="form-control"  data-placement="bottom" >
						    </div>
                             <label  class="col-sm-2 control-label">footer</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtfooter" runat="server" class="form-control" data-placement="bottom" >
						    </div>                           
					    </div>
                         <div class="clearfix"></div>
					        <div class="form-group">
						        <div class="col-sm-2">
                                    <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						        </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnCargar" runat="server" Text="Cargar Información" class="btn btn-primary btn-label-left" OnClick="btnCargar_Click" />
						        </div>
					        </div>
                   </div>
                </div>
                </div>
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
				    <h4 class="page-header">Informacion de CERTIFICADO</h4>
                    <div id="Div1" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                              <label  class="col-sm-2 control-label">Titulo</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtCertTitulo" runat="server" class="form-control" data-placement="bottom" >
						    </div>
						    <label  class="col-sm-2 control-label">Cuerpo</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtCerCuerpo" runat="server" class="form-control"  data-placement="bottom" >
						    </div>  
                             <label  class="col-sm-2 control-label">Att:</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtAtt" runat="server" class="form-control"  data-placement="bottom" >
						    </div>                                                   
					    </div>
                         <div class="clearfix"></div>
					        <div class="form-group">
						        <div class="col-sm-2">
                                    <asp:Button ID="btnCertif" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="btnCertif_Click" />
						        </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btngarCertif" runat="server" Text="Cargar Información" class="btn btn-primary btn-label-left" OnClick="btngarCertif_Click" />
						        </div>
					        </div>
                   </div>
                </div>
                </div>
            </div>
        </div>
  </form>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

