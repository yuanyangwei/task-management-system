<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs" Inherits="TMS.CreateTask" %>

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

    <br />
    <div>
        <br />
        <fieldset style="width: 100%;">
            <legend>Create Task</legend>
            <asp:Table ID="Table1" runat="server" Height="126px" Width="1067px" Style="margin-top: 0">
                <asp:TableRow runat="server">
                    <asp:TableCell>Project Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFName" runat="server" Style="width: 300px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="txtFName"
                            ErrorMessage="Project name cannot be empty"
                            SetFocusOnError="True">* </asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Task Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtContact" runat="server" Style="width: 300px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server"
                            ControlToValidate="txtContact"
                            ErrorMessage="Task name cannot be empty"
                            SetFocusOnError="True">* </asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Task Comment:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="commentTB" runat="server" Style="width: 300px" TextMode="MultiLine" />
                    </asp:TableCell><asp:TableCell>Task Description: </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="descriptionTB" runat="server" Style="width: 300px" TextMode="MultiLine" />
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Task Status:</asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="statusDropDownList" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>Review</asp:ListItem>
                            <asp:ListItem>Ongoing</asp:ListItem>
                            <asp:ListItem>Complete</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>Priority:</asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="priorityDropDownList" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>High</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Assignee:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="DropDownList1" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>Select From Database</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell ColumnSpan="4"><hr style="margin-left:0px; width:95%;" /></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Start Date:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtStart" runat="server" Style="width: 300px" />
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png" Width="25px" Style="margin-top: -11px; margin-left: 10px;" OnClick="ImageButton1_Click1" />
                    </asp:TableCell>
                    <asp:TableCell>Due Date:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtEnd" runat="server" Style="width: 300px" />
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png" Width="25px" Style="margin-top: -11px; margin-left: 10px;" OnClick="ImageButton2_Click1" />
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>.</asp:TableCell>
                    <asp:TableCell>
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Style="margin-top: -11px; margin-left: 10px;"></asp:Calendar>
                    </asp:TableCell>
                    <asp:TableCell>.</asp:TableCell>
                    <asp:TableCell>
                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Style="margin-top: -11px; margin-left: 10px;"></asp:Calendar>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </fieldset>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Button ID="btn_create" runat="server" BackColor="#163a55" OnClick="btn_create_Click" Text="Create" BorderColor="#163A55" Font-Bold="True" ForeColor="White" Width="160px" Height="40px" class="btn btn-light" /><br />
        <br />
    </div>


</asp:Content>
