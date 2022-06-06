<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminPage.Master" CodeBehind="Apartman.aspx.cs" Inherits="Zadatak01.Apartman" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Panel runat="server">

          <asp:Repeater ID="RepeaterImages" runat="server">
              <ItemTemplate>
                  <asp:TextBox runat="server" Text='<%#Eval("Path") %>'></asp:TextBox>
              </ItemTemplate>
</asp:Repeater> 
        <div style="margin:2rem auto; max-width:80vw; justify-content:center;" >
        <asp:Repeater  ID="RepeaterTags" runat="server">
              <ItemTemplate>
                  <span class="tagWrapper">
                  <asp:Label ClientIDMode="Static" style="cursor:pointer; width:auto; padding:0.3rem 0.5rem; border-radius:0.5rem; margin:0.3rem; box-sizing:border-box; background-color:blue; color:white;"
                      runat="server" Text='<%#Eval("TagName") %>'></asp:Label>
                  </span>
              </ItemTemplate>
</asp:Repeater>
           
            <asp:Button id="BtnAdd"
           Text="Dodaj tag"
           OnClick="addTag" 
           runat="server"/>
        </div>
        <div style="display:grid; grid-template-columns:1fr 1fr; max-width:900px; margin:0 auto; grid-gap:1rem;">

  <asp:Repeater ID="Repeater" runat="server">
        <ItemTemplate> 
                <label>Adresa</label>
            
            <asp:TextBox Enabled="false" ID="Address" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                       
                <label>Udaljenost od mora</label>
            <asp:TextBox Enabled="false" ID="BeachDistance" runat="server" Text='<%#Eval("BeachDistance") %>'></asp:TextBox>
            <label>Name</label>
            <asp:TextBox Enabled="false" ID="Name" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                <label>Cijena</label>
            <asp:TextBox Enabled="false" ID="Price" runat="server" Text='<%#Eval("Price") %>'></asp:TextBox>
                <label>Maksimalno odraslih</label>
            <asp:TextBox Enabled="false" ID="NumberOfAdults" runat="server" Text='<%#Eval("MaxAdults") %>'></asp:TextBox>
            <label>Maksimalno odraslih</label>
            <asp:TextBox Enabled="false" ID="NumberOfChildren" runat="server" Text='<%#Eval("MaxChildren") %>'></asp:TextBox>
                <label>Broj soba</label>
            <asp:TextBox Enabled="false" ID="NumberOfRooms" runat="server" Text='<%#Eval("TotalRooms") %>'></asp:TextBox>
                <label>Status</label>
            <asp:TextBox Enabled="false"  ID="Status" runat="server" Text='<%#Eval("StatusId") %>'></asp:TextBox>


    </tr>
        </ItemTemplate>
    </asp:Repeater>
        </div>

    </asp:Panel>
        <div style="display:flex; flex-direction:row; grid-gap:1rem; justify-content:center; align-items:center; margin-top:2rem;">
           <div id="btnEdit">Uredi podatke</div>
    <asp:Button id="btnSave"
           Text="Spremi"
        style="visibility:hidden;"
           OnClick="Update_Apartment" 
           runat="server"/>

    <div style="margin-left:1rem;">
        <div style="margin:1rem; color:white; border-radius:0.3rem; box-shadow:0px 0px 5px black;
display:inline-block; padding:0.3rem; cursor:pointer; background-color:red;
" id="add_tag">Izbriši apartman</div>
        </div>
    </div>

    <div id="modal" style="display:none;">
        <h4 id="tagName" ></h4>
        <div style="display:flex; gap:1rem; justify-content:center;">
            <div id="closeModal">Cancel</div>
                    <asp:HiddenField ID ="HiddenField1" runat ="server" />
            <asp:Button ID="delete" OnClick="deleteTag" Text="Delete" runat="server" />

        </div>
    </div>
     <div id="addTag" style="z-index:100; width:100vw; height:100vh; position:fixed;top:0;left:0; display:none;justify-content:center;align-items:center; background-color:black;">
            <div style=" height:400px; width:400px;background-color:white;border-radius:1rem;
 box-sizing:border-box; padding:1rem; display:flex; flex-direction:column;
 justify-content:center; align-items:center; gap:1rem;
 ">
                <h4>Jeste li sigurni da želite izbrisati apartman?</h4>
                <div style="display:flex; justify-content:center;">
                    <div style="margin:1rem; color:white; border-radius:0.3rem; box-shadow:0px 0px 5px black;
display:inline-block; padding:0.3rem; cursor:pointer; background-color:blue;
" id="cancel_delete">Odustani</div>
        </div>
        <asp:Button id="BtnDelete"
            style="background-color:red; color:white;"
           Text="Izbriši apartman"
           OnClick="deleteApartment" 
           runat="server"/>
                </div>
                
            </div>
        </div>
    <style>
        #btnEdit, #btnSave, #closeModal{
            padding:0.4rem 1.4rem;
            display:flex;
            justify-content:center;
            align-items:center;
            border-radius:0.5rem;
            border-width:1px;
            border-color:black;
            border-style:solid;
            cursor:pointer;
            display:inline-block;
        }

        #modal{
            position:fixed;
            top:50%;
            left:50%;
            transform:translate(-50%,-50%);
            z-index:100;
            background-color:white;
            box-shadow:0px 0px 10px black;
            border-radius:1rem;
            max-width:500px;
            flex-direction:column;
            padding:3rem;
        }
    </style>
<script>
    let isEditable = true;
    const elements = Array.from(document.getElementsByTagName("input"));
    const btnSave = document.getElementById("Content_btnSave");
    document.getElementById("btnEdit").addEventListener("click", e => {
        isEditable = !isEditable;
        btnSave.style.visibility = !isEditable?"Visible":"Hidden";
        console.log(elements, typeof elements);
        elements.map(element => {
            console.log(element);
            element.disabled = isEditable;
        })
    })
    const tags = document.getElementsByClassName("tagWrapper");
    for (let i = 0; i < tags.length; i++) {
        tags[i].addEventListener('click', (e) => {
            document.getElementsByTagName("h4")[0].innerText = `Jeste li sigurni da želite izbrisati tag ${e.target.innerText}?`
            document.getElementById("Content_HiddenField1").value = e.target.innerText;
            document.getElementById("modal").style.display = 'flex';
        })
    }
    document.getElementById("closeModal").addEventListener('click', () => {
        document.getElementById("modal").style.display = 'none';
    })
    
    var display = true;
    document.getElementById('add_tag').addEventListener('click', () => {
        display = !display;
        document.getElementById('addTag').style.display = display ? 'none' : 'flex';
    })
    document.getElementById('addTag').addEventListener('click', () => {
        display = !display;
        document.getElementById('addTag').style.display = display ? 'none' : 'flex';
    })
    document.getElementById('cancel_delete').addEventListener('click', () => {
        document.getElementById('addTag').click;
    })
    
</script>
</asp:Content>
