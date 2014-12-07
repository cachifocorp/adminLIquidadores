<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="ChatEsperaUsuario.aspx.cs" Inherits="mods_chat_RegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        function onBackClick() {
            window.close();
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
    <form id="Form1" runat="server">
        <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Solicitar Chat</span>
				    </div>
				    
			    </div>
			    <div class="box-content">
				    <h4 class="page-header">Solicitud enviada a nuestros agentes </h4>
                    <br />
                    &nbsp;
                    <br />
                    <h4>Por favor Espere</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            
                            <asp:Timer ID="Timer1"  Interval="1000"  runat="server" OnTick="Timer1_Tick"></asp:Timer>
                             
                        </ContentTemplate>
                    </asp:UpdatePanel>


                        <img src="loadig.GIF" />
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Cancelar Solicitud" class="btn btn-primary btn-label-left btn-danger" OnClick="SaveData_Click1" />
						</div>
                       
					</div>
                       
                    </div>
                </div>
            </div>
         </div>
    </div>
     </form>
</asp:Content>

