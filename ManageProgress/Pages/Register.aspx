<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ManageProgress.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>ユーザ登録</title>
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
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#">進捗管理アプリ</a>
        <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#Navber" aria-controls="Navber" aria-expanded="false" aria-label="ナビゲーションの切替">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="Navber">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="Register.aspx">ユーザ登録 <span class="sr-only">(現位置)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Login.aspx">ログイン</a>
                </li>
            </ul>
            <form class="form-inline my-2 my-lg-0">
                
            </form>
        </div>
        <!-- /.navbar-collapse -->
    </nav>
    <main role="main">
        <section class="jumbotron text-center">
            <div class="container">
                <h1 class="jumbotron-heading">ユーザ登録</h1>
                <p class="lead text-muted">
                    新しく進捗管理を作成する際はユーザ登録をおこなってください。
                進捗管理に参加するのみの場合は登録する必要ありません。
                </p>
            </div>
        </section>
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="form-group form-group-lg">
                        <asp:Label ID="registerAlert" CssClass="text-center alert" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="form-group form-group-lg">
                            <label>ユーザID(15文字以内)</label>
                            <asp:TextBox runat="server" CssClass="form-control input-lg" ID="userId" placeholder="UserId" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="form-group form-group-lg">
                            <label>メールアドレス</label>
                            <asp:TextBox runat="server" TextMode="email" class="form-control input-lg" ID="email" placeholder="Email" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="form-group form-group-lg">
                            <label>パスワード(15文字以内)</label>
                            <asp:TextBox TextMode="password" runat="server" CssClass="form-control" ID="pass" placeholder="Password" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="form-group form-group-lg">
                            <label>パスワード再入力</label>
                            <asp:TextBox runat="server" TextMode="password" CssClass="form-control" ID="rePass" placeholder="Password" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <asp:Button CssClass="btn btn-muted" runat="server" Text="登録" OnClick="Unnamed1_Click" />
                    </div>
                </div>
            </div>
        </form>
    </main>
</body>
</html>
