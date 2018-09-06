<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="LoaiPhim.aspx.cs" Inherits="HTQuanLyFilm.TEST.LoaiPhim" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table th {
            background-color: #DBF7F7;
            color: #333;
            font-weight: bold;
        }

        table th, table td {
            padding: 5px;
            border-color: #ccc;
        }

        .auto-style1 {
            width: 271px;
        }

        .popuHeader {
            padding: 7px;
            background-color: #000000;
            color: #ffffff;
            font-size: 100%;
            font-weight: bold;
        }

        .table-border {
            width: 100%;
        }

        .table-border td {
                border: 1px dashed #dddddd;
                padding: 4px;
            }

        .navbar {
            background-color: #660066;
            position: fixed;
            width: 99%;
            border: none;
            color: white;
            margin-top:20px;
        }

        .Grid {
            margin-top:45px;
        }
      
        .DivGridview {
            border: none;
            position: fixed;
            margin-top:10px;
        }

        .DivGridview td {
                margin-top: 0;
                padding: 0;
                vertical-align: middle;
            }

        .DivGridview tr {
                color: White;
                background-color: #df5015;
                height: 30px;
                text-align: center;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="navbar">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
             <table>
                    <tr>
                        <td >&nbsp;&nbsp;
                            <asp:Button ID="btnthemmoi" runat="server" Text="Add" OnClick="btnthemmoi_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btndelete" runat="server" Text="Delete" OnClientClick="return confirm('Do you want to delete records?');" OnClick="btndelete_Click" />
                        </td>
                    </tr>
                </table>
        </ContentTemplate>
    </asp:UpdatePanel>
        </div>
    <br />
    <br />
    <br />
      <table class="DivGridview">
        <tr>
            <td style="width: 40px;">Check</td>
            <td style="width: 40px;">ID</td>
            <td style="width: 120px;">Loại Phim</td>
            <td style="width: 120px;">Bộ Phận</td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               <asp:HiddenField ID="hfCount" runat="server" Value="0" />
              <asp:ObjectDataSource ID="dsloaiphim" runat="server" SelectMethod="GetLoaiPhim" TypeName="ActionService.Service"></asp:ObjectDataSource>
              <asp:GridView ID="GridView1" runat="server" ShowHeader="False" CssClass="Grid" DataKeyNames="idloaiphim" AutoGenerateColumns="False" DataSourceID="dsloaiphim">
        <Columns>
             <asp:TemplateField HeaderText="Check">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:TemplateField>
            <asp:BoundField DataField="idloaiphim" HeaderText="idloaiphim" SortExpression="idloaiphim" >
             <ItemStyle Width="33px" />
             </asp:BoundField>
             <asp:TemplateField HeaderText="loaiphim" SortExpression="loaiphim">
                 <ItemTemplate>
                     <asp:LinkButton ID="lkEdit" runat="server" OnClick="lkEdit_Click"><%# Eval("loaiphim") %></asp:LinkButton>
                 </ItemTemplate>
                 <ItemStyle Width="110px" />
             </asp:TemplateField>
             <asp:BoundField DataField="bophan" HeaderText="bophan" SortExpression="idloaiphim" >
             <ItemStyle Width="110px" />
             </asp:BoundField>
        </Columns>
    </asp:GridView>
                <asp:Panel ID="Panel1" runat="server">
                 <div id="pnlAddPopup" runat="server" style="width: 500px; background-color: #ffffff;">
                <div id="popupheader" class="popuHeader">
                    <asp:Label ID="lblHeader" runat="server" />
                    <span style="float: right">
                        <img id="imgClose" src="/Images/btn-close.png" alt="close" title="Close" />
                    </span>
                </div>
                <asp:HiddenField  ID="hfIdloaiphim" runat="server" Value="0"/>
                <div>
                    <table border="0" class="table-border">
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Loại Phim"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtloaiphim" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Bộ Phận"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="dropbophan" runat="server">
                                    <asp:ListItem Text="[--Bộ Phận--]" Value=""></asp:ListItem>
                                    <asp:ListItem>MA4-2F</asp:ListItem>
                                    <asp:ListItem>MA4-3F</asp:ListItem>
                                    <asp:ListItem>MA3-1F</asp:ListItem>
                                    <asp:ListItem>MA3-2F</asp:ListItem>
                                    <asp:ListItem>LƯỚI</asp:ListItem>
                                    <asp:ListItem>PT</asp:ListItem>
                                    <asp:ListItem>PE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style1">&nbsp;
                                <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:$find('Behavior').hide();return false;" />
                                <asp:Label ID="lbmassge" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <ajaxToolkit:ModalPopupExtender ID="popup" runat="server"
                    TargetControlID="hfIdloaiphim"
                    PopupControlID="Panel1"
                    BehaviorID ="Behavior"
                    DropShadow="true"
                    CancelControlID="imgClose"
                    PopupDragHandleControlID="popupheader">
                </ajaxToolkit:ModalPopupExtender>
            </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>
