<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="CoDinhTyLePhuSon3f.aspx.cs" Inherits="HTQuanLyFilm.PE.CoDinhTyLePhuSon3f" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
                background-color: #df5015;
                height: 30px;
                text-align: center;
            }

        .DivGridview {
            margin-top: 28px;
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
                <td>&nbsp;&nbsp;Từ Ngày:<asp:TextBox ID="TextBox1" CssClass="calfromdate" runat="server"></asp:TextBox>
                </td>
                <td>Đến Ngày:<asp:TextBox ID="TextBox2" CssClass="caltodate" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="SearchByDate" runat="server" Text="Search" OnClick="SearchByDate_Click" />
                </td>
                 
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td >&nbsp;&nbsp;
                            <asp:Button ID="btnthemmoi" runat="server" Text="Add" OnClick="btnthemmoi_Click" />
                        </td>
                         <td><asp:TextBox ID="txttimkiemsanpham" runat="server" OnTextChanged="txttimkiemsanpham_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                         <td> <asp:Button ID="TxtToExcel" runat="server" Text="To Excel" /></td>
                        <td style="width:920px;">Số Lượng:<asp:Label ID="lbsoluong" runat="server"></asp:Label></td>
                        <td>
                            <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
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
            <asp:GridView ID="GridView1" ShowHeader="False" runat="server" CssClass="Grid" DataKeyNames="idphuson" AutoGenerateColumns="False" DataSourceID="CoDinhPhuSon" Width="100%">
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
                            <asp:LinkButton ID="lkEdit" runat="server"  OnClick="lkEdit_Click"><%#Eval("tensanpham") %></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="loaiphim" HeaderText="loaiphim" SortExpression="loaiphim" ItemStyle-Width="120" />
                    <asp:BoundField DataField="tylexmin" HeaderText="tylexmin" SortExpression="tylexmin" ItemStyle-Width="146" />
                    <asp:BoundField DataField="tylexmax" HeaderText="tylexmax" SortExpression="tylexmax" ItemStyle-Width="152" />
                    <asp:BoundField DataField="tyleymin" HeaderText="tyleymin" SortExpression="tyleymin" ItemStyle-Width="148" />
                    <asp:BoundField DataField="tyleymax" HeaderText="tyleymax" SortExpression="tyleymax" />
                </Columns>
            </asp:GridView>
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
                                <asp:Label ID="Label10" runat="server" Text="Ngày Tạo"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtngaytao" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtngaytao_CalendarExtender" runat="server" BehaviorID="txtngaytao_CalendarExtender" TargetControlID="txtngaytao" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Người Tạo"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="dropnguoitao" runat="server" Height="16px" Width="137px">
                                    <asp:ListItem>Duy Tú</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Loại Phim"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="droploaiphim" runat="server" Width="175px">
                                    <asp:ListItem>Phủ Sơn</asp:ListItem>
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
                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:$find('mpeUserBehavior').hide();return false;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <ajaxToolkit:ModalPopupExtender ID="popup" runat="server"
                    TargetControlID="hfIdphuson"
                    PopupControlID="pnlAddPopup"
                    BehaviorID="mpeUserBehavior"
                    DropShadow="true"
                    CancelControlID="imgClose"
                    PopupDragHandleControlID="popupheader">
                </ajaxToolkit:ModalPopupExtender>
            </div>
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

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox") {
                    if (!inputList[i].checked) {
                        checked = true;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {

                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        function ConfirmDelete() {
            var count = document.getElementById("<%=hfCount.ClientID %>").value;
            var gv = document.getElementById("<%=GridView1.ClientID%>");
            var chk = gv.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].checked && chk[i].id.indexOf("CheckAll") == -1) {
                    count++;
                }
            }
            if (count == 0) {
                alert("No records to delete.");
                return false;
            }
            else {
                return confirm("Do you want to delete " + count + " records.");
            }
        }
    </script>
    <%--    <script type = "text/javascript">
          var GridId = "<%=GridView1.ClientID %>";
          var ScrollHeight = 200;
          window.onload = function () {
              var grid = document.getElementById(GridId);
              var gridWidth = grid.offsetWidth;
              var gridHeight = grid.offsetHeight;
              var headerCellWidths = new Array();
              for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                  headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
              }
              grid.parentNode.appendChild(document.createElement("div"));
              var parentDiv = grid.parentNode;

              var table = document.createElement("table");
              for (i = 0; i < grid.attributes.length; i++) {
                  if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                      table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                  }
              }
              table.style.cssText = grid.style.cssText;
              table.style.width = gridWidth + "px";
              table.appendChild(document.createElement("tbody"));
              table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
              var cells = table.getElementsByTagName("TH");

              var gridRow = grid.getElementsByTagName("TR")[0];
              for (var i = 0; i < cells.length; i++) {
                  var width;
                  if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                      width = headerCellWidths[i];
                  }
                  else {
                      width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                  }
                  cells[i].style.width = parseInt(width - 3) + "px";
                  gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
              }
              parentDiv.removeChild(grid);

              var dummyHeader = document.createElement("div");
              dummyHeader.appendChild(table);
              parentDiv.appendChild(dummyHeader);
              var scrollableDiv = document.createElement("div");
              if (parseInt(gridHeight) > ScrollHeight) {
                  gridWidth = parseInt(gridWidth) + 17;
              }
              scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
              scrollableDiv.appendChild(grid);
              parentDiv.appendChild(scrollableDiv);
          }
        </script>--%>
</asp:Content>
