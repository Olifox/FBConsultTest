<template>
    <div class="container body-content">
        <div class="contacts-list-row">
            <b-table hover :items="contacts" v-if="!isBusy" :fields="fields">
                <template #cell(control_contact)="row">
                    <div class="scale">
                        <img @click="changeSelectedContactId(row.item.Id)" v-b-modal.change-modal src="../assets/change.svg" class="scale" />
                    </div>
                    <div class="scale">
                        <img @click="showConfirmWindow(row.item.Id)" src="../assets/delete.svg" class="scale"/>
                    </div>
                </template>
                <template #cell(Bithday)="data">
                    {{ formatDate(data.item.Bithday) }}
                </template>
            </b-table>
            <div class="text-center text-danger my-2" v-else="isBusy">
                <b-spinner class="align-middle"></b-spinner>
                <strong>Loading...</strong>
            </div>
        </div>
        <b-modal id="change-modal" hide-footer title="Изменить контакт">
            <modal :contactId="selectedContactId" parent="change-modal" @update="getContacts"/>
        </b-modal>
    </div>
</template>

<script>
    import { eventBus } from '../main'
    import api from './ContactApiService.vue'
    import modal from './ModalWindow.vue'

    export default {
        name: 'contacts-list-row',
        mounted() {
            this.getContacts()
            console.log('mounted: got here')
            eventBus.$on("update", () => {
                this.getContacts()
            });
        },
        components: {
            modal
        },
        data() {
            return {
                message: 'Contact List Row',
                contacts: [],
                fields: [
                    {
                        key: 'FullName',
                        label: 'ФИО',
                        sortable: true
                    },
                    {
                        key: 'PhoneNumber',
                        label: 'Тел. номер',
                        sortable: false
                    },
                    {
                        key: 'Email',
                        sortable: true,
                    },
                    {
                        key: 'Sex',
                        label: 'Пол',
                        sortable: true
                    },
                    {
                        key: 'Bithday',
                        label: 'День рождения',
                        sortable: true
                    },
                    {
                        key: 'control_contact',
                        label: ''
                    }
                ],
                isBusy: true,
                selectedContactId: Number
            }
        },
        methods: {
            async getContacts() {
                console.log('get contacts')
                this.contacts=null
                this.contacts = await api.getAll()
                this.isBusy = false
            },
            showConfirmWindow(contactId) {
                this.$emit('update')
                this.$bvModal.msgBoxConfirm('Вы уверены что хотите удалить этот контакт?', {
                    size: 'sm',
                    okVariant: 'danger',
                    okTitle: 'Да',
                    cancelTitle: 'Отмена',
                })
                    .then(value => {
                        if (value) {
                            this.deleteContact(contactId)
                        }
                    })
                    .catch(err => {
                        console.log(err)
                    })
            },
            async deleteContact(contactId) {
                await api.delete(contactId)
                this.getContacts()
            },
            changeSelectedContactId(itemId) {
                this.selectedContactId = itemId
            },
            formatDate(date) {
                if (!!date) {
                    var options = { day: 'numeric', month: 'long', year: 'numeric', };
                    let d = new Date(date)
                    return d.toLocaleDateString("ru-RU", options);
                }
            }
        }
    }
</script>

<style>
    .scale {
        display: inline-block; /* Строчно-блочный элемент */
        overflow: hidden; /* Скрываем всё за контуром */
    }

        .scale img {
            transition: 0.5s; /* Время эффекта */
        }

            .scale img:hover {
                transform: scale(1.2); /* Увеличиваем масштаб */
            }
</style>