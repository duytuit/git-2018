<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Codinhphuson3f.aspx.cs" Inherits="HTQuanLyFilm.PE.Codinhphuson3f" %>
<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 258px;
        }

        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            width: 100%;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }

        .auto-style4 {
            width: 136px;
            height: 17px;
        }

        .auto-style5 {
            height: 17px;
        }

        .auto-style6 {
            height: 17px;
            width: 167px;
        }

        .auto-style7 {
            height: 17px;
            width: 168px;
        }

        .auto-style8 {
            height: 17px;
            width: 98px;
        }

        .auto-style9 {
            height: 34px;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-bottom:5px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:ObjectDataSource ID="CoDinhTyLePhuSon" runat="server" SelectMethod="GetCoDinhTyLePhuSon" TypeName="ActionService.Service" DataObjectTypeName="BusinessObjects.CoDinhTyLePhuSonBUS" DeleteMethod="DeleteCoDinhTyLePhuSon" UpdateMethod="UpdateCoDinhTyLePhuSon"></asp:ObjectDataSource>
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td class="auto-style8">
                  
                </td>
                <td class="auto-style7">Từ Ngày<asp:TextBox ID="TextBox8" runat="server" Width="100px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox8_CalendarExtender" runat="server" BehaviorID="TextBox8_CalendarExtender" TargetControlID="TextBox8" />
                </td>
                <td class="auto-style6">Đến Ngày<asp:TextBox ID="TextBox9" runat="server" Height="16px" Width="100px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox9_CalendarExtender" runat="server" BehaviorID="TextBox9_CalendarExtender" TargetControlID="TextBox9" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="Button5" runat="server" Text="Tìm" />
                </td>
                <td class="auto-style4" >Số Lượng :
                           <asp:Label ID="Label11" runat="server"></asp:Label>
                </td>   
                <td class="auto-style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" OnClientClick = "return ConfirmDelete();"  />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
 
        <asp:HiddenField ID="hfCount" runat="server" Value = "0" />
        <asp:HiddenField ID="hdidphuson" runat="server" />
        <asp:HiddenField ID="hdinsert" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Button ID="Button4" runat="server" Text="Thêm Mới" OnClick="Button4_Click" /> 
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="CoDinhTyLePhuSon" Width="99%" OnPageIndexChanging="GridView2_PageIndexChanging" >
                <Columns>
                    <asp:BoundField DataField="idphuson" HeaderText="idphuson" ItemStyle-Width="110" HtmlEncode="true" SortExpression="idphuson"></asp:BoundField>
                    <asp:BoundField DataField="ngaytao" HeaderText="ngaytao" SortExpression="ngaytao" />
                    <asp:BoundField DataField="nguoitao" HeaderText="nguoitao" SortExpression="nguoitao" />
                    <asp:BoundField DataField="tensanpham" HeaderText="tensanpham" SortExpression="tensanpham" />
                    <asp:BoundField DataField="loaiphim" HeaderText="loaiphim" SortExpression="loaiphim" />
                    <asp:BoundField DataField="tylexmin" HeaderText="tylexmin" SortExpression="tylexmin" />
                    <asp:BoundField DataField="tylexmax" HeaderText="tylexmax" SortExpression="tylexmax" />
                    <asp:BoundField DataField="tyleymin" HeaderText="tyleymin" SortExpression="tyleymin" />
                    <asp:BoundField DataField="tyleymax" HeaderText="tyleymax" SortExpression="tyleymax" />
                </Columns>
            </asp:GridView>

      <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: none" Height="300" Width="500">
            <table  >
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label9" runat="server" Text="Tên Sản Phẩm"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsanpham" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label10" runat="server" Text="Ngày Tạo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtngaytao" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtngaytao_CalendarExtender" runat="server" BehaviorID="txtngaytao_CalendarExtender" TargetControlID="txtngaytao" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label20" runat="server" Text="Người Tạo"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropnguoitao" runat="server" Height="16px" Width="137px">
                                <asp:ListItem>Duy Tú</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label21" runat="server" Text="Loại Phim"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="droploaiphim" runat="server" Width="175px">
                                <asp:ListItem>Phủ Sơn</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            <asp:Label ID="Label22" runat="server" Text="Tỷ Lệ X Min"></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txttylexmin" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label23" runat="server" Text="Tỷ Lệ X Max"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttylexmax" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label24" runat="server" Text="Tỷ Lệ Y Min"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttyleymin" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label25" runat="server" Text="Tỷ Lệ Y Max"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttyleymax" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;<asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" /></td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                    </td>
                </tr>
                </table>     
  </asp:Panel>
            <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
            <ajaxToolkit:ModalPopupExtender ID="popup" runat="server" DropShadow="false" 
                 PopupControlID="pnlAddEdit" TargetControlID="lnkFake"
                 BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView2" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
   
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
             '<img src="images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.3
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("<%=Panel22.ClientID %>");
            $.blockUI.defaults.css = {};
        });
            function Hidepopup() {
                $find("ModalPopupExtender1").hide();
                return false;
            }
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
    <script type = "text/javascript">
        function ConfirmDelete() {
        var count = document.getElementById("<%=hfCount.ClientID %>").value;
        var gv = document.getElementById("<%=GridView2.ClientID%>");
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
    <script type = "text/javascript">
        var GridId = "<%=GridView2.ClientID %>";
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
            if(parseInt(gridHeight) > ScrollHeight){
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
        </script>
       <script lang="javascript" >
           $(document).ready(function () {
               var gridHeader = $('#<%=GridView2.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=GridView2.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
                    $('#GHead').css('top', $('#<%=GridView2.ClientID%>').offset().top);

                });
            </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="CoDinhTyLePhuSon">
                <Columns>
                    <asp:BoundField DataField="idphuson" HeaderText="idphuson" SortExpression="idphuson" HtmlEncode = "true" />
                    <asp:BoundField DataField="ngaytao" HeaderText="ngaytao" SortExpression="ngaytao" HtmlEncode = "true" />
                    <asp:BoundField DataField="nguoitao" HeaderText="nguoitao" SortExpression="nguoitao" HtmlEncode = "true" />
                    <asp:BoundField DataField="tensanpham" HeaderText="tensanpham" SortExpression="tensanpham" HtmlEncode = "true" />
                    <asp:BoundField DataField="loaiphim" HeaderText="loaiphim" SortExpression="loaiphim" HtmlEncode = "true" />
                    <asp:BoundField DataField="tylexmin" HeaderText="tylexmin" SortExpression="tylexmin" HtmlEncode = "true" />
                    <asp:BoundField DataField="tylexmax" HeaderText="tylexmax" SortExpression="tylexmax" HtmlEncode = "true" />
                    <asp:BoundField DataField="tyleymin" HeaderText="tyleymin" SortExpression="tyleymin"  HtmlEncode = "true"/>
                    <asp:BoundField DataField="tyleymax" HeaderText="tyleymax" SortExpression="tyleymax" HtmlEncode = "true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="Panel22" runat="server" CssClass="modalPopup" style = "display:none" Height="300" Width="500">
                <table>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Tên Sản Phẩm"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Ngày Tạo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="Người Tạo"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="137px">
                                <asp:ListItem>Duy Tú</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="Loại Phim"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="175px">
                                <asp:ListItem>Phủ Sơn</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            <asp:Label ID="Label5" runat="server" Text="Tỷ Lệ X Min"></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="Tỷ Lệ X Max"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label7" runat="server" Text="Tỷ Lệ Y Min"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label8" runat="server" Text="Tỷ Lệ Y Max"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="SAVE" OnClick="btnSave_Click" /></td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                PopupControlID="Panel22" TargetControlID="LinkButton2"
                BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
        <Triggers>
             <asp:AsyncPostBackTrigger ControlID="GridView3" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
 
 
    <br />
    </asp:Content>
