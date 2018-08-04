"use strict";
let param, json, participants, tasks;
let selectedMember, currentProgress;
window.onload = () => {
    try {
        let urlParam = location.search.substring(1);
        if (urlParam) {
            param = urlParam.split('=');
        }
        AjaxCommunication();
    } catch (e) {
        window.close();
    }

    // 名前を押したとき進捗調整できる
    $("#tb").on('click', '#taskTable>#header>p', e => {
        if (e.target.innerText === "タスク名") {
            return;
        }
        selectedMember = e.target.innerText;
        $('#changeProgress').modal();
        let selected = document.getElementById("changeProgressTitle");
        selected.innerText = "進捗管理" + "(" + selectedMember + ")";
        let rangeParentTag = document.getElementById("progressRange");
        let tag = "" +
            "<input id='currentProgress' min='0'" +
            "max='" +
            tasks.length +
            "' step='1' type='range' />" +
            "<span id='value'></span>";
        rangeParentTag.innerHTML = tag;
        let elem = rangeParentTag.childNodes[0];
        let target = rangeParentTag.childNodes[1];
        target.innerHTML = elem.value;
        currentProgress = elem.value;
        let rangeValue = (elem, target) => {
            return function (evt) {
                target.innerHTML = elem.value;
                currentProgress = elem.value;
            }
        }
        rangeValue(elem, target);
        elem.addEventListener('input', rangeValue(elem, target));
    });

};
function ChangeProgressToDb() {
    json = {
        progressId: param[1],
        participantName: selectedMember,
        currentProgress: currentProgress,
        progPassword: $('#progPass').val()
    };
    console.log($('#progPass').val())

    let strData = JSON.stringify(json);

    $.ajax({
        type: "POST",
        url: "../API/SetJsonString.aspx/ChangeProgress",
        data: JSON.stringify({ jsonString: strData }),
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        timeout: 5000
    }).done(data => {
        console.log(data);
        if (data.d === "error") {
            $('#progPassAlert').text("サーバ内部でエラーが発生しました");
            return;
        } else if (data.d === "nil") {
            $('#progPassAlert').text("データが存在しません");
            return;
        } else if (data.d === "wrongPassword") {
            $('#progPassAlert').text("パスワードが間違っています");
            return;
        } else {
            AjaxCommunication();
        }
    }).fail(data => {
        alert("通信に失敗しました");
    });
}
function AjaxCommunication() {
    let data = JSON.stringify({ strProgressId: param[1] });
    $.ajax({
        type: "POST",
        url: "../API/GetJsonString.aspx/GetParticipants",
        data: data,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        timeout: 5000,
        success: OnSuccessGetParticipants,
        error: (xhr, ajaxOptions, thrownError) => {
            alert("通信に失敗しました");
        }
    });
    $.ajax({
        type: "POST",
        url: "../API/GetJsonString.aspx/GetTasks",
        data: data,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        timeout: 5000,
        success: OnSuccessGetTasks,
        error: (xhr, ajaxOptions, thrownError) => {
            alert("通信に失敗しました");
        }
    });
}
function CreateTable(members, tks) {
    let tag;
    let width = (members.length + 2) * 50;
    console.log(width);
    tag = "" +
        "<div id='taskTable' style='overflow:auto;width:" + width + "px'>" +
        "<div class='d-table-row' id='header'>" +
        "<p class='d-table-cell p-2 bg-dark text-white'>" +
        "タスク名" +
        "</p>";
    for (let i = 0; i < members.length; i++) {
        tag += "" +
            "<p class='d-table-cell p-2 bg-dark text-white'>" +
            members[i].participantName +
            "</p>";
    }
    tag += "</div>";
    for (let i = 1; i <= tks.length; i++) {
        tag += "" +
            "<div class='d-table-row'>" +
            "<p class='d-table-cell p-2 bg-dark text-white'>" +
            i + "." +
            tks[i - 1].task +
            "</p>";
        for (let j = 0; j < members.length; j++) {
            // tks[i].taskのタスクが終わっているかどうか
            if (members[j].currentProgress >= i) {
                tag += "<p class='d-table-cell p-2 bg-primary text-white'>済み</p>";
            } else {
                tag += "<p class='d-table-cell p-2  text-white' style='background-color: gray;'></p>";
            }
        }
        tag += "</div>";
    }
    tag += "</div>";
    let resultTag = document.getElementById("tb");
    resultTag.innerHTML = tag;
}
function OnSuccessGetParticipants(response) {
    if (response.d === "error") {
        alert("サーバでエラーが発生しました");
    }
    participants = JSON.parse(response.d);
}
function OnSuccessGetTasks(response) {
    if (response.d === "error") {
        alert("サーバでエラーが発生しました");
    }
    tasks = JSON.parse(response.d);
    CreateTable(participants, tasks);
    $('#join').modal('hide');
    $('#changeProgress').modal('hide');
}
function addParticipantDataToDb() {
    // バリデーション
    let password = $('#password').val();
    let name = $('#name').val();
    if (name === "") {
        $('#nameAlert').css('color', 'red');
        $('#nameAlert').text('名前が入力されていません');

    } else {
        $('#nameAlert').text('');
    }
    if (password === "") {
        $('#passAlert').css('color', 'red');
        $('#passAlert').text('パスワードが入力されていません');
    } else {
        $('#passAlert').text('');
    }
    if (name === "" || password === "") {
        return;
    }

    json = {
        progressId: param[1],
        name: name,
        password: password
    };

    console.log(json);
    let data = JSON.stringify({ jsonString: JSON.stringify(json) });

    $.ajax({
        type: "POST",
        url: "../API/SetJsonString.aspx/SetNewParticipant",
        data: data,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: OnSuccessRegister,
        error: (xhr, ajaxOptions, thrownError) => {
            alert("通信に失敗しました");
        }
    });
}
function OnSuccessRegister(responce) {
    console.log("aaa");
    if (responce.d === "wrongPassword") {
        $('#passAlert').css('color', 'red');
        $('#passAlert').text('パスワードが異なります');
    }
    if (responce.d === "sameNameExisted") {
        $('#nameAlert').css('color', 'red');
        $('#nameAlert').text('同じ名前が既に登録されています');
    }
    if (responce.d === "registeredSuccess") {
        $('#passAlert').text('');
        $('#nameAlert').text('');
        AjaxCommunication();
    }
    if (responce.d === "error") {
        alert("エラーが発生しました");
    }
}