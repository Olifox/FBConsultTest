﻿<script>
    import api from './ContactApiService.vue'
    const phoneUtil = require('google-libphonenumber').PhoneNumberUtil.getInstance()
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    export default {
        name: 'modal',
        props: {
            contactId: Number,
            parent: ''
        },
        mounted() {
            console.log(this.parent)
            if (!!this.contactId)
                this.getContact()

            this.parentId = this.parent
        },
        computed: {
            nameState() {
                return this.contact.name.length > 0 ? true : false
            },
            phoneState() {
                try {
                    return phoneUtil.isValidNumberForRegion(phoneUtil.parse(this.contact.phonenumber, 'RU'), 'RU');
                }
                catch {
                    return false;
                }
            },
            emailState() {
                if (this.contact.email.length > 0)
                    return re.test(this.contact.email);
                else
                    return null;
            }
        },
        data() {
            return {
                contact: {
                    name: '',
                    phonenumber: '',
                    email: ''
                },
                phoneFlag: null,
                nameFlag: null,
                parentId: ''
            }
        },
        methods: {
            async addContact() {
                if (!!this.contactId) {
                    await api.update(this.contact)
                }
                else {
                    await api.create(this.contact)
                }
                this.hide()
            },
            async getContact() {
                console.log(parent)
                var response = await api.getById(this.contactId)
                for (var key in response) {
                    response[key.toLowerCase()] = response[key];
                    delete response[key];
                }
                console.log(response)
                this.contact = response
            },
            hide() {
                this.$emit('update')
                this.$bvModal.hide(this.parentId)
            }
        },
    };
</script>

<template>
    <div>
        <b-container fluid>
            <b-row class="my-2">
                <b-form-input id="input-name" v-model="contact.name" :state="nameState" placeholder="Имя" aria-describedby="input-name-feedback"></b-form-input>
                <b-form-invalid-feedback id="input-name-feedback">
                    Введите имя
                </b-form-invalid-feedback>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="contact.surname" placeholder="Фамилия"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="contact.patronymic" placeholder="Отчество"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="contact.phonenumber" :state="phoneState" typeof="tel" placeholder="Номер телефона" aria-describedby="input-tel-feedback"></b-form-input>
                <b-form-invalid-feedback id="input-tel-feedback">
                    Введите номер
                </b-form-invalid-feedback>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="contact.email" type="email" placeholder="Email" :state="emailState" ></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-group label="Пол:" v-slot="{ ariaDescribedby }">
                    <b-form-radio v-model="contact.sex" :aria-describedby="ariaDescribedby" name="some-radios" value="Мужской">Мужской</b-form-radio>
                    <b-form-radio v-model="contact.sex" :aria-describedby="ariaDescribedby" name="some-radios" value="Женский">Женский</b-form-radio>
                </b-form-group>
            </b-row>
            <b-row class="my-2">
                <b-form-datepicker v-model="contact.bithday" placeholder="День рождения"></b-form-datepicker>
            </b-row>
        </b-container>
        <b-button class="mt-2 float-left" @click="hide">Отмена</b-button>
        <b-button :disabled="!phoneState || !nameState  || (emailState==false)" class="mt-2 float-right" variant="success" @click="addContact">Сохранить</b-button>
    </div>
</template>

<style>
</style>