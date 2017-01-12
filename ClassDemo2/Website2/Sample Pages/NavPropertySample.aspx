<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NavPropertySample.aspx.cs" Inherits="Sample_Pages_NavPropertySample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:GridView ID="AlbumArtistView" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="AlbumArtistODS" runat="server"
         OldValuesParameterFormatString="original_{0}" SelectMethod="ListAlbumsbyArtist" 
        TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
</asp:Content>


