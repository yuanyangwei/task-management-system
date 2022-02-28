<%@ Page Title="UserProfolio" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserProfolio.aspx.cs" Inherits="TMS.UserProfolio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="CSS/GridViewStyle.css" />
    <link rel="stylesheet" href="CSS/DDLPopUpStyle.css" />

    <div>
        <h3>Customer Profolio List</h3>
        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" DataKeyNames="employee_id" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" ShowHeaderWhenEmpty="true" AutoPostBack="true" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemStyle Width="50px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LB2" runat="server" CommandName="Update">Update</asp:LinkButton>
                        <asp:LinkButton ID="LB3" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="User Name">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("username" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Full Name">
                    <ItemStyle Width="200px" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("full_name" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <ItemStyle Width="220px" />
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("email" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone Number">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("phone_no" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Designation">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("position" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlDesignation" runat="server" BackColor="#F6F1DB" ForeColor="Black"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Department">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("department" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" BackColor="#F6F1DB" ForeColor="Black"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Role Type">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("roleType" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlRoleType" runat="server" AutoPostBack="true" BackColor="#F6F1DB" ForeColor="Black">
                            <asp:ListItem>Normal User</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Account Locked">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("account_status" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="dllAcctStatus" runat="server" BackColor="#F6F1DB" ForeColor="Black">
                            <asp:ListItem>Locked</asp:ListItem>
                            <asp:ListItem>Unlock</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div align="center">No records found.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
