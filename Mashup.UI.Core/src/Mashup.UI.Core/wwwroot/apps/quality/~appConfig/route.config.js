/*global mashupApp:false */

// --------------------------------------------------------------------------------------------- 
// --------------------------------------------------------------------------------------------- 
// core/apps/quality/~appConfig/route.config.js
// --------------------------------------------------------------------------------------------- 
// --------------------------------------------------------------------------------------------- 

///*jshint laxcomma: true*/

mashupApp.config(['$routeProvider', function ($routeProvider) {
    'use strict';

    $routeProvider
        .when('/quality/cqtsQualityExport', {
            templateUrl: 'apps/quality/cqtsQualityExport/cqtsQualityExport.min.html',
            controller: 'quality.CqtsQualityExportController',
            controllerAs: 'vm',
            resolve: {
                loadMyCtrl: [
                    '$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: 'mashupApp',
                            files: ['apps/quality/cqtsQualityExport/cqtsQualityExport.controller.js',
                                     'apps/quality/~appServices/qualityDataService.min.js']
                        });
                    }
                ],
                logRoute: ['$route', 'coreRouteHelper', function ($route, coreRouteHelper) {
                    return coreRouteHelper.logRoute();
                }]
            }
        })
        .when('/quality/cqtsTransExport', {
            templateUrl: 'apps/quality/cqtsTransExport/cqtsTransExport.min.html',
            controller: 'quality.CqtsTransExportController',
            controllerAs: 'vm',
            resolve: {
                loadMyCtrl: [
                    '$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: 'mashupApp',
                            files: ['apps/quality/cqtsTransExport/cqtsTransExport.controller.min.js',
                                     'apps/quality/~appServices/qualityDataService.min.js']
                        });
                    }
                ],
                logRoute: ['$route', 'coreRouteHelper', function ($route, coreRouteHelper) {
                    return coreRouteHelper.logRoute();
                }]

            }
        });
}]);