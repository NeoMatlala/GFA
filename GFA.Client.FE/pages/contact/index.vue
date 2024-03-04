<template>
    <div class="max-w-7xl mx-auto mb-10 px-2.5 md:px-0">
        <div class="mb-12 md:mb-16">
            <p class="text-center font-thin mb-3">Work with us | Just say hi</p>
            <h1 class="text-center text-4xl md:text-5xl font-medium">Let's Work Together</h1>
        </div>

        <div v-if="showSuccess" class="max-w-3xl mx-auto  font-medium text-center p-4 mb-10 text-sm text-green-800 border border-green-300 rounded-lg bg-green-50" role="alert">
            {{ successMessage }}
        </div>

        <form class="max-w-3xl mx-auto" @submit.prevent="SendMessage">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-7 mb-7">
                <div>
                    <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Name</label>
                    <input type="text" v-model="message.name" id="name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Jon" required />
                </div>
                <div>
                    <label for="number" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Phone Number</label>
                    <input type="text" v-model="message.phoneNumber" id="number" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="0745859658" required />
                </div>
                <div>
                    <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email Address</label>
                    <input type="email" v-model="message.email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@flowbite.com" required />
                </div>
                <div>
                    <label for="subject" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Subject</label>
                    <input type="text" v-model="message.subject" id="subject" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Hourly Rate" required />
                </div>
            </div>
            <div class="mb-5">
                <label for="message" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Your message</label>
                <textarea id="message" rows="4" v-model="message.messageBody" class="block whitespace-pre-wrap p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500" placeholder="Leave a message..."></textarea>
            </div>
            
            <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full px-5 py-2.5 text-center">Send message</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return{
            message: {
                name: '',
                phoneNumber: '',
                email: '',
                subject: '',
                messageBody: ''
            },
            showSuccess: false,
            successMessage: '',
        }
    },
    mounted(){
        this.showSuccess = false
    },
    methods: {
        async SendMessage() {
            try {
                const response = await axios.post("https://localhost:7049/api/Message/create-message", this.message)
                
                console.log(response.data)

                if (response.data.success) {
                    this.showSuccess = true

                    this.successMessage = response.data.message

                    this.message.name = ''
                    this.message.phoneNumber = ''
                    this.message.email = ''
                    this.message.subject = ''
                    this.message.messageBody = ''
                }

                
            } catch (error) {
                console.log("Error sending message", error)
            }
        }
    }
}
</script>