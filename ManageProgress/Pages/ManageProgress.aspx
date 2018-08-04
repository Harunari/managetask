<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProgress.aspx.cs" Inherits="ManageProgress.Pages.ManageProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>タスク表</title>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/popper.js"></script>
    <style>
        .headerCell {
            height:100px;
            width: 100px;
        }

        .taskCell {
            background-color: #a0c238;
            height: 100px;
            width: 100px;
            
        }

        .achiveCell {
            height: 100px;
            width: 100px;
        }

        .normalCell {
            background-color: white;
            height: 100px;
            width: 100px;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-4">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#join">
                        参加
                    </button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-10 col-md-offset-2">
                    <div id="tb" class="container table-responsive"></div>
                </div>
            </div>
        </div>
        
        <div class="modal fade" id="join" tabindex="-1" role="dialog" aria-labelledby="#joinTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="joinTitle">参加登録</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="閉じる">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div id="nameAlert"></div>
                            <label>名前</label>
                            <input type="text" id="name" class="form-control" />
                        </div>
                        <div class="form-group">
                            <div id="passAlert"></div>
                            <label>パスワード</label>
                            <input type="password" id="password" class="form-control" maxlength="15" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">閉じる</button>
                        <button type="button" class="btn btn-primary" onclick="addParticipantDataToDb()">参加</button>
                    </div>
                </div>
            </div>
        </div>
    
        <div class="modal fade" id="changeProgress" tabindex="-1" role="dialog" aria-labelledby="#changeProgressTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="changeProgressTitle"></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="閉じる">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group"  id="progressRange"></div>
                        <div class="form-group">
                            <div id="progPassAlert" style="color:red;"></div>
                            <label>パスワード</label>
                            <input type="password" id="progPass" class="form-control" maxlength="15" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">閉じる</button>
                        <button type="button" class="btn btn-primary" onclick="ChangeProgressToDb()">変更</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="ManageProgress.js"></script>
</html>
