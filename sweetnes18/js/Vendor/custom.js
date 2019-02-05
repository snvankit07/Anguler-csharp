var app = angular.module('vendor', ['uiSlider']);
app.controller('Offerdisplay', function ($scope, $http) {
    $http.get("/Vendor/AjaxOffer/OfferList")
        .then(function (response) {
            $scope.vendorofferjson = JSON.parse(response.data);
            
        });
});
/*-----------------Date Picker--------------------*/

//angular.module('myApp').filter('randomize', function() {
//  return function(input, scope) {
//    if (input!=null && input!=undefined && input > 1) {
//      return Math.floor((Math.random()*input)+1);
//    }  
//  }
//});