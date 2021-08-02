<script>
    import axios from 'axios'

    const regex = /^((8|7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/gm;

    export default {
        name: 'modal',
        computed: {
            nameState() {
                if (this.postBody.name.length > 2)
                    this.nameFlag = null
                return this.nameFlag
            },
            phoneState() {
                if (!!regex.exec(this.postBody.phonenumber))
                    this.phoneFlag = null
                return this.phoneFlag
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
                if (this.checkState()) {
                    const str = JSON.stringify(this.postBody);
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

            checkState: function () {
                const matches = regex.exec(this.postBody.phonenumber)
                if (!!matches && this.postBody.name.length > 2)
                    return true
                else {
                    this.phoneFlag = false
                    this.nameFlag = false
                    return false
                }
            }
        },
    };
</script>

<template>
    <div>
        <b-container fluid>
            <b-row class="my-2">
                <b-form-input v-model="postBody.name" :state="nameState" placeholder="Имя"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.surname" placeholder="Фамилия"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.patronymic" placeholder="Отчество"></b-form-input>
            </b-row>
            <b-row class="my-2">
                <b-form-input v-model="postBody.phonenumber" :state="phoneState" typeof="tel" placeholder="Номер телефона"></b-form-input>
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