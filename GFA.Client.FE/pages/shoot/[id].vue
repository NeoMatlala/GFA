<template>
    <div class="max-w-7xl mx-auto px-2.5 md:px-0">
        <!-- text -->
        <div>
            <h4 class="font-medium text-2xl">{{shoot.name}}</h4>
            <p class="my-1 text-sm">Client: <span class="text-slate-600">{{shoot.client}}</span></p>
            <small class="italic">{{shoot.category}}</small>
            <div class="text-sm text-slate-600 w-2/3 mt-5 mb-10 whitespace-pre-wrap">{{ shoot.description }}</div>
        </div>

        <!-- images -->
        <div class="grid grid-cols-2 md:grid-cols-5 gap-4 mb-10" >
            <div v-for="image in shoot.shootImages">
                <img class="h-auto max-w-full rounded-lg" :src="`data:image/png;base64,${image.shootImage}`" alt="">
            </div>
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
            shoot: {}
        }
    },
    mounted() {
        this.getShoot()
    },
    setup(){
        const id = ref(useRoute().params.id)

        return {
            id
        }
    },
    methods: {
        async getShoot() {
            try {
                const response = await axios.get(`https://localhost:7049/api/Shoot/get-shoot/${this.id}`)

                this.shoot = response.data.shootObj

                console.log(this.shoot)
            } catch (error) {
                console.log("Error getting contact details", error)
            }
        }
    }
}
</script>