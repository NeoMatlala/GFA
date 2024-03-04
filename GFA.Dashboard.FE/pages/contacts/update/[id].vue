<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="text-2xl text-slate-800 font-medium">Update Contact Link</h1>

        <form class="mt-10" @submit.prevent="handleUpdate">
            <div class="grid grid-cols-2 gap-5">
                <div class="mb-5">
                    <label for="platform" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Platform</label>
                    <input type="text" id="platform" v-model="detail.platform" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Facebook" required />
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Contact Detail</label>
                    <input type="text" id="link" v-model="detail.link" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="www.facebook.com/gfaphotography" required />
                </div>
            </div>
            
            <div class="flex justify-end items-center gap-5 mt-3">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update Contact Detail</button>
                <NuxtLink to="/contacts" class="text-slate-400 bg-slate-50 border border-slate-300 hover:bg-slate-200 focus:ring-4 focus:outline-none rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue'
import { useRoute } from 'vue-router'

export default{
    data() {
        return{
            detail: {
                platform: '',
                link: ''
            }
        }
    },
    setup() {
        const id = ref(useRoute().params.id)

        return {
            id
        }
    },
    mounted(){
        this.getDetail()
    },
    methods: {
        async getDetail() {
            try {
                const response = await axios.get(`https://localhost:7049/api/Socials/get-link/${this.id}`)

                this.detail = response.data
            } catch (error) {
                
            }
        },
        async handleUpdate() {
            try {
                const response = await axios.put(`https://localhost:7049/api/Socials/update-link/${this.id}`, this.detail)
                console.log(response.data)
                if (response.data.success) {
                    this.$router.replace('/contacts');
                }
            } catch (error) {
                console.log("Error creating contact details", error)
            }
        }
    }
}
</script>