angular.module('demo', [])
    .controller('Hello', function ($scope, $http) {
        $http.get('http://localhost:53099/api/person/1').
            then(function (response) {
                $scope.greeting = response.data;
            });
    });