<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <div class="mb-10 flex justify-between items-center">
                <h1 class="text-2xl text-slate-800 font-medium">Contacts</h1>
                <NuxtLink to="/contacts/add" class="text-white bg-[#3c50e0] hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5">Add link</NuxtLink>
            </div>
            
            <div class="relative overflow-x-auto">
                <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" class="px-6 py-3">
                                Platform
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Link / Number
                            </th>
                            <th scope="col" class="px-6 py-3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="bg-white border-b dark:bg-gray-800 dark:border-gray-700" v-for="link in links">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                {{ link.platform }}
                            </th>
                            <td class="px-6 py-4">
                                {{ link.link }}
                            </td>
                            <td class="px-6 py-4 flex justify-end items-center gap-5">
                                <NuxtLink :to="`/contacts/update/${link.socialId}`" class="hover:underline text-blue-600">Update</NuxtLink>
                                <NuxtLink :to="`/contacts/delete/${link.socialId}`"  class="hover:underline text-red-600">Delete</NuxtLink>
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
                
                this.links = response.data
            } catch (error) {
                console.log("Error getting contact details", error)
            }
        }
    }
}
</script>