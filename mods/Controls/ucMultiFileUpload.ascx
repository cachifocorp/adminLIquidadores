<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMultiFileUpload.ascx.cs" Inherits="MultiFileUpload" %>
<!--    2011 Marcelo Calderón - www.lengasoft.com
        Este código es de uso y distribución libre bajo los términos de GPLv2
        siempre que se conserve este texto. -->
<fieldset class="fUploadControl">
    <legend>
        <asp:Label ID="lblUploadFilesTitle" Text="Archivos a subir" runat="server"></asp:Label>
    </legend>
    <asp:Label ID="lblNote" Text="" CssClass="comment" runat="server" />
    <asp:Panel ID="pnlUpload" runat="server">
        <asp:FileUpload ID="upldFile_0" CssClass="fileInput" runat="server" />
    </asp:Panel>
    <asp:HyperLink ID="lnkAddFileUpload" CssClass="AddNewButton" NavigateUrl="javascript:addFileUploadCtrl();" Text="Agregar" runat="server" />
    <asp:Button ID="btnUpload" Text="Subir archivos" ToolTip="Upload files" runat="server" onclick="btnUpload_Click" />
    <asp:Label ID="lblInfo" Text="" CssClass="mssgOK" runat="server" />
</fieldset>
