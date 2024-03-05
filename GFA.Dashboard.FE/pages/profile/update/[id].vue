<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="text-2xl text-slate-800 font-medium">Update Profile</h1>

        <form class="mt-10" @submit.prevent="handleUpdate">
            <div class="grid grid-cols-2 gap-5">
                <div class="mb-5">
                    <label for="platform" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Title</label>
                    <input type="text" id="platform" v-model="profile.title" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Facebook" required />
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" @change="handleImageUpload" type="file">
                </div>
            </div>
            <div>
                <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Bio</label>
                <textarea id="message" rows="30" v-model="profile.bio" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500" required placeholder="Write bio here..."></textarea>
            </div>
            
            <div class="flex justify-end items-center gap-5 mt-3">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update Profile</button>
                <NuxtLink to="/profile" class="text-slate-400 bg-slate-50 border border-slate-300 hover:bg-slate-200 focus:ring-4 focus:outline-none rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Cancel</NuxtLink>
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
            profile: {
                title: '',
                bio: '',
                image: ''
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
        this.getProfile()
    },
    methods: {
        async getProfile() {
            try {
                const response = await axios.get(`https://localhost:7049/api/Profile/get-profile`)

                this.profile = response.data[0]
            } catch (error) {
                
            }
        },
        async handleUpdate() {
            try {
                const formData = new FormData()
                formData.append('title', this.profile.title)
                formData.append('bio', this.profile.bio)
                formData.append('image', this.profile.image)

                const response = await axios.put(`https://localhost:7049/api/Profile/update-profile/${this.id}`, formData, {
                    headers: {
                        "Content-Type": 'multipart/form-data'
                    }
                })

                console.log(response.data)

                if (response.data.success) {
                    this.$router.replace('/profile');
                }
            } catch (error) {
                console.log("Error creating contact details", error)
            }
        },
        handleImageUpload(event) {
            const file = event.target.files[0]
            this.profile.image = file
        },
    }
}
</script>