<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="mt-10">
            <h1 class="text-xl font-medium mb-1">{{ message.name }}</h1>
            <p class="text-sm text-slate-500">{{ message.email }}</p>

            <h4 class="text-4xl font-medium my-10">{{ message.subject }}</h4>

            <div class="whitespace-pre-wrap text-slate-700">{{ message.messageBody }}</div>

            <hr class="mt-10">
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue'
import { useRoute } from 'vue-router'

export default{
    data() {
        return{
            message: {}
        }
    },
    setup() {
        const id = ref(useRoute().params.id)

        return {
            id
        }
    },
    mounted(){
        this.getMessage()
    },
    methods: {
        async getMessage() {
            try {
                const response = await axios.get(`https://localhost:7049/api/Message/get-message/${this.id}`)

                this.message = response.data.messageObj
                
            } catch (error) {
                console.log(error)   
            }
        }
    }
}
</script>