$(document).click(function (e) {
    if ($(e.target).closest('.productsearch .search-head').length != 0) {
        $('.productsearchresults').show();
    }
    else {
        $('.productsearchresults').hide();
    }
});

$(document).ready(function () {
    if ($(document).width() < 500) {
        $(".myaccountlisting li").click(function () {
            $(".myaccountlisting").hide();
        });
        $('.myaccountlisting li').click(function () {
            $('.back_btn').css('display', 'block');
        });
        $('.myaccountlisting li').click(function () {
            $('.hamburger ').css('display', 'none');
        });
        $('.myaccountlisting li').click(function () {
            $('#all-order').css('display', 'block');
        });
        $('.myaccountlisting li a').click(function () {
            $(".tab-pane.fade.in.active").show();
        });
    }
});


/**************************Home PAge ********************************/

var Home = angular.module('Homex', ['pascalprecht.translate', 'ngCookies']);

Home.controller('HomeC', ["$scope", "$http", "$translate", "$cookies", function ($scope, $http, $translate, $cookies ) {
 
    $translate.use($cookies.get('language')); // Working for home page 
   
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    };
    $scope.getaddressdata = function (i) {
        $http.get("/Ajaxapi/GetShippingAddress?user="+i)
            .then(function (response) {
                
                $scope.shippingaddress = (response.data.result);
            });
    }

    $scope.deleteaddress = function (i, j) {
       
        $http.get("/Ajaxapi/DeleteShippingAddress?user=" + i +"&AddressID="+j)
            .then(function (response) {
                
                $scope.getaddressdata(i);
            });
    }

    $http.get("/Ajax/NewProducts")
        .then(function (response) {
            $scope.NewProductsjson = JSON.parse(response.data);
        });

    $http.get("/Ajax/TodaySweet")
        .then(function (response) {
            console.log(response);
            if (response.data.length === 0) {
                response.data = "{ }";
            }
            $scope.TodaySweetjson = JSON.parse(response.data);
        });

    $http.get("/Ajax/TrandingSweet")
        .then(function (response) {
            $scope.TrandingSweetjson = JSON.parse(response.data);
        });

    $http.get("/Ajax/Brand")
        .then(function (response) {
            $scope.Brandjson = JSON.parse(response.data);
        });

    $http.get("/Ajax/Lastview")
        .then(function (response) {
            $scope.Lastviewjson = JSON.parse(response.data);
        });


    $http.get("/ajax/bycatproduct?CatID=1")
        .then(function (response) {
            $scope.choclatejson = (response.data);
        });
    $http.get("/ajax/bycatproduct?CatID=2")
        .then(function (response) {
            $scope.DryfruitProductsjson = (response.data);
        });
    $http.get("/ajax/bycatproduct?CatID=3")
        .then(function (response) {
            $scope.DarkProductsjson = (response.data);
        });
    
    $scope.addtocart = function (productid, that) { 
        var quan = 0;
        $('.addtocartbutton,.addtocartbuttonbg').show();
        quan = quan + 1;

        $.ajax({
            url: "/cart/AddC/?productid=" + productid + "&Quantity=" + quan,
            success: function (result) {
                cartpageupdate();
                 notifyMe("Add one-more product", "One More Product Add In Cart", "/shoppingcart", '/img/Icon/1.png');
            }
        });
        
    };
}]); 

$(document).on('click', '.reviewsave', function (){ 
    keysd = $(this).parents('.ratingreviewboxxx');

    PID = keysd.find(".products").attr("data-productid");        
    review = keysd.find(".producttext").val();
    rating = keysd.find(".ratingcontent").val();
    token = $(this).parents('.reviewshow').find('#keys').val();
    $.ajax({
        url: "/ajax/submitreviewdata",
        data: { review: review, rating: rating, token: token, ProductID: PID },
        success: function (result) {
        }
    })
})

