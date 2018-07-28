<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProgress.aspx.cs" Inherits="ManageProgress.Pages.ManageProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>タスク表</title>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/popper.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#join">
                新規作成
            </button>
        </div>
        <div>
            <div class="d-table" id="taskTable">
                <div class="d-table-row">
                    <p class="d-table-cell p-2 bg-dark text-white"></p>
                    <p class="d-table-cell p-2 bg-dark text-white">大崎</p>
                    <p class="d-table-cell p-2 bg-dark text-white">亀井</p>
                    <div class="d-table-cell p-2 bg-dark text-white" runat="server">松村</div>
                </div>
                <div class="d-table-row">
                    <p class="d-table-cell p-2 bg-primary text-white">うんこする</p>
                    <p class="d-table-cell p-2  text-white" style="background-color: gray;"></p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                </div>
                <div class="d-table-row">
                    <p class="d-table-cell p-2 bg-primary text-white">御飯食べる</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                </div>
                <div class="d-table-row">
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                </div>
                <div class="d-table-row">
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
                    <p class="d-table-cell p-2 bg-primary text-white">d-table</p>
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
    </form>
</body>
<script src="ManageProgress.js"></script>
</html>
