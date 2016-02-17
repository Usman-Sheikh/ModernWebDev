﻿(function () {
    'use strict';

    angular
        .module('common.services')
        .factory('productResource',
        ['$resource', 'appSettings',productResource]);

    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/Products/:id",null,
            {
                'update':{method:'PUT'}
            });

       
    }
})();