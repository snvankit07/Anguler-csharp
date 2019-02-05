$("#shippinglogin").submit(function (event) {
    u = $('.user').val();
    p = $('.pass').val();
    $.ajax({
        url: "/ajaxapi/LoginShipping?user=" + u + "&pass=" + p,
        success: function (result) {
            if (result.flag == true) {
                location.href = '/Company/productshow';
            } else {
                location.href = '/Company';
            }
        }
    });
    event.preventDefault();
});
$(document).on('click', '.imagesd,.detailsdata', function () {
    $('.opendetails').hide();
    $(this).parent().find('.opendetails').slideDown('slow');
});
var Home = angular.module('ShippingCompany', []);
Home.controller('ShippingCData', function ($scope, $http) {
    $scope.OpenOrdershippingdata = function (i, t) {
        $http.get("/ajaxapi/ShippingOrder?ShippingID=" + i + "&Type=" + t)
            .then(function (response) {
                $scope.ShowResult = response.data;
            });
    }
    $scope.updatestatus = function (k = 1, i, j) {
        
        
            $http.get("/ajaxapi/updateshippingdata?orderid=" + i + "&ststus=" + j)
                .then(function (response) {
                    $scope.OpenOrdershippingdata(k, '1');
                });
        
            
         
    }
});

$(function () {
    $('.bgcolordata .btn').click(function () {
        $('.bgcolordata .btn.active').removeClass('active');
        $(this).addClass('active');
    });
});