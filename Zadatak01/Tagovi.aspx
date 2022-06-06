<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminPage.Master" CodeBehind="Tagovi.aspx.cs" Inherits="Zadatak01.Tagovi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>

        <div style="margin:1rem; color:white; border-radius:0.3rem; box-shadow:0px 0px 5px black;
display:inline-block; padding:0.3rem; cursor:pointer; background-color:blue;
" id="add_tag">Dodaj tag</div>
        <div id="addTag" style="z-index:100; width:100vw; height:100vh; position:fixed;top:0;left:0; display:none;justify-content:center;align-items:center; background-color:black;">
            <div style=" height:400px; width:400px;background-color:white;border-radius:1rem;
 box-sizing:border-box; padding:1rem; display:flex; flex-direction:column;
 justify-content:center; align-items:center; gap:1rem;
 ">
                <label>Ime taga</label>
                <asp:TextBox Width="150px" runat="server" ID="newTagName" Text="" />
 <asp:RequiredFieldValidator style="color:red;" runat="server" id="reqName" controltovalidate="newTagName" errormessage="Unesite ime taga!" />
                <label>Tag type</label>
                <asp:DropDownList Width="150px" runat="server" AutoPostBack="False" id="selectTagType">
</asp:DropDownList>
                <asp:Button OnClick="Add_tag" runat="server" Text="Add tag" />
            </div>
        </div>
        <div>

         <asp:Panel runat="server" ID="pnlApartments">
        <div class="container p-4">
            <div class="form-group">
                <fieldset class="p-4">
                    <legend>List of Apartments</legend>


                    <asp:Repeater runat="server" ID="Tags">
                        <HeaderTemplate>
                            <table id="myTable" class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">Ime</th>
                                        <th scope="col">Korišteno puta</th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%# Eval("TagName") %></th>
                                <th><%# Eval("Count") %></th>
                                <td>
                                     <asp:Button ID="btnDelete"
                      CommandArgument='<%# Eval("TagName") %>'
                      meta:resourcekey="btnSend"  runat="server" Text="Izbriši" OnCommand="btnDelete_Command" commandname="Update" Visible='<%# Eval("Count").ToString() == "0"  %>' />
                
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
        </div>
 
         
    </div>
<script>
    var display=true;
    document.getElementById('add_tag').addEventListener('click', () => {
        display = !display;
        document.getElementById('addTag').style.display=display?'none':'flex';
    })
    document.getElementById('addTag').addEventListener('click', () => {
        display = !display;
        document.getElementById('addTag').style.display = display ? 'none' : 'flex';
    })

</script>
</asp:Content>