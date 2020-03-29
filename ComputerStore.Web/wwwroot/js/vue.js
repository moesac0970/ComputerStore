'use strict';

var apiUrl = "https://localhost:5001/";
var split = document.cookie.split("BearerToken=");
var token = split[0].split("bearerToken=")[1];

var app = new Vue({
    el: '#app',
    data: {
        message: 'loading parts...',
        currentPart: null,
        currentCategory: null,
        categoryModels: null,
        categories: null,
        makers: null,
        isActive: false,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchCategories();
        self.fetchMakers();
    },
    methods: {
        fetchParts: function () {
            self = this;
            fetch(`${apiUrl}pcparts/category/Cpu`)
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
        },
        fetchModelsByCategories: function (categoryName) {
            self = this;
            console.log(categoryName);
            fetch(`${apiUrl}pcparts/category/${categoryName}`)
                .then(res => res.json())
                .then(function (res) {
                    self.categoryModels = res;
                })
                .catch(err => console.err('fout voor fetch categories models ' + err));
        },
        fetchCategories: function () {
            self = this;
            fetch(`${apiUrl}pcparts/Categories`)
                .then(res => res.json())
                .then(function (res) {
                    self.categories = res;
                    self.message = "list of categories";
                })
                .catch(err => console.err('fout voor fetch categories' + err));
        },
        fetchMakers: function () {
            self = this;
            fetch(`${apiUrl}Makers`)
                .then(res => res.json())
                .then(function (res) {
                    self.makers = res;
                })
                .catch(err => console.err('fout voor fetch makers' + err));
        },

        fetchModelDetail: function (id) {
            self = this;
            console.log(id);
            fetch(`${apiUrl}${currentCategory}s/${id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentPart = res;
                })
                .catch(err => console.err('fout voor fetch specific model' + err));
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
            // bearer tokens
            ajaxHeaders.append("Authorization", "Bearer " + token);
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(self.currentPart),
                headers: ajaxHeaders
            };
            if (self.isEdit) {
                let myRequest = new Request(`${apiUrl}pcparts/${self.currentPart.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateParts(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            else {
                self.currentPart.images = null;
                ajaxConfig.body = JSON.stringify(self.currentPart);
                ajaxConfig.method = 'POST';
                let myRequest = new Request(`${apiUrl}pcparts`, ajaxConfig);
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

            let myRequest = new Request(`${apiUrl}pcparts/${self.currentPart.id}`, ajaxConfig);
            fetch(myRequest)
                .then(res => res.json())
                .then(function (res) {
                    console.log("we did it ");

                })
                .catch(err => console.error('Fout: ' + err));
        }
    }
});
