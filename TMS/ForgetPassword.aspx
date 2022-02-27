<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="TMS.ForgetPassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

    <head>
        <script src="Scripts/jquery.min.js"></script>
        <script src="Scripts/popper.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/main.js" type="text/javascript"></script>

        <title>TMS</title>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

        <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet" />

        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

        <link rel="stylesheet" href="CSS/LoginStyle.css" />


    </head>
    <%--<body class="img js-fullheight" style="background-image: url(Image/LoginBG.jpg); height: 1406px">--%>
    <body>
        <div class="img js-fullheight" style="background-image: url(Image/bg.jpg);">
            <section class="ftco-section" style="padding:0px">
                <div class="container" style="max-width:1200px; padding-top:12%">
                    <div class="row justify-content-center">
                        <div class="col-md-6 text-center mb-5">
                            <h2 class="heading-section" style="color: #163a55; font-size: 50px; font-weight: bold; margin: 0; font-family: 'Trocchi', serif;">TMS</h2>
                        </div>
                    </div>
                    <div class="row justify-content-center" style="border-style: solid; background-color: antiquewhite;">
                        <h5 style="margin-top:15px; margin-left:30px;">Forgot your password? Dont worry! Just fill in your username and email. We will send you a link to reset your password.</h5>
                        <div class="col-md-6 col-lg-4">
                            <div class="login-wrap p-0">
                                <%--<form action="#" class="signin-form">--%>
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="Email:" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="350px" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="LoginButton" class="form-control btn btn-primary submit px-3" runat="server" OnClick="btn_Submit_Click" style="width:350px; height:32px; margin-bottom:15px;" Text="Reset Password" /> <br />
                                        <asp:Button ID="LoginButton1" class="form-control btn btn-primary submit px-3" runat="server" OnClick="btn_Login_Click" style="width:350px; height:32px" Text="Login" />
                                    </div>
                                    <br />
                               <%-- </form>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </body>
</asp:Content>
