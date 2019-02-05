window.onload = function () {
    $('.brand-dtl>DIV').find('div').click(function () {
        $('.brand-dtl>DIV').find('div a').removeAttr('href'); $('.brand-dtl>DIV').find('div').removeClass('highlight'); $(this).addClass('highlight');
    })

}
$(document).ready(function () {
   
    $('#State,#city').attr('readOnly', 'readOnly');

})

var Account = angular.module('AllMyAccount', ['ngSanitize']);




$(document).on('click', '.SaveProfile', function () {
    loaderhide();
    fn = $('#fname').val();
    ln = $('#lname').val();
    add1 = $('#add1').val();
    add2 = $('#add2').val();
    email = $('#email').val();
    country = $('#contry').val();
    postal = $('#postal').val();
    state = $('#State').val();
    city = $('#city').val();
    contact = $('#contact').val();

    $.ajax({
        url: "/ajax/updateProfile",
        data: { contact: contact, city: city, fn: fn, ln: ln, add1: add1, add2: add2, email: email, country: country, postal: postal, state: state },
        success: function (result) {
            if (result == "1") {
                loaderhide(true);
                notifyMe("Your Profile Update SuccessFull", "Now Your profile update", "/img/Icon/1.png");

            }

        }

    })


})
