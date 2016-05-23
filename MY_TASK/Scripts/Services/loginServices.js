var loginServicesAddress = 'http://localhost:55765/api/login/';
var url = "";

//Factory style, more involved but more sophisticated
mainApp.factory('loginServices', function ($http) {
    return {
        getTitle: function () {
            return "Log in for new task !"
        },
        authentication: function (user) {
            url = loginServicesAddress + "Login";
            return $http.post(url, user)
        }
    };
});