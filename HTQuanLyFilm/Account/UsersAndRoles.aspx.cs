﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace HTQuanLyFilm.Account
{
    public partial class UsersAndRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Bind the users and roles
                BindUsersToUserList();
                BindRolesToList();

                // Check the selected user's roles
                CheckRolesForSelectedUser();

                // Display those users belonging to the currently selected role
                DisplayUsersBelongingToRole();
            }
        }
        private void BindRolesToList()
        {
            // Get all of the roles
            string[] roles = Roles.GetAllRoles();
            UsersRoleList.DataSource = roles;
            UsersRoleList.DataBind();

            RoleList.DataSource = roles;
            RoleList.DataBind();
        }
        #region 'By User' Interface-Specific Methods
        private void BindUsersToUserList()
        {
            // Get all of the user accounts
            MembershipUserCollection users = Membership.GetAllUsers();
            UserList.DataSource = users;
            UserList.DataBind();
        }

        protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckRolesForSelectedUser();
        }

        private void CheckRolesForSelectedUser()
        {
            // Determine what roles the selected user belongs to
            string selectedUserName = UserList.SelectedValue;
            string[] selectedUsersRoles = Roles.GetRolesForUser(selectedUserName);

            // Loop through the Repeater's Items and check or uncheck the checkbox as needed
            foreach (RepeaterItem ri in UsersRoleList.Items)
            {
                // Programmatically reference the CheckBox
                CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;

                // See if RoleCheckBox.Text is in selectedUsersRoles
                if (selectedUsersRoles.Contains<string>(RoleCheckBox.Text))
                    RoleCheckBox.Checked = true;
                else
                    RoleCheckBox.Checked = false;
            }
        }

        protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
        {
            // Reference the CheckBox that raised this event
            CheckBox RoleCheckBox = sender as CheckBox;

            // Get the currently selected user and role
            string selectedUserName = UserList.SelectedValue;
            string roleName = RoleCheckBox.Text;

            // Determine if we need to add or remove the user from this role
            if (RoleCheckBox.Checked)
            {
                // Add the user to the role
                Roles.AddUserToRole(selectedUserName, roleName);

                // Display a status message
                ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName);
            }
            else
            {
                // Remove the user from the role
                Roles.RemoveUserFromRole(selectedUserName, roleName);

                // Display a status message
                ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
            }

            // Refresh the "by role" interface
            DisplayUsersBelongingToRole();
        }
        #endregion

        #region 'By Role' Interface-Specific Methods
        protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayUsersBelongingToRole();
        }

        private void DisplayUsersBelongingToRole()
        {
            // Get the selected role
            string selectedRoleName = RoleList.SelectedValue;

            // Get the list of usernames that belong to the role
            string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

            // Bind the list of users to the GridView
            RolesUserList.DataSource = usersBelongingToRole;
            RolesUserList.DataBind();
        }

        protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the selected role
            string selectedRoleName = RoleList.SelectedValue;

            // Reference the UserNameLabel
            Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

            // Remove the user from the role
            Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

            // Refresh the GridView
            DisplayUsersBelongingToRole();

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);

            // Refresh the "by user" interface
            CheckRolesForSelectedUser();
        }

        protected void AddUserToRoleButton_Click(object sender, EventArgs e)
        {
            // Get the selected role and username
            string selectedRoleName = RoleList.SelectedValue;
            string userNameToAddToRole = UserNameToAddToRole.Text;

            // Make sure that a value was entered
            if (userNameToAddToRole.Trim().Length == 0)
            {
                ActionStatus.Text = "You must enter a username in the textbox.";
                return;
            }

            // Make sure that the user exists in the system
            MembershipUser userInfo = Membership.GetUser(userNameToAddToRole);
            if (userInfo == null)
            {
                ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole);
                return;
            }

            // Make sure that the user doesn't already belong to this role
            if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName))
            {
                ActionStatus.Text = string.Format("User {0} already is a member of role {1}.", userNameToAddToRole, selectedRoleName);
                return;
            }

            // If we reach here, we need to add the user to the role
            Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);

            // Clear out the TextBox
            UserNameToAddToRole.Text = string.Empty;

            // Refresh the GridView
            DisplayUsersBelongingToRole();

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName);

            // Refresh the "by user" interface
            CheckRolesForSelectedUser();
        }
        #endregion
    }
}