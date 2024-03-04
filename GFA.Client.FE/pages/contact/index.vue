<template>
    <div class="max-w-7xl mx-auto mb-10 px-2.5 md:px-0">
        <div class="mb-12 md:mb-16">
            <p class="text-center font-thin mb-3">Work with us | Just say hi</p>
            <h1 class="text-center text-4xl md:text-5xl font-medium">Let's Work Together</h1>
        </div>

        <form class="max-w-3xl mx-auto">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-7 mb-7">
                <div>
                    <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Name</label>
                    <input type="text" id="name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Jon" required />
                </div>
                <div>
                    <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Surname</label>
                    <input type="text" id="name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Masuku" required />
                </div>
                <div>
                    <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email Address</label>
                    <input type="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@flowbite.com" required />
                </div>
                <div>
                    <label for="subject" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Subject</label>
                    <input type="text" id="subject" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Hourly Rate" required />
                </div>
            </div>
            <div class="mb-5">
                <label for="message" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Your message</label>
                <textarea id="message" rows="4" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500" placeholder="Leave a message..."></textarea>
            </div>
            
            <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full px-5 py-2.5 text-center">Send message</button>
        </form>
    </div>
</template>