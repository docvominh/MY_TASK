mainApp.config(['$routeProvider',
   function ($routeProvider) {
       $routeProvider.
           when('/index', {
               templateUrl: 'TaskUser.html',
               controller: 'userController'
           }).
          when('/task-manager', {
              templateUrl: 'TaskManager.html',
              controller: 'managerController'
          }).
          otherwise({
              redirectTo: '/index'
          });
   }]);