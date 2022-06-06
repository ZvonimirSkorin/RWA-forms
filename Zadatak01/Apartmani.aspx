<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminPage.Master" CodeBehind="Apartmani.aspx.cs" Inherits="Zadatak01.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
    <a class='nav-link' href="/DodajApartman" runat="server" meta:resourcekey="addApartment">Dodaj apartman</a>

    </div>
    <div style="display:flex;">

   <div class="flex"  style="display:flex;">
       <strong style="width:100px; display:inline-block; margin-left:2rem;">Status</strong>
    <asp:DropDownList runat="server" AutoPostBack="True" id="selectStatus">

                       

</asp:DropDownList>
   </div>
    <div style="display:flex; width:100%;">
        
             <div class="flex ml-auto" style="margin-left:auto; margin-right:2rem;">

   
        <div class="flex">

       <strong style="width:100px; display:inline-block;">City</strong>
            <asp:DropDownList id="selectCty"
                    AutoPostBack="True"
                    runat="server">
                <asp:ListItem Value=null  Text="Svi"/>
            </asp:DropDownList>

       
        </div>
                 

             </div>
   </div>
    </div>
   
  
      <asp:Panel runat="server" ID="pnlApartments">
        <div class="container p-4">
            <div class="form-group">
                <fieldset class="p-4">
                    <legend>List of Apartments</legend>


                    <asp:Repeater runat="server" ID="Repeater1">
                        <HeaderTemplate>
                            <table id="myTable" class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Name</th>
                                        <th scope="col">City</th>
                                        <th scope="col">Address</th>
                                        <th scope="col">Adults</th>
                                        <th scope="col">Children</th>
                                        <th scope="col">Rooms</th>
                                        <th scope="col">Beach distance</th>
                                        <th scope="col">Price</th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%# Eval("Id") %></th>
                                <th><%# Eval("Name") %></th>
                                <td><%# Eval("City") %></td>
                                <td><%# Eval("Address") %></td>
                                <td><%# Eval("MaxAdults") %></td>
                                <td><%# Eval("MaxChildren") %></td>
                                <td><%# Eval("TotalRooms") %></td>
                                <td><%# Eval("BeachDistance") %></td>
                                <td><%# $"{Eval("Price")}$" %></td>
                                <td>
            <a class='nav-link' href='<%# string.Concat("Apartman?id=", Eval("Id"))%>' runat="server" meta:resourcekey="aDashboard">Otvori</a>
                                </td>
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
     
   
   <script>
       $(document).ready(function () {
           $('#dtBasicExample').DataTable();
           $('.dataTables_length').addClass('bs-select');
       });
       
   </script>  

</asp:Content>
