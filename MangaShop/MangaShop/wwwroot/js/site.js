var connection = new signalR.HubConnectionBuilder().withUrl("/ConversasHub").build();

connection.on("ReceiveMessage", function (userId, message) {
    var msg = message;
    var li = document.createElement("li");
    var divMessage = document.createElement("div")
    divMessage.classList.add("message")
    divMessage.textContent = msg
    li.append(divMessage);
    if (id == userId) { li.classList.add("me") }
    else { li.classList.add("you") }
    $('#chat').prepend(li);
});

connection.start();

$("#btnSend").on("click", function () {
    var userId = $.;
    var message = $("#txtMsg").val();

    connection.invoke("SendMessage", userId, message);
})