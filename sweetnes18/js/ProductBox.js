$(document).ready(function () {
    $('.close-hide').click(function () {
        $("#wrapper").removeClass("toggled");
        $(".overlay").hide();
        $(".close-hide").hide();
        $('.hamburger img').attr('src', '/img/app-icon.png');
    });
    $('.hamburger').click(function () {
        $(".close-hide").show();
        $(".overlay").show();
        $("#wrapper").addClass("toggled");
    });

});