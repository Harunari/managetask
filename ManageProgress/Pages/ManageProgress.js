"use strict";
let param, json;
window.onload = () => {
    let urlParam = location.search.substring(1);
    if (urlParam) {
        param = urlParam.split('=');
    }
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
        password: password,
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
            alert(xhr.status);
            alert(thrownError);
            alert(xhr.responseText);
        }
    });
}
function OnSuccessRegister(responce) {
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
        $('#join').modal('hide');
    }
    if (responce.d === "error") {
        alert("エラーが発生しました");
    }
}