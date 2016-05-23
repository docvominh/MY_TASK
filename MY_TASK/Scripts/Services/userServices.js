var userServicesAddress = 'http://localhost:55765/api/user/';
var url = "";
mainApp.factory('userServices', function ($http) {
    return {
        initialize: function (userId) {
            url = userServicesAddress + "Initialize";
            return $http({
                method: 'GET',
                url: url,
                params: { userId: userId }
            });
        },

        userGetTask: function (userId, taskId) {
            url = userServicesAddress + "UserGetTask";

            return $http({
                method: 'GET',
                url: url,
                params: {
                    userId: userId,
                    taskId: taskId
                }
            });
        },
        userReturnTask: function (userId, taskId) {
            url = userServicesAddress + "UserReturnTask";

            return $http({
                method: 'GET',
                url: url,
                params: {
                    userId: userId,
                    taskId: taskId
                }
            });
        },
        UserResolveTask: function (userId, taskId) {
            url = userServicesAddress + "UserResolveTask";

            return $http({
                method: 'GET',
                url: url,
                params: {
                    userId: userId,
                    taskId: taskId
                }
            });
        },
        searchTask: function (condition) {
            url = userServicesAddress + "SearchTask";
            return $http.post(url, condition)

            // This way is not work

            //return $http({
            //    method: 'POST',
            //    url: url,
            //    params: {
            //        condition: JSON.stringify(condition),
            //    }
            //});
        }
    };
});