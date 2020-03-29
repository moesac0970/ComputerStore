"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var split = document.cookie.split("BearerToken=");
var token = split[0].split("bearerToken=")[1];
$("#btnSend").attr("disabled", true);


connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt").replace(/>/g, "&gt;");
    var encodeMsg = msg;
    $("#messageList").append(   
        "<div class='msg'> <div class='bubble'> <div class='txt'> <span class='name'>"
        + user + 
        "</span> <span class='message'>" +
        encodeMsg +
        "</span> </div>  <div class='bubble-arrow'></div> </div> </div>"
    );
});

connection.start().then(function () {
    $("#btnSend").attr("disabled", false);

}).catch(function (err) {
    alert(err.toString());
});

$("#btnSend").on("click", function () {
    var user = $("#txtUserName").val();
    var message = $("#txtMessage").val();

    if (user !== "" && message !== "") {
        connection.invoke("SendMessage", user, message, token).catch(function () {
            return alert(err.toString());
        });

        event.preventDefault();
    }
})