"use strict";

var apiUrl = "https://localhost:5001/";
var split = document.cookie.split("BearerToken=");
var token = split[0].split("bearerToken=")[1];

var app = new Vue({
    el: '#app',
    data: {
        message: 'loading parts...',
        currentMaker: null,
        makers: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchMakers();
    },
    methods: {
        fetchMakers: function () {
            self = this;
            fetch(`${apiUrl}Makers`)
                .then(res => res.json())
                .then(function (res) {
                    self.makers = res;
                    self.currentMaker = self.makers[0];
                    self.message = "list of makers";
                })
                .catch(err => console.err('fout voor fetch makers' + err));
        },
        asignMaker: function (maker) {
            self = this;
            self.currentMaker = maker;
        }, toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
        },
        save: function () {
            var self = this;

            

            // opslaan - ajax configuratie
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            // bearer tokens
            ajaxHeaders.append("Authorization", "Bearer " + token);
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(self.currentMaker),
                headers: ajaxHeaders
            };
            if (self.isEdit) {
                let myRequest = new Request(`${apiUrl}makers/${self.currentMaker.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateParts(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            else {
                ajaxConfig.body = JSON.stringify(self.currentMaker);
                ajaxConfig.method = 'POST';
                let myRequest = new Request(`${apiUrl}makers`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addToMakers(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        }, deleteBook: function () {
            self = this;

            // give bearer headers to request
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Authorization", "Bearer " + token);
            var ajaxConfig = {
                method: 'DELETE',
                headers: ajaxHeaders
            };
            let myRequest = new Request(`${apiUrl}makers/${self.currentMaker.id}`, ajaxConfig);
            fetch(myRequest)
                .then(res => res.json())
                .then(function (res) {

                    location.reload();
                })
                .catch(err => console.error('Fout: ' + err));
        },
        addToMakers: function (maker) {

            self.currentMaker.id = maker.id;
            self.makers.push(maker);
        }
    }
});