/**************************Shopping Cart ********************************/
Administrator.controller('Standardnew', function ($scope, $http) {
    
    $scope.changestatus = function (i, s, type) {
        if (type == 2) {
            s = -2;
        } else {
            if (s == 0) {
                s = 1;
            } else {
                s = 0;
            }
        }
        $http.get("/administrator/AdminAjax/userstatus?id=" + i + "&status=" +s)
            .then(function (response) {
                $scope.datashow = (response.data);
            });

        
    }

});

Administrator.controller('updateuserprofile', function ($scope, $http) {
    $scope.error = "";
    $scope.userid = function (i) {
        $http.get("/administrator/AdminAjax/getuser?id=" + i)
            .then(function (response) {

                $scope.fname = response.data[0].fname;
                $scope.lname = response.data[0].lname;
                $scope.mobile = response.data[0].mobileno;
                $scope.userstatus = response.data[0].status;
                $scope.usertypes = response.data[0].usertype;
                $scope.email = response.data[0].username;
                $scope.hiddenpassword = response.data[0].password;
                
                

            });

        $scope.formupdateprofile = function (e, i) {
            $scope.fname;
            $scope.lname;
            $scope.mobile;
            $scope.userstatus;
            $scope.usertypes;
            $scope.email;
            pass = "";
            $scope.e = "0";
            if ($scope.password == null || $scope.password == undefined || $scope.password == "") {
                pass = $scope.hiddenpassword;

            } else {
                if ($scope.password == $scope.cpassword) {
                    pass = $scope.password;
                    $scope.error = "";
                } else {
                    $scope.e="1";
                    $scope.error = "Password Mismatch";
                }
            }
            
            if ($scope.e == "0") {
                
                    $http.get("/administrator/AdminAjax/getuserupdate?id=" + i + "&fname=" + $scope.fname + "&lname=" + $scope.lname + "&mobileno=" + $scope.mobile + "&userstatus=" + $scope.userstatus + "&usertypes=" + $scope.usertypes + "&email=" + $scope.email + "&password=" + pass)
                        .then(function (response) {
                            $scope.showform = "Successfull update Profile";
                        });
                
            }
        }

    }
    
});