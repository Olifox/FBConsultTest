<script>
    import axios from 'axios'

    export default {
        name: 'modal',
        data() {
            return {
                postBody: {
                    Id: Number,
                    Name: '',
                    Surname: '',
                    Patronymic: '',
                    PhoneNumber: '',
                    Email: '',
                    Sex: '',
                    Bithday: null
                }
            }
        },
        methods: {
            addContact: function () {
                const str = JSON.stringify(this.postBody);
                const url = window.location.origin + '/api/Contact/Post'
                axios.post(url, str)
                    .then(function (response) {
                        console.log(response.data)
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }
        },
    };
</script>

<template>
    <div>
        <b-container fluid>
            <b-form-input v-model="postBody.Name" placeholder="Имя"></b-form-input>
            <b-form-input v-model="postBody.Surname" placeholder="Фамилия"></b-form-input>
            <b-form-input v-model="postBody.Patronymic" placeholder="Отчество"></b-form-input>
            <b-form-input v-model="postBody.PhoneNumber" placeholder="Номер телефона"></b-form-input>
            <b-form-input v-model="postBody.Email" placeholder="Email"></b-form-input>
            <b-form-input v-model="postBody.Sex" placeholder="Пол"></b-form-input>
            <b-form-input v-model="postBody.Bithday" placeholder="День рождения"></b-form-input>
        </b-container>
        <b-button class="mt-2" @click="addContact">Сохранить</b-button>
    </div>
</template>

<style>
</style>