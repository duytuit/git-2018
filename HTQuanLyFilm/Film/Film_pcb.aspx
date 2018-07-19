<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Film_pcb.aspx.cs" Inherits="HTQuanLyFilm.Film.Film_pcb" %>
<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>WellCome To Film PCB</p>
   <asp:UpdatePanel ID="panel1" runat="server">
       <ContentTemplate>
           <br />
           <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCoDinhTyLePhuSon" TypeName="ActionService.Service"></asp:ObjectDataSource>
           <br />
           <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" EnableTheming="True" Theme="Aqua">
               <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" />
               <Columns>
                   <dx:GridViewDataTextColumn FieldName="idphuson" VisibleIndex="1">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tensanpham" VisibleIndex="2">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="loaiphim" VisibleIndex="3">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tylexmin" VisibleIndex="4">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tylexmax" VisibleIndex="5">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tyleymin" VisibleIndex="6">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tyleymax" VisibleIndex="7">
                   </dx:GridViewDataTextColumn>
               </Columns>
           </dx:ASPxGridView>
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
