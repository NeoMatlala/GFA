<template>
    <div class="max-w-7xl mx-auto px-2.5 md:px-0">

        <div class="mt-10 flex flex-col md:flex-row justify-center gap-8 md:gap-5 items-start">
            <div role="status" class="w-full md:w-1/4 p-4 rounded animate-pulse md:p-6 dark:border-gray-700" v-if="shoots.length <= 0">
                <div class="flex items-center justify-center h-48 mb-4 bg-gray-300 rounded dark:bg-gray-700">
                    <svg class="w-10 h-10 text-gray-200 dark:text-gray-600" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 16 20">
                        <path d="M14.066 0H7v5a2 2 0 0 1-2 2H0v11a1.97 1.97 0 0 0 1.934 2h12.132A1.97 1.97 0 0 0 16 18V2a1.97 1.97 0 0 0-1.934-2ZM10.5 6a1.5 1.5 0 1 1 0 2.999A1.5 1.5 0 0 1 10.5 6Zm2.221 10.515a1 1 0 0 1-.858.485h-8a1 1 0 0 1-.9-1.43L5.6 10.039a.978.978 0 0 1 .936-.57 1 1 0 0 1 .9.632l1.181 2.981.541-1a.945.945 0 0 1 .883-.522 1 1 0 0 1 .879.529l1.832 3.438a1 1 0 0 1-.031.988Z"/>
                        <path d="M5 5V.13a2.96 2.96 0 0 0-1.293.749L.879 3.707A2.98 2.98 0 0 0 .13 5H5Z"/>
                    </svg>
                </div>
                <div class="h-2.5 bg-gray-200 rounded-full dark:bg-gray-700 w-48 mb-4"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700 mb-2.5"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700 mb-2.5"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700"></div>
                <div class="flex items-center mt-4">
                <svg class="w-10 h-10 me-3 text-gray-200 dark:text-gray-700" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                        <path d="M10 0a10 10 0 1 0 10 10A10.011 10.011 0 0 0 10 0Zm0 5a3 3 0 1 1 0 6 3 3 0 0 1 0-6Zm0 13a8.949 8.949 0 0 1-4.951-1.488A3.987 3.987 0 0 1 9 13h2a3.987 3.987 0 0 1 3.951 3.512A8.949 8.949 0 0 1 10 18Z"/>
                    </svg>
                    <div>
                        <div class="h-2.5 bg-gray-200 rounded-full dark:bg-gray-700 w-32 mb-2"></div>
                        <div class="w-48 h-2 bg-gray-200 rounded-full dark:bg-gray-700"></div>
                    </div>
                </div>
                <span class="sr-only">Loading...</span>
            </div>
            <div role="status" class="w-full md:w-1/4 p-4 rounded animate-pulse md:p-6 dark:border-gray-700" v-if="shoots.length <= 0">
                <div class="flex items-center justify-center h-48 mb-4 bg-gray-300 rounded dark:bg-gray-700">
                    <svg class="w-10 h-10 text-gray-200 dark:text-gray-600" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 16 20">
                        <path d="M14.066 0H7v5a2 2 0 0 1-2 2H0v11a1.97 1.97 0 0 0 1.934 2h12.132A1.97 1.97 0 0 0 16 18V2a1.97 1.97 0 0 0-1.934-2ZM10.5 6a1.5 1.5 0 1 1 0 2.999A1.5 1.5 0 0 1 10.5 6Zm2.221 10.515a1 1 0 0 1-.858.485h-8a1 1 0 0 1-.9-1.43L5.6 10.039a.978.978 0 0 1 .936-.57 1 1 0 0 1 .9.632l1.181 2.981.541-1a.945.945 0 0 1 .883-.522 1 1 0 0 1 .879.529l1.832 3.438a1 1 0 0 1-.031.988Z"/>
                        <path d="M5 5V.13a2.96 2.96 0 0 0-1.293.749L.879 3.707A2.98 2.98 0 0 0 .13 5H5Z"/>
                    </svg>
                </div>
                <div class="h-2.5 bg-gray-200 rounded-full dark:bg-gray-700 w-48 mb-4"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700 mb-2.5"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700 mb-2.5"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700"></div>
                <div class="flex items-center mt-4">
                <svg class="w-10 h-10 me-3 text-gray-200 dark:text-gray-700" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                        <path d="M10 0a10 10 0 1 0 10 10A10.011 10.011 0 0 0 10 0Zm0 5a3 3 0 1 1 0 6 3 3 0 0 1 0-6Zm0 13a8.949 8.949 0 0 1-4.951-1.488A3.987 3.987 0 0 1 9 13h2a3.987 3.987 0 0 1 3.951 3.512A8.949 8.949 0 0 1 10 18Z"/>
                    </svg>
                    <div>
                        <div class="h-2.5 bg-gray-200 rounded-full dark:bg-gray-700 w-32 mb-2"></div>
                        <div class="w-48 h-2 bg-gray-200 rounded-full dark:bg-gray-700"></div>
                    </div>
                </div>
                <span class="sr-only">Loading...</span>
            </div>
            <div role="status" class="w-full md:w-1/4 p-4 rounded animate-pulse md:p-6 dark:border-gray-700" v-if="shoots.length <= 0">
                <div class="flex items-center justify-center h-48 mb-4 bg-gray-300 rounded dark:bg-gray-700">
                    <svg class="w-10 h-10 text-gray-200 dark:text-gray-600" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 16 20">
                        <path d="M14.066 0H7v5a2 2 0 0 1-2 2H0v11a1.97 1.97 0 0 0 1.934 2h12.132A1.97 1.97 0 0 0 16 18V2a1.97 1.97 0 0 0-1.934-2ZM10.5 6a1.5 1.5 0 1 1 0 2.999A1.5 1.5 0 0 1 10.5 6Zm2.221 10.515a1 1 0 0 1-.858.485h-8a1 1 0 0 1-.9-1.43L5.6 10.039a.978.978 0 0 1 .936-.57 1 1 0 0 1 .9.632l1.181 2.981.541-1a.945.945 0 0 1 .883-.522 1 1 0 0 1 .879.529l1.832 3.438a1 1 0 0 1-.031.988Z"/>
                        <path d="M5 5V.13a2.96 2.96 0 0 0-1.293.749L.879 3.707A2.98 2.98 0 0 0 .13 5H5Z"/>
                    </svg>
                </div>
                <div class="h-2.5 bg-gray-200 rounded-full dark:bg-gray-700 w-48 mb-4"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700 mb-2.5"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700 mb-2.5"></div>
                <div class="h-2 bg-gray-200 rounded-full dark:bg-gray-700"></div>
                <div class="flex items-center mt-4">
                <svg class="w-10 h-10 me-3 text-gray-200 dark:text-gray-700" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                        <path d="M10 0a10 10 0 1 0 10 10A10.011 10.011 0 0 0 10 0Zm0 5a3 3 0 1 1 0 6 3 3 0 0 1 0-6Zm0 13a8.949 8.949 0 0 1-4.951-1.488A3.987 3.987 0 0 1 9 13h2a3.987 3.987 0 0 1 3.951 3.512A8.949 8.949 0 0 1 10 18Z"/>
                    </svg>
                    <div>
                        <div class="h-2.5 bg-gray-200 rounded-full dark:bg-gray-700 w-32 mb-2"></div>
                        <div class="w-48 h-2 bg-gray-200 rounded-full dark:bg-gray-700"></div>
                    </div>
                </div>
                <span class="sr-only">Loading...</span>
            </div>
        </div>

        <div class="grid grid-cols-1 md:grid-cols-3 gap-5" v-if="shoots.length > 0">
            <NuxtLink :to="`/shoot/${shoot.shootId}`" class="hover:scale-[1.005]" v-for="shoot in shoots">
                <img :src="`data:image/png;base64,${shoot.mainImage}`" class="w-full rounded h-[600px] object-cover">
            </NuxtLink>
        </div>
        <!-- masonry grid -->

        <!-- <div class="flex flex-col md:flex-row justify-between items-start gap-5">
            <div class="w-full md:w-1/3 flex flex-col gap-5">
                <NuxtLink :to="`/shoot/${shoot.shootId}`" class="hover:scale-[1.005]" v-for="shoot in shoots">
                    <img :src="`data:image/png;base64,${shoot.mainImage}`" class="w-full rounded h-[600px] object-cover">
                </NuxtLink>
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-5.jpg" class="w-full rounded h-auto">
                </NuxtLink>
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-3.jpg" class="w-full rounded h-auto">
                </NuxtLink>
            </div>
            <div class="w-full md:w-1/3 flex flex-col gap-5">
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-4.jpg" class="w-full rounded h-auto">
                </NuxtLink>
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-7.jpg" class="w-full rounded object-cover h-[700px]">
                </NuxtLink>
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-6.jpg" class="w-full rounded h-auto">
                </NuxtLink>
            </div>
            <div class="w-full md:w-1/3 flex flex-col gap-5">
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-2.jpg" class="w-full object-cover rounded h-96">
                </NuxtLink>
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-8.jpg" class="w-full rounded h-auto">
                </NuxtLink>
                <NuxtLink to="/shoot" class="hover:scale-[1.005]">
                    <img src="../assets/img/gfa-9.jpg" class="w-full rounded h-auto">
                </NuxtLink>
            </div>
        </div> -->
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return{
            shoots: []
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

                console.log(this.shoots)
            } catch (error) {
                console.log("Error getting contact details", error)
            }
        }
    }
}
</script>