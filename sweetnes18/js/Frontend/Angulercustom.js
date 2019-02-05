 


/**************************Shopping Cart ********************************/

var Home = angular.module('shoppingcart', ['ngCookies']);

Home.controller('Shopping', function ($scope, $http, $translate, $cookies ) {
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }

    $http.get("/cart/getCart")
        .then(function (response) {
            
            $scope.Shopjson = JSON.parse(response.data);
        });
}); 


var MyAccount = angular.module('MyAccount', ['ngCookies']);

MyAccount.controller('MyAccountUserProfile', function ($scope, $http, $translate, $cookies) {
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }

    $http.get("/cart/getCart")
        .then(function (response) {
            
            $scope.Shopjson = JSON.parse(response.data);
        });
});


var Profile = angular.module('updateprofile', ['ngCookies']);
Profile.controller('Passwordchange', function ($scope, $http, $translate, $cookies) {
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    $scope.passwordupdate = function () {
       
       
        if ($scope.reoldpass != $scope.oldpass) {
            $scope.msg = "Password mismatch";
            $scope.class = "animated bounceIn alert alert-danger";
        } else {
            $scope.class = "animated bounceOut ";
            $scope.msg = "";
           /* $http({
                method: 'POST',
                url: '/ajax/updateProfile',
                data: $.param($scope.formData),  // pass in data as strings
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // set the headers so angular passing info as form data (not request payload)
            })
                .success(function (data) {

                }) */
        }
        
    }
});

/**************************Todays Sweet Page ***********************/

function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;
    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }

    return res;
}

function findAncestor(el, cls) {
    while ((el = el.parentElement) && !el.classList.contains(cls));
    return el;
}
var app = angular.module('product', ['rzModule','ngCookies']);

app.controller('pdisplay', function ($scope, $http, $timeout, $q, $translate, $cookies) {
    $translate.use($cookies.get('language')); // Working for  filter page 
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    $scope.PageName = "Sweet";
    $scope.count = 0;
    $scope.countx = 0;
    //Range slider config
    $scope.rangeSlider = {

        minValue: 0,
        maxValue: 50000,
        options: {
            id: 'slider-id',
            floor: 0,
            ceil: 50000,
            step: 1,
            onChange: function (id) {
                $scope.count = 1;
                $scope.countx = 1;
                setTimeout(function () {
                    if ($scope.count) {
                        $scope.filterbycategories($scope.$event);
                        $scope.count = 0;
                    }
                }, 3000);

            }
        }
    };
    $scope.runx = function () {
        var parent = $('.side-div').find('li');
        parent.find(':checked').each(function (that, index, element) {
            var parent = $(index).closest('li');
            parent.find('input').each(function (that, index, element) {
                $scope.category_selected[index.value] = true;
            });

            //    if ($(index).checked) {
            // console.log(that, index, element, $(index).checked);
            //     }               
        });
    };
    $q.all([
        $http.get("/Todaysweet/categories")
            .then(function (response) {
                $scope.categoriesjson = JSON.parse(response.data);
                $timeout($scope.runx, 1);
            }),
        $http.get("/Todaysweet/brands")
            .then(function (response) {
                $scope.brandjson = JSON.parse(response.data);
            })]).then(function () {

                if ($scope.category == 0) {
                    var parent = $('.side-div').find('li');
                    parent.find('input').each(function (that, index, element) {
                        $scope.category_selected[index.value] = true;
                    });
                }
                $scope.PageName = $scope.option;

                $scope.filterbycategories($scope.$event);
            });

    $scope.category_selected = {};
    $scope.brand_selected = 0;
    $scope.categoryinit = 0;
    $scope.option = "Filter";
    $scope.category = 0;
    $scope.filterbycategories = $scope.filterbybrand = function (obj, value) {

        if (typeof obj != 'undefined') {
            var parent = $(obj.target).closest('li');
            parent.find('input').each(function (that, index, element) {
                $scope.category_selected[index.value] = obj.target.checked;
            });
            // delete $scope.category_selected[0]; 
        }

        loaderhide();
        // var brand_val = (typeof value == 'undefined') ? $scope.brand_selected : value;
        if (typeof value != 'undefined') {
            $scope.brand_selected = value;
        }

        var keys = [];
        for (var k in $scope.category_selected) {
            if ($scope.category_selected[k] && k != 0)
                keys.push(k);
        }

        var a = keys;
        keys = [];
        var b = encodeURI(a.join(','));
        $http.get("/Todaysweet/filter?Category_option=" + b + "&Brand_option=" + $scope.brand_selected + "&pricing_max=" + $scope.rangeSlider.maxValue + "&pricing_min=" + $scope.rangeSlider.minValue + "&option=" + $scope.option)
            .then(function (response) {
                $scope.productjson = (response.data);
            });
        loaderhide(true);
    }


    $scope.someSelected = function (object) {
        //Object
        return Object.keys(object).some(function (key) {
            return object[key];
        });
    }



    $scope.addtocart = function (productid, that) {
        var quan = 0;
        quan = quan + 1; 
        $.ajax({
            url: "/cart/AddC/?productid=" + productid + "&Quantity=" + quan,
            success: function (result) {
                cartpageupdate();
                notifyMe("Add one-more product", "One More Product Add In Cart", "/shoppingcart", '/img/Icon/1.png');
                
            }
        });
    };



    var option = getUrlParameter('option');
    if (typeof option != "undefined") {
        $scope.option = option;
    }

    var category = $scope.category  = getUrlParameter('category');
    if (typeof category != "undefined") {
        $scope.PageName = "Category";
        $scope.category_selected[category] = true;
        $scope.categoryinit = category; 
    }
    var brand = getUrlParameter('brand');
    if (typeof brand != "undefined") {
        $scope.PageName = "Brand";
        $scope.category_selected = {};
        $scope.brand_selected = brand;
        $scope.filterbybrand($scope.$event,brand);
    }
});
        //?Category_option=2&Brand_option=5&pricing_max=2001&pricing_min=1999 



var ngright = angular.module("rightpannel", ['ngCookies']);


ngright.controller("rightpannels", function ($scope, $http, $translate, $cookies) {
    
    
    
   
     if (typeof $cookies.get('language') === "undefined") {
         $cookies.put("language", "en", { 'path': '/' });
         $("body").removeClass('en'); 
         $("body").removeClass('ar');
         $("body").addClass('en');
    }  
    $scope.selectedName = $cookies.get('language');
    console.log($cookies.get('language'), document.cookie, "ret");
    $translate.use($cookies.get('language')); // Working for home page
    console.log($cookies.get('language'), document.cookie, "ret");
    $("body").removeClass('en');
    $("body").removeClass('ar');
    $("body").addClass($cookies.get('language'));
    
    $scope.changeLanguage = function () {  
        $cookies.put("language", $scope.selectedName,{ 'path': '/' });
        $translate.use($cookies.get('language'));
        
        $("body").removeClass('en');
        $("body").removeClass('ar');
        $("body").addClass($cookies.get('language'));
        cartpageupdate();
    } 
    $http.get("/ajax/CheckLogin")
        .then(function (response) {
            
            $scope.checkoutuser = response.data;
            if (response.data.Status) {
                //createaccount/login
                //createaccount/logout
                $scope.loginmyaccount       = "My Account";
                $scope.loginmyaccounturl = "Myaccount"; 
                $scope.logoutregistration = "Logout"; 
                $scope.logoutregistrationurl = "createaccount/logout";

                $scope.checkoutusername =  response.data.result.fname + " " + response.data.result.lname;

            } else {
                $scope.loginmyaccount = "Login";
                $scope.loginmyaccounturl = "createaccount/login";
                $scope.logoutregistration = "Registration";
                $scope.logoutregistrationurl = "createaccount";
                $scope.checkoutusername = "Guest";
            }
        });

});



var FooterBrand = angular.module('FooterBrand', ['ngCookies']);

FooterBrand.controller('FooterBrandC', function ($scope, $http, $translate, $cookies) { 
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    $http.get("/Ajax/Brand?w=1")
        .then(function (response) {
            $scope.brandjsonx = JSON.parse(response.data);
        });

    /*
        $http.post("/Ajaxapi/UpdateProductDatas")
        .then(function (dresponse) {
        });*/
});
 
var rootApp = angular.module('rootApp', ['rightpannel', 'Homex', 'product', 'FooterBrand', 'shoppingcart', 'MyAccount', 'getshoppingcart', 'updateprofile', 'pascalprecht.translate', 'ngCookies','extra']);

var extra = angular.module('extra', ['pascalprecht.translate', 'ngCookies']);
extra.controller('extra', function ($scope, $http, $translate, $cookies) {
    $translate.use($cookies.get('language')); 
    $scope.csslang=$cookies.get('language')
    $scope.changeLanguage = function (lang) {
        $translate.use(lang); 
        $scope.csslang = lang;
    }
});
rootApp.controller('CreateVendor', function ($scope, $http) {
    $scope.msg = "ssssss";
    alert($scope.msg);
})


rootApp.controller('formsubmit', function ($scope, $http, $translate, $cookies ) {
    $scope.mobile = "";
    $scope.email = "";
    $scope.fname = ""
    $scope.lname = "";
    $scope.pass = "";

    $translate.use($cookies.get('language')); 
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    } 
    
    $scope.mobilenoupdate = function () {
       
        $http.get("/ajaxapi/PasswordCheackMobile?mobile=" + $scope.mobileno)
            .then(function (response) {
                if (response.data.flag == true) {
                    $scope.optgen = (response.data.result);
                    //alert(response.data.result);
                    $("#mobilenoupdate").hide();
                    $("#otpupdate").show();
                    $scope.msg = "";
                } else {
                    $scope.msg = response.data.message;
                }
            })
       
    }
    $scope.Otpupdate = function () {
        if ($scope.optgen == $scope.otpno) {
            $("#otpupdate").hide();
            $("#passupdate").show();
            $scope.msg = "";
        } else {
            msgshow("Please Enter Valid Otp Number", "danger");
            $scope.msg = "Please Enter Valid Otp Number";

        }
    }
    $scope.Passwordupdate = function () {
        
        if ($scope.passno == $scope.passno1) {
            $http.get("/ajaxapi/PasswordSetMobile?mobile=" + $scope.mobileno + "&password=" + $scope.passno)
                .then(function (response) {
                    if (response.data.flag == true) {
                        $("#passupdate").hide();
                        $('.successpassword').show();
                        msgshow("Your Password successfully update", "success");
                    }

                }) 
        }
        else
        {
            $scope.msg = "Please Enter Same password";
            msgshow($scope.msg, "danger");
        }
        
        
        
    }
    $scope.passwordstrong = function () {
        var password_strength = document.getElementById("password_strength");
        password = $("#txtPassword").val();
        //TextBox left blank.
        if (password.length == 0) {
            password_strength.innerHTML = "";
            return;
        }

        //Regular Expressions.
        var regex = new Array();
        regex.push("[A-Z]"); //Uppercase Alphabet.
        regex.push("[a-z]"); //Lowercase Alphabet.
        regex.push("[0-9]"); //Digit.
        regex.push("[$@$!%*#?&]"); //Special Character.

        var passed = 0;

        //Validate for each Regular Expression.
        for (var i = 0; i < regex.length; i++) {
            if (new RegExp(regex[i]).test(password)) {
                passed++;
            }
        }

        //Validate for length of Password.
        if (passed > 2 && password.length > 8) {
            passed++;
        }

        //Display status.
        var color = "";
        var strength = "";
        var width = "";
        switch (passed) {
            case 0:
            case 1:
                strength = "Weak";
                color = "red";
                width = 20;
                break;
            case 2:
                strength = "Good";
                color = "darkorange";
                width = 40;
                break;
            case 3:
            case 4:
                strength = "Strong";
                color = "green";
                width = 80;
                break;
            case 5:
                strength = "Very Strong";
                color = "darkgreen";
                width = 100;
                break;
        }
        password_strength.innerHTML = strength;
        password_strength.style.background = color;
        password_strength.style.width = width + "%";
    }

    $scope.msg = "";
    $scope.error = 0;
    $scope.CreateAccountFunc = function () {
        i = 0;
        v = $http.get("/ajax/mobileEmailchk?mobile=" + $scope.mobile +"&email="+$scope.email)
            .then(function (response) {
                $scope.chkmobiledata = (response.data);
               
                $(".mailer,.pher").html("");
                $scope.msg = "";
                if ($scope.chkmobiledata.username == $scope.email) {
                    $scope.msg = " Mail Address already used.";
                    $(".mailer").html("Mail ID already used.")
                    i++;
                }
                if ($scope.chkmobiledata.mobileno == $scope.mobile) {
                    $scope.msg = " Mobile Numer Already Used";
                    $(".pher").html("Mobile Numer Already Used.")
                    i++;
                }
                if (i > 0) {
                    msgshow($scope.msg, "danger");
                }
                if (i == 0) {
                    $http.get("/ajax/CreateNewUser?mobile=" + $scope.mobile + "&email=" + $scope.email + "&fname=" + $scope.fname + "&lname=" + $scope.lname + "&pass=" + $scope.pass+"&type=1")
                        .then(function (response) { 
                           
                            
                            if (response.data.flag) {
                                $scope.mobile = "";
                                $scope.email = "";
                                $scope.fname = ""
                                $scope.lname = "";
                                $scope.pass = "";
                                msgshow("User Create Successfully.", "success");
                                
                            }
                        })
                }
             });
         }
        $scope.chkmobile = function () {
            $http.get("/ajax/mobilenochk?mobile=" + $scope.mobile)
                .then(function (response) {
                    $scope.chkmobiledata = (response);
                   
                    $(".pher").html("");
                    if ($scope.chkmobiledata.data != "" && $scope.mobile.length>3) {
                        $scope.error = $scope.error + 1;
                        //msgshow("Mobile Number Already Used.", "danger");
                        $(".pher").html("Mobile Number Already Used.")
                    }
                });
        }
        $scope.chkemail = function () {
            $http.get("/ajax/emailidchk?email=" + $scope.email)
                .then(function (response) {
                    $scope.chkemaildata = (response);
                    
                    $(".mailer").html("");
                    if ($scope.chkemaildata.data != "") {
                        $scope.error = $scope.error + 1;
                        //msgshow("Mailaddress Already Used.", "danger");
                        $(".mailer").html("Mailaddress Already Used.")
                    }
                }); 
        }
});
rootApp.controller('searchingproducts', function ($scope, $http, $translate, $cookies ) {
    $translate.use($cookies.get('language'));
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
    }
    $scope.searchingdataproduct = function () {
        $http.get("/ajax/productSearch?product=" + $scope.product)
            .then(function (response) {
                $scope.chkproductdata = JSON.parse(response.data);
                
                if ($scope.chkproductdata.length == 0) {
                    $('.productsearchresults').hide();
                } else {
                    $('.productsearchresults').show();
                }
            });
    }
    
});
rootApp.controller('getCustomerAccount', function ($scope, $http, $translate) {
    $translate.use($cookies.get('language')); 
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
        window.location.reload();
    };
    $scope.ordershow = function (data, value) {
        // $scope
    };
});


var sp_translations = {}
var en_translations = {
    "language": "Selected Language English",
    "greeting": "Welcome Dinesh"
}
rootApp.config(["$translateProvider", function ($translateProvider) { 
    $translateProvider.useSanitizeValueStrategy('sce');
    var sp_traslation = [];
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

rootApp.controller("translateController", ["$scope", "$translate", function ($scope, $translate) {
    $scope.changeLanguage = function (lang) {
        $translate.use(lang);
        window.location.reload();
    }
}]);

