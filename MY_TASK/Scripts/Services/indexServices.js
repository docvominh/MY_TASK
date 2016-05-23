var indexServicesAddress = 'http://localhost:55765/api/index/';
var url = "";
mainApp.factory('indexServices', function ($http) {
    return {
        initialize: function (userId) {
            url = indexServicesAddress + "Initialize";
            return $http({
                method: 'GET',
                url: url,
                params: { userId: userId }
            });
        }
    };
});