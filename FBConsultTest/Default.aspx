<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FBConsultTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="app">
        <input type="text" name="name" v-model="name" />
        {{name}}
    </div>
    <script src="Scripts/Vue/Contact.js"></script>
</asp:Content>
