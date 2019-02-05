function ScrollCheckHeader() {
    if ($(this).scrollTop() >= 50) {
        $('header').addClass('staticheader animated fadeInDown');
        if ($('header').find('.hamburger').hasClass("is-open")) {
            $('header').addClass('newcontainer');
        } else {
            $('header').removeClass('newcontainer');
        }
    } else {
        $('header').removeClass('newcontainer');
        $('header').removeClass('staticheader animated fadeInDown');
    }

}
$(document).scroll(function () {
    ScrollCheckHeader();
})



/*------------All Page Validation--------------*/
$('form').parsley();
/*------------All Page Validation--------------*/
/*------------All Product Details page--------------*/
$('#thumbs img').click(function () {
    $('#largeImage').attr('src', $(this).attr('src').replace('thumb', 'large'));
    $('#description').html($(this).attr('alt'));
});

/*
 $(document).ready(function () {
    $('.add-to-cart').on('click', function () {
        //Scroll to top if cart icon is hidden on top
        $('html, body').animate({
            'scrollTop': $(".cart_anchor").position().top
        });
        //Select item image and pass to the function
        var itemImg = $(#panel).find('img').eq(0);
        flyToElement($(itemImg), $('.cart_anchor'));
    });
});
*/
/*------------All Product Details page--------------*/
function wishlistData() {
    userID = 0;

    $.ajax({
        url: "/ajax/CheckLogin",
        success: function (result) {
            if (result.Status == true) {
                userID = result.result.id;
                /*---------------------------*/
                $.ajax({
                    url: "/ajax/addwishlist?uid=" + userID + "&pid=0",
                    success: function (result) {
                        res = JSON.parse(result);
                        console.log(res);
                        for (i = 0; i < res.length; i++) {
                            console.log(res[i].ProductID);
                            $('.heart_box').each(function () {
                                id = parseInt($(this).attr('data-wishlist'));
                                pid = parseInt(res[i].ProductID);
                                if (id == pid) {
                                    $(this).attr('data-status', '1');
                                    $(this).find('i').removeClass('fa-heart-o');
                                    $(this).find('i').addClass('fa-heart');
                                }

                            })
                        }
                    }
                })
                /*******************************/

            }
        }
    })
}

$(document).on('click', '.heart_box', function () {
    var nthis = $(this);
    /*====ChkLogin=====*/
    $.ajax({
        url: "/ajax/CheckLogin",
        success: function (result) {
            if (result.Status) {
                userID = result.result.id;
                pid = nthis.attr('data-wishlist');
                // alert(nthis.attr('data-status'));
                if (nthis.attr('data-status') == 1) {

                    $.ajax({
                        url: "/ajax/removewishlist?uid=" + userID + "&pid=" + pid,
                        success: function (result) {
                            wishlistData();
                        }
                    })
                } else {
                    $.ajax({
                        url: "/ajax/addwishlist?uid=" + userID + "&pid=" + pid,
                        success: function (result) {
                            wishlistData();
                        }
                    })
                    //nthis.attr('data-status', 1);
                }

                wishlist = nthis.data('wishlist');
                nthis.find('i.fa').toggleClass('fa-heart-o');
                nthis.find('i.fa').toggleClass('fa-heart');
            } else {

                window.location.href = "/createaccount/login";

            }
        }

    });

})
$(document).ready(function () {
    ScrollCheckHeader();
    wishlistData();
    loaderhide();
    cartpageupdate();

    var trigger = $('.hamburger'),
        overlay = $('.overlay'),
        isClosed = false;

    function buttonSwitch() {
        ScrollCheckHeader();
        if (isClosed === true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            trigger.find('img').attr('src', '/img/app-icon.png');
            isClosed = false;
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
            trigger.find('img').attr('src', '/img/app-close.png');
        }
    }

    trigger.click(function () {
        buttonSwitch();
    });

    $('[data-toggle="offcanvas"]').click(function () {
        $('#wrapper').toggleClass('toggled');
    });
});