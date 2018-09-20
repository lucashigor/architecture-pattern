angular.module('demo', [])
    .controller('Hello', function ($scope, $http) {
        $http.get('http://localhost:54885/api/person/1').
            then(function (response) {
                $scope.greeting = response.data;
            });
    });