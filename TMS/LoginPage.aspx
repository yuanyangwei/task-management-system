<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Blank.Master" CodeBehind="LoginPage.aspx.cs" Inherits="TMS.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
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
    <body>
        <div class="img js-fullheight" style="background-image: url(Image/bg.jpg)";>
            <section class="ftco-section">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-6 text-center mb-5">
                            <h2 class="heading-section" style="color: #163a55; font-size: 50px; font-weight: bold; margin: 0; font-family: 'Trocchi', serif;">TMS</h2>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-6 col-lg-4">
                            <div class="login-wrap p-0">
                                <form action="#" class="signin-form">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsername" class="form-control" placeholder="Username" runat="server" Style="width: 100%" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                            runat="server"
                                            ControlToValidate="txtUserName"
                                            ErrorMessage="Please Enter Your Username"
                                            SetFocusOnError="false">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="passwordfield" class="form-control" placeholder="Password" runat="server" Style="width: 100%" name="password" TextMode="Password" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                            runat="server"
                                            ControlToValidate="passwordfield"
                                            ErrorMessage="Please Enter Your Password"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>

                                        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" BackColor="#F5CBA7" Font-Size="Medium" runat="server" />
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="LoginButton" class="form-control btn btn-primary submit px-3" runat="server" Text="Sign In" OnClick="LoginButton_Click" />
                                    </div>
                                    <div> 
                                        <a href="ForgetPassword" style="color: #fff; margin-right:10px; float:right; text-decoration:underline">Forgot Password</a>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </body>
    </html>
</asp:Content>
