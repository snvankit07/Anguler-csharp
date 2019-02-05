
$(document).on('click', '.Additbtnminus,.specibtnminus', function () {

    $(this).parents('.row.deletedata').remove();
})
$(document).on('click', '.cloth-box', function (e) {
    $('.cloth-box').removeClass("active");
    $(this).addClass("active");
})


$(document).on('click', '.specibtn', function (e) {
    v = '<div><div class="boxspec"><b>Specifications(English)</b><div  class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6" ><input required type="text"  class="form-control" placeholder="Key" name="Specificationskey[]"></div><div class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6"><input required type="text"  class="form-control" placeholder="Value" name="Specificationsvalue[]"></div><div style="clear:both"></div></div>';
    v += '<div class="boxspecAr"><b>Specifications(Arabic)</b><div  class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6" ><input required type="text"  class="form-control" placeholder="Key Arabic" name="SpecificationskeyArabic[]"></div><div class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6"><input required type="text"  class="form-control" placeholder="Value Arabic" name="SpecificationsvalueArabic[]"></div><div style="clear:both"></div></div><div class="boxes specibtn btns col-lg-6 col-sm-6 col-md-6 col-xs-6"><a class="btn btn-info">+</a></div><div class="boxes specibtnminus btns col-lg-6 col-sm-6 col-md-6 col-xs-6"><a class="btn btn-danger"><i class="fa fa-trash-o" aria-hidden="true"></i></a></div>';
    $('.spec').append('<div data-aos="fade-left" class="row deletedata"><div class="container productspecborder">' + v + '</div></div>');

})

$(document).on('click', '.Additbtn', function (e) {

    v = '<div><div class="boxspec"><b>Additional Information(English)</b><div class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6" ><input required type="text"  class="form-control" placeholder="Key" name="AdditionalInformationkey[]"></div><div class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6"><input type="text" required class="form-control" placeholder="Value" name="AdditionalInformationvalue[]"></div><div style="clear:both"></div></div>';
    v += '<div class="boxspecAr"><b>Additional Information(Arabic)</b><div class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6" ><input required type="text"  class="form-control" placeholder="Key Arabic" name="AdditionalInformationkeyAr[]"></div><div class="boxes col-lg-6 col-sm-6 col-md-6 col-xs-6"><input type="text" required class="form-control" placeholder="Value Arabic" name="AdditionalInformationvalueAr[]"></div><div style="clear:both"></div></div><div class="boxes Additbtn btns col-lg-6 col-sm-6 col-md-6 col-xs-6"><a class="btn btn-info">+</a></div><div class="boxes Additbtnminus btns col-lg-6 col-sm-6 col-md-6 col-xs-6"><a class="btn btn-danger"><i class="fa fa-trash-o" aria-hidden="true"></i></a></div>';
    $('.addition').append('<div data-aos="fade-left" class="row deletedata"><div class="container productspecborder">' + v + '</div></div>');

})
UploadInstantShow("exampleInputFile1", "upload_box");

setTimeout(function () {
    for (i = 1; i <= 12; i++) {
        UploadInstantShow('images_' + i, 'imagesshow_' + i);
    }

}, 5000);


/*-----------------------Image Show Instant----------------------------*/
function UploadInstantShow(ID, Class) {


    $("." + ID).change(function () {
        readURL(this, Class);
    });

}

function readURL(input, Class) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('.' + Class).css('background', 'url(' + e.target.result + ')')
            $('.' + Class).find('img,h6').hide();
        }

        reader.readAsDataURL(input.files[0]);
    }
}

/*---------------------Front End Js------------------------*/
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
/*------------All Product Details page--------------*/
function wishlistData() {
    userID = 0;

    $('body').find('.ShippingAddress').attr('data-user', "0");
    $.ajax({
        url: "/ajax/CheckLogin",
        success: function (result) {
            if (result.Status == true) {
                $(".customerlogin").hide();
                userID = result.result.id;
                $('body').find('.ShippingAddress').attr('data-user', userID);
                
                /*---------------------------*/
                $.ajax({
                    url: "/ajax/addwishlist?uid=" + userID + "&pid=0",
                    success: function (result) {
                        res = JSON.parse(result);

                        for (i = 0; i < res.length; i++) {
                            //alert(res[i].ProductID);
                            $('.heart_box').each(function () {

                                id = parseInt($(this).parents('.productlistbox').attr('data-wishlist'));
                                pid = parseInt(res[i].ProductID);

                                if (id == pid) {
                                    $(this).attr('data-status', '1');
                                    $(this).removeClass('fa-heart-o');
                                    $(this).addClass('fa-heart');
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
                pid = nthis.parents('.productlistbox').attr('data-wishlist');
                if (nthis.attr('data-status') == "1") {
                    nthis.attr('data-status', "0");
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
                            notifyMe("Successfully add Your favourite", "One More Product Add In Your favourite", "/Myaccount/favourites", '/img/Icon/2.png');
                        }
                    })
                }

                wishlist = nthis.parents('.productlistbox').data('wishlist');
                nthis.toggleClass('fa-heart-o');
                nthis.toggleClass('fa-heart');
            } else {

                window.location.href = "/createaccount/login";

            }
        }

    });

})
function showprice() {
    return parseFloat($('.totalprice').html());
}

function Payaddress() {
    return parseFloat($('.totalprice').html());
}

 

function cartpageupdate() {


    $('.loaders').hide();
    UpdateShippingAddress();
    var res = 0;
    $('.cardcount').addClass('flip');

    $.ajax({
        url: "/cart/getC",
        success: function (result) {

            $('.cart-left,.subtotal-right').hide();
            $('.tocontinue').hide();
            if (result != false) {

                var $injector = angular.injector(['ng', 'pascalprecht.translate', 'ngCookies']);
                var $cookies = $injector.get("$cookies");
                $.ajax({
                    url: "/Shoppingcart/GetShippingAddress",
                    success: function (addshipping) {
                        $.ajax({
                            url: "/ajaxapi/getProductCartResult/?cartproduct=" + result + "&addressid=" + addshipping[0].AddID + "&shippingcompanyid=" + addshipping[0].SIDS + "&lang=" + $cookies.get('language') ,
                            success: function (resultnew) {
                                htmlPage = html = "";
                                res1 = resultnew.result[0];

                                res = resultnew.result[0].WholCartData;
                                var fullstring = null;
                                var totalprice = 0;
                                var quantity = 0;


                                var $injector = angular.injector(['ng']);
                               // var $filter = rootApp.get("$filter");
                                var obj = 'In Stock';
                                 

                             //   console.log("ddassad", rootApp.$scope.injector().get('$filter')('translator')('In Stock') ); 
                                var instock = '';// rootApp.$scope.translator('In Stock');
                                html += ' <li><div class="productcartlisting mCustomScrollbar_old">';
                                htmlPage += '<tbody>';
                                if (res != null && res.length > 0) {
                                    for (i = 0; i < res.length; i++) {
                                        parseFloat(res1.TotalOfferprice).toFixed(2)
                                        res[i].Product.ProductSalePrice
                                        var ShowPrice = "";
                                        if (parseInt(res[i].Product.ProductSalePrice) > 0) {
                                            ShowPrice += '<del>' + parseFloat(res[i].Product.ProductSalePrice).toFixed(2) + 'AED</del> ';
                                            ShowPrice += parseFloat(res[i].Product.ProductRegulerPrice).toFixed(2) + " AED ";
                                            var offer = parseInt(res[i].ProductOffer);
                                            ShowPrice += "<a style='color:orange'> " + offer + "%</a>";
                                        } else {
                                            ShowPrice += res[i].Product.ProductRegulerPrice + " AED";
                                        }
                                        htmlPage += '<tr>';
                                        htmlPage += '<td><div class="table-img"><a href="/ProductDetail/product/' + res[i].Product_id + '"><img onerror="imgError(this);" src="' + res[i].Product.productimg + '"></a></div >';
                                        htmlPage += '<div class="table-cont"><h5 class="shopping_title"><a href="/ProductDetail/product/' + res[i].Product_id + '">' + res[i].Product.ProductTitle + '</a></h5><p class="shopping_smline small-line"> ' + res[i].Vendor.fname + ' ' + res[i].Vendor.lname + '</p>';
                                        if (res[i].Flag == true) {
                                            htmlPage += '<span  class="blockx green-text">' + res[i].FlagMsg + '</span>';
                                        } else {
                                            //htmlPage += '<span  class="blockx red-text err">Out of Stock</span>';
                                            htmlPage += '<div class="error">' + res[i].FlagMsg + '</div>';
                                        }
                                        if (res[i].Product.IsCustomized == 1) {
                                            htmlPage += '<div class="customproductdata"><i class="cusomization fa  fa-check-circle"></i>' + res[i].Product.CustomizedMsg+'</div>';
                                        }

                                        htmlPage += '<span class="price-text priceingAddition mobile">' + ShowPrice + '</span></div></td >';

                                        htmlPage += '<td class="shiping' + res[i].Flag + '"><div class="plus-minus-numbers-row"><div class="counter_number"><div class="input-group numbers-row">';
                                        htmlPage += '<input type="text"  data-qun="' + res[i].Product.ProductQun + '" data-Pid="' + res[i].Product_id + '" name="quant[1]" class="form-control input-number quntity validateq" value="' + res[i].ProductPurchaseQun + '" min="1" max="' + res[i].Product.ProductQun + '" data-parsley-required-message="Max product quantity available ' + res[i].Product.ProductQun + ' " readonly="readonly">';
                                        htmlPage += '</div></div><span class="err"></span></div></td>';
                                        htmlPage += '<td class="shiping' + res[i].Flag + '"><span class="price-text priceingAddition">' + res[i].ProductPurchaseQun * res[i].Product.ProductRegulerPrice + '</span> AED</td>';
                                        htmlPage += '<td class="text-center"><a onclick="remove(' + res[i].Product_id + ',this)" href="#" data-productid="' + res[i].Product_id + '" title="Delete Cart" class="cross-btn">x</a></td>';
                                        htmlPage += '</tr>';

                                        html += '<div><span class="item">';
                                        html += '<span class="item-left"><a href="/ProductDetail/product/' + res[i].Product_id + '"><img onerror="imgError(this);" src="' + res[i].Product.productimg + '" alt="' + res[i].Product.ProductTitle + '"></a>';
                                        html += '<span class="item-info"><a href="/ProductDetail/product/' + res[i].Product_id + '"><span class="titledata">' + res[i].Product.ProductTitle + '</span></a>';
                                        html += '<span class="price">' + res1.qunmsg + ': ' + res[i].ProductPurchaseQun + '</span>';
                                        html += '<span class="price">' + res1.pricemsg + ': ' + ShowPrice + '  </span>';
                                        html += '</span ></span >';
                                        html += '<span class="item-right"><a href="#" data-productid="' + res[i].Product.Product_id + '" onclick="remove(' + res[i].Product_id + ',this)" class="cross-btn"><i class="fa fa-trash"></i></a></span></span >';
                                        html += '</div>';
                                    }
                                    html += '</div><ul class="cartpriceshow">';
                                    html += '<li class="total_price_cart dataProductdata first"><span class="item-left">' + res1.productsubtotalmsg + ': ' +'</span><span class="item-right">' + parseFloat(res1.SubTotalPrice).toFixed(2) + ' AED </span></span ></li > ';
                                    html += '<li class="total_price_cart dataProductdata"><span class="item-left">' + res1.offermsg + ': ' +'</span><span class="item-right">-' + parseFloat(res1.TotalOfferprice).toFixed(2) + ' AED </span></span ></li > ';
                                    html += '<li class="total_price_cart dataProductdata"><span class="item-left">' + res1.Shippingnmsg + ': ' +'</span><span class="item-right">+' + parseFloat(res1.ShippingCost).toFixed(2) + ' AED </span></span ></li > ';
                                    html += '<li class="total_price_cart dataProductdata last"><span class="item-left">' + res1.totalmsg + '(' + res1.TotalQuntity + ')' + res1.itemnmsg + ': </span><span class="item-right">' + parseFloat(res1.TotalPrice).toFixed(2) + ' AED </span></span ></li > ';
                                    html += '<li class="view_cart"><a class="viewbtn text-center col-xs-12" href="/shoppingcart">' + res1.viewcartmsg + '</a><a class="text-center  col-xs-6 hidden" href="/checkout">Checkout</a></li>';

                                    $('.subtotals').html(parseFloat(res1.SubTotalPrice).toFixed(2));
                                    $('.offer').html(parseFloat(res1.TotalOfferprice).toFixed(2));
                                    $('.shipments').html(parseFloat(res1.ShippingCost).toFixed(2));
                                    $('.totalprice').html(parseFloat(res1.TotalPrice).toFixed(2));
                                    $('.quntt').html(parseFloat(res1.TotalQuntity));
                                    $('.dropdown-menu.dropdown-cart').removeAttr('style');
                                    $('.dropdown-menu.dropdown-cart').html('');
                                    $('.dropdown-menu.dropdown-cart').html(html);
                                    $('body').find('.shopping-cart-left table.table').html('');
                                    $('body').find('.shopping-cart-left table.table').html(htmlPage);
                                    $('.cart-left,.subtotal-right').show();

                                    $('.cardcount').each(function () {
                                        ShowCheckOutOption();
                                        setTimeout(function () {
                                            $('.cardcount').addClass('flip');
                                            $('.subtotal_overlay h4 span').html(res1.TotalQuntity);
                                            $('.cardcount').html(res1.TotalQuntity);
                                            $('.loaders').fadeOut();
                                            $('.addtocartbutton,.addtocartbuttonbg').fadeOut(1000);
                                        }, 1000)
                                        setTimeout(function () {
                                            $('.cardcount').removeClass('flip');
                                        }, 3500);
                                    });
                                    addbutton();
                                } else {
                                    $('.loaders').fadeOut();
                                    $('.tocontinue').show();
                                    $(".cardcount").html("");
                                    $('.addtocartbutton,.addtocartbuttonbg').fadeOut(1000);
                                    $('.dropdown-menu.dropdown-cart').hide();
                                }
                            }
                        });
                    }
                });
            } else {
                $('.tocontinue').show();
                $('.dropdown-menu.dropdown-cart').hide();

                $('.loaders').fadeOut();
                $(".cardcount").html("");
                $('.addtocartbutton,.addtocartbuttonbg').fadeOut(1000);
                $('.dropdown-menu.dropdown-cart').hide();

            }
        },
        error: function (result) {
            loaderhide(true);
            $('.tocontinue').show();
            $('.loaders').fadeOut();
            $(".cardcount").html("");
            $('.addtocartbutton,.addtocartbuttonbg').fadeOut(1000);
            $('.dropdown-menu.dropdown-cart,.subtotal-right,.cart-left').hide();
        }
    });
    loaderhide(true);
}


function UpdateShippingAddress() {

    $.ajax({
        url: "/Shoppingcart/GetShippingAddress",
        success: function (addshipping) {
            $.ajax({
                url: "/ajaxapi/GetShippingAddressGuest?AddressID=" + addshipping[0].AddID,
                success: function (Address) {
                    if (Address.flag == true) {
                        a = Address.result[0];
                        var $div = $('.adds,.address-confirm');
                        html = '<b ng-controller="extra">' + a.Fname + ' ' + a.Lname + '</b><div>' + a.StreetName + ' , ' + a.BuildingName + ' , ' + a.CityName + ' <div>{{"Mobile"|translate}}:' + a.Mobile + '<div>{{"Email"|translate}}:' + a.email + '</div></div> </div>';
                        $('.adds,.address-confirm').html(html); 
                            angular.element(document).injector().invoke(function ($compile) {
                                var scope = angular.element($div).scope();
                                $compile($div)(scope);
                            });
                        $('.adds').parents('.subtotal_overlay').find('.parsley-required').html("");
                        $('.ShippingAddress').attr('data-address', a.Id);
                        $('.ShippingAddress').val(a.Fname + ' ' + a.Lname);
                    }
                },
                error: function (result) {
                    loaderhide(true);
                }
            });
        }
    });
}

$(document).on('click', '.selectaddress', function () {
    AID = $(this).parents('.addressdata').attr('data-id');
    SID = $('.ShippingCompany').val();
    $.ajax({
        url: "/Shoppingcart/GetShippingAddress?AddresID=" + AID + "&ShippingCompany=" + SID,
        success: function (addshipping) {
            cartpageupdate();
        }
    })
    $('.popupbg').fadeOut(1000);
});
$(document).on('change', '.ShippingCompany', function () {
    AID = $('.ShippingAddress').attr('data-address');
    SID = $('.ShippingCompany').val();
    $.ajax({
        url: "/Shoppingcart/GetShippingAddress?AddresID=" + AID + "&ShippingCompany=" + SID,
        success: function (addshipping) {
            cartpageupdate();
        }
    })
});

function ShowCheckOutOption() {
    $.ajax({
        url: "/ajax/CheckLogin",
        success: function (result) {
            if (result.Status == true) {
                $('body').find('.customerlogin').html('');
            }
        }
    });
}





function loaderhide(hide = false) {
    
    if (hide == true) {
        setTimeout(function () {
            $('.loader').fadeOut(1000);
            //angular.element($('.menu-top-head')).scope().changeLanguage();
        }, 1000);
    } else {
        $('.loader').fadeIn();
    }
}




function remove(a, that) {

    if (confirm('Are you sure to delete this product ?')) {

        $.ajax({
            url: "/cart/RemoveC/?productid=" + a,
            success: function (result) {

                location.reload();
            }
        });
    }

}

function updatecardProduct() {

    $('.quntity').each(function () {
        mq = parseInt($(this).attr("data-qun"));
        q = parseInt($(this).val());
        a = parseInt($(this).attr('data-pid'));
        $.ajax({
            url: "/cart/AddC/?productid=" + a + "&Quantity=" + q,
            success: function (result) {
                cartpageupdate();
                notifyMe("Update product", "Update Product in Cart", "/shoppingcart", '/img/Icon/1.png');

            }
        });
    })
}



$(document).ready(function () {
    $('.addtocartbutton,.addtocartbuttonbg').hide();
    $(document).ready(function () {
        $(".mobile_category1").click(function () {
            $(".category_drop1").toggle(1000);
            $(".category_drop2").hide(1000);
            $('.category-list,.category_drop2').click(function () {
                $('.category_drop1,.category_drop2').hide();
            })
        });
    });
    $(document).ready(function () {
        cartpageupdate();
        $(".mobile_category2").click(function () {
            $(".category_drop2").toggle(1000);
            $(".category_drop1").hide(1000);
            $('.category-list,.category_drop2').click(function () {
                $('.category_drop1,.category_drop2').hide();
            })
        });
    });


    ScrollCheckHeader();
    wishlistData();
    loaderhide();


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




// counter number


$('.btn-number').click(function (e) {
    e.preventDefault();

    fieldName = $(this).attr('data-field');
    type = $(this).attr('data-type');
    var input = $("input[name='" + fieldName + "']");
    var currentVal = parseInt(input.val());
    if (!isNaN(currentVal)) {
        if (type == 'minus') {

            if (currentVal > input.attr('min')) {
                input.val(currentVal - 1).change();
            }
            if (parseInt(input.val()) == input.attr('min')) {
                $(this).attr('disabled', true);
            }

        } else if (type == 'plus') {

            if (currentVal < input.attr('max')) {
                input.val(currentVal + 1).change();
            }
            
            if (parseInt(input.val()) == input.attr('max')) {
                $(this).attr('disabled', true);
            }

        }
    } else {
        input.val(0);
    }
});
$('.input-number').focusin(function () {
    $(this).data('oldValue', $(this).val());
});
$('.input-number').change(function () {

    minValue = parseInt($(this).attr('min'));
    maxValue = parseInt($(this).attr('max'));
    valueCurrent = parseInt($(this).val());

    name = $(this).attr('name');
    if (valueCurrent >= minValue) {
        $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr('disabled')
    } else {
        alert('Sorry, the minimum value was reached');
        $(this).val($(this).data('oldValue'));
    }
    if (valueCurrent <= maxValue) {
        $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled')
    } else {
        alert('Sorry, the maximum value was reached');
        $(this).val($(this).data('oldValue'));
    }


});

function imgError(image) {
    image.onerror = "";
    image.src = "/img/imgs.jpg";
    return true;
}

$(".input-number").keydown(function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
        // Allow: Ctrl+A
        (e.keyCode == 65 && e.ctrlKey === true) ||
        // Allow: home, end, left, right
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});


function addbutton() {
    $(".numbers-row").append('<div class="inc button btn-number">+</div><div class="dec button btn-number">-</div>');

    $(".button").on("click", function () {

        var $button = $(this);
        var oldValue = $button.parent().find("input").val();
        var max = $button.parent().find("input").attr('data-qun');
        
        if ($button.text() == "+") {
            var newVal = parseFloat(oldValue) + 1;
            $(this).attr('disabled', true);
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 1) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 1;
            }
        }
        if (newVal > max) {
            newVal = max;
        }
        $button.parent().find("input").val(newVal);
        
    });
}






