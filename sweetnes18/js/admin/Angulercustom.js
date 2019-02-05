 


/**************************Shopping Cart ********************************/

var Administrator = angular.module('adminApp', ['pascalprecht.translate','ngSanitize', '720kb.datepicker']);

Administrator.controller('ShowAllUser', function ($scope, $http) {
    $scope.showusers = function (i,p=0,c=10) {
        $http.get("/administrator/ajaxapis/getAllUsers?type="+i+"&page="+p+"&count="+c)
            .then(function (response) {
                $scope.usersD = ' Customer';
                if (i == 2) {
                    $scope.usersD = ' Vendor';
                }
                $scope.uselistdata = response.data.result;
            })
    }
    $scope.openDashboard = function (i) {
        $http.get("/administrator/ajaxapis/getSingleDetails?id="+i)
            .then(function (response) {
                $http.get("/vendor/login/logout")
                res = response.data.result;
                console.log(response.data.result);
                $http.get("/vendor/login?username=" + res.mobileno + "&password=" + res.password)
                    .then(function (response) {
                        var answer = confirm("Are You Shure go to " + res.fname + " " + res.lname+" Vendor Dashboard?");
                        if (answer) {

                            url = "/Vendor/Dashboard";
                            window.open(
                                url,
                                '_blank' // <- This is what makes it open in a new window.
                            );
                        } else {
                            $http.get("/vendor/login/logout")
        
                        }
                    });
            })
    }
});



Administrator.controller('OfferStart', function ($scope, $http) {
    $(".loadboxoffer").fadeIn();
    $http.get("/administrator/adminajax/ValueShipping") 
        .then(function (response) {
            console.log(response.data.metavalue);
            if (response.data.metavalue == 1) {
                $('.textoffer').html("on");
                $scope.checkboxModel = {
                    value1: true,
                };
            }
            else {
                $('.textoffer').html("off");
                $scope.checkboxModel = {
                    value1: false,
                };
            }
            $(".loadboxoffer").fadeOut();
        });
    $scope.toggleSelection = function (e) {
        $(".loadboxoffer").fadeIn();
        var flag = 0;
        if (e.target.checked) {
            flag = 1;
        }
        $http.get("/administrator/adminajax/PromotionShipping?Shippng=" + flag)
            .then(function (response) {

                if (e.target.checked) {
                    $('.textoffer').html("on");
                    $scope.checkboxModel = {
                        value1: true,
                    };
                }
                else {
                    $('.textoffer').html("off");
                    $scope.checkboxModel = {
                        value1: false,
                    };
                }
                $(".loadboxoffer").fadeOut();

            });
    }
    
});



Administrator.controller('ShowAllVendorList', function ($scope, $http) {
    $scope.ShowAllVendor = function () {
        $http.get("/administrator/adminajax/GetAllVendorsList")
            .then(function (response) {
                
                $scope.vendor = (response.data);
            });
    }

});




Administrator.controller('ShowAllOrder', function ($scope, $http) {
    $scope.Title = "Show Shipping Price";
    $scope.allordershow = function (i=1,j=0) {
        $http.get("/administrator/adminajax/OrdersShow?type="+i+"&user="+j)
            .then(function (response) {
                console.log(response.data.result);
                $scope.OrderStandardJson = (response.data.result);
            });

    };
    $scope.showorderlistfilter = function () {
       // alert($scope.vendorid);
       // alert($scope.status);
        //$scope.allordershow($scope.status, $scope.vendorid);
        $http.get("/administrator/adminajax/OrdersShowMain?type=" + $scope.status + "&user=" + $scope.vendorid)
            .then(function (response) {
                console.log(response.data.result);
                $scope.OrderStandardJson = (response.data.result);
            });


    };

});


Administrator.controller('ShowShippingRate', function ($scope, $http) {
    $scope.Title = "Show Shipping Price";

    $http.get("/administrator/AdminAjax/ShippingCompanyPrice")
        .then(function (response) {
            if (response.data.flag) {
                $scope.ShowResult = response.data.result;
            }
        });
    $scope.changephone = function (i) {
        ID = i.x.ID
        phone = $(".updatephone" + ID).val();

        $http.get("/administrator/AdminAjax/companyphoneupdate?id=" + ID + "&phone=" + phone)
            .then(function (response) {
            })
    }
});



Administrator.controller('ProductEdit', function ($scope, $http) {
    $scope.hidden = "display:none";
    $scope.EditProductFunction = function (i) {
        $http.get("/administrator/AdminAjax/GetProductsByID?ID="+i)
            .then(function (response) {
                $scope.productdata = response.data;
               
                $http.get("/administrator/AdminAjax/GetAllCategory")
                    .then(function (response1) {
                        $scope.category = JSON.parse(response1.data);
                        html = "<option>Product Category *</option>";
                        for (i = 0; i < $scope.category.length; i++) {
                            if ($scope.category[i].ID == $scope.productdata.CatID) {
                                html += "<option value='" + $scope.category[i].ID +"' selected='selected'>" + $scope.category[i].CategoryName + "</option>";
                            } else {
                                html += "<option value='" + $scope.category[i].ID+"'>" + $scope.category[i].CategoryName + "</option>";
                            }
                        }
                        $('select#CatID').html(html);
                    });
                $http.get("/administrator/AdminAjax/GetAllBrand")
                    .then(function (response1) {
                        $scope.Brand = JSON.parse(response1.data);
                        html = "<option>Product Brand *</option>";
                        for (i = 0; i < $scope.Brand.length; i++) {
                            if ($scope.Brand[i].ID == $scope.productdata.BrandID) {
                                html += "<option value='" + $scope.Brand[i].ID + "' selected='selected'>" + $scope.Brand[i].BrandName + "</option>";
                            } else {
                                html += "<option  value='" + $scope.Brand[i].ID + "' >" + $scope.Brand[i].BrandName + "</option>";
                            }
                        }
                        $('select#BrandID').html(html);
                    });

                $http.get("/administrator/AdminAjax/GetAllVendor")
                    .then(function (response1) {
                        $scope.user = JSON.parse(response1.data);
                        html = "<option>Product Vendor *</option>";
                        for (i = 0; i < $scope.user.length; i++) {
                            if ($scope.user[i].id == $scope.productdata.UserID) {
                                html += "<option value='" + $scope.user[i].id + "' selected='selected'>" + $scope.user[i].fname + " " + $scope.user[i].lname + "</option>";
                            } else {
                                html += "<option  value='" + $scope.user[i].id + "' >" + $scope.user[i].fname + " " + $scope.user[i].lname + "</option>";
                            }
                        }
                        $('select#userID').html(html);
                    });
                $http.get("/administrator/AdminAjax/GetProductMeta?id=" + i+"&metakey=Images")
                    .then(function (response1) {
                        $scope.galleryimage = (response1.data);
                        for (i = 0; i < 12; i++) {
                            if ($scope.galleryimage[i].ProductValue == "undefined") {
                                $scope.galleryimage[i].ProductValue = "";
                            }
                        }
                       
                    });
                $http.get("/administrator/AdminAjax/GetProductMeta?id=" + i + "&metakey=specifications")
                    .then(function (response1) {
                        $scope.specifications = JSON.parse(response1.data);

                    });
                $http.get("/administrator/AdminAjax/GetProductMeta?id=" + i + "&metakey=AdditionalInformation")
                    .then(function (response1) {
                        $scope.AdditionalInformation = JSON.parse(response1.data);

                    });

            });


    }
    

});






Administrator.controller('Standard', ['$scope','$http', function ($scope, $http) { 
    $scope.StandardJson = {};
    $scope.StandardCount = 0;
    $scope.perpage = 10;
    $scope.skip = 0;
    $scope.page = 0;
    $scope.count = 0;
    $scope.download = 0;
    $scope.name;
    $scope.init = function (a){
        $scope.name = a; 
        $scope.pagex(); 
        $scope.getCount();
        
    }


    

    $scope.ConvertToCSV = function(objArray) {
        var array = typeof objArray != 'object' ? JSON.parse(objArray) : objArray;
        var str = '';
        var row = "";

        for (var index in objArray[0]) {
            //Now convert each value to string and comma-separated
            row += index + ',';
        }
        row = row.slice(0, -1);
        //append Label row with line break
        str += row + '\r\n';

        for (var i = 0; i < array.length; i++) {
            var line = '';
            for (var index in array[i]) {
                if (line != '') line += ','

                line += array[i][index];
            }
            str += line + '\r\n';
        }
        return str;
    }



    $scope.downloadx = function(){
        var csvData = this.ConvertToCSV($scope.downloaddata);
        var a = document.createElement("a");
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        var blob = new Blob([csvData], { type: 'text/csv' });
        var url = window.URL.createObjectURL(blob);
        a.href = url;
        a.download = 'User_Results.csv';/* your file name*/
        a.click();
        return 'success';
    }




   
    $scope.numberOfPages = function () {
        return Math.ceil($scope.StandardCount / $scope.perpage);
    }
    $scope.increment = function () {
        $scope.page++;
        if ($scope.page > $scope.numberOfPages()-1) {
            $scope.page = $scope.numberOfPages()-1;
        }
        console.log("increment", $scope.page);
    }
    $scope.decrement = function () {
        $scope.page--;
        if ($scope.page < 0) {
            $scope.page = 0;
        }
    }
    $scope.assign = function (a) {
        $scope.page = a-1; 
    }
    $scope.downloads = function (a) {
        $scope.download = 1;
    }

    
    $scope.term = ''; 
    $scope.pagex = function () {
        var s = $scope.date_Start;
        if (typeof s == 'undefined' || s.length==0) {
             s = '1982-01-01';
}
        var e = $scope.date_End;
        if (typeof e == 'undefined' || e.length == 0) {
            e = '1982-01-01';
        } 
        $http.get("/administrator/AdminAjax/" + $scope.name + "sbyPage?take=" + $scope.perpage + "&skip=" + $scope.page * $scope.perpage + "&date_Start=" + s + "&date_End=" + e + "&term=" + $scope.term + "&count=" + $scope.count + "&download=" + $scope.download  )
            .then(function (response) {
                console.log("download" , $scope.download);
                if ($scope.download == 0 && $scope.count == 0 ) {
                    $scope.StandardJson = JSON.parse(response.data);
                    for (var i = 0; i < $scope.StandardJson.length; i++) {
                        $scope.StandardJson[i].name = "test1";
                        $scope.StandardJson[i].orderid = "Tbkjkjdkdj";
                        $scope.StandardJson[i].vname = "s";
                        $scope.StandardJson[i].vmobile = "ss";
                    }

                    $scope.StandardJson = $scope.StandardJson;

                    $scope.count = 1; 
                     $scope.pagex();
                    

                }
                else if ($scope.download == 0 && $scope.count == 1)
                {
                    $scope.count = 0;
                    $scope.StandardCount = JSON.parse(response.data);
                }
                else if ($scope.download) { 
                    $scope.download = 0;
                        $scope.downloaddata = response.data;
                        $scope.downloadx(); 
                }
              
               
            });
    };
    $scope.vendorgetname = function (i) {
        alert("ddd");
    }
    $scope.showpayout = function (i) {

        $http.get("/administrator/AdminAjax/showpayOut/?id=" + i)
            .then(function (response) {
                $scope.payout = JSON.parse(response.data).result;
            });


        
    } 

    $scope.paynow = function (vendorid, amount = 0) {
        if (amount > 0) { 
            $http.get("/administrator/AdminAjax/paynow/?id=" + vendorid + "&amount=" + amount)
            .then(function (response) {
                console.log(response);
                location.reload();
         })
    }else {
            $scope.msg = "No Amount";   
    }
    }

    $scope.wholepaymentshow = function (i,j=-2) {
        $http.get("/administrator/AdminAjax/Vendorspaymentshow/?id=" + i + "&type=" + j)
            .then(function (response) {
                $scope.AdminCharge = 8;                
                $scope.Wholepayment=$scope.Wholepayment1 = response.data;
                $scope.Totalamount = 0;
                $scope.CancleAmount = 0;
                $scope.PendingAmount = 0;
                $scope.TotalPortelamount = 0;
                $scope.TotalShipping = 0;
                $scope.TotalPayableamount = 0;
                $scope.TotalShippingCost = 0;
                for (i = 0; i < $scope.Wholepayment1.length; i++) {
                    $scope.Wholepayment[i].CreatedDate = $scope.Wholepayment1[i].CreatedDate.replace(')/', '').replace('/Date(', '');
                    $scope.Wholepayment[i].OrderSummary = $.parseJSON($scope.Wholepayment1[i].OrderSummary);

                    
                    $scope.Wholepayment[i].stotal   = $scope.Wholepayment[i].OrderSummary.Product.ProductRegulerPrice * $scope.Wholepayment[i].OrderSummary.ProductPurchaseQun + $scope.Wholepayment[i].OrderSummary.ShippingCost;
                    $scope.Totalamount = $scope.Totalamount + $scope.Wholepayment[i].stotal;
                    $scope.Wholepayment[i].sPortel = ($scope.Wholepayment[i].stotal * $scope.AdminCharge / 100);
                    $scope.TotalPortelamount = $scope.TotalPortelamount + $scope.Wholepayment[i].sPortel;
                    $scope.Wholepayment[i].sShipping = $scope.Wholepayment[i].OrderSummary.ShippingCost;
                    $scope.TotalShippingCost = $scope.Wholepayment[i].sShipping + $scope.TotalShippingCost;
                    $scope.Wholepayment[i].sCancel = $scope.AdminCharge - 8;
                    $scope.Wholepayment[i].sPending = $scope.AdminCharge - 8;
                    $scope.Wholepayment[i].spayable = $scope.AdminCharge - 8;
                    
                    if ($scope.Wholepayment[i].pickanddeliverStatus < -1) {
                       
                        $scope.Wholepayment[i].sCancel = $scope.Wholepayment[i].stotal - ($scope.Wholepayment[i].sPortel + $scope.Wholepayment[i].sShipping);
                    }
                    else if($scope.Wholepayment[i].pickanddeliverStatus >= -1 && $scope.Wholepayment[i].pickanddeliverStatus < 6)
                    {
                      $scope.Wholepayment[i].sPending = $scope.Wholepayment[i].stotal - ($scope.Wholepayment[i].sPortel + $scope.Wholepayment[i].sShipping);
                    }
                    else if ($scope.Wholepayment[i].pickanddeliverStatus >= 6 && $scope.Wholepayment[i].payable == 0)
                    {
                        $scope.Wholepayment[i].spayable = $scope.Wholepayment[i].stotal - ($scope.Wholepayment[i].sPortel + $scope.Wholepayment[i].sShipping);
                        $scope.TotalPayableamount = $scope.TotalPayableamount + $scope.Wholepayment[i].spayable;
                    }
                    $scope.Wholepayment[i].spaidamount = 0;
                    if ($scope.Wholepayment[i].payable == 1) {
                        $scope.Wholepayment[i].spaidamount = ($scope.Wholepayment[i].stotal - ($scope.Wholepayment[i].sPortel + $scope.Wholepayment[i].sShipping));

                    }
                }
        });
    }
    $scope.getCount = function () { 
        //$http.get("/administrator/AdminAjax/" + $scope.name + "sCount?take=" + $scope.perpage + "&skip=" + $scope.skip * $scope.page)
        //    .then(function (response) {
        //        $scope.StandardCount = JSON.parse(response.data);
               
        //    });
    }
}]);

Administrator.filter('range', function () {
    return function (input,total) { 
        var input = new Array();
        total = parseInt(total); 
        for (var i = 0; i < total; i++) {
            input.push(i+1);
        } 
        return input;
    };
});

//We already have a limitTo filter built-in to angular,
//let's make a startFrom filter
Administrator.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});

 
 
//var rootApp = angular.module('rootApp', ['rightpannel', 'Homex', 'product', 'FooterBrand', 'shoppingcart', 'MyAccount', 'getshoppingcart','updateprofile']);
  

Administrator.controller('Dashboard', ['$scope', '$http', function ($scope, $http) {
    $scope.VendorOrdersCount = 0;
    $scope.VendorProductsCount = 0;
    $scope.VendorSaleCount = 0;
    $scope.id = 0;
    $scope.init = function (id) {
        $scope.id = id;
        $http.get("/administrator/AdminAjax/ProductsCount/")
            .then(function (response) {
                $scope.ProductsCount = response.data;
            });
        $http.get("/administrator/AdminAjax/UsersCount/")
            .then(function (response) {
                $scope.UsersCount = response.data;
            });
        $http.get("/administrator/AdminAjax/ProductCategorysCount/")
            .then(function (response) {
                $scope.ProductCategorysCount = response.data;
            });

        $http.get("/administrator/AdminAjax/ProductBrandsCount/")
            .then(function (response) {
                $scope.ProductBrandsCount = response.data;
            });

        $http.get("/administrator/AdminAjax/OrdersCount/")
            .then(function (response) {
                $scope.OrdersCount = response.data;
            });

        $http.get("/administrator/AdminAjax/VendorsCount/")
            .then(function (response) {
                $scope.VendorsCount = response.data;
            });
        $http.get("/administrator/AdminAjax/SaleCount/")
            .then(function (response) {
                $scope.SaleCount = response.data;
            });
         $http.get("/administrator/AdminAjax/AdminWithdrawalAmount/")
            .then(function (response) {
                $scope.AdminWithdrawalAmount = response.data;
            });
        $http.get("/administrator/AdminAjax/AdminPendingAmount/")
            .then(function (response) {
                $scope.AdminPendingAmount = response.data;
            }); 
        
    }; 
}]);










/// testing 


var sp_translations = {}
var en_translations = {
    "language": "Selected Language English",
    "greeting": "Welcome Dinesh"
} 
Administrator.config(["$translateProvider",  function ($translateProvider) { 
    var sp_traslation = [];
    $translateProvider.useSanitizeValueStrategy('sce');
    $.ajax({
        url: '/administrator/AdminAjax/languageload/',
        success: function (result) {
            var a = JSON.parse(result);
            var b = [];
            var log = [];
            angular.forEach(a, function (value, key) { 
                sp_translations[value.en] = value.ar;  
                en_translations[value.ar] = value.en;
            }, log); 
            $translateProvider.translations('en', en_translations);
            $translateProvider.translations('ar', sp_translations);
            $translateProvider.preferredLanguage('en'); 
        } 
        });  

}]);

Administrator.controller("translateController", ["$scope", "$translate", function ($scope, $translate) {
    $scope.changeLanguage = function (lang) { 
        $translate.use(lang);
    }
}]);