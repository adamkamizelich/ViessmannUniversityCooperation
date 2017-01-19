var controllers = angular.module('controllers', ['ui.router', 'controllers']);

controllers.controller('loginController', ['$scope', '$http' , '$state', function($scope, $http, $state){
    $scope.login = function(e) {
        console.log("Suscscsckces");
        e.preventDefault();
        var authorizationHeader = "Basic " + btoa($scope.userName + ":" + $scope.password);
    
        $http.get('http://universityiotvitocontrolapi.azurewebsites.net/users/me', {
            headers: {
                Authorization : authorizationHeader
            }
        }).
        then(function(data){
            console.log("Sukces: " + data);
            $state.go('temperature')
        },
        function(error, headers){
            if (error.status == 401) {
                alert('dupa')
            }
            console.log("Błąd: " + headers)
         })
      };

}])