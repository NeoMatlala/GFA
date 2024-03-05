<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="text-2xl text-slate-800 font-medium">Update Contact Link</h1>

        <form class="mt-10" @submit.prevent="handleUpdate">
            <div class="grid grid-cols-2 gap-5">
                <div class="mb-5">
                    <label for="platform" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Platform</label>
                    <input type="text" id="platform" v-model="detail.platform" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Facebook" required />
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Contact Detail</label>
                    <input type="text" id="link" v-model="detail.link" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="www.facebook.com/gfaphotography" required />
                </div>
            </div>
            
            <div class="flex justify-end items-center gap-5 mt-3">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update Contact Detail</button>
                <NuxtLink to="/contacts" class="text-slate-400 bg-slate-50 border border-slate-300 hover:bg-slate-200 focus:ring-4 focus:outline-none rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Cancel</NuxtLink>
            </div>
        </form>

        <!-- success modal -->
        <div id="popup-modal" data-modal-backdrop="static" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
            <div class="relative p-4 w-full max-w-md max-h-full">
                <div class="relative bg-white rounded-lg shadow">
                    <div class="p-4 md:p-5 text-center">
                        <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                        </svg>
                        <h3 class="mb-5 text-lg font-normal text-gray-5000">Successfully updated</h3>
                        
                        <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Ok, thanks</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import { onMounted } from 'vue'
import { Modal } from 'flowbite'

export default{
    data() {
        return{
            detail: {
                platform: '',
                link: ''
            }
        }
    },
    setup() {
        const id = ref(useRoute().params.id)

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
                
            }
        },
        async handleUpdate() {
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdrop: 'static',
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }

            try {
                const response = await axios.put(`https://localhost:7049/api/Socials/update-link/${this.id}`, this.detail)
                console.log(response.data)

                const $modalElement = document.querySelector('#popup-modal');

                if (response.data.success) {
                    const modal = new Modal($modalElement, modalOptions);
                    modal.toggle()
                }

                if ($modalElement) {
                    const modal = new Modal($modalElement, modalOptions);
                    modal.toggle();
                    $closeButton.addEventListener('click', () => {
                        modal.hide()
                        this.$router.replace('/contacts');
                    });
                }
            } catch (error) {
                console.log("Error creating contact details", error)
            }
        }
    }
}
</script>