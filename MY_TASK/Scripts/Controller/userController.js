mainApp.controller('userController', ['$scope', 'userServices', '$filter', function ($scope, userServices, $filter) {
    var userSession = JSON.parse(sessionStorage.USER_INFO);
    var currentUserTask;

    // Default search condition
    $scope.condition = {
        TaskDate: new Date(),
        SortItem: "",
        SortDirection: 0
    };

    //----------------------------- Common section-------------------------

    // Get user session
    var userSession = JSON.parse(sessionStorage.USER_INFO);

    userServices.initialize(userSession.UserId).success(function (data) {
        $scope.data = data;

        // Save current User's task
        currentUserTask = data.ListTask;
    }).error(function (data) {
        $scope.errorMessage = "Wrong Username or Password";
    });

    //----------------------------- End Common section---------------------

    //----------------------------- Remote section-------------------------
    $scope.searchTask = function () {
        var condition = $scope.condition;

        userServices.searchTask(condition).success(function (data) {
            $scope.data.ListAllTaskToday = data;
        }).error(function (data) {
            $scope.alert('Server Error', 'Can not connect to server !')
        });
    }

    // Disable radio button when dropdown didn't choise
    $scope.checkDisable = function (value) {
        if (value == "") return true;
        return false;
    };

    //----------------------------- End Remote section---------------------

    //----------------------------- All task section-------------------------
    $scope.userGetTask = function (taskId, $event, isStop) {
        // Check if user already get this task
        check = false;
        for (var i = 0; i < currentUserTask.length; i++) {
            if (taskId == currentUserTask[i].TaskID) {
                check = true;
                break;
            }
        }

        if (check) {
            $scope.alert('Nothing important', 'You are already got this !')
        } else {
            userServices.userGetTask(userSession.UserId, taskId).success(function (data) {
                $scope.data = data;
                // Save current User's task
                currentUserTask = data.ListTask;
            }).error(function (data) {
            });
        }

        // prevent div click event
        // ngClick directive (as well as all other event directives) creates $event variable which is available on same scope.
        // This variable is a reference to JS event object and can be used to call stopPropagation():
        if (isStop) {
            $event.stopPropagation();
        }
    }

    // Shop task detail
    $scope.showTask = function (item) {
        $scope.showTaskDetail(item)
    }

    //----------------------------- End all task section---------------------

    //----------------------------- My task section-------------------------
    $scope.userReturnTask = function (taskId, $event) {
        userServices.userReturnTask(userSession.UserId, taskId).success(function (data) {
            $scope.data = data;
            // Save current User's task
            currentUserTask = data.ListTask;
        }).error(function (data) {
        });
    }

    $scope.UserResolveTask = function (taskId, $event) {
        userServices.UserResolveTask(userSession.UserId, taskId).success(function (data) {
            $scope.data = data;
            // Save current User's task
            currentUserTask = data.ListTask;
        }).error(function (data) {
        });
    }

    //----------------------------- End My task section---------------------

    //----------------------------- Popup section -------------------------

    // Show task detail
    $scope.showTaskDetail = function (item) {
        $scope.item = item;
        $('#myModal').modal('show');
    };

    // Shop myTask
    $scope.showMyTask = function (item) {
        $scope.item = item;
        $('#myTask').modal('show');
    };

    // Alert
    $scope.alert = function (title, content) {
        $scope.alertTitle = title;
        $scope.alertContent = content;
        $('#myAlert').modal('show');
    };

    //----------------------------- End Popup section ---------------------
}]);