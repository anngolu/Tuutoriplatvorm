<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">

          <div>
            <label for="name">Nimi</label>
            <input
              id="name"
              name="name"
              v-model="tutor.name"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Nimi"
            />
          </div>
          <div>
            <label for="town">Linn</label>
            <input
              id="town"
              name="town"
              v-model="tutor.town"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Linn"
            />
          </div>

          <div>
            <label for="university">Ülikool (kui veel õpid)</label>
            <input
              id="university"
              name="university"
              v-model="tutor.university"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Ülikool"
            />
          </div>

          <div>
            <label for="faculty">Fakulteet</label>
            <input
              id="faculty"
              name="faculty"
              v-model="tutor.speciality"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Fakulteet"
            />
          </div>

          <div>
            <label for="mail">Mail</label>
            <input
              id="mail"
              name="mail"
              v-model="tutor.mail"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="mail"
            />
          </div>
          <div>
            <label for="subject">Aine</label>
            <input
              id="subject"
              name="subject"
              v-model="tutor.subject"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Aine"
            />
          </div>

          <div>
            <label for="hourlyPrice">Tunnihind</label>
            <input
              type="number"
              id="hourlyPrice"
              name="hourlyPrice"
              v-model="tutor.hourlyPrice"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-blue-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            />
          </div>

          
        </div>

        <div>
          <button
            @click.prevent="submitForm"
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            <span class="absolute left-0 inset-y-0 flex items-center pl-3">
            </span>
            Lisa tuutor
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { Tutor } from '@/model/tutor';
import { useTutorsStore } from '@/stores/tutorsStore';
import { Ref, ref } from 'vue';
import { useRouter } from 'vue-router';

const tutor: Ref<Tutor> = ref({

  name: '',
  town: '',
  university: '',
  speciality: '',
  mail: '',
  subject: '',
  hourlyPrice: undefined,

});

const { addTutor } = useTutorsStore();
const router = useRouter();

const submitForm = () => {
  addTutor({ ...tutor.value });

  tutor.value.name = '';
  tutor.value.town = '';
  tutor.value.university = '';
  tutor.value.speciality = '';
  tutor.value.mail = '';
  tutor.value.subject = '';
  tutor.value.hourlyPrice = 0;

  router.push({ name: 'Tuutorid' });
};
</script>
@/model/tutor @/stores/tutorsStore
