var app = angular.module("app",['ngResource']);

app.config(['$resourceProvider', function($resourceProvider) {
  // Don't strip trailing slashes from calculated URLs
  $resourceProvider.defaults.stripTrailingSlashes = false;
}]);

app.factory("OefeningService",function($resource){
    return $resource('http://localhost:51794/api/Oefening/:oefening',{oefening: "@oefening"});
});

app.factory("ActiveOefeningService",function($resource){
    return $resource('http://localhost:51794/api/ActiveOefening/:oefening',{oefening: "@oefening"})
});

app.factory("GetOefeningByIdService",function($resource){
    return $resource('http://localhost:51794/api/GetOefeningById/:oefening',{oefening: "@oefening"})
});

app.factory("OplossingService", function($resource){
    return $resource('http://localhost:51794/api/Oplossing/:oplossing',{oplossing: "@oplossing"})
})

app.factory("KindService", function($resource){
    return $resource('http://localhost:51794/api/Kind/:kind',{kind: "@kind"})
})

app.factory("KindActiveService", function($resource){
    return $resource('http://localhost:51794/api/KindActive/:kind',{kind: "@kind"})
})
