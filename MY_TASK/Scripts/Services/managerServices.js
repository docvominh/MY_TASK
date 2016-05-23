var managerServicesAddress = 'http://localhost:55765/api/manager/';
var url = "";
mainApp.factory('managerServices', function ($http) {
    return {
        initialize: function (bossId) {
            url = managerServicesAddress + "Initialize";
            return $http({
                method: 'GET',
                url: url,
                params: { bossId: bossId }
            });
        },
        createNewTask: function (userId, userName, item) {
            url = managerServicesAddress + "NewTask";

            item.CreateUserID = userId;
            item.CreateUserName = userName;

            return $http.post(url, item)

            // This way is not work

            //return $http({
            //    method: 'GET',
            //    url: url,
            //    params: { userId: userId, userName: userName, item: item, }
            //});
        }
    };
});