<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin.Master" AutoEventWireup="true" CodeBehind="Account_pcb.aspx.cs" Inherits="HTQuanLyFilm.Account.Account_pcb" %>

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
            border: none;
            color: white;
            width:100%;
        }

        .Grid {
            margin-top: 60px;
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
            margin-top: 28px;
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
                  <td> <asp:Button ID="TxtToExcel" runat="server" Text="To Excel" OnClick="TxtToExcel_Click"/></td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td >&nbsp;&nbsp;
                            <asp:Button ID="btnthemmoi" runat="server" Text="Add" OnClick="btnthemmoi_Click" />
                        </td>
                         <td>
                             <asp:DropDownList ID="dropbophan" runat="server" AppendDataBoundItems="true">
                                 <asp:ListItem Selected="True" Text="--Chọn--" Value=""></asp:ListItem>
                             </asp:DropDownList>

                         </td>
                        <td><asp:TextBox ID="txttimkiemsanpham" runat="server" OnTextChanged="txttimkiemsanpham_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="drophientrang" runat="server" AppendDataBoundItems="true">
                               <asp:ListItem Selected="True" Text="--Chọn--" Value=""></asp:ListItem>
                            </asp:DropDownList>

                        </td>
                           <td >Số Lượng:<asp:Label ID="lbsoluong" runat="server"></asp:Label></td>
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
            <td style="width: 77px;">Ca</td>
            <td style="width: 77px;">Ngày</td>
            <td style="width: 120px;">Giờ</td>
            <td style="width: 120px;">Bộ Phận</td>
            <td style="width: 190px;">Tên Sản Phẩm</td>
            <td style="width: 120px;">Phận Loại</td>
            <td style="width: 120px;">Loai Phim</td>
            <td style="width: 120px;">Máy Dùng</td>
            <td style="width: 120px;">Số Bộ</td>
            <td style="width: 120px;">Tỷ Lệ X</td>
            <td style="width: 120px;">Tỷ Lệ Y</td>
            <td style="width: 120px;">Người Yêu Cầu</td>
            <td style="width: 120px;">Nội Dung</td>
            <td style="width: 120px;">Xác Nhận PE</td>
            <td style="width: 120px;">Xác Nhận CAM</td>
            <td style="width: 120px;">Máy In</td>
            <td style="width: 120px;">Hiện Trạng</td>
            <td style="width: 120px;">Giờ Xong</td>
            <td style="width: 120px;">Ngày Xuất</td>
            <td style="width: 120px;">Ngày Phế</td>
            <td style="width: 120px;">Nội Dung Phế</td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsphimpcb" runat="server" SelectMethod="GetPhimPcb" TypeName="ActionService.Service"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCount" runat="server" Value="0" />
            <asp:GridView ID="GridView1" runat="server" ShowHeader="False" DataKeyNames="idpcb" CssClass="Grid" AutoGenerateColumns="False" DataSourceID="dsphimpcb">
                <Columns>
                    <asp:TemplateField HeaderText="Check">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ca" HeaderText="ca" SortExpression="ca" />
                    <asp:BoundField DataField="ngay" HeaderText="ngay" SortExpression="ngay" DataFormatString="{0:dd/MM/yy}" />
                    <asp:BoundField DataField="gio" HeaderText="gio" SortExpression="gio"  DataFormatString="{0:HH:mm}" />
                    <asp:BoundField DataField="bophan" HeaderText="bophan" SortExpression="bophan" />
                    <asp:BoundField DataField="masanpham" HeaderText="masanpham" SortExpression="masanpham" />
                    <asp:BoundField DataField="phanloai" HeaderText="phanloai" SortExpression="phanloai" />
                    <asp:BoundField DataField="loaiphim" HeaderText="loaiphim" SortExpression="loaiphim" />
                    <asp:BoundField DataField="maydung" HeaderText="maydung" SortExpression="maydung" />
                    <asp:BoundField DataField="sobo" HeaderText="sobo" SortExpression="sobo" />
                    <asp:BoundField DataField="tylex" HeaderText="tylex" SortExpression="tylex" />
                    <asp:BoundField DataField="tyley" HeaderText="tyley" SortExpression="tyley" />
                    <asp:BoundField DataField="nguoiyeucau" HeaderText="nguoiyeucau" SortExpression="nguoiyeucau" />
                    <asp:BoundField DataField="noidungyeucau" HeaderText="noidungyeucau" SortExpression="noidungyeucau" />
                    <asp:BoundField DataField="xacnhanpe" HeaderText="xacnhanpe" SortExpression="xacnhanpe" />
                    <asp:BoundField DataField="xacnhancam" HeaderText="xacnhancam" SortExpression="xacnhancam" />
                    <asp:BoundField DataField="mayin" HeaderText="mayin" SortExpression="mayin" />
                    <asp:BoundField DataField="hientrang" HeaderText="hientrang" SortExpression="hientrang" />
                    <asp:BoundField DataField="giohoanthanh" HeaderText="giohoanthanh" SortExpression="giohoanthanh"  DataFormatString="{0:HH:mm}" />
                    <asp:BoundField DataField="ngayxuatxuong" HeaderText="ngayxuatxuong" SortExpression="ngayxuatxuong" DataFormatString="{0:dd/MM/yy}" />
                    <asp:BoundField DataField="ngaybaophe" HeaderText="ngaybaophe" SortExpression="ngaybaophe" DataFormatString="{0:dd/MM/yy}" />
                    <asp:BoundField DataField="noidungbaophe" HeaderText="noidungbaophe" SortExpression="noidungbaophe" />
                </Columns>
            </asp:GridView>
            <asp:Panel ID="Panel1" runat="server">
                 <div id="pnlAddPopup" runat="server" style="width: 500px; background-color: #ffffff;">
                <div id="popupheader" class="popuHeader">
                    <asp:Label ID="lblHeader" runat="server" Text="Add New User" />
                    <span style="float: right">
                        <img id="imgClose" src="/Images/btn-close.png" alt="close" title="Close" />
                    </span>
                </div>
                <asp:HiddenField  ID="hfIdphuson" runat="server" Value="0"/>
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
                                <asp:DropDownList ID="dropnguoitao" runat="server" Height="16px" Width="137px" AppendDataBoundItems="True">
                                   <asp:ListItem Selected="True" Text="--Chọn--" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Loại Phim"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="droploaiphim" runat="server" Width="175px" AppendDataBoundItems="True">
                                    <asp:ListItem Text="--Chọn--" Value="" Selected="True"></asp:ListItem>
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
                    BehaviorID ="Behavior"
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
</asp:Content>
