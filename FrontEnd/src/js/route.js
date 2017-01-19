app.config( ['$stateProvider', '$urlRouterProvider' , function($stateProvider, $urlRouterProvider) {

    $stateProvider
    .state("login", {
        url: "/login",
        controller: "loginController",
        templateUrl: "partials/login.html"
    })

    
    .state('temperature', {
        url: "/temperature",
        
        templateUrl: 'partials/temperature.html'
        
    });

    $urlRouterProvider.otherwise('/login');

}]);