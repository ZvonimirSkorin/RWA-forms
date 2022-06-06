<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminPage.Master" CodeBehind="DodajApartman.aspx.cs" Inherits="Zadatak01.DodajApartman" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
    <div style=" border-radius:1rem; margin:0 auto; display:flex; flex-direction:column; align-items:center;">
    <div class="col-md-4 mb-3">
      <label for="validationDefault01">Ime apartmana</label>
                <asp:TextBox class="form-control" ID="Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator style="color:red;" runat="server" id="reqName" controltovalidate="Name" errormessage="Unesite ime apartmana!" />
    </div>
    <div class="col-md-4 mb-3">
      <label for="validationDefault02">Ime apartmana na engleskom</label>
                        <asp:TextBox class="form-control" ID="NameEng" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator2" controltovalidate="Name" errormessage="Unesite englesko ime apartmana!" />
    </div>
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Grad</label>
                        <asp:TextBox class="form-control" ID="City" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator3" controltovalidate="Name" errormessage="Unesite grad!" />
    </div> 
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Adresa</label>
                        <asp:TextBox class="form-control" ID="Address" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator4" controltovalidate="Name" errormessage="Unesite adresu!" />
    </div>
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Udaljenost od mora</label>
                                <asp:TextBox class="form-control" type="number" ID="BeachDistance" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator5" controltovalidate="Name" errormessage="Unesite udaljenost od mora!" />
    </div> 
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Broj mjesta za odrasle</label>
        <asp:TextBox class="form-control" type="number" ID="Adults" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator1" controltovalidate="Name" errormessage="Unesite broj mjesta za odrasle!" />

    </div>
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Broj mjesta za djecu</label>
            <asp:TextBox class="form-control" type="number" ID="Children" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator6" controltovalidate="Name" errormessage="Unesite broj mjesta za djecu!" />
    </div>
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Cijena</label>
                    <asp:TextBox class="form-control" type="number" ID="Price" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator7" controltovalidate="Name" errormessage="Unesite cijenu!" />
    </div> 
            <div class="col-md-4 mb-3">
      <label for="validationDefault02">Broj soba</label>
        <asp:TextBox class="form-control" type="number" ID="RoomsCount" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator style="color:red;" runat="server" id="RequiredFieldValidator8" controltovalidate="Name" errormessage="Unesite broj soba!" />
    </div>
    <asp:Button id="BtnAdd"
           Text="Dodaj apartman"
           OnClick="addApartment" 
           runat="server"/>
 
</div>
</asp:Content>