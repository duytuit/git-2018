<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Codinhphuson3f.aspx.cs" Inherits="HTQuanLyFilm.PE.Codinhphuson3f" %>
<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 118px;
    }
        .auto-style2 {
            width: 130px;
        }
        .auto-style3 {
            width: 185px;
        }
        .auto-style4 {
            width: 193px;
        }
        .auto-style5 {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="panel1" runat="server">
       <ContentTemplate>
           <br />
           <asp:Panel ID="Panel3" runat="server">
               <table style="width: 100%;">
                   <tr>
                       <td class="auto-style5">
                           <asp:Button ID="Button2" runat="server" Text="Thêm Mới" />
                       </td>
                       <td class="auto-style3">Từ Ngày<asp:TextBox ID="TextBox6" runat="server" Width="100px"></asp:TextBox>
                           <ajaxToolkit:CalendarExtender ID="TextBox6_CalendarExtender" runat="server" BehaviorID="TextBox6_CalendarExtender" TargetControlID="TextBox6" />
                       </td>
                       <td class="auto-style4">Đến Ngày<asp:TextBox ID="TextBox7" runat="server" Height="16px" Width="100px"></asp:TextBox>
                           <ajaxToolkit:CalendarExtender ID="TextBox7_CalendarExtender" runat="server" BehaviorID="TextBox7_CalendarExtender" TargetControlID="TextBox7" />
                       </td>
                       <td>
                           <asp:Button ID="Button3" runat="server" Text="Tìm" />
                       </td>
                       <td>Số Lượng :
                           <asp:Label ID="Label7" runat="server"></asp:Label>
                       </td>
                   </tr>
               </table>
           </asp:Panel>
           <br />
           <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCoDinhTyLePhuSon" TypeName="ActionService.Service"></asp:ObjectDataSource>
           <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" EnableTheming="True" Theme="Aqua" Width="100%">
               <Settings ShowFilterRow="True" EnableFilterControlPopupMenuScrolling="True" ShowFilterRowMenu="True" VerticalScrollableHeight="100" VerticalScrollBarMode="Visible" />
               <Columns>
                   <dx:GridViewDataTextColumn FieldName="idphuson" VisibleIndex="0">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tensanpham" VisibleIndex="1">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="loaiphim" VisibleIndex="2">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tylexmin" VisibleIndex="3">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tylexmax" VisibleIndex="4">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tyleymin" VisibleIndex="5">
                   </dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="tyleymax" VisibleIndex="6">
                   </dx:GridViewDataTextColumn>
               </Columns>
               <TotalSummary>
                   <dx:ASPxSummaryItem SummaryType="Count" />
               </TotalSummary>
           </dx:ASPxGridView>
         
           <br />
           
       </ContentTemplate>
   </asp:UpdatePanel>
      <asp:Panel ID="Panel2" runat="server" BackColor="#3366FF" Width="520px">
          <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="230px" Width="500px">
              <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Yêu Cầu 1">
                  <ContentTemplate>
                      <table id="tab1" style="width: 100%;">
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
                                  <asp:Label ID="Label2" runat="server" Text="Loại Phim"></asp:Label>
                              </td>
                              <td>
                                  <asp:DropDownList ID="DropDownList1" runat="server" Width="175px">
                                  </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:Label ID="Label3" runat="server" Text="Tỷ Lệ X Min"></asp:Label>
                              </td>
                              <td>
                                  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:Label ID="Label4" runat="server" Text="Tỷ Lệ X Max"></asp:Label>
                              </td>
                              <td>
                                  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:Label ID="Label5" runat="server" Text="Tỷ Lệ Y Min"></asp:Label>
                              </td>
                              <td>
                                  <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:Label ID="Label6" runat="server" Text="Tỷ Lệ Y Max"></asp:Label>
                              </td>
                              <td>
                                  <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                      </table>
                  </ContentTemplate>
              </ajaxToolkit:TabPanel>
              <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Yêu Cầu 2">
                  <ContentTemplate>
                      <table id="tab2" style="width: 100%;">
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                      </table>
                  </ContentTemplate>
              </ajaxToolkit:TabPanel>
              <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Yêu Cầu 3">
                  <ContentTemplate>
                      <table id="tab3" style="width: 100%;">
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                      </table>
                  </ContentTemplate>
              </ajaxToolkit:TabPanel>
          </ajaxToolkit:TabContainer>
          <table style="width: 100%;">
              <tr>
                  <td class="auto-style2">&nbsp;</td>
                   <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="SAVE" /></td>
              </tr>
          </table>
           </asp:Panel>
</asp:Content>
