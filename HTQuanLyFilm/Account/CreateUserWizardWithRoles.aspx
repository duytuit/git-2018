<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin.Master" AutoEventWireup="true" CodeBehind="CreateUserWizardWithRoles.aspx.cs" Inherits="HTQuanLyFilm.Account.CreateUserWizardWithRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Create a User Account (with Roles!)</h2>
    
    <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" 
          ContinueDestinationPageUrl="~/Author/Login.aspx" 
        onactivestepchanged="RegisterUserWithRoles_ActiveStepChanged" 
        LoginCreatedUser="False">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:WizardStep ID="SpecifyRolesStep" runat="server" StepType="Step" 
                Title="Specify Roles" AllowReturn="False">
                <asp:CheckBoxList ID="RoleList" runat="server">
                </asp:CheckBoxList>
            </asp:WizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
