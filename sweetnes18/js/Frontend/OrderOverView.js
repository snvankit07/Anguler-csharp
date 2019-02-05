$(document).on('click', '.location', function () {
    id = $(this).parents('.productlistbox').attr('data-wishlist');
    window.location.href = "/ProductDetail/product/" + id;
})
/**************************Shopping Cart ********************************/

var Home = angular.module('getshoppingcart', ['ngSanitize',  'pascalprecht.translate','ngCookies']);

Home.controller('Shopping', ["$scope", "$http", "$translate", "$cookies", function ($scope, $http, $translate,$cookies ) {
    $translate.use($cookies.get('language')); 
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
 $http.get("/cart/getC")
     .then(function (response) {
          $scope.Shopjson = JSON.parse(response.data);
        });
}]); 




Home.controller('Trackorders', function ($scope,$http) {
   
    $scope.livetest = function (i) {
    
        var url = "/ajax/TrackOrder?OrderID=" +i;
        $http.get(url)
            .then(function (response) {
                
                $scope.datashow = JSON.parse(response.data)[0];
                $scope.datashow.orderDetail = JSON.parse($scope.datashow.orderDetail);
                $scope.datashow.customername = "Omar Humaid Alali";
               /*
                var url = "/ajax/GetCustomerDetailDetails?userID=" + $scope.datashow.customerID;
                $http.get(url)
                    .then(function (response1) {
                        $scope.datashow.customername = response1.data[0].;

                    });
                    */

                
                var Price = 0;
                
                for (i = 0; i < $scope.datashow.orderDetail.length; i++) {
                    Price = Price+($scope.datashow.orderDetail[i].price * $scope.datashow.orderDetail[i].Quantity);
                }
                
                /*-------------------------------------*/
                $scope.totalproduct = $scope.datashow.orderDetail.length;
                $scope.Orderdate = $scope.datashow.CreatedDate;
                $scope.OrderID = $scope.datashow.TransactionId;
                $scope.Method = $scope.datashow.ModeOfPayment;
                $scope.customername = $scope.datashow.customername;
                $scope.Price = Price;
                $scope.orderDetaildata = $scope.datashow.orderDetail;

                /*-------------------------------------*/
            });
        }

    
    });

Home.controller('getAllCartdata', ["$scope", "$http", "$translate", "$cookies", function ($scope, $http, $translate, $cookies) {
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    $http.get("/cart/getC")
        .then(function (response) {
            //alert(response);
            responsedata = (response.data.WholCartData);
            if (responsedata.length == 0 || responsedata == null || responsedata == undefined) {
                //window.location.href = "/";
            }
            
            osubtotal=gtotal=stotal = 0;
            $scope.cartstatus = responsedata;
            for (i = 0; i < responsedata.length; i++) {
                gtotal =osubtotal=stotal += responsedata[i].Quantity * responsedata[i].productdetail.ProductRegulerPrice;
            } 
            if (responsedata[0].OfferType == 'WholeCart')
            {
                if (responsedata[0].ProductOffer.OfferType == 1) {
                    osubtotal = osubtotal -(osubtotal*responsedata[0].ProductOffer.OfferAmount / 100);
                }
                if (responsedata[0].ProductOffer.OfferType == 2) {
                    osubtotal = osubtotal - responsedata[0].ProductOffer.OfferAmount;
                }
                $scope.subtotal = '<del>' + stotal + ' AED</del><br>' + osubtotal + ' AED';
            }
            if (responsedata[0].OfferType == 'Product') {
                osubtotal = 0;
                for (i = 0; i < responsedata.length; i++) {
                    
                    if (responsedata[i].Product_id == responsedata[i].ProductOffer.productID) {
                        if (responsedata[i].ProductOffer.OfferType == 1) {
                            osubtotal += ((responsedata[i].productdetail.ProductRegulerPrice * responsedata[i].Quantity) - ((responsedata[i].ProductOffer.OfferAmount / 100) * responsedata[i].Quantity));
                        }
                        if (responsedata[i].ProductOffer.OfferType == 2) {
                            osubtotal += ((responsedata[i].productdetail.ProductRegulerPrice * responsedata[i].Quantity) - (responsedata[i].ProductOffer.OfferAmount * responsedata[i].Quantity));
                        }
                    } else {
                        osubtotal += responsedata[i].productdetail.ProductRegulerPrice * responsedata[i].Quantity;
                    }
                    
                } 
                $scope.subtotal = '<del>' + stotal + ' AED</del><br>' + osubtotal + ' AED';
            }
            
            
            $scope.grandsubtotal = '<b>' + stotal +' AED</b>';
        });

}]);

Home.controller("RadioController", ["$scope", "$http", "$translate", "$cookies", function ($scope, $http, $translate, $cookies  ) {
    $scope.ShowShoppingCart = function () {

        $http.get("/ajaxapi/ShippingCompany")
            .success(function (response) {
                res=(response.result);
                html = "";
                for (i = 0; i < res.length; i++) {
                    //console.log(res[0][i]);
                    html += '<option value="' + res[i].ID + '">' + res[i].name+'</option>';
                }
                $('.ShippingCompany').html(html);
            })
        
        $http.get("/cart/getC")
            .success(function (response) {
                
                if (response.data == false) {
                    $scope.showboxcart = 0;
                } else {
                    $scope.showboxcart = 1;
                $.ajax({
                    url: "/ajaxapi/getProductCartResult/?cartproduct=" + response.data,
                    success: function (resultnew) {
                        $scope.Shoppingdata = resultnew.result[0].WholCartData;
                        $scope.Quantity = resultnew.result[0].TotalQuntity;
                        $scope.ProductTotal = resultnew.result[0].SubTotalPrice;
                        $scope.OfferAmount = resultnew.result[0].TotalOfferprice;
                        $scope.Shipping = resultnew.result[0].ShippingCost;
                        $scope.TotalPrice = resultnew.result[0].TotalPrice;
                       // $scope.price = (resultnew.data.TotalPrice);
                    }
                    });
                }
            }).error(function (data, status) {
                $scope.showboxcart = 0;
            })
    }
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) { 
        $translate.use(lang);
    }
    /*
    $scope.checkouturl = "";
    $scope.checkouturl = "/createaccount/login";
    $http.get("/ajax/CheckLogin")
        .then(function (data) {
            $scope.chkLogin = data;
            if (data.Status == true) {
                $scope.checkouturl = "/checkout";
                $('.customerlogin').hide();
                $scope.chkoutbox = 1;
            } else {
                $scope.chkoutbox = 0;
            }

        });
    */
    $scope.x = false;
    $scope.firsttime = function (){
        $scope.x = true;
    }
    $scope.abc = false;
    $scope.requiredx = 1;
    $scope.checkouturl = "/Myorder";
    $scope.RadioChange = function (s) {
        $('.customerlogin').click(function () {
            $(this).find('input').prop("checked", true);
        })
        
        $scope.GenderSelected = s;
        if (s == 1) {
            $scope.requiredx = "";
            $('.paynowbuttons1').show();
            $('.paynowbuttons').hide();
            $scope.checkouturl = "/createaccount/login";
            $('.parsley-required').html('');
        }
        else
        {
            $('.paynowbuttons1').hide();
            $('.paynowbuttons').show();
            $scope.requiredx = "required";
            $scope.checkouturl = "/Myorder";
        }
        
    };
}]); 


Home.controller('ReviewSubmit', ["$scope", "$http", "$translate","$cookies", function ($scope, $http, $translate, $cookies ) {
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    var ReviewApp = angular.module('ReviewApp', []);
    var ReviewRating = angular.module('ReviewRating', []);
    
    
    $scope.init = function (a) {
        ID = a;
        
        $http.get("/ajax/getreviewdata?orderID=" + ID)
            .then(function (response) {
                if (response == "" || (response == null && response.lenth == 0)) {
                    $scope.msg = "No Purchase Found";
                }
                $scope.reviewProduct = JSON.parse(response.data.orderDetail);
                console.log(JSON.parse(response.data.orderDetail));
            }, function (response) {
                if (response.status == 500) {
                    $scope.msg = "No Purchase Found";
                }
            });

        $scope.reviewupdate = function () {
            console.log($scope.ReviewApp);
        }
    }
    
}])


Home.controller('StarCtrl', ['$scope', function ($scope) {
    var RatingApp = angular.module('RatingApp', []);
    $scope.rating = 0;
    $scope.ratings = [{
        current: 1,
        max: 5
    }];

    $scope.getSelectedRating = function (rating) {
        console.log(rating);
    }
}]);

Home.directive('starRating', function () {
    return {
        restrict: 'A',
        template: '<ul class="rating">' +
            '<li ng-repeat="star in stars" ng-class="star" ng-click="toggle($index)">' +
            '\u2605' +
            '</li>' +
            '</ul>',
        scope: {
            ratingValue: '=',
            max: '=',
            onRatingSelected: '&'
        },
        link: function (scope, elem, attrs) {

            var updateStars = function () {
                scope.stars = [];
                for (var i = 0; i < scope.max; i++) {
                    scope.stars.push({
                        filled: i < scope.ratingValue
                    });
                }
            };

            scope.toggle = function (index) {
                scope.ratingValue = index + 1;
                scope.onRatingSelected({
                    rating: index + 1
                });
            };

            scope.$watch('ratingValue', function (oldVal, newVal) {
                if (newVal) {
                    updateStars();
                }
            });
        }
    }
});
Home.controller("ProductDetails", ["$scope", "$http", "$translate", "$cookies", function ($scope, $http, $translate, $cookies ) {
    $translate.use($cookies.get('language')); 
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    ID = IDss = $scope.productID;
    
    $http.get("/Ajax/TrandingSweet")
        .then(function (response) {
            $scope.TrandingSweetjson = JSON.parse(response.data);
        });

    $http.get("/ajax/ProductDetails?Product=" + IDss)
        .then(function (response) {
            
            $scope.rating = 0;
            $scope.ratinguser = 0;
            $scope.datashow = response.data;
            for (i = 0; i < response.data.length; i++) {
                rating = rating + (response.data[i].StarRating);
                response.data[i].CustomerID = response.data[i].CustomerID
            }

            $scope.datashow = response.data;

            $scope.starusercount = response.data.length ; 
            $scope.starrating = ($scope.rating / response.data.length);
            $scope.getStars = function (rating) {
                // Get the value
                var val = parseFloat(rating);
                // Turn value into number/100
                var size = val / 5 * 100;  
                return size + '%';
            }
     });
}]);
$(document).ready(function () {
    $("#idForm").submit(function (e) {

        var url = "/ajax/submitreviewdata"; // the script where you handle the form input.

        $.ajax({
            type: "POST",
            url: url,
            data: $("#idForm").serialize(), // serializes the form's elements.
            success: function (data) {
                $scope.msg = "Your Review Successully saved";
                
            }
        });

        e.preventDefault(); // avoid to execute the actual submit of the form.
    });


})



 