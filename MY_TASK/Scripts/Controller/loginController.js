var mainApp = angular.module("mainApp", ['ngRoute']);

mainApp.controller('loginController', ['$scope', '$window', 'loginServices', function ($scope, $window, loginServices) {
    this.title = loginServices.getTitle();
    var indexURL = 'http://localhost:55765/View/Index.html';

    // Check session to pass login step
    if (sessionStorage.USER_INFO && sessionStorage.USER_INFO != '[object Object]') {
        // Redirect to external url
        $window.location.href = indexURL;
    }

    // Check for auto login
    if (localStorage.REMEMBER_USER && localStorage.AUTO_LOGIN == 'true' && !sessionStorage.USER_INFO) {
        loginServices.authentication(localStorage.REMEMBER_USER).success(function (data) {
            // Save user info
            sessionStorage.setItem('USER_INFO', data);

            // Redirect to index page
            $window.location.href = indexURL;
        }).error(function (data) {
        });
    }

    // Submit button click
    $scope.submit = function () {
        var currentUser = $scope.user;
        $('#myLoading').modal('show');
        loginServices.authentication(currentUser).success(function (data) {
            if (data != null) {
                if (data == 'W0001') {
                    $scope.alert('Validate Error', 'ModelState is invalid')
                } else {
                    // Save user info
                    sessionStorage.setItem('USER_INFO', JSON.stringify(data));
                    // Save user info for auto login
                    if (currentUser.remember) {
                        localStorage.setItem('REMEMBER_USER', JSON.stringify(currentUser));
                        localStorage.setItem('AUTO_LOGIN', true);
                    }

                    // Redirect to index page
                    $window.location.href = indexURL;
                }
            } else {
                $('#myLoading').modal('hide');
                $scope.alert('Authenticate Error', 'Wrong username or password')
            }
        }).error(function (data) {
             $scope.alert('Server Error', 'Cannot connect to server !')
        });
    };

    $scope.alert = function (title, content) {
        $scope.modelTitle = title;
        $scope.modelContent = content;

        // Show popup alert
        $('#myModal').modal('show');
    };
}]);