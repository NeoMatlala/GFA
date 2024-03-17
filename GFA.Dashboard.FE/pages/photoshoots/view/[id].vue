<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="bg-white p-5">
            <!-- text -->
            <div class="flex justify-between items-start">
                <div>
                    <h4 class="font-medium text-2xl">{{shoot.name}}</h4>
                    <p class="my-1 text-sm">Client: <span class="text-slate-600">{{shoot.client}}</span></p>
                    <small class="italic">{{shoot.category}}</small>
                    <div class="text-sm text-slate-600 mt-5 mb-10 whitespace-pre-wrap">{{ shoot.description }}</div>
                </div>
                <div class="flex justify-end items-enter gap-2">
                    <button class="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5">Update</button>
                    <NuxtLink to="/photoshoots" class="text-slate-400 bg-slate-50 border border-slate-300 hover:bg-slate-200 focus:ring-4 focus:outline-none rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Cancel</NuxtLink>
                </div>
                
            </div>

            <!-- images -->
            <div class="grid grid-cols-2 md:grid-cols-5 gap-4 mb-10">
                <div v-for="image in shoot.shootImages">
                    <img class="h-auto max-w-full rounded-lg" :src="`data:image/png;base64,${image.shootImage}`" alt="">
                </div>
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
            shoot: {
                name: '',
                client: '',
                description: '',
                category: '',
                shootImages: [
                    {
                        shootImage: null
                    }
                ]
            }
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
            } catch (error) {
                console.log("Error getting contact details", error)
            }
        }
    }
}
</script>