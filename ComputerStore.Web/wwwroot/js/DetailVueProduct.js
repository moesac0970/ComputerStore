'use strict';

var apiUrl = "https://localhost:5001/";
var url = window.location.pathname;
var param = url.substring(url.lastIndexOf('/') + 1);

var app = new Vue({
    el: '#app',
    data: {
        id: param,
        partdetails: null
    },
    created: function () {
        var self = this;
    },
    methods: {
        fetchDetails: function () {
            self = this;
            var url = window.location.pathname;
            var param = url.substring(url.lastIndexOf('/') + 1);
            fetch(`${apiUrl}pcparts/partbypartid/${param}`)
                .then(res => res.json())
                .then(function (res) {
                    self.partdetails = toLowerCaseKeys(res);
                }).catch(err => console.error("+++++++++++++++ err+++++++++" + err));
        } 
    }
});

function toLowerCaseKeys(obj) {
    return Object.keys(obj).reduce(function (accum, key) {
        accum[key.toLowerCase()] = obj[key];
        return accum;
    }, {});
}