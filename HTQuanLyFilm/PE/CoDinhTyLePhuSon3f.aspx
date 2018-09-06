<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="CoDinhTyLePhuSon3f.aspx.cs" Inherits="HTQuanLyFilm.PE.CoDinhTyLePhuSon3f" EnableEventValidation="false" %>

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
            margin-top: 4px;
            background-color: #660066;
            position: fixed;
            width: 99%;
            border: none;
            color: white;
        }

        .DivGridview {
            border: none;
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

        .DivGridview {
            margin-top: 30px;
            width: 99%;
            position: fixed;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="navbar">
        <table>
            <tr>
                <td>&nbsp;&nbsp;Từ Ngày:<asp:TextBox ID="txtFromdate" CssClass="calfromdate" runat="server"></asp:TextBox>
                </td>
                <td>Đến Ngày:<asp:TextBox ID="txtTodate" CssClass="caltodate" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="SearchByDate" runat="server" Text="Search" OnClick="SearchByDate_Click" />
                </td>
                <td style="width: 400px;">
                    <asp:Button ID="TxtToExcel" runat="server" Text="To Excel" OnClick="TxtToExcel_Click" />
                    <asp:Label ID="lbthongbao" runat="server"></asp:Label>

                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>&nbsp;&nbsp;
                            <asp:Button ID="btnthemmoi" runat="server" Text="Add" OnClick="btnthemmoi_Click" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttimkiemsanpham" runat="server" OnTextChanged="txttimkiemsanpham_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                        <td>Số Lượng:<asp:Label ID="lbsoluong" runat="server"></asp:Label></td>
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
    <asp:ObjectDataSource ID="CoDinhPhuSon" runat="server" SelectMethod="GetCoDinhTyLePhuSon" TypeName="ActionService.Service"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="listmember" runat="server" SelectMethod="GetListMemBer" TypeName="ActionService.Service">
        <SelectParameters>
            <asp:Parameter DefaultValue="PE" Name="production" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsloaiphim" runat="server" SelectMethod="GetLoaiPhimByBoPhan" TypeName="ActionService.Service">
        <SelectParameters>
            <asp:Parameter DefaultValue="MA4-3F" Name="bophan" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <table class="DivGridview">
        <tr>
            <td style="width: 40px;">Check</td>
            <td style="width: 77px;">ID</td>
            <td style="width: 120px;">Ngày Tạo</td>
            <td style="width: 120px;">Người Tạo</td>
            <td style="width: 190px;">Tên Sản Phẩm</td>
            <td>Loại Phim</td>
            <td>Tỷ Lệ X Min</td>
            <td>Tỷ Lệ X Max</td>
            <td>Tỷ Lệ Y Min</td>
            <td>Tỷ Lệ Y Max</td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCount" runat="server" Value="0" />
            <div id="divGrid" style="height: 493px; width: 100%; overflow-y: scroll; margin-top: 64px;">
                <asp:GridView ID="GridView1" runat="server" ShowHeader="false" DataKeyNames="idphuson" AutoGenerateColumns="False" DataSourceID="CoDinhPhuSon" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Check">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="idphuson" HeaderText="idphuson" SortExpression="idphuson">
                            <ItemStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ngaytao" HeaderText="ngaytao" SortExpression="ngaytao" DataFormatString="{0:HH:mm dd/MM/yy}">
                            <ItemStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nguoitao" HeaderText="nguoitao" SortExpression="nguoitao" ItemStyle-Width="110" />
                        <asp:TemplateField HeaderText="Tên Sản Phẩm" ItemStyle-Width="184">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkEdit" runat="server" OnClick="lkEdit_Click"><%#Eval("tensanpham") %></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="loaiphim" HeaderText="loaiphim" SortExpression="loaiphim" ItemStyle-Width="120" />
                        <asp:BoundField DataField="tylexmin" HeaderText="tylexmin" SortExpression="tylexmin" ItemStyle-Width="146" />
                        <asp:BoundField DataField="tylexmax" HeaderText="tylexmax" SortExpression="tylexmax" ItemStyle-Width="152" />
                        <asp:BoundField DataField="tyleymin" HeaderText="tyleymin" SortExpression="tyleymin" ItemStyle-Width="148" />
                        <asp:BoundField DataField="tyleymax" HeaderText="tyleymax" SortExpression="tyleymax" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Panel ID="Panel1" runat="server">
                <div id="pnlAddPopup" runat="server" style="width: 500px; background-color: #ffffff;">
                    <div id="popupheader" class="popuHeader">
                        <asp:Label ID="lblHeader" runat="server" Text="Add New User" />
                        <span style="float: right">
                            <img id="imgClose" src="/Images/btn-close.png" alt="close" title="Close" />
                        </span>
                    </div>
                    <asp:HiddenField ID="hfIdphuson" runat="server" />
                    <div>
                        <table border="0" class="table-border">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Tên Sản Phẩm"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtsanpham" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="Người Tạo"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="dropnguoitao" runat="server" Height="16px" Width="137px" AppendDataBoundItems="True" DataSourceID="listmember" DataTextField="member" DataValueField="member">
                                        <asp:ListItem Selected="True" Text="[--Chọn--]" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="Loại Phim"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="droploaiphim" runat="server" Width="175px" AppendDataBoundItems="True" DataSourceID="dsloaiphim" DataTextField="loaiphim" DataValueField="loaiphim">
                                        <asp:ListItem Text="[--Chọn--]" Value="" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="Tỷ Lệ X Min"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txttylexmin" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text="Tỷ Lệ X Max"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txttylexmax" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text="Tỷ Lệ Y Min"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txttyleymin" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text="Tỷ Lệ Y Max"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txttyleymax" runat="server"></asp:TextBox>
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
                        TargetControlID="hfIdphuson"
                        PopupControlID="Panel1"
                        BehaviorID="Behavior"
                        DropShadow="true"
                        CancelControlID="imgClose"
                        PopupDragHandleControlID="popupheader">
                    </ajaxToolkit:ModalPopupExtender>
                </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Scripts/DatePicker/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/DatePicker/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".calfromdate,.caltodate").datepicker();
        });
    </script>
    <script type="text/javascript">
        // This Script is used to maintain Grid Scroll on Partial Postback
        var scrollTop;
        //Register Begin Request and End Request 
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        //Get The Div Scroll Position

        function BeginRequestHandler(sender, args) {
            var m = document.getElementById('divGrid');
            scrollTop = m.scrollTop;
        }
        //Set The Div Scroll Position
        function EndRequestHandler(sender, args) {
            var m = document.getElementById('divGrid');
            m.scrollTop = scrollTop;
        }
    </script>
</asp:Content>
