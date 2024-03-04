<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="text-2xl text-slate-800 font-medium">Delete Contact Link</h1>

        <form class="mt-10" @submit.prevent="handleDelete">
            <div class="grid grid-cols-2 gap-5">
                <div class="mb-5">
                    <label for="platform" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Platform</label>
                    <input type="text" id="platform" disabled v-model="detail.platform" class="bg-slate-200 border border-gray-300 text-gray-700 text-sm rounded-lg block w-full p-2.5" />
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Contact Detail</label>
                    <input type="text" disabled id="link" v-model="detail.link" class="bg-slate-200 border border-gray-300 text-gray-700 text-sm rounded-lg block w-full p-2.5" />
                </div>
            </div>
            
            <div class="flex justify-end items-center gap-5 mt-3">
                <button type="submit" class="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Delete Contact Detail</button>
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
            detail: {}
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
                console.log("Error retrieving contact detail:", error)
            }
        },
        async handleDelete() {
            try {
                const response = await axios.delete(`https://localhost:7049/api/Socials/delete-link/${this.id}`)
                console.log(response.data)
                if (response.data.success) {
                    this.$router.replace('/contacts');
                }
            } catch (error) {
                console.log("Error deleting contact details:", error)
            }
        }
    }
}
</script>