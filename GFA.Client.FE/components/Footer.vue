<template>
    <footer class="bg-white max-w-7xl mx-auto pt-10">
        <hr class="h-px my-8 bg-slate-200 border-0">
        <div class="grid grid-cols-2 gap-8 px-4 py-6 lg:py-8 md:grid-cols-3">
            <div>
                <h2 class="mb-4 text-md font-medium text-black uppercase dark:text-white">Connect</h2>
                <ul class="text-gray-500 space-y-2 font-light">
                    <li class="hover:underline" v-for="link in links">
                        <a :href="link.link" target="_blank" class="hover:underline">{{link.platform}}</a>
                    </li>
                </ul>
            </div>
            <div>
                <h2 class="mb-4 text-md font-medium text-black uppercase dark:text-white">Address</h2>
                <ul class="text-gray-500 space-y-2 font-light">
                    <li>14 Solomon Drive</li>
                    <li>Seshego</li>
                    <li>Polokwane</li>
                </ul>
            </div>
            <div>
                <h2 class="mb-4 text-md font-medium text-black uppercase dark:text-white">Contact</h2>
                <ul class="text-gray-500 space-y-3 font-light">
                    <li class="hover:underline">Email: info@gfa.com</li>
                    <li class="hover:underline">Phone: 074859632</li>
                    <li class="italic  text-sm">© 2023 GFA. All Rights Reserved.</li>
                </ul>
            </div>
            
        </div>
    </footer>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return{
            links: []
        }
    },
    mounted() {
        this.getContactDetails()
    },
    methods: {
        async getContactDetails() {
            try {
                const response = await axios.get("https://localhost:7049/api/Socials/get-all-links")
                
                response.data = response.data.filter(obj => obj.platform !== "Email")
                response.data = response.data.filter(obj => obj.platform !== "Phone Number")

                this.links = response.data
            } catch (error) {
                console.log("Error getting contact details", error)
            }
        }
    }
}
</script>