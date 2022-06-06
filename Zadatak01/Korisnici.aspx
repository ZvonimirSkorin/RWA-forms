<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminPage.Master" CodeBehind="Korisnici.aspx.cs" Inherits="Zadatak01.Korisnici" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <asp:Panel runat="server" ID="pnlApartments">
        <div class="container p-4">
            <div class="form-group">
                <fieldset class="p-4">
                    <legend>Korisnici</legend>


                    <asp:Repeater runat="server" ID="Repeater1">
                        <HeaderTemplate>
                            <table id="myTable" class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">UserName</th>
                                        <th scope="col">Email</th>
                                        <th scope="col">Address</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%# Eval("Username") %></th>
                                <th><%# Eval("Email") %></th>
                                <td><%# Eval("Address") %></td>
                               
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </table>
                        </FooterTemplate>

                    </asp:Repeater>

                </fieldset>
            </div>
        </div>
    </asp:Panel>
 
</asp:Content>

