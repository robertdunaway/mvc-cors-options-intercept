/*global mashupApp:false */

mashupApp.service('qualityDataService', ['$http', 'apiUrl', '$q', '$log', 'cacheService',
    function ($http, apiUrl, $q, $log, cacheService) {
        'use strict';

        return {

            getCQTSAdHocQualityData: function (staleMinutes, begindate, enddate) {
                var deferred = $q.defer();

                var cacheName = 'Quality_CQTSAdHocQuality';
                var schema = { name: cacheName, keyPath: 'Complaint_Number' };

                var heartBeatOptions = {
                    heartBeatUrl: apiUrl.qualityApi + '/api/HeartBeat',
                    heartBeatName: 'QualityApi',
                };

                var params = {
                    begindate: begindate,
                    enddate: enddate,
                };
                var options = {
                    url: apiUrl.qualityApi + '/api/Quality/CQTSAdHocQuality',
                    method: 'POST',
                    data: JSON.stringify(params),
                    withCredentials: true,
                    contentType: 'application/json'
                };

                cacheService.getData(cacheName, schema, options, staleMinutes, heartBeatOptions)
                    .then(function (data) {
                        deferred.resolve(data);
                    });

                return deferred.promise;
            },
            getCQTSAdHocTransData: function (staleMinutes, begindate, enddate) {
                var deferred = $q.defer();

                var cacheName = 'Quality_CQTSAdHocTrans';
                var schema = { name: cacheName, keyPath: 'Complaint_Number' };

                var heartBeatOptions = {
                    heartBeatUrl: apiUrl.qualityApi + '/api/HeartBeat',
                    heartBeatName: 'QualityApi',
                };

                var params = {
                    begindate: begindate,
                    enddate: enddate,
                };
                var options = {
                    url: apiUrl.qualityApi + '/api/Quality/CQTSAdHocTrans',
                    method: 'POST',
                    data: JSON.stringify(params),
                    withCredentials: true,
                    contentType: 'application/json'
                };

                cacheService.getData(cacheName, schema, options, staleMinutes, heartBeatOptions)
                    .then(function (data) {
                        deferred.resolve(data);
                    });

                return deferred.promise;
            },
            getCache: function (cacheName) {
                var deferred = $q.defer();

                cacheService.getCache(cacheName).then(function (data) {
                    deferred.resolve(data);
                });

                return deferred.promise;
            }

        };
    }]);