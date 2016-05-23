mainApp.controller('managerController', ['$scope', '$location', '$window', 'managerServices', '$filter', function ($scope, $location, $window, managerServices, $filter) {
    //----------------------------- Common section-------------------------

    // Get user session
    var bossSession = JSON.parse(sessionStorage.USER_INFO);

    // Check for boss role
    if (bossSession.UserRole != '1') {
        $location.path('/index')
    } else {
        managerServices.initialize(bossSession.UserId).success(function (data) {
            $scope.data = data;
        }).error(function (data) {
        });
    }

    // Show create task popup
    $scope.showTaskCreatePopup = function () {
        $('#taskCreate').modal('show');
    };

    $scope.createNewTask = function (item) {
        // Validate
        var pass = true;
        if (item.TaskName == '') {
            $scope.taskNameMessage = " this is required"
            pass = false;
        }

        if (pass) {
            managerServices.createNewTask(bossSession.UserId, bossSession.UserName, item).success(function (data) {
                $scope.data = data;
            }).error(function (data) {
            });
        }
    };

    //----------------------------- End Common section---------------------

    //----------------------------- Popup section -------------------------

    // Alert
    $scope.alert = function (title, content) {
        $scope.alertTitle = title;
        $scope.alertContent = content;
        $('#myAlert').modal('show');
    };

    //----------------------------- End Popup section ---------------------
}]);