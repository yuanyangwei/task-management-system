<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createTaskTest.aspx.cs" Inherits="TMS.CreateNewTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            text-align: right;
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
        .auto-style23 {
            width: 341px;
            text-align: left;
            height: 52px;
        }
        .auto-style24 {
            width: 341px;
            height: 12px;
        }
        .auto-style25 {
            width: 341px;
        }
        .auto-style27 {
            width: 225px;
            height: 12px;
        }
        .auto-style28 {
            width: 225px;
            text-align: right;
            height: 52px;
        }
        .auto-style29 {
            width: 225px;
        }
        .auto-style31 {
            width: 169px;
            text-align: right;
            height: 52px;
        }
        .auto-style32 {
            width: 169px;
            text-align: right;
        }
        .auto-style33 {
            width: 750px;
            text-align: left;
        }
        .auto-style34 {
            width: 169px;
            text-align: right;
            height: 41px;
        }
        .auto-style35 {
            width: 750px;
            text-align: left;
            height: 41px;
        }
        .auto-style36 {
            width: 341px;
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
            text-align: center;
            height: 65px;
        }
        .auto-style40 {
            width: 750px;
            height: 65px;
        }
        .auto-style44 {
            width: 169px;
            text-align: center;
            height: 128px;
        }
        .auto-style45 {
            width: 341px;
            height: 65px;
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
        .auto-style50 {
            width: 225px;
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
            text-align: center;
            height: 38px;
        }
        .auto-style55 {
            width: 341px;
            height: 38px;
        }
        .auto-style56 {
            width: 225px;
            height: 38px;
        }
        .auto-style57 {
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style2">
            Create Task</p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style20"><strong>Project Nmae:</strong></td>
                <td class="auto-style21">
                    <asp:TextBox ID="ProjectName" runat="server" BorderStyle="Solid" Height="23px" Width="748px"></asp:TextBox>
                </td>
                <td class="auto-style24">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProjectName" ErrorMessage="Project name can't be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style27"></td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style31"><strong>Task Name:</strong></td>
                <td class="auto-style18">
                    <asp:TextBox ID="TaskName" runat="server" BorderStyle="Solid" Height="33px" Width="749px"></asp:TextBox>
                </td>
                <td class="auto-style23">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TaskName" ErrorMessage="Task name can't be empty" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style28"><strong>Task Description:</strong></td>
                <td class="auto-style19" rowspan="2">
                    <asp:TextBox ID="TaskDescription" runat="server" BorderStyle="Solid" Height="158px" Width="936px" CssClass="auto-style52"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style32"><strong>Task Comment:</strong></td>
                <td class="auto-style33">
                    <asp:TextBox ID="TextBox3" runat="server" Height="114px" Width="744px"></asp:TextBox>
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style29">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style34"><strong>Task Status:</strong></td>
                <td class="auto-style35">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="32px" Width="305px">
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem Value="Reviewed">Reviewed</asp:ListItem>
                        <asp:ListItem>Ongoing</asp:ListItem>
                        <asp:ListItem>Completed</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style36"></td>
                <td class="auto-style37"><strong>Priority:</strong></td>
                <td class="auto-style38">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="277px">
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
                <td class="auto-style56"></td>
                <td class="auto-style57"></td>
                <td class="auto-style53">
                </td>
            </tr>
            <tr>
                <td class="auto-style39"><strong>Start Date:</strong></td>
                <td class="auto-style40">
                    <asp:TextBox ID="cal_start" runat="server" Height="30px" Width="196px"></asp:TextBox>
         
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png"  Width="32px" OnClick="ImageButton1_Click1" />
 
                </td>
                <td class="auto-style45"></td>
                <td class="auto-style46"><strong>End Date:</strong></td>
                <td class="auto-style47">
                    <asp:TextBox ID="cal_end" runat="server" Height="30px" Width="196px"></asp:TextBox>
         
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="31px" ImageAlign="Middle" ImageUrl="~/Image/Calendar.png"  Width="33px" OnClick="ImageButton2_Click1" />
 
                </td>
            </tr>
            <tr runat="server" id="hide_calendar_row">
                <td class="auto-style44"></td>
                <td class="auto-style49">
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
                <td class="auto-style50">&nbsp;</td>
                <td class="auto-style51"></td>
                <td class="auto-style52">
                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
