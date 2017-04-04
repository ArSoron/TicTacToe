var global = {};

$(function () {
    function displayUser(response) {
        var $element = $(".alertMessage");
        $element.text(response.DisplayName);
        $element.show(500);
        setTimeout(function () { $element.hide(500); }, 5000);
    }
    function displayError(response) {
        console.log(response);
        $(".alertMessage").text(response);
    }

});
//CHAT
$(function () {

    var user = $.connection.userHub;
    user.client.setUser = function (response) {
        global.user = response;
        $("#userName").text(global.user.Login);
    }
    var game = $.connection.gameHub;
    game.client.gameStarted = function (response) {
        $("#waiting").hide();
        $("#opponent").text(response.Player1.Login === global.user.Login ? response.Player2.Login : response.Player1.Login);
        $("#game").show();
    }

    // Reference the auto-generated proxy for the hub.
    var chat = $.connection.chatHub;
    // Create a function that the hub can call back to display messages.
    chat.client.addNewMessageToPage = function (name, message) {
        // Add the message to the page.
        $('#discussion').append('<li><strong>' + htmlEncode(name)
            + '</strong>: ' + htmlEncode(message) + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Enter your name:', ''));
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        user.server.login($('#displayname').val());
        $('#sendmessage').click(function () {            
            // Call the Send method on the hub.
            chat.server.send($('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
        $('#start').click(function () {
            $("#nogame").hide();
            game.server.start();
            $("#waiting").show()
        });
    });
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}