"use strict";
let countTask = 1;

window.onload = () => {
    countTask = 1;
    let data = {
        userId: "",
    };

    $.ajax({
        type: "POST",
        url: '<%= ResolveUrl("../API/GetJsonString.aspx/GetRegisteredProgresses")%>',
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
        "<table id='table' class='table table-hover'>" +
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
            "<tr>" +
            "<td>" + progresses[i].title + "</td>" +
            "<td>" + progresses[i].dateTimeRegistered + "</td>" +
            "<td>" + progresses[i].numberOfItems + "</td>" +
            "</tr>";
    }
    tag += "" +
        "<tbody>" +
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
        "<label>タスク" + countTask + "</label>" +
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
    // TODO: ライブラリ使うべき　https://kishiken.com/bootstrap/validator.html
    if ($('#password').val() === "") {
        $('#passAlert').css("color", "red");
        $('#passAlert').text("パスワードを入力してください");
    } else {
        json = {
            title: $('#title').val(),
            password: $('#password').val(),
            task1: $('#task1').val()
        };

        // モーダルのフォームを初期化
        $('#passAlert').text("");
        $('#title').val('');
        $('#password').val('');
        $('#task1').val('');
        
        // オブジェクトにtask2以降のフォームの中身を追加し初期化
        let addedTask = document.getElementById("addedTask");
        for (let i = 0; i < countTask - 1; i++) {
            let item = addedTask.childNodes[i].childNodes[1];
            json[item.id] = item.value;
            item.value = "";
        }
        
        // モーダルを消す
        $('#registerNew').modal('hide');

    }

    // ajaxでjsonをサーバへPOSTで送る
    $.ajax({
        type: "POST",
        url: '<%= ResolveUrl("../API/")%>',
        data: JSON.stringify(json),
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

    console.log(json);
}