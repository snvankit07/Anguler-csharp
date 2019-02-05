var Vendor = angular.module('vendorApp', ['720kb.datepicker']);

Vendor.controller('CreateVendorPasswrord', function ($scope, $http) {
    $('.newPassword,.sendotpchk').fadeOut();
    
    $scope.updatemobilenumber = function () {
        
        $http.get("/vendor/vendorapi/PasswordCheackMobile?mobile=" + $scope.mobilenumber)
            .then(function (response) {
                if (response.data.flag == false) {
                    $scope.smsg = "";
                    $scope.emsg = response.data.message;
                    $('.mobilenumber').show();
                } else {
                    $scope.emsg = "";
                    $scope.smsg = response.data.message;
                    $scope.otpdata = response.data.result;
                    $('.mobilenumber').fadeOut();
                    $('.sendotpchk').show();
                }
            })
       
    }

    $scope.updateotpdatanumber = function () {

        if ($scope.otpdata == $scope.votpdata) {
            $scope.emsg = "";
            $scope.smsg = "Otp Data Verify";
            $('.mobilenumber,.sendotpchk').fadeOut();
            $('.newPassword').show();
            
        } else {
            $scope.emsg = "OTP Not Matched";
            $scope.smsg = "";
            $('.sendotpchk').show();
        }

    }
    $scope.resentotp = function () {
        $scope.updatemobilenumber();
        $('.sendotpchk').show();
    }

    $scope.updatePassword = function () {
        if ($scope.password == $scope.cpassword) {
            $http.get("/vendor/vendorapi/PasswordSetMobile?mobile=" + $scope.mobilenumber + "&password=" + $scope.cpassword)
                .then(function (response) {
                    $scope.smsg = response.data.message+" successfully";
                    $scope.emsg = "";
                });

        } else {
            $scope.emsg = "Password mismatched";
            $scope.smsg = "";
        }
    }

});


Vendor.controller('Menus', function ($scope, $http) {
    $scope.menusdata = {
        "menu1": { "link": "Dashboard", "icon": "fa-fw fa-dashboard", "text": "Dashboard" },
        "menu2": { "link": "Products/Create", "icon": "fa-fw fa-area-chart", "text": "Add New Products" },
        "menu3": { "link": "Products", "icon": "fa-fw fa-list", "text": "Product List" },
        "menu4": { "link": "Order", "icon": "fa-fw fa-dashboard", "text": "All Orders" },
        "menu5": { "link": "Productoffers", "icon": "fa-fw fa-dashboard", "text": "Your Offer's" },
        //"menu6": { "link": "Setting", "icon": "fa-fw fa-dashboard", "text": "Genral setting" },
        "menu7": { "link": "Financial", "icon": "fa-fw fa-dashboard", "text": "Financial" },
        "menu8": { "link": "vendor_profile", "icon": "fa-fw fa-dashboard", "text": "Vendor Profile" },
    };
});
Vendor.controller('checkprofilecomplete', function ($scope, $http) {

    $http.get("/Vendor/vendorajax/VendorProfileData")
        .then(function (response) {
            $scope.msg = "Please Complete Your Profile City  Overwise Your Product not Show in Portel";
            $scope.showhide = response.data.result.userdata[0].City;
        })
   //$scope.showhide = "hidden";
})


Vendor.controller('showtitle', function ($scope, $http) {
    $http.get("/Vendor/vendorajax/getbusinessinfo")
        .then(function (response) { 
            var business = "Ankit Business";
            for (i = 0; i < response.data.result.length;i++)
            {
                if (response.data.result[i].metakey == "Business") {
                    $scope.Businesstitle = response.data.result[i].metavalue;
                }
            }

            
        });
  })

Vendor.controller('VendorProfile', function ($scope, $http) {
    $scope.Profiledata = [];

    $(document).on("change", ".Citybox select", function () {
        
        alert($(this + " option:selected").val());
    })
    

    $scope.ShowVendorProfile = function (id) {
        
        $http.get("/Vendor/vendorajax/VendorProfileData?vendorID=" + id)
            .then(function (response) {
                $scope.Profiledata = response.data.result;
                //alert($scope.Profiledata.userdata[0].City);
                $http.get("/js/citys.js").then(function (response) {
                    
                    var html = "<select ng-keyup='updatecountry()'  class='form-control citydata' ng-model='Profiledata.usermetadata.City'>";
                    html += "<option " + s + " value='0'>Select City</option>";
                    for (i = 0; i < response.data.length; i++) {
                        if (response.data[i].country == "United Arab Emirates") {
                        var s = "";
                        if ($scope.Profiledata.userdata[0].City == response.data[i].geonameid) {
                            $scope.Profiledata.usermetadata.Country = response.data[i].subcountry;
                            $scope.Profiledata.usermetadata.State = response.data[i].geonameid;
                            s = "selected='selected'";
                        }
                             html += "<option " + s + " value='" + response.data[i].geonameid + "'>" + response.data[i].name + "</option>";
                        }
                    }
                    html += "</select>";
                    
                    $('.Citybox').html(html);
                });


                $scope.Profiledata.usermetadata = {};
                for (i = 0; i <= $scope.Profiledata.usermeta.length; i++) {
                    console.log($scope.Profiledata.usermeta[i]);
                    $scope.Profiledata.usermetadata[$scope.Profiledata.usermeta[i].metakey] = $scope.Profiledata.usermeta[i].metavalue;
                    $scope.Profiledata.cnewpass = $scope.Profiledata.newpass = $scope.Profiledata.oldpass = ""; 
                }
                
            })
        
    }
    $scope.VendorProfileUpdate = function (id) {
        formData = $scope.Profiledata;

        if (formData.oldpass == formData.userdata[0].password) {
            alert("change");
        }


        var data = $.param({
            userid: id,
            fName: formData.userdata[0].fname,
            lName: formData.userdata[0].lname,
            About: formData.usermetadata.About,
            Business: formData.usermetadata.Business,
            City: $('.citydata').val(),
            Country: formData.usermetadata.Country,
            Dec: formData.usermetadata.Dec,
            Vatnumber: formData.usermetadata.Vatnumber,
            Accountholder: formData.usermetadata.Accountholder,
            Accountnumber: formData.usermetadata.Accountnumber,
            IBAN: formData.usermetadata.IBAN,
            Swiftcode: formData.usermetadata.Swiftcode,
            Bankname: formData.usermetadata.Bankname,
            Bankcity: formData.usermetadata.Bankcity,
            Bankcountry: formData.usermetadata.Bankcountry,
            State: formData.usermetadata.State,
            add: formData.usermetadata.add,
            oldpass: formData.oldpass,
            newpass: formData.newpass,
            cnewpass: formData.cnewpass,
        });
        console.log(data);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        $http.post('/Vendor/vendorajax/UpdateVendorProfile', data, config)
            .success(function (data) {
                $scope.msg = data.message;
                if (data.flag == true) {
                    document.location.reload();

                }
               
            })
    }

});

Vendor.controller('ProductEdit', function ($scope, $http) {
    $scope.hidden = "display:none";
    $scope.deleteproductimg = function (i) {
        
        var noimg = "background: url('/img/Product/imgs.jpg')";
        $(".imagesshow_" + i).attr('style', noimg);
        $(".imagesSh_" + i).val('/img/Product/imgs.jpg');
        $(".images_" + i).val("");
      
    }
    $scope.EditProductFunction = function (i) {
        
        $http.get("/administrator/AdminAjax/GetProductsByID?ID=" + i)
            .then(function (response) {
                console.log("----------ProDetail---------------" );
                console.log(response.data)
                $scope.productdata = response.data;

                $http.get("/administrator/AdminAjax/GetAllCategory")
                    .then(function (response1) {
                        $scope.category = JSON.parse(response1.data);
                        html = "<option>Product Category *</option>";
                        for (i = 0; i < $scope.category.length; i++) {
                            if ($scope.category[i].ID == $scope.productdata.CatID) {
                                html += "<option value='" + $scope.category[i].ID + "' selected='selected'>" + $scope.category[i].CategoryName + "</option>";
                            } else {
                                html += "<option value='" + $scope.category[i].ID + "'>" + $scope.category[i].CategoryName + "</option>";
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
                $http.get("/administrator/AdminAjax/GetProductMeta?id=" + i + "&metakey=Images")
                    .then(function (response1) {
                        $scope.galleryimage = ( response1.data) ;  

                    });
                $http.get("/administrator/AdminAjax/GetProductMeta?id=" + i + "&metakey=specifications")
                    .then(function (response1) {
                        $scope.specifications = (response1.data);
                        console.log($scope.specifications);

                    });
                $http.get("/administrator/AdminAjax/GetProductMeta?id=" + i + "&metakey=AdditionalInformation")
                    .then(function (response1) {
                        $scope.AdditionalInformation = (response1.data); 
                    });

            });


    }

 

});

Vendor.controller('ProductsList', function ($scope, $http) {

    $scope.getProductList = function (i) {

        $http.get("/Vendor/VendorAjax/ProductList/?vendorID=" +i)
            .then(function (response) {
                $scope.Productlists = response;
        })
    }
});

Vendor.filter('shipping', function () {
    return function (input) { 
        return JSON.parse(input).ShippingCost;
    };
});
Vendor.filter('title', function () {
    return function (input) {
        return JSON.parse(input).Product.ProductTitle;
    };
});
Vendor.filter('adminamount', function () {
    return function (input) {
        var i = input.ProductPricing * 8 / 100;
        //input.ProductPricing - 
        //- JSON.parse(input.OrderSummary).ShippingCost  
        return i;
    };
});

Vendor.filter('paybleamount', function () {
    return function (input) {
        var i = input.ProductPricing - ( input.ProductPricing * 8 / 100 )  -  ( JSON.parse(input.OrderSummary).ShippingCost ) ;
        console.log(i);
        return i; 
    };
});

Vendor.controller('Financial', function ($scope, $http) {
    
      
    $scope.showvendordata = function (i, j) {

        $http.get("/VendorApi/transaction/?vendor=" + i + "&type=" + j)
            .then(function (response) {
                $scope.Wholepayment = (response.data);


            });
    };

    $scope.showtransactionDetails = function (i) {

        $http.get("/VendorApi/transactionDetails/?ID=" + i)
            .then(function (response) {
                $scope.showtransactionData = (response.data.result[0]);


            });
    };

});
Vendor.controller('OrderTypeS', function ($scope, $http) {
    $scope.OrderTypeShow = function (id) {
        $http.get("/vendor/vendorapi/OrdersShow?type=1&user=" + id)
            .then(function (response) {
                $scope.Offerd = response.data.result;
                $scope.OrderList = response.data.result;
            })
    }

    $scope.OrderDetailsShow = function (id) {
        $http.get("/vendor/VendorApi/OrdersShowSingle?orderid=" + id)
            .then(function (response) {
                
                $scope.OrderListDetails = response.data.result[0];
            })

    }

    $scope.updatestatus = function (status,vids) {
        
        $http.get("/vendor/VendorAjax/UpdateStatus?id=" + status)
            .then(function (response) {
                $scope.OrderDetailsShow(status);
                $scope.OrderTypeShow(vids);
            })
    }

    $scope.detailsupdatestatus = function (status) {
        
        $http.get("/vendor/VendorAjax/UpdateStatus?id=" + status)
            .then(function (response) {
                $scope.OrderDetailsShow(status);
                
            })
    }


    $scope.GetOrderByStatus = function (UID, ID) {
        ID = parseInt(ID);
        $http.get("/vendor/VendorApi/OrdersShow?user=" + UID + "&type=" + ID)
            .then(function (response) {
                
                $scope.OrderType = response.data.message;
                $scope.GetOrderData = response.data.result;
                
            })
    }
});




Vendor.controller('ShowOfferData', function ($scope, $http) {
    
    $scope.getOfferdata = function (id) {
        $http.get("/vendor/VendorAjax/getAllOfferList?id=" + id)
            .then(function (response) {
                $scope.MobileshowOffer = response.data.result;
                $scope.DesktopshowOffer = response.data.result;
            });
    }

});
Vendor.controller('Dashboard', function ($scope, $http) {
    $scope.VendorOrdersCount = 0;
    $scope.VendorProductsCount = 0;
    $scope.VendorSaleCount = 0;
    $scope.VendorWithdrawalAmount = 0;
    $scope.VendorPendingAmount = 0;
    $scope.id = 0;
    $scope.init = function (id) {
        $scope.id = id; 
        $http.get("/VendorApi/Dashboard/?user=" + $scope.id)
            .then(function (response) {
                var data = response.data.result[0];
             //   console.log();
             //   AllPayment, ClearPayment, Customer, Order, PendingPayment, Product, graphdata
                $scope.VendorRevenue = data.AllPayment;
                $scope.VendorClearPayment = data.ClearPayment;
                $scope.VendorPendingPayment = data.PendingPayment;
                $scope.VendorTotalOrders = data.Order;
                $scope.VendorCustomer = data.Customer;
                $scope.VendorProduct = data.Product;
            });
       
    }; 
});










Vendor.controller('Standard', ['$scope', '$http', function ($scope, $http) {
    $scope.StandardJson = {};
    $scope.StandardCount = 0;
    $scope.perpage = 10;
    $scope.skip = 0;
    $scope.page = 0;
    $scope.count = 0;
    $scope.download = 0;
    $scope.name;
    $scope.init = function (a) {
        $scope.name = a;
        $scope.pagex();
    };
    $scope.statusupdate = function (i, j) {

        $http.get("/vendor/vendorapi/ProductStatus/?ProductID=" + j + "&Status=" + i)
            .then(function (response) {
                $scope.init('Product');
            });

    };

    $scope.deleteproductdata = function (j) {

        $http.get("/vendor/vendorapi/ProductStatus/?ProductID=" + j + "&Status=-2")
            .then(function (response) {
                $scope.init('Product'); 
            });

    };
    

    $scope.ConvertToCSV = function (objArray) {
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

    

    $scope.downloadx = function () {
        var csvData = this.ConvertToCSV($scope.downloaddata);
        var a = document.createElement("a");
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        var blob = new Blob([csvData], { type: 'text/csv' });
        var url = window.URL.createObjectURL(blob);
        a.href = url;
        a.download = 'Results.csv';/* your file name*/
        a.click();
        return 'success';
    }





    $scope.numberOfPages = function () {
        return Math.ceil($scope.StandardCount / $scope.perpage);
    }
    $scope.increment = function () {
        $scope.page++;
        if ($scope.page > $scope.numberOfPages() - 1) {
            $scope.page = $scope.numberOfPages() - 1;
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
        $scope.page = a - 1;
    }
    $scope.downloads = function (a) {
        $scope.download = 1;
    }


    $scope.term = '';
    $scope.pagex = function () {
        var s = $scope.date_Start;
        if (typeof s == 'undefined' || s.length == 0) {
            s = '1982-01-01';
        }
        var e = $scope.date_End;
        if (typeof e == 'undefined' || e.length == 0) {
            e = '1982-01-01';
        }
        $http.get("/Vendor/VendorAjax/" + $scope.name + "List?take=" + $scope.perpage + "&skip=" + $scope.page * $scope.perpage + "&date_Start=" + s + "&date_End=" + e + "&term=" + $scope.term + "&count=" + $scope.count + "&download=" + $scope.download)
            .then(function (response) {
                console.log("download", $scope.download);
                if ($scope.download == 0 && $scope.count == 0) {
                    $scope.StandardJson = response.data.result;
                    for (var i = 0; i < $scope.StandardJson.length; i++) {
                        $scope.StandardJson[i].name = "test1";
                        $scope.StandardJson[i].orderid = "Tbkjkjdkdj";
                        $scope.StandardJson[i].vname = "s";
                        $scope.StandardJson[i].vmobile = "ss";
                    }

                    $scope.StandardJson = $scope.StandardJson;
                    ;
                    $scope.StandardCount = response.data.totalcount;
                   // $scope.count = 1;
                   // $scope.pagex();


                } 
                else if ($scope.download) {
                    $scope.download = 0;
                    $scope.downloaddata = response.data.result;
                    $scope.downloadx();
                }


            });
    };
    $scope.vendorgetname = function (i) {
        //alert("ddd");
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
        } else {
            $scope.msg = "No Amount";
        }
    }

    $scope.wholepaymentshow = function (i, j = -2) {
        $http.get("/administrator/AdminAjax/Vendorspaymentshow/?id=" + i + "&type=" + j)
            .then(function (response) {
                console.log(JSON.parse(response.data).result);
                $scope.Wholepayment = JSON.parse(response.data).result;
                $scope.Totalamount = 0;
                $scope.TotalPortelamount = 0;
                $scope.TotalPayableamount = 0;
                for (i = 0; i < $scope.Wholepayment.length; i++) {
                    $scope.Totalamount = $scope.Totalamount + $scope.Wholepayment[i].ProductPricing;
                    $scope.TotalPortelamount = $scope.TotalPortelamount + (($scope.Wholepayment[i].ProductPricing * 15) / 100);
                    if ($scope.Wholepayment[i].payable == 0) {
                        $scope.TotalPayableamount = $scope.TotalPayableamount + ($scope.Wholepayment[i].ProductPricing - (($scope.Wholepayment[i].ProductPricing * 15) / 100));
                    }
                }

            });

    } 
}]);

Vendor.filter('range', function () {
    return function (input, total) {
        var input = new Array();
        total = parseInt(total);
        for (var i = 0; i < total; i++) {
            input.push(i + 1);
        }
        return input;
    };
});

//We already have a limitTo filter built-in to angular,
//let's make a startFrom filter
Vendor.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});