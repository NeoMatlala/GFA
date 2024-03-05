<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <div class="mb-10 flex justify-between items-center">
                <h1 class="text-2xl text-slate-800 font-medium">Profile</h1>
                <NuxtLink :to="`/profile/update/${profile.profileId}`" class="text-white bg-[#3c50e0] hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5">Update Profile</NuxtLink>
            </div>

            <div class="p-10 bg-white flex justify-between items-start gap-10">
                <div class="w-1/5">
                    <img class="w-full h-auto" :src="`data:image/png;base64,${profile.image}`">
                </div>
                <div class="w-4/5">
                    <h1 class="capitalize font-medium text-3xl mb-5">{{ profile.title }}</h1>

                    <div class="whitespace-pre-wrap text-slate-700">{{ profile.bio }}</div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return{
            profile: {}
        }
    },
    mounted() {
        this.getProfile()
    },
    methods: {
        async getProfile() {
            try {
                const response = await axios.get("https://localhost:7049/api/Profile/get-profile")
                console.log(response.data[0])
                this.profile = response.data[0]
            } catch (error) {
                console.log("Error getting profile", error)
            }
        }
    }
}
</script>