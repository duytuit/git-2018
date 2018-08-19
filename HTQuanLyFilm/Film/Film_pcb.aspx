<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Film_pcb.aspx.cs" Inherits="HTQuanLyFilm.Film.Film_pcb" %>
<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>WellCome To Film PCB</p>
   <asp:UpdatePanel ID="panel1" runat="server">
       <ContentTemplate>
           <br />
           <br />
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
