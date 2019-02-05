// Write your JavaScript code.



function notificationshow(type)
{
        
    setInterval(notifyMe, 500000);
}

function msgshow(msg = 'Alert', type = "success") {

    $.notify(msg, { type: type });
}


function notifyMe(title = "One more Product Add", msg = "Hey there! You've been notified!", url = "/", icon ="https://www.sweetness.ae/img/Icon/7.png") {
    
    document.addEventListener('DOMContentLoaded', function () {
        if (!Notification) {
            alert('Desktop notifications not available in your browser. Try Chromium.');
            return;
        }

        if (Notification.permission !== "granted")
            Notification.requestPermission();
    })


    if (Notification.permission !== "granted")
        Notification.requestPermission();
    else {
       
        var notification = new Notification(title, {
            icon: icon,
            body: msg,
        });

        notification.onclick = function () {
            window.open(url);
        };

    }

}  

