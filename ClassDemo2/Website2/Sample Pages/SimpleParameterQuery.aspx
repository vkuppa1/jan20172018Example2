<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SimpleParameterQuery.aspx.cs" Inherits="Sample_Pages_SimpleParameterQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class ="row">
    <asp:Label ID="Label1" runat="server" Text="Enter Artist Name"></asp:Label>&nbsp;&nbsp;
<asp:TextBox ID="ArtistName" runat="server"></asp:TextBox>&nbsp;&nbsp;
    <asp:LinkButton ID="GetArtistAlbums" runat="server">Get Artist Albums</asp:LinkButton>&nbsp;&nbsp;
        </div>
    <br />
    <div class ="row">
    <asp:GridView ID="ArtisrNameGV" runat="server"></asp:GridView>
        </div>
    <asp:ObjectDataSource ID="ArtistNameODS" runat="server"></asp:ObjectDataSource>
</asp:Content>
