<template>
    <div>
        <b-navbar toggleable="lg" type="dark" variant="info">
            <b-navbar-brand>NavBar</b-navbar-brand>

            <b-navbar-nav small="true" class="ml-auto">
                <b-nav-form>
                    <img v-b-modal.modal-1 src="../assets/add.png" width="30" height="30">
                </b-nav-form>
            </b-navbar-nav>
        </b-navbar>
        <b-modal id="modal-1" hide-footer title="BootstrapVue">
            <modal/>
        </b-modal>
    </div>  
</template>

<script>
    import modal from './ModalWindow.vue'
    export default {
        name: 'add-button',
        data() {
            return {
                buttonPushed: false
            }
        },
        components: {
            modal
        },
        methods: {
            open() {
                this.$emit('open');
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