var mainApp = angular.module("mainApp", ['ngRoute']);

mainApp.controller('indexController', ['$scope', 'indexServices', '$location', '$window', function ($scope, indexServices, $location, $window) {
    var loginURL = 'http://localhost:55765/View/Login.html';
    var userSession = JSON.parse(sessionStorage.USER_INFO);
    var currentUserTask;

    // Hello on the top - right screen
    this.helloMessage = "Hello " + userSession.UserName + " !";

    // Default search condition
    $scope.condition = {
        TaskDate: new Date(),
        SortItem: "",
        SortDirection: 0
    };

    //----------------------------- Common section-------------------------

    // Check if session not null
    if (!sessionStorage.USER_INFO || sessionStorage.USER_INFO == '[object Object]') {
        // Clear session
        sessionStorage.clear();

        // Disable auto login
        localStorage.AUTO_LOGIN = false;

        // Redirect to login page
        $window.location.href = loginURL;
    }

    $scope.logOut = function (item) {
        // Clear session
        sessionStorage.clear();
        localStorage.clear();

        // Redirect to login page
        $window.location.href = loginURL;
    }
    //----------------------------- End Common section---------------------
}]);