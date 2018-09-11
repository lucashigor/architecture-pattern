var config = {headers: {
		'Access-Control-Allow-Origin': 'localhost',
		'Host': 'file:///D:/Projetos/GitHub/architecturepattern/src/02%20Base%20Repository/Site/Person.html',
		'Connection': 'keep-alive',
		'Cache-Control': 'max-age=0',
		'Upgrade-Insecure-Requests': '1',
		'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8',
		'Accept-Encoding': 'gzip, deflate, br',
		'Accept-Language': 'pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7'
	}
};

angular.module('demo', [])
    .controller('Hello', function ($scope, $http) {
        $http.get('http://localhost:53099/api/person/1', config).
            then(function (response) {
                $scope.greeting = response.data;
            });
    });