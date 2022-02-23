<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="TMS.PasswordReset" %>

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
            padding-left: 50px;
            padding-right: 50px;
            font-size: large;
        }
    </style>

    <div>
        <br />
        <fieldset style="width: 100%;">
            <legend>Password Reset</legend>
            <asp:Table ID="Table1" runat="server" Height="126px" Width="800px">
                <asp:TableRow runat="server">
                    <asp:TableCell>New Password:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtPassword" runat="server" Style="max-width: 500px; width: 443px" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                            runat="server"
                            ControlToValidate="txtPassword"
                            ErrorMessage="Please Enter Your Password"
                            SetFocusOnError="True"> *</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPassword"
                            runat="server"
                            ControlToValidate="txtPassword" Display="None"
                            ErrorMessage="Your password must be a minimum of 8 characters that consist numbers, uppercase, lowercase and special number."
                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell>Confirm Password:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" Style="max-width: 500px; width: 443px" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                            runat="server"
                            ControlToValidate="txtConfirmPassword"
                            ErrorMessage="Please Enter Your Confirm Password"
                            SetFocusOnError="True"> * </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" Display="None"
                            ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password Mismatch.">
                        </asp:CompareValidator>
                    </asp:TableCell></asp:TableRow></asp:Table><br />
        </fieldset>
          <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Font-Size="Medium" />
        <asp:Button ID="btn_update" runat="server" BackColor="#163a55" OnClick="btn_update_Click" Text="Update" BorderColor="#163A55" Font-Bold="True" ForeColor="White" Width="160px" Height="40px" class="btn btn-light" /><br />
    </div>
    <br />
</asp:Content>
