<template>
    <div class="max-w-7xl mx-auto mb-10 px-2.5 md:px-0">
        <div class="mb-12 md:mb-16">
            <p class="text-center font-thin mb-3">Work with us | Just say hi</p>
            <h1 class="text-center text-4xl md:text-5xl font-medium">Let's Work Together</h1>
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

        <!-- success modal -->
        <div id="popup-modal" data-modal-backdrop="static" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
            <div class="relative p-4 w-full max-w-md max-h-full">
                <div class="relative bg-white rounded-lg shadow">
                    <div class="p-4 md:p-5 text-center">
                        <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                        </svg>
                        <h3 class="mb-5 text-lg font-normal text-gray-5000">Message sent, we'll get back to you shortly.</h3>
                        
                        <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Ok, thanks</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { onMounted } from 'vue'
import { Modal } from 'flowbite'

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
        }
    },
    setup(){
        onMounted(async () => {
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdrop: 'static',
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }
            if ($modalElement) {
                const modal = new Modal($modalElement, modalOptions);
                 $closeButton.addEventListener('click', () => modal.hide());
            }
        })
    },
    methods: {
        async SendMessage() {
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdrop: 'static',
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }

            try {
                const response = await axios.post("https://localhost:7049/api/Message/create-message", this.message)

                const $modalElement = document.querySelector('#popup-modal');
                
                if (response.data.success) {
                    this.message.name = ''
                    this.message.phoneNumber = ''
                    this.message.email = ''
                    this.message.subject = ''
                    this.message.messageBody = ''

                    const modal = new Modal($modalElement, modalOptions);
                    modal.toggle()
                }

                if ($modalElement) {
                    const modal = new Modal($modalElement, modalOptions);
                    modal.toggle();
                    $closeButton.addEventListener('click', () => {
                        modal.hide()
                    });
                }
            } catch (error) {
                console.log("Error sending message", error)
            }
        }
    }
}
</script>