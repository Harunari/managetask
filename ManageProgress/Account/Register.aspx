<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ManageProgress.Account.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Eメール入力エリア -->
            <div class="form-group">
                <label>Email address</label>
                <input type="email" class="form-control" placeholder="Email"/>
            </div>
            <!-- パスワード入力エリア -->
            <div class="form-group">
                <label>Password</label>
                <input type="password" class="form-control" placeholder="Password"/>
            </div>
            <!-- ファイルアップロード -->
            <div class="form-group">
                <label>File input</label>
                <input type="file"/>
            </div>
            <!-- チェックボックス -->
            <div class="checkbox">
                <input type="checkbox"/>
                Check me out
            </div>
            <!-- 送信ボタン -->
            <button type="submit" class="btn btn-default">Submit</button>
        </div>
    </form>
</body>
</html>
