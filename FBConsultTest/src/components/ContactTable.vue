<template>
    <div class="container body-content">
        <div class="contacts-list-row">
            <table class='table table-striped' v-if="visible">
                <thead>
                    <tr>
                        <th>ФИО</th>
                        <th>Тел. Номер</th>
                        <th>Email</th>
                        <th>Пол</th>
                        <th>День рождения</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="contact in contacts">
                        <td>{{ contact.FullName }}</td>
                        <td>{{ contact.PhoneNumber }}</td>
                        <td>{{ contact.Email}}</td>
                        <td>{{ contact.Sex }}</td>
                        <td>{{ contact.Bithday }}</td>
                    </tr>
                </tbody>
            </table>
            <p v-else="visible">Loading...</p>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'contacts-list-row',
        mounted: function () {
            this.getContacts()
            console.log('mounted: got here')
        },
        data: function () {
            return {
                message: 'Contact List Row',
                contacts: [],
                visible: false
            }
        },
        methods: {
            getContacts: function () {
                var self = this
                const url = window.location.origin + '/api/Contact/GetFullName'
                axios.get(url, {
                    dataType: 'json',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    mode: 'no-cors',
                    credentials: 'include'
                })
                    .then(function (response) {
                        console.log(JSON.stringify(response.data))
                        self.contacts = response.data
                        self.visible = true
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }
        }
    }
</script>