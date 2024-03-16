<template>
    <div class="max-w-7xl mx-auto mb-10 px-2.5 md:px-0">
        <div class="flex flex-col md:flex-row justify-center items-start gap-10">
            <div class="w-full md:w-1/2 h-full">
                <img class="w-full h-full" :src="`data:image/png;base64,${profile.image}`">
            </div>
            <div class="w-full md:w-1/2 h-full">
                <h1 class="text-3xl md:text-5xl leading-relaxed md:leading-[1.2] font-medium mb-5">{{ profile.title }}</h1>
                <p class="text-slate-600 leading-8 whitespace-pre-wrap">{{ profile.bio }}</p>
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
                //console.log(response.data[0])
                this.profile = response.data[0]
            } catch (error) {
                console.log("Error getting profile", error)
            }
        }
    }
}
</script>