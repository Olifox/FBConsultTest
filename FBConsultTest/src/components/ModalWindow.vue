<script>
    import axios from 'axios'

    const regex = /^((8|7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/gm;

    export default {
        name: 'modal',
        computed: {
            nameState() {
                return this.postBody.name.length > 0 ? true : false
            },
            phoneState() {
                return !!regex.exec(this.postBody.phonenumber) ? true : false
            }
        },
        data() {
            return {
                postBody: {
                    name: '',
                    phonenumber: ''
                },
                phoneFlag: null,
                nameFlag: null
            }
        },
        methods: {
            addContact: function () {
                console.log(str)
                const url = window.location.origin + '/api/Contact/Post'
                axios.post(url, this.postBody)
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
            <b-row class="my-2">
                <b-form-input id="input-name" v-model="postBody.name" :state="nameState" placeholder="Имя" aria-describedby="input-name-feedback"></b-form-input>
                <b-form-invalid-feedback id="input-name-feedback">
                    Введите имя
                </b-form-invalid-feedback>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.surname" placeholder="Фамилия"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.patronymic" placeholder="Отчество"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.phonenumber" :state="phoneState" typeof="tel" placeholder="Номер телефона" aria-describedby="input-tel-feedback"></b-form-input>
                <b-form-invalid-feedback id="input-tel-feedback">
                    Введите номер
                </b-form-invalid-feedback>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.email" type="email" placeholder="Email"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-group label="Пол:" v-slot="{ ariaDescribedby }">
                    <b-form-radio v-model="postBody.sex" :aria-describedby="ariaDescribedby" name="some-radios" value="Male">Мужской</b-form-radio>
                    <b-form-radio v-model="postBody.sex" :aria-describedby="ariaDescribedby" name="some-radios" value="Female">Женский</b-form-radio>
                </b-form-group>
            </b-row>
            <b-row class="my-2">
                <b-form-datepicker v-model="postBody.bithday" placeholder="День рождения"></b-form-datepicker>
            </b-row>
        </b-container>
        <b-button class="mt-2" variant="success" @click="addContact">Сохранить</b-button>
    </div>
</template>

<style>
</style>