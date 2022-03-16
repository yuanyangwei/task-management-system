<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ManagerDashBoard.aspx.cs" Inherits="TMS.ManagerDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="CSS/GridViewStyle.css" />
    <link rel="stylesheet" href="CSS/DDLPopUpStyle.css" />

    <div>
        <h3>Task List</h3>
        <div>
            <asp:DropDownList ID="ddlFilterByProjectType" runat="server" Style="margin-bottom: 40px; margin-right: 40px;" Width="336px" BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" CssClass="ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterByProjectType_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" Style="" AlternateText="Add Task" Height="34px" ImageUrl="~/Image/AddTask.png" Width="40px" ImageAlign="Bottom" OnClick="ImageButton1_Click" />
        </div>

        <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" DataKeyNames="task_id" 
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" ShowHeaderWhenEmpty="true" OnRowCommand="GridView1_RowCommand"  OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemStyle Width="50px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task ID" Visible="false">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="lblTaskID" runat="server" Text='<%# Eval("task_id" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Name">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("project_name" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task Name">
                    <ItemStyle Width="200px" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("task_name" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task Description">
                    <ItemStyle Width="220px" />
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("task_desc" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task Comment">
                    <ItemStyle Width="220px" />
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("task_comment" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Assignee">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="lblAssignee" runat="server" Text='<%# Eval("assignee" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task Status">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("task_status" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Priority">
                    <ItemStyle Width="90px" />
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("priority" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Start Date">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("start_date" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Due Date">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("due_date" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div align="center">No records found.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
