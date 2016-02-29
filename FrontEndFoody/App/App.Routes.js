﻿(function () {
    foodyApp.config(function ($routeProvider, $locationProvider) {
        $routeProvider
        .when('/Account', {
            templateUrl: 'App/Components/account.html',
        })
        .when('/Book/:bookId', {
            templateUrl: 'App/Components/book.html',
            controller: 'BookController',
            resolve: {
                // I will cause a 1 second delay
                delay: function ($q, $timeout) {
                    var delay = $q.defer();
                    $timeout(delay.resolve, 1000);
                    return delay.promise;
                }
            }
        })
        .when('/Book/:bookId/ch/:chapterId', {
            templateUrl: 'App/Components/chapter.html',
            controller: 'ChapterController'
        });

        // configure html5 to get links working on jsfiddle
        $locationProvider.html5Mode(true);

        /*
        Copyright 2016 Google Inc. All Rights Reserved.
        Use of this source code is governed by an MIT-style license that
        can be found in the LICENSE file at http://angular.io/license
        */
    })
})();
