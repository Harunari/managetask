"use strict";
// フォームの数をカウントする変数
// 初期のフォームの数は１つ
let countTask = 1;

window.onload = () => {
    countTask = 1;
    GetTable();
    $('#result').on('click', 'table>tbody', e => {
        let progressId = e.target.parentNode.id;
        window.location.href = "ManageProgress.aspx?progressId=" + progressId;
    });
};

function OnSuccess(response) {
    if (response.d !== "nil") {
        console.log(response.d);
        let progresses = JSON.parse(response.d);
        CreateTable(progresses);
    } else {
        FailedGetJson("何も登録されていません");
    }
}
function CreateTable(progresses) {
    let tag;
    tag = "" +
        "<table id='table' class='table table-hover table-striped'>" +
        "<thead class='thead-dark'>" +
        "<tr>" +
        "<th scope='col'>題名</th>" +
        "<th scope='col'>登録日時</th>" +
        "<th scope='col'>タスク数</th>" +
        "</tr>" +
        "</thead>" +
        "<tbody>";
    for (let i = 0; i < progresses.length; i++) {
        tag += "" +
            "<tr id=" + progresses[i].id + ">" +
            "<td>" + progresses[i].title + "</td>" +
            "<td>" + progresses[i].dateTimeRegistered + "</td>" +
            "<td>" + progresses[i].numberOfItems + "</td>" +
            "</tr>";
    }
    tag += "" +
        "</tbody>" +
        "</table>";

    let resultTag = document.getElementById("result");
    resultTag.innerHTML = tag;
}
function FailedGetJson(str) {
    let resultTag = document.getElementById("result");
    resultTag.innerHTML = str;
}
function AddTaskForm() {
    if (countTask > 99) {
        return;
    }
    countTask++;
    let tag;
    let divElement = document.createElement("div");
    divElement.setAttribute('class', 'form-group');
    divElement.setAttribute('id', countTask);

    tag = "" +
        "<div class='alert1' id='task" + countTask + "Alert'></div>"+
        "<label>タスク" + countTask + "(10文字以内)</label>" +
        "<input type='text' id='task" + countTask + "' class='form-control' />";

    divElement.innerHTML = tag;
    let parentObject = document.getElementById("addedTask");
    parentObject.appendChild(divElement);

}
function RemoveTaskForm() {
    if (countTask > 1) {
        let parentObject = document.getElementById("addedTask");
        let targetElement = document.getElementById(countTask);
        parentObject.removeChild(targetElement);
        countTask--;
    }
}
function AddTaskToDB() {
    let json;
    // TODO: バリデーションはライブラリ使うべき　https://kishiken.com/bootstrap/validator.html
    if ($('#title').val() === "") {
        $('#titleAlert').text("タイトルを入力してください");
        return;
    } else if ($('#title').val().length  > 10) {
        $('#titleAlert').text("10文字以内で入力してください");
        return;
    }
    if ($('#task1').val() === "") {
        $('#task1Alert').text("入力してください");
        return;
    } else if ($('#task1').val().length > 10) {
        $('#task1Alert').text("10文字以内で入力してください");
        return;
    }
    
    if ($('#password').val() === "") {
        $('#passAlert').text("パスワードを入力してください");
        return;
    } else {
        json = {
            userId: $('#loginId').text(),
            title: $('#title').val(),
            password: $('#password').val(),
            numberOfTask: countTask,
            task1: $('#task1').val()
        };

        // オブジェクトにtask2以降のフォームの中身を追加
        let addedTask = document.getElementById("addedTask");
        for (let i = 2; i <= countTask; i++) {
            let item = addedTask.childNodes[i - 2].childNodes[2];
            let alertElement = addedTask.childNodes[i - 2].childNodes[0];
            console.log(alertElement);
            if (item.value === "") {
                alertElement.textContent = "入力してください";
                return;
            } else if (item.value.length > 10) {
                alertElement.textContent = "10文字以内で入力してください";
                return;
            }
            json[item.id] = item.value;
        }

        // 追加されたフォームを全削除
        for (let i = 2; i <= countTask; i++) {
            let targetElement = document.getElementById(i);
            addedTask.removeChild(targetElement);
        }

        // モーダルのフォーム数、フォームを初期化
        $('#passAlert').text("");
        $('#title').val('');
        $('#password').val('');
        $('#task1').val('');

        // カウント変数初期化
        countTask = 1;       
    }
    let data = JSON.stringify({ jsonString: JSON.stringify(json) });
    $.ajax({
        type: "POST",
        url: "../API/SetJsonString.aspx/SetNewProgress",
        data: data,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: OnSuccessOperateDB,
        error: (xhr, ajaxOptions, thrownError) => {
            alert("通信に失敗しました");
        }
    });
    $('#registerNew').modal('hide');
}
function OnSuccessOperateDB(response) {
    if (response.d === "success") {
        // テーブル再取得
        GetTable();
    } else {
        alert("登録失敗しました");
    }
}
function GetTable() {
    let data = {
        userId: "admin"
    };

    $.ajax({
        type: "POST",
        url: "../API/GetJsonString.aspx/GetRegisteredProgresses",
        data: JSON.stringify(data),
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        timeout: 5000,
        success: OnSuccess,
        error: (xhr, ajaxOptions, thrownError) => {
            FailedGetJson("通信に失敗しました");
        }
    });
}