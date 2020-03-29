'use strict';

var apiUrl = "https://localhost:5001/";
var split = document.cookie.split("BearerToken=");
var token = split[0].split("bearerToken=")[1];
var app = new Vue({
    el: '#app',
    data: {
        message: 'loading parts...',
        currentPart: null,
        params: null,
        currentDetailPart: null,
        isReadOnly: true,
        isEdit: false

    },
    created: function () {
        var self = this;
        self.fetchDetails();
    },
    methods: {
        fetchDetails: function () {
            self = this;
            var url = window.location.pathname;
            var param = url.substring(url.lastIndexOf('/') + 1);
            fetch(`${apiUrl}pcparts/partbypartid/${param}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentPart = toLowerCaseKeys(res);
                    self.currentPart.partid = self.currentPart.pcpart.id;
                }).catch(err => console.error("+++++++++++++++ err+++++++++" + err));
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
        },
        save: function () {
            var self = this;

            // de properties authorId en publisherId van het Book zijn nog leeg
            // de vue.js databinding vult enkel de compositeproperties author en publisher
            self.currentPart.maker = self.currentPart.maker;
            self.currentPart.images = self.currentPart.images;

            // opslaan - ajax configuratie
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            ajaxHeaders.append("Authorization", "Bearer " + token);
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(self.currentPart),
                headers: ajaxHeaders
                // add bearer token if needed for auth
            };
            if (self.isEdit) {
                let myRequest = new Request(`${apiUrl}${self.currentPart.pcpart.type}s/${self.currentPart.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateParts(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            else {
                ajaxConfig.method = 'POST';
                let myRequest = new Request(`${apiUrl}${self.currentPart.pcpart.type}s`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addPartToParts(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addPartToParts: function (part) {

            self.currentPart.id = part.id;
            self.pcparts.push(part);
            self.fetchModelDetail(self.pcparts[self.pcparts.length - 1]);
        },
        updateParts: function (part) {
            // het geupdate boek uit de boekenlijst ophalen (dit is een lijst van BookBasic-elementen)
            var updatedPart = self.pcparts.filter(p => p.id === part.id)[0];
            // gegevens aanpassen
            updatedPart.name = part.name;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchModelDetail(self.currentBook);
            } else {
                self.fetchModelDetail(self.books[0]);
            }
        },
        deleteBook: function () {
            self = this;

            // give bearer headers to request
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Authorization", "Bearer " + token);
            var ajaxConfig = {
                method: 'DELETE',
                headers: ajaxHeaders
            };
            let myRequest = new Request(`${apiUrl}${self.currentPart.pcpart.type}s/${self.currentPart.id}`, ajaxConfig);
            fetch(myRequest)
                .then(res => res.json())
                .then(function (res) {
                    // boek verwijderen uit de lijst

                    var path = window.location.href.split("/detail/");
                    var url = path[0];
                    location.replace(url);
                    
                    // eerste boek selecteren
                    if (self.books.length > 0)
                        self.fetchBookDetails(self.books[0]);
                })
                .catch(err => console.error('Fout: ' + err));
        }
    }
});

function toLowerCaseKeys(obj) {
    return Object.keys(obj).reduce(function (accum, key) {
        accum[key.toLowerCase()] = obj[key];
        return accum;
    }, {});
}
