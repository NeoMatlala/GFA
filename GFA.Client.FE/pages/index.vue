<template>
    <div class="max-w-7xl mx-auto px-2.5 md:px-0">
        <!-- masonry grid -->
        
        <div class="grid grid-cols-2 md:grid-cols-4 gap-4 mb-10">
            <div class="grid gap-4">
                <div class="relative">
                    <NuxtLink @mouseover="showOverlay = true" @mouseleave="showOverlay = false" class="block z-10 relative" to="/shoot">
                        <img class="h-auto max-w-full z-10 rounded-lg" src="../assets/img/gfa-4.jpg" alt="">
                        <div v-if="showOverlay">
                            <div class="absolute inset-0 ease-in-out duration-300 bg-black opacity-80 rounded-lg"></div>
                            <div class="absolute text-white inset-0 w-full h-full flex flex-col items-center justify-center">
                                <h2 class=" text-xl font-medium">Get Lost in Mountains</h2>
                                <p class="text-sm ">Matric farewell shoot</p>
                            </div>
                        </div>
                    </NuxtLink>
                </div>
                <NuxtLink to="/shoot">
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-5.jpg" alt="">
                </NuxtLink>
                <NuxtLink to="/shoot">
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-6.jpg" alt="">
                </NuxtLink>
            </div>
            <div class="grid gap-4">
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-1.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-2.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-3.jpg" alt="">
                </div>
            </div>
            <div class="grid gap-4">
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-8.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-9.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-10.jpg" alt="">
                </div>
            </div>
            <div class="grid gap-4">
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-11.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-12.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../assets/img/gfa-12.jpg" alt="">
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      showOverlay: false
    };
  }
};
</script>