<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">
          <div>
            <label for="code">Tuutori id</label>
            <input
              id="code"
              name="code"
              v-model="tutor.code"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Tuutori ID"
            />
          </div>

          <div>
            <label for="name">Eesnimi</label>
            <input
              id="name"
              name="name"
              v-model="tutor.name"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Nimi"
            />
          </div>
          <div>
            <label for="surname">Perenimi</label>
            <input
              id="surname"
              name="surname"
              v-model="tutor.surname"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Perenimi"
            />
          </div>
          <div>
            <label for="status">Olek</label>
            <select
              id="status"
              name="status"
              v-model="tutor.status"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Olek"
            >
              <option value="aktiivne">Aktiivne</option>
              <option value="mitteaktiivne">Mitteaktiivne</option>
            </select>
          </div>

          <div>
            <label for="university">Ülikool</label>
            <input
              id="university"
              name="university"
              v-model="tutor.university"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Ülikool"
            />
          </div>

          <div>
            <label for="faculty">Teaduskond</label>
            <input
              id="faculty"
              name="faculty"
              v-model="tutor.faculty"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Teaduskond"
            />
          </div>

          <div>
            <label for="status">Gender</label>
            <select
              id="gender"
              name="status"
              v-model="tutor.gender"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Olek2"
            >
              <option value="M">Male</option>
              <option value="N">Female</option>
            </select>
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
import { Tutor, TutorGender, TutorStatus } from '@/model/tutor';
import { useTutorsStore } from '@/stores/tutorsStore';
import { Ref, ref } from 'vue';
import { useRouter } from 'vue-router';

const tutor: Ref<Tutor> = ref({
  name: '',
  surname: '',
  status: TutorStatus.Active,
  gender: TutorGender.Male,
  hourlyPrice: 0,
  code: '',
  university: '', // Add this property
  faculty: '',    // Add this property
});

const { addTutor } = useTutorsStore();
const router = useRouter();

const submitForm = () => {
  addTutor({ ...tutor.value });

  tutor.value.name = '';
  tutor.value.surname = '';
  tutor.value.code = '';
  tutor.value.status = TutorStatus.Active;
  tutor.value.gender = TutorGender.Male;
  tutor.value.hourlyPrice = 0;
  router.push({ name: 'Tuutorid' });
};
</script>
@/model/tutor @/stores/tutorsStore
