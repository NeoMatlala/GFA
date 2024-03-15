<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="bg-white p-5">
            <!-- text -->
            <div class="flex justify-between items-start">
                <div>
                    <h4 class="font-medium text-2xl">Matric delight</h4>
                    <p class="my-1 text-sm">Client: <span class="text-slate-600">Thobeka Zwane</span></p>
                    <small class="italic">Matric dance shoot</small>
                    <p class="text-sm text-slate-600 mt-5 mb-10">
                        Stepping into the radiant ambiance of our matric farewell dance shoot, we were greeted by a tapestry of vibrant colors and effervescent energy. Adorned in our finest attire, each ensemble a testament to our individuality, we embarked on a journey to capture the essence of this momentous occasion. Against the backdrop of twinkling lights and ornate decor, our spirits soared as we embraced the anticipation of bidding adieu to our high school years.
                        <br><br>
                        With every click of the camera, we reveled in the magic of the evening, allowing laughter to cascade effortlessly and smiles to illuminate the room. Each pose, carefully curated, echoed the jubilant spirit that permeated the air, a celebration of friendship and shared experiences. From candid snapshots to meticulously staged shots, every frame encapsulated the joy and camaraderie that defined our matric farewell.
                        <br><br>
                        As the night unfolded, we found ourselves immersed in a whirlwind of emotions, from bittersweet nostalgia to unbridled excitement for the future. Amidst the swirl of music and laughter, we seized the opportunity to freeze moments in time, knowing that these memories would become cherished keepsakes for years to come. Our matric farewell dance shoot was more than just a photographic endeavor—it was a testament to the bonds we forged, the dreams we shared, and the unforgettable moments that defined our high school journey.
                    </p>
                </div>
                <div class="flex justify-end items-enter gap-2">
                    <button class="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5">Delete</button>
                    <NuxtLink to="/photoshoots" class="text-slate-400 bg-slate-50 border border-slate-300 hover:bg-slate-200 focus:ring-4 focus:outline-none rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Cancel</NuxtLink>
                </div>
                
            </div>

            <!-- images -->
            <div class="grid grid-cols-2 md:grid-cols-5 gap-4 mb-10">
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../../../assets/img/studio.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../../../assets/img/studio.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../../../assets/img/studio.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../../../assets/img/studio.jpg" alt="">
                </div>
                <div>
                    <img class="h-auto max-w-full rounded-lg" src="../../../assets/img/studio.jpg" alt="">
                </div>
            </div>
        </div>
    </div>
</template>