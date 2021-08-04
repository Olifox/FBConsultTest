<template>
    <div>
        <b-navbar toggleable="lg" type="dark" variant="info" >
            <b-navbar-brand>NavBar</b-navbar-brand>

            <b-navbar-nav class="ml-auto">
                <b-nav-form>
                    <img v-b-modal.add-modal src="../assets/add.png" width="30" height="30">
                </b-nav-form>
            </b-navbar-nav>
        </b-navbar>
        <b-modal id="add-modal" hide-footer title="Добавить контакт">
            <modal parent="add-modal" @update="save"/>
        </b-modal>
    </div>
</template>

<script>
    import { eventBus } from '../main'
    import modal from './ModalWindow.vue'

    export default {
        components: {
            modal
        },
        methods: {
            save() {
                eventBus.$emit("update");
            }
        }
    }
</script>

<style scoped>
    #add-button {
        position: absolute;
        max-height: 50px;
        max-width: 50px;
    }
</style>