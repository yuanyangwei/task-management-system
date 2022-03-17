<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ManagerUpdateTask.aspx.cs" Inherits="TMS.ManagerUpdateTask" %>

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
        <fieldset style="width: 100%;">
            <legend>Update Task</legend>
            <asp:Table ID="Table1" runat="server" Height="126px" Width="1067px" Style="margin-top: 0">
                <asp:TableRow runat="server">
                    <asp:TableCell>Project Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlProjectName" runat="server" Style="width: 300px; height: 26px;">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell>Task Name:</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtTaskName" runat="server" Style="width: 300px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server"
                            ControlToValidate="txtTaskName"
                            ErrorMessage="Task name cannot be empty"
                            SetFocusOnError="True">* </asp:RequiredFieldValidator>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell>Task Comment:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtComment" runat="server" Style="width: 300px" TextMode="MultiLine" />
                    </asp:TableCell><asp:TableCell>Task Description: </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtDescription" runat="server" Style="width: 300px" TextMode="MultiLine" />
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell>Task Status:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlTaskStatus" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>In Progress</asp:ListItem>
                            <asp:ListItem>Completed</asp:ListItem>
                            <asp:ListItem>Delay</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell><asp:TableCell>Priority:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlPriority" runat="server" Style="width: 300px; height: 26px;">
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>High</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell></asp:TableRow><asp:TableRow ID="AssigneeRow" runat="server">
                    <asp:TableCell>Assignee:</asp:TableCell><asp:TableCell>
                        <asp:DropDownList ID="ddlAssignee" runat="server" Style="width: 300px; height: 26px;">
                        </asp:DropDownList>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
                    <asp:TableCell ColumnSpan="4"><hr style="margin-left:0px; width:95%;" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell>Start Date:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtStart" runat="server" Style="width: 300px" />
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png" Width="25px" Style="margin-top: -11px; margin-left: 10px;" OnClick="ImageButton1_Click1" />
                    </asp:TableCell><asp:TableCell>Due Date:</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtEnd" runat="server" Style="width: 300px" />
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png" Width="25px" Style="margin-top: -11px; margin-left: 10px;" OnClick="ImageButton2_Click1" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>.</asp:TableCell><asp:TableCell>
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Style="margin-top: -11px; margin-left: 10px;">
                            <TodayDayStyle BackColor="#009900" />
                            <WeekendDayStyle Font-Bold="True" />
                        </asp:Calendar>
                    </asp:TableCell><asp:TableCell>.</asp:TableCell><asp:TableCell>
                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Style="margin-top: -11px; margin-left: 10px;">
                            <TodayDayStyle BackColor="#009900" />
                            <WeekendDayStyle Font-Bold="True" />
                        </asp:Calendar>
                    </asp:TableCell></asp:TableRow></asp:Table></fieldset> <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Button ID="btn_update" runat="server" BackColor="#163a55" OnClick="btn_Update_Click" Text="Update" BorderColor="#163A55" Font-Bold="True" ForeColor="White" Width="160px" Height="40px" class="btn btn-light" /><br />
        <br />
    </div>

</asp:Content>
