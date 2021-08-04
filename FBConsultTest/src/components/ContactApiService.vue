<script>
    import axios from 'axios'

    const client = axios.create({
        baseURL: window.location.origin + '/api/Contact/',
        json: true
    })

    export default {
        async execute(method, resource, data) {
            return client({
                method,
                url: resource,
                data
            }).then(req => {
                return req.data
            })
        },
        getAll() {
            return this.execute('get', '/Get')
        },
        getById(id) {
            return this.execute('get', `/Get/${id}`)
        },
        create(data) {
            return this.execute('post', '/Post', data)
        },
        update(data) {
            return this.execute('put', `/Put`, data)
        },
        delete(id) {
            return this.execute('delete', `/Delete/${id}`)
        }
    }
</script>