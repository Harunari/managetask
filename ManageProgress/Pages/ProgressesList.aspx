<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressesList.aspx.cs" Inherits="ManageProgress.Pages.ProgressesList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>進捗一覧</title>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/popper.js"></script>
    <style>
        .alert1 {
            color: red;
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
                    <a class="nav-link" href="ProgressesList.aspx">進捗管理一覧 <span class="sr-only">(現位置)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Logout.aspx">ログアウト</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Register.aspx">アカウント新規登録</a>
                </li>
            </ul>
            <ul class="navbar-nav justify-content-end">
                <li>
                    <div id="loginId" runat="server"></div>
                </li>
            </ul>
            <form class="form-inline my-2 my-lg-0">
            </form>
        </div>
        <!-- /.navbar-collapse -->
    </nav>

    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 class="display-4">進捗一覧</h1>
            <p class="lead">
                ここでは作成されたタスク管理を見ることができます。作成者で検索をかけることも可能です。
            </p>
            <hr class="my-4" />
            <p>新たなタスク管理を作成しましょう。</p>
            <p class="lead">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#registerNew">
                    新規作成
                </button>
            </p>
        </div>

        <div class="modal fade" id="registerNew" tabindex="-1" role="dialog" aria-labelledby="#registerNewTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="registerNewTitle">新規登録</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="閉じる">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div id="titleAlert" class="alert1"></div>
                            <label>タイトル(10文字以内)</label>
                            <input type="text" id="title" class="form-control" />
                        </div>
                        <div class="form-group">
                            <div id="passAlert" class="alert1"></div>
                            <label>この進捗管理のパスワード</label>
                            <input type="password" id="password" class="form-control" maxlength="15" />
                        </div>
                        <div class="form-group">
                            <label>パスワード再入力</label>
                            <input type="password" id="passwordRe" class="form-control" maxlength="15" />
                        </div>
                        <div class="form-group" id="1">
                            <div id="task1Alert" class="alert1"></div>
                            <label>タスク1(10文字以内)</label>
                            <input type="text" id="task1" class="form-control" />
                        </div>

                        <div id="addedTask"></div>

                        <div class="col-xs-offset-2 col-xs-10">
                            <input type="button" class="btn btn-default" value="タスク追加" onclick="AddTaskForm()" />
                            <input type="button" class="btn btn-default" value="タスク削減" onclick="RemoveTaskForm()" />
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">閉じる</button>
                        <button type="button" class="btn btn-primary" onclick="AddTaskToDB()">変更を保存</button>
                    </div>
                </div>
            </div>
        </div>

        <div id="result" class="container">
        </div>
    </form>


</body>
<script src="ProgressesList.js"></script>
</html>
