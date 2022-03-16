<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewProjectList.aspx.cs" Inherits="TMS.ViewProjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="CSS/GridViewStyle.css" />
    <link rel="stylesheet" href="CSS/DDLPopUpStyle.css" />

    <div>
        <h3>Project List</h3>
        <br />
        <asp:ImageButton ID="btnUnarchived" runat="server" Style="margin-bottom: 8px; margin-left: -30px;" AlternateText="Archive" Height="75px" ImageUrl="~/Image/ongoingIcon.png" Width="160px" ImageAlign="Bottom" OnClick="Ongoing_Click" Visible="False" />
        <asp:ImageButton ID="btnArchived" runat="server" Style="margin-bottom: 8px; " AlternateText="Archive" Height="75px" ImageUrl="~/Image/ArchiveIcon.png" Width="93px" ImageAlign="Bottom" OnClick="Archived_Click" />

        <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" DataKeyNames="project_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="RowDataBound"
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

                <asp:TemplateField HeaderText="Project ID" Visible="false">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="lblPojectID" runat="server" Text='<%# Eval("project_id" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Name">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("project_name" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Description">
                    <ItemStyle Width="380px" />
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("project_des" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_comment" runat="server" TextMode="MultiLine" Style="background-color: #F6F1DB; color: black; max-width: 600px;" Text='<%#Eval("project_des") %>' max-width="600px" Width="600px" Height="50px"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Status">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="lblProjectStatus" runat="server" Text='<%# Eval("project_status" ) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatusType" runat="server" BackColor="#F6F1DB" ForeColor="Black"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Department">
                    <ItemStyle Width="150px" />
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("department" ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div align="center">No records found.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>



</asp:Content>
