<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SimpleParameterQuery.aspx.cs" Inherits="Sample_Pages_SimpleParameterQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class ="row">
    <asp:Label ID="Label1" runat="server" Text="Enter Artist Name"></asp:Label>&nbsp;&nbsp;
<asp:TextBox ID="ArtistName" runat="server"></asp:TextBox>&nbsp;&nbsp;
    <asp:LinkButton ID="GetArtistAlbums" runat="server">Get Artist Albums</asp:LinkButton>&nbsp;&nbsp;
        </div>
    <br />
    <div class ="row">
    <asp:GridView ID="ArtisrNameGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ArtistNameODS" Width="377px">
        <Columns>
            <asp:BoundField DataField="AlbumId" HeaderText="AlbumId" SortExpression="AlbumId">
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="ArtistId" HeaderText="ArtistId" SortExpression="ArtistId" />
            <asp:BoundField DataField="ReleaseYear" HeaderText="ReleaseYear" SortExpression="ReleaseYear" />
            <asp:BoundField DataField="ReleaseLabel" HeaderText="ReleaseLabel" SortExpression="ReleaseLabel" />
        </Columns>
        </asp:GridView>
        </div>
    <div class ="row">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ArtistNameODS">
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ArtistIdLabel" runat="server" Text='<%# Eval("ArtistId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                        </td>
                        <%--<td>
                            <asp:Label ID="ArtistLabel" runat="server" Text='<%# Eval("Artist") %>' />
                        </td>--%>
                    </tr>
                </AlternatingItemTemplate>
            <%--    <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="AlbumIdTextBox" runat="server" Text='<%# Bind("AlbumId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ArtistIdTextBox" runat="server" Text='<%# Bind("ArtistId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ReleaseYearTextBox" runat="server" Text='<%# Bind("ReleaseYear") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ReleaseLabelTextBox" runat="server" Text='<%# Bind("ReleaseLabel") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ArtistTextBox" runat="server" Text='<%# Bind("Artist") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>--%>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No records as no search has been prformed</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="AlbumIdTextBox" runat="server" Text='<%# Bind("AlbumId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ArtistIdTextBox" runat="server" Text='<%# Bind("ArtistId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ReleaseYearTextBox" runat="server" Text='<%# Bind("ReleaseYear") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ReleaseLabelTextBox" runat="server" Text='<%# Bind("ReleaseLabel") %>' />
                        </td>
                        <%--<td>
                            <asp:TextBox ID="ArtistTextBox" runat="server" Text='<%# Bind("Artist") %>' />
                        </td>--%>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ArtistIdLabel" runat="server" Text='<%# Eval("ArtistId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                        </td>
                       
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server">Album</th>
                                        <th runat="server">Title</th>
                                        <th runat="server">Artist</th>
                                        <th runat="server">Released</th>
                                        <th runat="server">Label</th>
                                 <%--       <th runat="server">Artist</th>--%><%--This is a navigation property--%>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                
            </asp:ListView>
    </div>

    <asp:ObjectDataSource ID="ArtistNameODS" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Albums_GetForArtistbyName" TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ArtistName" Name="name" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
