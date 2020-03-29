"use strict";

var apiUrl = "https://localhost:5001/pcparts/basic"

var app = new Vue({
    el: '#app',
    data: {
        message: 'loading parts...',
        pcparts: null,
        currentPart: null,
        isActive: false,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchParts();
    },
    methods: {
        fetchParts: function () {
            self = this;
            fetch(`${apiUrl}`)
                .then(res => res.json())
                .then(function (parts) {
                    parts.forEach(function (part, i) {
                        part.isActive = false;
                    });
                    self.parts = parts;
                    self.message = 'overview';
                })
                .catch(err => console.error('fout' + err));
        }
    }
})