<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="createTaskTest2.aspx.cs" Inherits="TMS.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style type="text/css">
        .auto-style1 {
            width: 100%;
            background-color: #C0C0C0;
        }
        
        .auto-style2 {
            font-size: xx-large;
        }

        .auto-style18 {
            width: 750px;
            height: 52px;
            text-align: left;
        }

        .auto-style19 {
            text-align: left;
        }

        .auto-style20 {
            text-align: left;
            width: 169px;
            height: 12px;
        }

        .auto-style21 {
            width: 750px;
            height: 12px;
            text-align: left;
        }

        .auto-style22 {
            height: 12px;
        }

        .auto-style27 {
            width: 225px;
            height: 12px;
        }

        .auto-style29 {
            width: 225px;
        }

        .auto-style31 {
            width: 169px;
            text-align: left;
            height: 52px;
        }

        .auto-style32 {
            width: 169px;
            text-align: left;
        }

        .auto-style33 {
            width: 750px;
            text-align: left;
        }

        .auto-style34 {
            width: 169px;
            text-align: left;
            height: 41px;
        }

        .auto-style35 {
            width: 750px;
            text-align: left;
            height: 41px;
        }

        .auto-style37 {
            width: 225px;
            height: 41px;
            text-align: right;
        }

        .auto-style38 {
            height: 41px;
        }

        .auto-style39 {
            width: 169px;
            text-align: left;
            height: 65px;
        }

        .auto-style40 {
            width: 750px;
            height: 65px;
        }

        .auto-style44 {
            width: 169px;
            text-align: left;
            height: 128px;
        }

        .auto-style46 {
            width: 225px;
            height: 65px;
            text-align: right;
        }

        .auto-style47 {
            height: 65px;
        }

        .auto-style49 {
            width: 341px;
            height: 128px;
        }

        .auto-style51 {
            height: 128px;
        }

        .auto-style52 {
            margin-top: 0px;
        }

        .auto-style53 {
            margin-top: 0px;
            height: 38px;
        }

        .auto-style54 {
            width: 169px;
            text-align: left;
            height: 38px;
        }

        .auto-style55 {
            width: 341px;
            height: 38px;
        }

        .auto-style57 {
            height: 38px;
        }
        .auto-style61 {
            width: 169px;
            text-align: left;
            height: 27px;
        }
        .auto-style62 {
            width: 750px;
            text-align: left;
            height: 27px;
        }
        .auto-style63 {
            width: 225px;
            height: 27px;
            text-align: right;
        }
        .auto-style64 {
            width: 225px;
            text-align: right;
        }

        
        .auto-style65 {
            text-align: left;
            height: 27px;
        }
        .auto-style66 {
            width: 341px;
            height: 128px;
            text-align: center;
        }
    </style>



    <p class="auto-style2">
        Create Task
    </p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style20"><strong>Project Nmae:</strong></td>
            <td class="auto-style21">
                <asp:TextBox ID="ProjectName" runat="server" BorderStyle="Solid" Height="33px" Width="748px" CssClass="offset-sm-0"></asp:TextBox>
            </td>
            <td class="auto-style27"></td>
            <td class="auto-style22"></td>
        </tr>
        <tr >
            <td class="auto-style61"></td>
            <td class="auto-style62">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ProjectName" ErrorMessage="Project name can't be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style63"></td>
            <td class="auto-style65">
            </td>
        </tr>
        <tr>
            <td class="auto-style31"><strong>Task Name:</strong></td>
            <td class="auto-style18">
                <asp:TextBox ID="TaskName" runat="server" BorderStyle="Solid" Height="33px" Width="749px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style32">&nbsp;</td>
            <td class="auto-style33">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TaskName" ErrorMessage="Task name can't be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style32"><strong>Task Comment:</strong></td>
            <td class="auto-style33">
                <asp:TextBox ID="TextBox3" runat="server" Height="94px" Width="744px" TextMode="MultiLine" ReadOnly="True">NULL</asp:TextBox>
            </td>
            <td class="auto-style64"><strong>Task Description:</strong></td>
            <td class="text-sm-center">
                <asp:TextBox ID="TextBox4" runat="server" Height="94px" Width="744px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style34"><strong>Task Status:</strong></td>
            <td class="auto-style35">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="32px" Width="305px" >
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem Value="Reviewed">Reviewed</asp:ListItem>
                    <asp:ListItem>Ongoing</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style37"><strong>Priority:</strong></td>
            <td class="auto-style38">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="32px" Width="309px" >
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem Value="Reviewed">Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style54"><strong>Assignee:</strong></td>
            <td class="auto-style55">
                <asp:DropDownList ID="DropDownList5" runat="server" Height="30px" Width="331px">
                    <asp:ListItem>Select From Database</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style57"></td>
            <td class="auto-style53"></td>
        </tr>
        <tr>
            <td class="auto-style39"><strong>Start Date:</strong></td>
            <td class="auto-style40">
                <asp:TextBox ID="cal_start" runat="server" Height="30px" Width="196px"></asp:TextBox>

                <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png" Width="32px" OnClick="ImageButton1_Click1" />

            </td>
            <td class="auto-style46"><strong>End Date:</strong></td>
            <td class="auto-style47">
                <asp:TextBox ID="cal_end" runat="server" Height="30px" Width="196px"></asp:TextBox>

                <asp:ImageButton ID="ImageButton2" runat="server" Height="31px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png" Width="33px" OnClick="ImageButton2_Click1" />

            </td>
        </tr>
        <tr runat="server" id="hide_calendar_row">
            <td class="auto-style44"></td>
            <td class="auto-style49">
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </td>
            <td class="auto-style51"></td>
            <td class="auto-style52">
                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr">
            <td class="auto-style44">&nbsp;</td>
            <td class="auto-style66">
                <asp:Button ID="CreateTaskButton" runat="server" Height="48px" Text="Create" Width="167px" OnClick="CreateTaskButton_Click" />
            </td>
            <td class="auto-style51">&nbsp;</td>
            <td class="auto-style52">
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
