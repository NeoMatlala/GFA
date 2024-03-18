<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="text-2xl text-slate-800 font-medium">Add Photoshoot</h1>

        <form class="mt-10" @submit.prevent="handleSubmit" enctype="multipart/form-data">
            <div class="grid grid-cols-2 gap-5">
                <div class="mb-5">
                    <label for="platform" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Shoot Name</label>
                    <input type="text" v-model="shoot.name" id="platform" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Matric Delight" required />
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Client</label>
                    <input type="text" v-model="shoot.client" id="link" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John Doe" required />
                </div>
            </div>
            <div class="grid grid-cols-2 gap-5">
                <div class="mb-5">
                    <label for="platform" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Shoot Category</label>
                    <input type="text" v-model="shoot.category" id="platform" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Matric Dance Shoot" required />
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Main Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" @change="handleMainImageUpload" type="file">
                </div>
            </div>
            <div class="mb-5">
                <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Shoot Description</label>
                <textarea id="message" v-model="shoot.description" rows="10" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500 whitespace-pre-wrap" required placeholder="Write bio here..."></textarea>
            </div>
            <!-- iWant to imporove this part -->
            <!-- <div class="grid grid-cols-4 gap-5">
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none"  type="file">
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none"  type="file">
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none"  type="file">
                </div>
                <div class="mb-5">
                    <label for="link" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none"  type="file">
                </div>
            </div> -->
            
            <!-- Additional Images Inputs -->
            <div v-for="(input, index) in inputs" :key="index" class="mb-5 flex justify-between items-end">
                <div class="w-4/5">
                    <label for="additionalImage" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Additional Image</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" type="file" @change="handleAdditionalImageUpload($event)">
                </div>
                
                <button @click.prevent="removeImage(index)" class="rounded-sm bg-red-500 text-white px-2 py-1 focus:outline-none hover:bg-red-600">-</button>
            </div>
            <div class="my-5 flex items-center">
                <button @click.prevent="addImageInput" class="rounded-sm bg-blue-500 text-white px-2 py-1 focus:outline-none hover:bg-blue-600">Add shoot Image</button>
            </div>

            <div class="flex justify-end items-center gap-5 mt-3">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Add Photoshoot</button>
                <NuxtLink to="/photoshoots" class="text-slate-400 bg-slate-100 border border-slate-300 hover:bg-slate-200 focus:ring-4 focus:outline-none font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return{
            shoot: {
                name: '',
                client: '',
                category: '',
                description: '',
                mainImage: '',
                shootImages: []
            },
            inputs: []
        }
    },
    methods: {
        handleMainImageUpload(event) {
            const file = event.target.files[0]
            this.shoot.mainImage = file
        },
        handleAdditionalImageUpload(event) {
            const file = event.target.files[0]
            this.shoot.shootImages.push(file)
        },

        async handleSubmit() {
            try {
                const formData = new FormData()
                formData.append('name', this.shoot.name)
                formData.append('client', this.shoot.client)
                formData.append('category', this.shoot.category)
                formData.append('description', this.shoot.description)
                formData.append('mainImage', this.shoot.mainImage)
                for(let i = 0; i < this.shoot.shootImages.length;i++) {
                    formData.append('shootImages', this.shoot.shootImages[i])
                }

                // for (const [key, value] of formData.entries()) {
                //     console.log(`${key}:`, value);
                // }

                const response = await axios.post(`https://localhost:7049/api/Shoot/create-shoot`, formData, {
                    headers: {
                        "Content-Type": 'multipart/form-data'
                    }
                })

                console.log(response.data)

                if (response.data.success) {
                    this.$router.replace('/photoshoots');
                }
            } catch (error) {
                console.log("Error creating shoot: ", error.message)

                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log("Server response data:", error.response.data);
                    // this.errorDisplay = true
                    // this.errorMessage = error.response.data.message
                    console.log("Status code:", error.response.status);
                } else if (error.request) {
                    // The request was made but no response was received
                    console.log("No response received from the server");
                } else {
                    // Something happened in setting up the request that triggered an Error
                    console.log("Error:", error.message);
                }
            }
        },
        addImageInput() {
            this.inputs.push({})
        },
        removeImage(index){
            this.inputs.splice(index,1)
        }
    }
}
</script>