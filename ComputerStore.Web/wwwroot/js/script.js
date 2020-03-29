"use strict";

var apiUrl = "https://localhost:5001/";

var app = new Vue({
    el: '#app',
    data: {
        message: 'loading parts...',
        pcparts: null,
        currentPart: null, 
        isActive: false,
        isReadOnly: true,
        isEdit: false
    },
    created: function(){
        var self = this;
        self.fetchParts();
    },
    methods:{
        fetchParts: function(){
            self = this;
            fetch(`${apiUrl}pcparts`)
                .then(res => res.json())
                .then(function (pcparts) {
                    pcparts.forEach(function (part, i) {
                        part.isActive = false;
                    });
                    self.pcparts = pcparts;
                    self.message = 'overview';
                })
                .catch(err => console.error('fout' + err));
        },
        fetchPartDetails: function (part) {
            self = this;
            console.log(part.id);
            if (!self.isReadOnly) return;
            fetch(`${apiUrl}pcparts/${part.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentPart = res;
                })
                .catch(err => console.error('Fout: ' + err));
        }
    }
})
