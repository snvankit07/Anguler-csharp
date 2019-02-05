function getcountry(SELID=0) {
        $.ajax({
            url: "/ajax/country",
            success: function (result) {
                res = JSON.parse(result);
                console.log("Country");
                console.log(res)
                html = '';
                for (i = 0; i < res.length; i++) {
                    if (res[i].name) {
                        console.log(res[i]);
                        console.log(res[i].name);
                        html = html + '<option value="' + res[i].id + '">' + res[i].name + '</option>';
                        //  console.log(html);
                    }
                }
                $('#contry').html(html);

            }
        })
    }

    function getSteate(Country=0,SELID = 0) {
        $.ajax({
            url: "/ajax/state?Cid=" + Country,
            success: function (result) {
                res = JSON.parse(result);
                console.log("State" + res);
                html = '';
                for (i = 0; i < res.length; i++) {
                    if (res[i].name) {

                        html = html + '<option value="' + res[i].id + '">' + res[i].name + '</option>';
                    }
                }
                $('#State').removeAttr('readOnly');
                $('#State').html(html);
            }
        })
    }

    function getcity(State = 0, SELID = 0) {

        $('#city').html('');
    $.ajax({
        url: "/ajax/cities?Cid=" + State,
            success: function (result) {
        res = JSON.parse(result);

    html = '';
                for (i = 0; i < res.length; i++) {


        html = html + '<option value="' + res[i].id + '">' + res[i].name + '</option>';

    }
    $('#city').removeAttr('readOnly');
    $('#city').html(html);

}
})
}



    $(document).on('click', '.myaccountlisting li', function () {
        var v = ($(this).data('value'));
        id = $('.userdetails').attr('data-userid');
        if (v == 'myaccount') {
        $.ajax({
            url: "/ajax/userdetails?userID=" + id,
            success: function (result) {
                res = JSON.parse(result);
                console.log(res);
                $('#fname').val(res[0].fname);
                $('#lname').val(res[0].lname);
                $('#email').val(res[0].username);
                $('#contact').val(res[0].mobileno);
                $('postal').val(res[0].Postalcode);
                getcountry();
                $(document).on('change', '#contry', function () {
                    getSteate($(this).val());

                });
                $(document).on('change', '#State', function () {

                    getcity($(this).val());
                })



            }
        })
    }
    if (v == 'favourite') {

        $.ajax({
            url: "/ajax/featchwishlist?uid=" + id,
            success: function (result) {
                res = JSON.parse(result);
                console.log(res);
                html = '';
                for (i = 0; i < res.length; i++) {

                    html += '<div class="col-md-3  ng-scope" >';
                    html += '<div class="productsmallbox">';
                    html += '<a href="/ProductDetail/product/' + res[i].productdetail.ProductID+'">';
                    html += '<div class="img-div">';
                    html += '<img onerror="imgError(this);" src="' + res[i].productdetail.productimg + '">';
                    html += '</div>';
                    html += '<h5 class="ng-binding">' + res[i].productdetail.ProductTitle + '...</h5>';
                    html += '<span class="ng-binding">' + res[i].productdetail.ProductRegulerPrice + ' AED</span>';
                    html += '</a>';
                    //html += '<div data-wishlist="82" class="productlistbox col-xs-12">';
                    //html += '<div class="addtocartbtn col-xs-4"><i class="fa heart_box fa-heart" aria-hidden="true" data-status="1"></i></div>';
                    //html += '<div class="addtocartbtn location col-xs-4"><img style=" width: 8px; " src="/img/Icon/icoinfo.png"></div>';
                    //html += '<div ng-click="addtocart(j.ProductID,this)" class="addtocartbtn col-xs-4 productshow82"><i data-proid="82"></i><img style=" width: 19px; margin-top: -5px;" src="/img/Icon/1.png"></div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    //html = html + '<div class="col-md-3 detail-div"><a href="/ProductDetail/product/' + res[i].productdetail.ProductID + '"><div class="img-div"><img onerror="imgError(this);" src="' + res[i].productdetail.productimg + '"></div><h5>' + res[i].productdetail.ProductTitle + '</h5><h4 class="price-text">' + res[i].productdetail.ProductRegulerPrice + ' AED </h4></a></div>';
                }
                $('.newwishlist').html(html);

            }
        })
    }
    })
    $(document).on('click', '.resultopen', function () {
        $('.resultshow').hide(500);
    $(this).parent().find('.resultshow').fadeIn(1000);
})
    $(document).on('click', '.order-details-top', function () {
        $('.order-description').hide(1000);
    $(this).parents('.showbox').find('.order-description').slideToggle(1000);

})
    $(document).on('click', '.tabshowbox li', function () {
        $('.tabshowbox li').removeClass('active');
    $(this).addClass('active');
    v = $(this).attr('data-show');
    id = $('.userdetails').attr('data-userid');
    $('.order-description').hide("slow");
        $('.loader').show();
    if (v == 'all') {
        showorder(id, 0);
    } else {
        showorder(id, v);
    }
   
  })

    function showorder(id, v) {
        $('#all-order').html("");
        urls = "";
        if (id === undefined) {
            trackordser = $('.userdetails').attr('data-orderid');
            
            if (trackordser === undefined) {
                
            } else {
                urls = "?order=" + trackordser;
            }
        } else {
            urls = "?user=" + id + "&type=" + v;
        }
        $.ajax({
            url: "/ajaxapi/OrdersShow" + urls,
            success: function (result)
            {
                res = (result);
                html = ''
                $('#all-order').html("");
                
                
                if (result.flag && res.result.length > 0) {
                    
                    for (i = 0; i < result.result.length; i++) {
                        if (i % 2 == 0) {
                            html += "<div>";
                        }
                        datas = result.result[i];
                        html += '<div data-aos="flip-down" class="topboxs col-lg-6 col-lg-6 col-lg-6 col-xs-12">';
                        html += '<div data-wholecart="' + datas.ProductOrderNumber + '" class="boxes">';
                        html += '<div class="Showdetails">';
                        html += '<div class="imagest col-lg-4 col-md-4 col-sm-4 col-xs-4">';
                        html += '<img onerror="imgError(this);" class="boxesimages" src="' + datas.Product.productimage + '">';
                        html += '</div > ';
                        html += '<div class=" col-lg-8 col-md-8 col-sm-8 col-xs-8">';
                        html += '<div class="ordertitle">{{"' + datas.Product.ProductTitle + '"|translate}}</div>';
                        html += '<div class="ordervendor"><span>{{"By"|translate}}:</span> ' + datas.Vendor.fname + ' ' + datas.Vendor.lname + '</div>';
                        html += '<div class="orderdate">' + datas.OrderCreatedDate + ' </div>';
                        html += '</div >';
                        html += '<div style="clear:both;"></div>';
                        html += '</div >';
                        if (datas.pickanddeliverStatus == -3) {
                            html += '<div class="Buttonshow  canceled col-lg-12 col-lg-12 col-lg-12 col-xs-12">';
                            html += '<center>{{"Not Pickedup"|translate}}</center>';
                            html += '</div>';
                        }
                        if (datas.pickanddeliverStatus == -4) {
                            html += '<div class="Buttonshow  canceled col-lg-12 col-lg-12 col-lg-12 col-xs-12">';
                            html += '<center>{{"Order Return"|translate}}</center>';
                            html += '</div>';
                        }

                        
                        if (datas.pickanddeliverStatus < 6 && datas.pickanddeliverStatus > -2) {
                            html += '<div class="col-lg-12 col-lg-12 col-lg-12 col-xs-12">';
                            css = " canceled col-lg-12 col-lg-12 col-lg-12 col-xs-12";
                            
                            if (datas.pickanddeliverStatus <= 0 && datas.pickanddeliverStatus >= -1) {
                                html += '<div class="Buttonshow showcancelbtn col-lg-6 col-lg-6 col-lg-6 col-xs-6">';
                                html += '<center>{{"Cancel Order"|translate}}</center>';
                                html += '</div>';
                                css = " col-lg-6 col-lg-6 col-lg-6 col-xs-6";
                            }
                            html += '<div class="Showdetails Buttonshow ' + css+'">';
                            html += '<center>{{"Track Your Order"|translate}}</center>';
                            html += '</div>';
                            html += '</div>';
                        }


                        if (datas.pickanddeliverStatus == -2) {
                            html += '<div class="Buttonshow  canceled col-lg-12 col-lg-12 col-lg-12 col-xs-12">';
                            html += '<center>{{"Cancelled"|translate}}</center>';
                            html += '</div>';
                        }
                        if (datas.pickanddeliverStatus == 6) {
                            html += '<div class="Buttonshow ratingreviw col-lg-12 col-lg-12 col-lg-12 col-xs-12">';
                            html += '<center>{{"Share Rating & Review"|translate}}</center>';
                            html += '</div>';
                        }
                        html += '<div style="clear:both;"></div>';

                        if (datas.pickanddeliverStatus <= 0 && datas.pickanddeliverStatus >= -1) {
                            html += '<div class="cancelbutton col-lg-12 col-lg-12 col-lg-12 col-xs-12"><i  class="closebuttoncancle fa fa-close"></i>';
                            html += '{{"Cancel Reason"|translate}}:<textarea data-trackid="' + datas.ProductOrderNumber + '" class="addresionforcancel"></textarea><input value="{{\'Confirm cancel order\'|translate}}" class="saveresioncancel" type="button">';
                            html += '</div>'; 
                        }
                        html += '</div>';
                        html += '</div > ';
                        if (i % 2 == 1) {
                            html += '<div style="clear:both;"></div>';
                            html += "</div>";
                        }
                        
                    }
                } else {
                    html = "<h2><center>{{'No Order Found'|translate}}</center></h2>";
                    
                }
                $('.loader').fadeOut(1000);
                $('#all-order').html(html);
                var $div = $('#all-order');
                angular.element(document).injector().invoke(function ($compile) {
                    var scope = angular.element($div).scope();
                    $compile($div)(scope);
                });
            }
        });


    }
    
$(document).on('click', '.closebuttoncancle', function () {
    $('.cancelbutton').fadeOut(500);

})
    function imgError(image,type=0) {
        image.onerror = "";
        image.src = "/img/imgs.jpg";
       return true;
    }
    

    $(document).on('click', '.saveresioncancel', function () {
        p = $(this).parents('.cancelbutton')
        resion=p.find('.addresionforcancel').val();
    trakingid=p.find('.addresionforcancel').attr('data-trackid');
        $('.tabshowbox.ordertab-show').find('li').each(function () {
            if ($(this).hasClass('active')) {
        ids = $(this).attr('data-show');
    id = $('.userdetails').attr('data-userid');
                $.ajax({
        url: "/ajaxapi/CancelOrder?token=" + trakingid+"&cancelMsg=" + resion,
                    success: function (result) {
                        notifyMe("Successfully Cancel Order", result.message, "/Myaccount", '/img/Icon/icoinfo.png');
                        showorder(id, ids);
                    }
                });
            }
        })
})

    
     /*----------------------Show save rating reviwe Popup----------------*/
$(document).on('click', '.ratingreviw', function () {
    id = ($(this).parents('.boxes').attr('data-wholecart'));
    var $injector = angular.injector(['ng', 'pascalprecht.translate', 'ngCookies']);
    var $cookies = $injector.get("$cookies");
    $.ajax({
        url: "/ajaxapi/GetOrderProduct?id=" + id + "&lang=" + $cookies.get('language'),
        success: function (result) {
            if (result.flag == true) {

                Order = result.result;
                data = JSON.parse(result.result.OrderSummary);

                html = '<div class="reviewsd" data-cart="' + id +'" ng-controller="HomeC">';
                html += '<b>{{"Product Rating"|translate}}:<br></b><div class="orderproducts ratingreview">';
                html += '<div class="proimg col-lg-3 col-sm-3 col-md-3 col-xs-3">';
                html += '<img onerror="imgError(this);" style="width:100%;" src="' + data.Product.productimage + '">';
                html += '</div>';
                html += '<div class="col-lg-9 col-sm-9 col-md-9 col-xs-9">';
                html += data.Product.ProductTitle;
                html += '<div  data-productrate="0" id="productrate" class="productrate">';
                html += '<i data-star="1" class="fa fa-star"></i>';
                html += '<i data-star="2" class="fa fa-star"></i>';
                html += '<i data-star="3" class="fa fa-star"></i>';
                html += '<i data-star="4" class="fa fa-star"></i>';
                html += '<i data-star="5" class="fa fa-star"></i>';
                html += '</div>';
                html += '</div>';

                html += '<div style="clear:both;"></div>';
                html += '</div>';
                html += '<textarea placeholder="{{\'Write You Review here\'|translate}}" class="reviewmsg col-lg-12 col-sm-12 col-md-12 col-xs-12"></textarea>';

                html += '<b>{{"Shipping Rating"|translate}}:<br></b>';
                html += '<div class="orderproducts ratingreview">';
                html += '<div class="proimg col-lg-3 col-sm-3 col-md-3 col-xs-3">';
                html += '<img onerror="imgError(this);" style="width:100%;" src="' + data.shippingCompanys.logo + '">';
                html += '</div>';
                html += '<div class="col-lg-9 col-sm-9 col-md-9 col-xs-9">{{"';
                html += data.shippingCompanys.name;
                html += '" | translate }}<div data-shippingrate="0" id="shippingrate" class="shippingrate">';
                html += '<i data-star="1" class="fa fa-star"></i>';
                html += '<i data-star="2" class="fa fa-star"></i>';
                html += '<i data-star="3" class="fa fa-star"></i>';
                html += '<i data-star="4" class="fa fa-star"></i>';
                html += '<i data-star="5" class="fa fa-star"></i>';
                html += '</div>';
                html += '</div>';
                html += '<div style="clear:both;"></div>';
                html += '</div>';
                html += '</div>';
                html += '<input type="button" value="{{\'Save\'|translate}}" class="form-control savereview">';
                showpopup(html, true);
            }
        }
    });
});


$(document).on('click', '.productrate i,.shippingrate i', function () {
    datas = parseInt($(this).attr('data-star'));
   
    d = $(this).parent().attr("id");
    
    $(this).parent().attr('data-' + d, datas);
    $(this).parent().find('i').removeClass('fill');
    for(i = 1; i <= datas; i++)
    {
        $(this).parent().find('i:nth-child('+i+')').addClass('fill');
    }
});


$(document).on('click', '.form-control.savereview', function () {
    review = $('.reviewmsg').val();
    ratingp=$('.productrate').attr('data-productrate');
    ratings = $('.shippingrate').attr('data-shippingrate');
    id=$('.reviewsd').attr('data-cart');
    url='ajaxapi/WriteReview?token='+id+'&rating='+ratingp+'&Ratingdelivery='+ratings+'&review='+review;
    $('.tabshowbox.ordertab-show').find('li').each(function () {
        if ($(this).hasClass('active')) {
            ids = $(this).attr('data-show');
            id = $('.userdetails').attr('data-userid');
            $.ajax({
                url: url,
                success: function (result) {
                    notifyMe("Successfully Saved Your Rating Review", result.message, "/Myaccount", '/img/Icon/icoinfo.png');
                    showorder(id, ids);
                    showpopup(html, false);
                }
            });
        }
    })





})

    /*----------------------Show save rating reviwe Popup----------------*/

    $(document).on('click', '.Showdetails', function () {
        id=($(this).parents('.boxes').attr('data-wholecart'));
        html = "";
        var $injector = angular.injector(['ng', 'pascalprecht.translate', 'ngCookies']);
        var $cookies = $injector.get("$cookies");
         $.ajax({
             url: "/ajaxapi/GetOrderProduct?id=" + id + "&lang=" + $cookies.get('language'),
             success: function (result) {
                 if (result.flag == true) {

                     Order = result.result;
                     data = JSON.parse(result.result.OrderSummary);

                     qun = data.ProductPurchaseQun
                     data.ProductSubtotal = parseFloat(data.Product.ActualAmount) * parseFloat(qun);
                     data.Discount = ((parseFloat(data.Product.ActualAmount) * (parseFloat(data.Product.adminoffer) + parseFloat(data.Product.vendoroffer))) / 100) * parseFloat(qun);
                     if (data.ShippingRatecard === null) {
                         data.ShippingRatecard = { price: 0, ExtraQuntityprice:0};
                         data.ShippingRatecard.price = 0;
                         data.ShippingRatecard.ExtraQuntityprice = 0;
                     }
                     data.Shipping =    parseFloat(data.ShippingCost);
                     data.OrderTotal = (parseFloat(data.Offerprice) + parseFloat(data.ShippingCost));

                     html += '<div class="popupdetailsbg" ng-controller="HomeC">';
                     html += '<div class="OrderPopupDeading">{{"Order Details"|translate}}</div>';
                     html += '<div class="OrderPopupbgwhite">';
                     html += '<table>';
                   
                     var dateString = Order.CreatedDate.substr(6);
                     var currentTime = new Date(parseInt(dateString));
                     var month = currentTime.getMonth() + 1;
                     var day = currentTime.getDate();
                     var year = currentTime.getFullYear();
                     var date = day + "/" + month + "/" + year; 
                     html += '<tr><th>{{"Order Placed"|translate}}</th><td>' + date +'</td></tr>';
                     html += '<tr><th>{{"Order ID"|translate}}</th><td>' +data.ProductOrderNumber+'</td></tr>';
                     html += '<tr><th>{{"Total"|translate}}</th><td>' + Order.ProductPricing + ' AED (' + data.ProductPurchaseQun +') {{"Items"|translate}}</td></tr>';
                     html += '</table>';
                     
                     html += '</div>';
                     html += '<div class="OrderPopupDeading">{{"Shipment Details"|translate}}</div>';
                     html += '<div class="OrderPopupbgwhite">';
                     html += '<table>';
                     html += '<tr><th>{{"Shipment Via"|translate}}</th><td>{{"' + data.shippingCompanys.name + '"|translate }}</td></tr>';
                     html += '<tr><th>{{"Tracking Number"|translate}}</th><td>' + Order.ProductOrderID + '</td></tr>';
                     html += '</table><hr>';
                     html += '<div>';
                     html += '<div class="orderproducts">';
                     html += '<img class="col-lg-3 col-sm-3 col-md-3 col-xs-3" src="' + data.Product.productimage + '">';
                     html += '<div class="col-lg-9 col-sm-9 col-md-9 col-xs-9">{{"';
                     html += data.Product.ProductTitle + '"| translate}}<br>' + data.Product.ActualAmount + 'AED';
                     
                     html += '</div>'; 
                     html += '<div style="clear:both;"></div>';
                     im = 0;
                     im = Order.pickanddeliverStatus;
                     img = 'flow_0' + im;
                     datac = "{{'On The Way'|translate}}";
                     switch (Order.pickanddeliverStatus)
                     {
                         case -2:
                         case -3:
                         case -4:
                             img = 'flow_00';
                             break;
                         case 5:
                             img = 'flow_04';
                             datac = "{{'It May Delay'|translate}}";
                             break;
                         case 6:
                         case 7:
                             img = 'flow_05';
                             break;
                         
                     }


                     
                     html += '</div >'; 
                     html += '<div class="trackshipment"><img style="width:20px;" src="/img/tracking/' + img+'.png">';
                     html += '<span class="ship1">{{"Shipment Information Received"|translate}}</span>';
                     html += '<span class="ship2">{{"Picked up from store"|translate}}</span>';
                     html += '<span class="ship3">{{"Departed"|translate}}</span>';
                     html += '<span class="ship4">' + datac+'</span>';
                     html += '<span class="ship5">{{"Delivered"|translate}}</span>';
                     
                     
                     
                     html += '</div >'; 
                     html += '</div>';
                     html += '<div style="clear:both;"></div>';
                     html += '</div>';
                     html += '<div class="OrderPopupDeading">{{"Shipping Detail Info"|translate}}</div>';
                     html += '<div class="OrderPopupbgwhite">';
                     html += ''; 
                      
                     
                     html += '<div><b>{{"Shipping Address"|translate}}</b><br>' + data.ShippingAddress.Fname + '<br>' + data.ShippingAddress.Lname + '<br>' + data.ShippingAddress.BuildingName + '<br>' + data.ShippingAddress.StreetName + '<br>' + data.ShippingAddress.Location + '<br>{{"City" | translate }}' + data.ShippingAddress.City +'<br> {{"Mobile" | translate }}'+ data.ShippingAddress.Mobile +'</div>';
                     html += '<div style="clear:both;"></div>';
                     html += '</div>';
                     html += '<div class="OrderPopupDeading">{{"Order Summary"|translate}}</div>';
                     html += '<div class="OrderPopupbgwhite">';

                     html += '<table>';
                     html += '<tr><th>{{"Items"|translate}}</th><td>' + qun + ' {{"Items"|translate}}</td></tr>';
                     html += '<tr><th>{{"Product Subtotal"|translate}}</th><td>' + data.ProductSubtotal + '  AED</td></tr>';
                     html += '<tr><th>{{"Discount"|translate}}</th><td>-' + data.Discount + ' AED</td></tr>';
                     html += '<tr><th>{{"Shipping"|translate}}</th><td>+' + data.Shipping + ' AED</td></tr>';
                     html += '<tr class="maintotal"><th>{{"Order Total"|translate}}</th><td>' + data.OrderTotal + ' AED</td></tr>';
                     html += '</table>';
                     html += '<div style="clear:both;"></div>';
                     html += '</div>';
                     html += '</div>';
                     showpopup(html, true);
                 }
                 

                 
             }
        })

        
    })
    $(document).on('click', '.calcelbtnpopup', function () {
        showpopup("",false);
    })



    $(document).on('click', '.showcancelbtn', function () {
        $('.cancelbutton').hide();
    $(this).parents('.boxes').find('.cancelbutton').show();


})

    $(document).ready(function () {
        id = $('.userdetails').attr('data-userid');
    showorder(id, 0);
        $('.ordertab-click').click(function () {
        $(".ordertab-show").slideToggle();
    });
        $('.tabshowbox-hide').click(function () {
        $(".ordertab-show").hide();
    });
        $('.ordertab-click').click(function () {
        $(".ordertab-click").toggleClass('arowup-order');
    });
        $('.tabshowbox-hide').click(function () {
        $(".ordertab-click").removeClass('arowup-order');
    });

});


function showpopup(data,flag=false)
{
    $('.popupbg').find('.popupbody').html("");
    if (flag == true) {
        $('.popupbg').fadeIn(1000);
        $('.popupbg').find('.popupbody').html(data); 
        console.log("123");
        var $div = $('.popupbg').find('.popupbody');
        angular.element(document).injector().invoke(function ($compile) {
            var scope = angular.element($div).scope();
            $compile($div)(scope);
        });
    } else {
        $('.popupbg').fadeOut(500);
    }
}