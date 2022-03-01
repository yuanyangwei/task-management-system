<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="TMS.UserRegistration" %>

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
            padding: 5px
        }
    </style>

    <br />
    <div>
        <br />
        <fieldset style="width: 100%;">
            <legend>User Registration</legend>

            <asp:Table ID="Table1" runat="server" Height="126px" Width="1067px" Style="margin-top: 0">
                <asp:TableRow runat="server">
                    <asp:TableCell>Full Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFName" runat="server" Style="width: 300px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="txtFName"
                            ErrorMessage="Please Enter Your Full Name"
                            SetFocusOnError="True">**</asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Contact:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtContact" runat="server" Style="width: 300px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server"
                            ControlToValidate="txtContact"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server"
                            ControlToValidate="txtContact" Display="None"
                            ErrorMessage="Invalid contact number format, contact should consist of 8 digits, starting with either 8 or 9. Example: 91234567."
                            ValidationExpression="^[89]\d{7}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="txtContact"
                            ErrorMessage="Please Enter Your Contact Number"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </asp:TableCell><asp:TableCell>Email:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtEmail" runat="server" Style="width: 300px; text-transform: lowercase;" TextMode="Email" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                            runat="server"
                            ControlToValidate="txtEmail"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Please Enter Your Email"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell>Department:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlDepartment" runat="server" Style="width: 300px; height: 26px;"></asp:DropDownList>
                    </asp:TableCell><asp:TableCell>Designation:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlDesignation" runat="server" Style="width: 300px; height: 26px;"></asp:DropDownList>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell ColumnSpan="4"><hr style="margin-left:0px; width:95%;"></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Username:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtUserName" runat="server" Style="width: 300px; text-transform: lowercase;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                            runat="server"
                            ControlToValidate="txtUserName"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                            runat="server"
                            ControlToValidate="txtUserName"
                            ErrorMessage="Please Enter Your Username"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </asp:TableCell><asp:TableCell>Role Type:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlRoleType" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>Normal User</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell>Access Type:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlAccessType" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>User</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell></asp:TableRow></asp:Table></fieldset> <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Button ID="btn_create" runat="server" BackColor="#163a55" OnClick="btn_create_Click" Text="Create" BorderColor="#163A55" Font-Bold="True" ForeColor="White" Width="160px" Height="40px" class="btn btn-light" UseSubmitBehavior="False" /><br />
        <br />
    </div>


</asp:Content>
