<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-2xl mb-10 text-slate-800 font-medium">Messages</h1>

            <div class="relative overflow-x-auto">
                <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                    <thead class="text-xs text-gray-700 uppercase bg-gray-50 ">
                        <tr>
                            <th scope="col" class="px-6 py-3">
                                Subject
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Name
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Email
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Phone Number
                            </th>
                            <th scope="col" class="px-6 py-3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="bg-white border-b" :class="{'font-medium bg-blue-50 text-blue-600': !message.isRead}" v-for="message in messages">
                            <th scope="row" class="px-6 py-4 font-medium ">
                                {{ message.subject }}
                            </th>
                            <td class="px-6 py-4">
                                {{ message.name }}
                            </td>
                            <td class="px-6 py-4">
                                {{ message.email }}
                            </td>
                            <td class="px-6 py-4">
                                {{ message.phoneNumber }}
                            </td>
                            <td class="px-6 py-4 flex justify-end items-center gap-5">
                                <NuxtLink :to="`/messages/view/${message.messageId}`" class="hover:underline text-blue-600">View</NuxtLink>
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
            messages: []
        }
    },
    mounted() {
        this.getMessages()
    },
    methods: {
        async getMessages() {
            try {
                const response = await axios.get("https://localhost:7049/api/Message/get-all-messages")
                
                this.messages = response.data.reverse()
            } catch (error) {
                console.log("Error getting messages", error)
            }
        }
    }
}
</script>