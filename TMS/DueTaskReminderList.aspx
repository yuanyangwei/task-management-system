<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DueTaskReminderList.aspx.cs" Inherits="TMS.DueTaskReminderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="CSS/GridViewStyle.css" />
    <link rel="stylesheet" href="CSS/DDLPopUpStyle.css" />

    <div>
        <h3>There are <%:Session["DueTaskCount"]%> tasks due in 3 days or have already been due</h3>

        <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" DataKeyNames="task_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="RowDataBound"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" ShowHeaderWhenEmpty="true" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_comment" runat="server" TextMode="MultiLine" Style="background-color: #F6F1DB; color: black" Text='<%#Eval("task_comment") %>' Width="200px" Height="20px"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task Status">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("task_status" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatusType" runat="server" BackColor="#F6F1DB" ForeColor="Black">
                        </asp:DropDownList>
                    </EditItemTemplate>
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
