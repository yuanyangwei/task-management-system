<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UpdateProfileDetails.aspx.cs" Inherits="TMS.UpdateProfileDetails" %>

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
            <legend>My Profile</legend>

            <asp:Table ID="Table1" runat="server" Height="126px" Width="1067px" Style="margin-top: 0">
                <asp:TableRow runat="server">
                    <asp:TableCell>Full Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFName" runat="server" Style="max-width:400px; width: 350px;" Enabled="False"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Contact:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtContact" runat="server" Style="max-width:400px; width: 350px;" />
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
                        <asp:TextBox ID="txtDepartment" runat="server" Style="max-width:400px; width: 350px;" Enabled="False"></asp:TextBox>
                    </asp:TableCell><asp:TableCell>Designation:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtDesignation" runat="server" Style="width: 300px;" Enabled="False"></asp:TextBox>
                    </asp:TableCell></asp:TableRow></asp:Table></fieldset> <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Button ID="btn_Edit" runat="server" BackColor="#163a55" OnClick="btn_Edit_Click" Text="Update" BorderColor="#163A55" Font-Bold="True" ForeColor="White" Width="160px" Height="40px" class="btn btn-light" UseSubmitBehavior="False" /><br />
        <br />
    </div>
</asp:Content>

