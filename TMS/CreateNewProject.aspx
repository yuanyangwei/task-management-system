<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CreateNewProject.aspx.cs" Inherits="TMS.CreateNewProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        legend {
            background-color: #163a55;
            color: #fff;
            padding: 3px 6px;
        }

        fieldset {
            margin-bottom: auto;
            margin-right: auto;
            border-style: solid;
            border-width: thin;
            border-color: slategray;
            min-width: inherit;
            padding: 15px;
        }

        th, td {
            padding: 8px
        }
    </style>

    <div>
        <br />
        <fieldset style="width: 100%;">
            <legend>Create New Project</legend>
            <asp:Table ID="Table1" runat="server" Height="126px" Width="800px">
                <asp:TableRow runat="server">
                    <asp:TableCell>Project Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtProjectName" runat="server" Style="max-width: 500px; width: 500px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                            runat="server"
                            ControlToValidate="txtProjectName"
                            ErrorMessage="Please Enter Your Project Name"
                            SetFocusOnError="True"> *</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                            runat="server"
                            ControlToValidate="txtProjectName"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Project Description:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtProjectDesc" runat="server" Style="max-width: 500px; width: 500px; height: 200px;" TextMode="MultiLine" />
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Project Status:</asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlProjectStatus" runat="server" Style="width: 500px; height: 26px;">
                            <asp:ListItem>Ongoing</asp:ListItem>
                            <asp:ListItem>Completed</asp:ListItem>
                            <asp:ListItem>Suspend</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
        </fieldset>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Font-Size="Medium" />
        <asp:Button ID="btn_create" runat="server" BackColor="#163a55" OnClick="btn_create_Click" Text="Create" BorderColor="#163A55" Font-Bold="True" ForeColor="White" Width="160px" Height="40px" class="btn btn-light" /><br />
    </div>
    <br />




</asp:Content>
