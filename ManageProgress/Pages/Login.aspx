<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ManageProgress.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>ログイン</title>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/popper.js"></script>
    <style>
        :root {
            --jumbotron-padding-y: 3rem;
        }

        .alert {
            color: red;
        }

        .jumbotron {
            padding-top: var(--jumbotron-padding-y);
            padding-bottom: var(--jumbotron-padding-y);
            margin-bottom: 0;
            background-color: #fff;
        }

        @media (min-width: 768px) {
            .jumbotron {
                padding-top: calc(var(--jumbotron-padding-y) * 2);
                padding-bottom: calc(var(--jumbotron-padding-y) * 2);
            }
        }

        .jumbotron p:last-child {
            margin-bottom: 0;
        }

        .jumbotron-heading {
            font-weight: 300;
        }

        .jumbotron .container {
            max-width: 40rem;
        }

        footer {
            padding-top: 3rem;
            padding-bottom: 3rem;
        }

            footer p {
                margin-bottom: .25rem;
            }
    </style>
</head>
<body>
    <section class="jumbotron text-center">
        <div class="container">
            <h1 class="jumbotron-heading">ログイン</h1>
            <p class="lead text-muted">
                登録を行っていない場合はユーザ登録を行ってください
            </p>
            <p><a href="Register.aspx">>ユーザ登録</a></p>
        </div>
    </section>
    <form id="form1" class='form-horizontal' runat="server">
        <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-4">
                <div class="form-group form-group-lg">
                    <asp:Label ID="loginAlert" CssClass="text-center alert" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="form-group form-group-lg">
                        <label>ユーザID</label>
                        <asp:TextBox runat="server" CssClass="form-control input-lg" ID="userId" placeholder="UserId" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="form-group form-group-lg">
                        <label>パスワード</label>
                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control input-lg" ID="pass" placeholder="Password" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <asp:Button ID="LoginButton" CssClass="btn btn-muted" runat="server" Text="ログイン" OnClick="Login_Click" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
