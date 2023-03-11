
const handleNewMessageReceiving = (message) => {
    alert(message);
}

$(() => {
    registerMessageReceiveListener(handleNewMessageReceiving);

    $("#btnSendMessage").on("click", () => {
        var message = $("#txtMessage").val();
        sendMessage(message);
    });     
})

