<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <div class="flex justify-between items-center">
                <h1 class="text-2xl mb-10 text-slate-800 font-medium">Photo shoots</h1>
                <NuxtLink to="/photoshoots/add" class="text-white bg-[#3c50e0] hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5">Add photo shoot</NuxtLink>
            </div>
            

            <div class="relative overflow-x-auto">
                <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                    <thead class="text-xs text-gray-700 uppercase bg-gray-50 ">
                        <tr>
                            <th scope="col" class="px-6 py-3">
                                Shoot Name
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Client
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Category
                            </th>
                            <th scope="col" class="px-6 py-3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="bg-white border-b" v-for="shoot in shoots">
                            <th scope="row" class="px-6 py-4 font-medium ">
                                {{ shoot.name }}
                            </th>
                            <td class="px-6 py-4">
                                {{ shoot.client }}
                            </td>
                            <td class="px-6 py-4">
                                {{ shoot.category }}
                            </td>
                            <td class="px-6 py-4 flex justify-end items-center gap-5">
                                <NuxtLink :to="`/photoshoots/view/${shoot.shootId}`" class="hover:underline text-blue-600">View</NuxtLink>
                                <NuxtLink :to="`/photoshoots/delete/${shoot.shootId}`" class="hover:underline text-red-600">Delete</NuxtLink>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return{
            shoots: [
                {
                shootId: '',
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
            ]
        }
    },
    mounted() {
        this.getShoots()
    },
    methods: {
        async getShoots() {
            try {
                const response = await axios.get("https://localhost:7049/api/Shoot/get-shoots")

                this.shoots = response.data
            } catch (error) {
                console.log("Error getting contact details", error)
            }
        }
    }
}
</script>