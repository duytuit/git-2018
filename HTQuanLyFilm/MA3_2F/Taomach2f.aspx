<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Taomach2f.aspx.cs" Inherits="HTQuanLyFilm.MA3_2F.Taomach2f" EnableEventValidation="false" %>

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
            width: 99%;
            background-color: #660066;
            position: fixed;
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
                background-color: #333399;
                height: 30px;
                text-align: center;
            }

        .DivGridview {
            margin-top: 33px;
            background-position-x: right;
            width: 1980px;
        }

        .auto-style4 {
            width: 90px;
        }

        .auto-style5 {
            width: 114px;
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
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txttimkiemsanpham" runat="server" OnTextChanged="txttimkiemsanpham_TextChanged" AutoPostBack="True" Height="19px"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="drophientrang" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="drophientrang_SelectedIndexChanged" Height="25px">
                                <asp:ListItem Text="[--Hiện Trạng--]" Value=""></asp:ListItem>
                                <asp:ListItem>Đang Làm</asp:ListItem>
                                <asp:ListItem>Đã Xong</asp:ListItem>
                                <asp:ListItem>Đã Chuyển Xưởng</asp:ListItem>
                                <asp:ListItem>Đã Báo Phế</asp:ListItem>
                                <asp:ListItem>Sai Tỷ Lệ</asp:ListItem>
                                <asp:ListItem>Yêu Cầu Mới</asp:ListItem>
                                <asp:ListItem>Chưa Có Dữ Liệu</asp:ListItem>
                                <asp:ListItem>Tỷ Lệ Bất Thường</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td>Số Lượng:<asp:Label ID="lbsoluong" runat="server"></asp:Label></td>

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
            <td style="width: 75px;">Ca</td>
            <td style="width: 95px;">Ngày</td>
            <td style="width: 75px;">Giờ</td>
            <td style="width: 119px;">Bộ Phận</td>
            <td style="width: 184px;">Tên Sản Phẩm</td>
            <td style="width: 118px;">Phận Loại</td>
            <td style="width: 130px;">Loai Phim</td>
            <td style="width: 120px;">Máy Dùng</td>
            <td style="width: 80px;">Số Bộ</td>
            <td style="width: 80px;">Tỷ Lệ X</td>
            <td style="width: 80px;">Tỷ Lệ Y</td>
            <td style="width: 100px;">Người Yêu Cầu</td>
            <td style="width: 160px;">Nội Dung</td>
            <td style="width: 100px;">Xác Nhận PE</td>
            <td style="width: 100px;">Xác Nhận CAM</td>
            <td style="width: 80px;">Máy In</td>
            <td style="width: 160px;">Hiện Trạng</td>
            <td style="width: 80px;">Giờ Xong</td>
            <td style="width: 100px;">Ngày Xuất</td>
            <td style="width: 100px;">Ngày Phế</td>
            <td style="width: 212px;">Nội Dung Phế</td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="dsloaiphim" runat="server" SelectMethod="GetLoaiPhimByBoPhan" TypeName="ActionService.Service">
        <SelectParameters>
            <asp:Parameter DefaultValue="MA3-2F" Name="bophan" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsphimpcb" runat="server" SelectMethod="GetPhimPcbMa3_2f" TypeName="ActionService.Service"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsmember" runat="server" SelectMethod="GetListMemBer" TypeName="ActionService.Service">
        <SelectParameters>
            <asp:Parameter DefaultValue="MA3-2F" Name="production" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Timer ID="Timer1" runat="server" Interval="600000" OnTick="Timer1_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
            <div id="divGrid" style="height: 478px; width: 2000px; overflow-y: scroll;">
                <asp:GridView ID="GridView1" runat="server" CssClass="Grid" ShowHeader="False" DataKeyNames="idpcb" AutoGenerateColumns="False" DataSourceID="dsphimpcb" Width="1980px" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="ca" HeaderText="ca" SortExpression="ca">
                            <ItemStyle Width="53px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ngay" HeaderText="ngay" SortExpression="ngay" DataFormatString="{0:dd/MM/yy}">
                            <ItemStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gio" HeaderText="gio" SortExpression="gio" DataFormatString="{0:HH:mm}">
                            <ItemStyle Width="53px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bophan" HeaderText="bophan" SortExpression="bophan">
                            <ItemStyle Width="89px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="masanpham" HeaderText="masanpham" SortExpression="masanpham">
                            <ItemStyle Width="139px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="phanloai" SortExpression="phanloai">
                            <ItemTemplate>
                                <asp:Label ID="lbphanloai" runat="server" Text='<%# Bind("phanloai") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="89px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="loaiphim" HeaderText="loaiphim" SortExpression="loaiphim">
                            <ItemStyle Width="97px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="maydung" HeaderText="maydung" SortExpression="maydung">
                            <ItemStyle Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sobo" HeaderText="sobo" SortExpression="sobo">
                            <ItemStyle Width="56px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tylex" HeaderText="tylex" SortExpression="tylex">
                            <ItemStyle Width="55px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tyley" HeaderText="tyley" SortExpression="tyley">
                            <ItemStyle Width="55px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nguoiyeucau" HeaderText="nguoiyeucau" SortExpression="nguoiyeucau">
                            <ItemStyle Width="77px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="noidungyeucau" HeaderText="noidungyeucau" SortExpression="noidungyeucau">
                            <ItemStyle Width="121px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="xacnhanpe" HeaderText="xacnhanpe" SortExpression="xacnhanpe">
                            <ItemStyle Width="76px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="xacnhancam" HeaderText="xacnhancam" SortExpression="xacnhancam">
                            <ItemStyle Width="76px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mayin" HeaderText="mayin" SortExpression="mayin">
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="hientrang" SortExpression="hientrang">
                            <ItemTemplate>
                                <asp:Label ID="lbhientrang" runat="server" Text='<%# Bind("hientrang") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="giohoanthanh" HeaderText="giohoanthanh" SortExpression="giohoanthanh" DataFormatString="{0:HH:mm}">
                            <ItemStyle Width="59px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ngayxuatxuong" HeaderText="ngayxuatxuong" SortExpression="ngayxuatxuong" DataFormatString="{0:dd/MM/yy}">
                            <ItemStyle Width="75px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ngaybaophe" HeaderText="ngaybaophe" SortExpression="ngaybaophe" DataFormatString="{0:dd/MM/yy}">
                            <ItemStyle Width="75px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="noidungbaophe" HeaderText="noidungbaophe" SortExpression="noidungbaophe" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Panel ID="Panel1" runat="server">
                <div id="pnlAddPopup" runat="server" style="width: 700px; background-color: #66CC66; border-left: solid; border-left-color: black">
                    <div id="popupheader" class="popuHeader">
                        <asp:Label ID="lblHeader" runat="server" Text="Thêm Sản Phẩm" />
                        <span style="float: right">
                            <img id="imgClose" src="/Images/btn-close.png" alt="close" title="Close" />
                        </span>
                    </div>
                    <asp:HiddenField ID="hfIdpcb" runat="server" />
                    <asp:HiddenField ID="hftime" runat="server" />
                    <div>
                        <table border="0" class="table-border">
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label9" runat="server" Text="Tên Sản Phẩm"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtsanpham" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server" Text="VD: 0826-5917LR" Font-Italic="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label21" runat="server" Text="Loại Phim"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="droploaiphimform" runat="server" Width="175px" AppendDataBoundItems="True" DataSourceID="dsloaiphim" DataTextField="loaiphim" DataValueField="loaiphim" Height="25">
                                        <asp:ListItem Text="[--Chọn--]" Selected="True" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label4" runat="server" Text="Tỷ Lệ"></asp:Label>
                                </td>
                                <td class="auto-style4">X:
                                            <asp:TextBox ID="txttylex" runat="server" Height="20px" Width="130px">

                                            </asp:TextBox>
                                    Y:
                                            <asp:TextBox ID="txttyley" runat="server" Height="20px" Width="130px">

                                            </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Người Yêu Cầu"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="dropnguoiyeucau" runat="server" AppendDataBoundItems="true" DataSourceID="dsmember" DataTextField="member" DataValueField="member" Height="25px" Width="175px">
                                        <asp:ListItem Text="[--Chọn--]" Selected="True" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label7" runat="server" Text="Nôi Dung Yêu Cầu"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtnoidungyeucau" runat="server" Height="80px" TextMode="MultiLine" Width="160px"></asp:TextBox>
                                    &nbsp;<span class="auto-style7"><em>&nbsp;&nbsp; * Ghi rõ nội dung và số điện thoại yêu cầu</em></span></td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label17" runat="server" Text="Số Lượng"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="dropsoluong" runat="server" Height="25px" Width="160px">
                                        <asp:ListItem Selected="True">1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">&nbsp;</td>
                                <td class="auto-style1">&nbsp;
                                   <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                                    <asp:Label ID="lbmessage" runat="server" ForeColor="#CC3300"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <ajaxToolkit:ModalPopupExtender ID="popup" runat="server"
                        TargetControlID="hfIdpcb"
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
