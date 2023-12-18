<template>
  <div
    class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8"
  >
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm">
        <div>
          {{ tutor.id !== undefined ? 'Uuendame andmed: ' : 'Lisa tuutor' }}
          <br />
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
            <select
              id="town"
              name="town"
              v-model="tutor.town"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Linn"
            >
              <option value="Tartu">Tartu</option>
              <option value="Tallinn">Tallinn</option>
              <option value="Narva">Narva</option>
              <option value="KohtlaJarve">Kohtla-Järve</option>
            </select>
          </div>

          <div>
            <label for="university">Ülikool (kui veel õpid)</label>
            <select
              id="university"
              name="university"
              v-model="tutor.university"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Ülikool"
            >
              <option value="UniversityOfTartu">University of Tartu</option>
              <option value="TallinnTechnicalUniversity">
                Tallinn Technical University
              </option>
              <option value="TallinnUniversity">Tallinn University</option>
              <option value="TallinnCollegeOfHealth">
                Tallinn College Of Health
              </option>
              <option value="TartuHigherArtSchool">
                Tartu Higher Art School
              </option>
            </select>
          </div>

          <div>
            <label for="speciality">Fakulteet</label>
            <select
              id="speciality"
              name="speciality"
              v-model="tutor.speciality"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Fakulteet"
            >
              <option value="BusinessIt">Business It</option>
              <option value="Economics">Economics</option>
              <option value="Informatics">Informatics</option>
              <option value="Science">Science</option>
              <option value="CyberSecurity">CyberSecurity</option>
              <option value="Psychologist">Psychologist</option>
            </select>
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
            <MultiSelect
              id="subject"
              name="subject"
              v-model="tutor.subjects"
              :options="subjects"
              display="chip"
              optionValue="code"
              optionLabel="name"
              :maxSelectedLabels="3"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Aine"
            >
            </MultiSelect>
          </div>

          <div class="mb-2">
            <label for="hourlyPrice">Tunnihind</label>
            <input
              type="number"
              id="hourlyPrice"
              name="hourlyPrice"
              v-model="tutor.hourlyPrice"
              class="appearance-none relative block w-full px-3 py-2 border border-blue-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            />
          </div>
        </div>
      </div>

      <div>
        <button
          @click.prevent="submitForm"
          class="group w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          {{ tutor.id !== undefined ? 'Uuenda tuutor' : 'Lisa tuutor' }}
        </button>
      </div>
      <div class="mt-2" v-if="tutor.id">
        <button
          @click.prevent="deleteTutorHandler"
          class="group w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500"
        >
          Kustuta tuutor
        </button>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { Tutor } from '@/model/tutor';
import { useTutorsStore } from '@/stores/tutorsStore';
import { onMounted, Ref, ref, watch } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { Subject } from '@/model/schedule';

const tutor: Ref<Tutor> = ref({
  name: '',
  town: undefined,
  university: undefined,
  speciality: undefined,
  mail: '',
  subjects: [],
  hourlyPrice: 0,
  id: undefined,
});

const { addTutor, deleteTutor, getTutorById, updateTutor, load } = useTutorsStore();
const router = useRouter();
const route = useRoute();

watch(
  () => route.params.id,
  async (id) => await getTutor(id),
);

onMounted(() => {
  getTutor(route.params.id);
});

const getTutor = async (id: any) => {
  const tutorById = await getTutorById(Number(id));
  tutor.value = { ...tutorById };
};


//Lisamine või uuendamine
const submitForm = () => {
  if (tutor.value.id !== undefined) {
    updateTutor({ ...tutor.value });
    delete tutor.value.id;
  } else {
    addTutor({ ...tutor.value });
  }

  clearForm();
  router.push({ name: 'Tuutorid' });
};

const subjects = ref([
  { name: 'Economics', code: Subject.Economics },
  { name: 'Maths', code: Subject.Maths },
  { name: 'Programming', code: Subject.Programming },
  { name: 'Start up', code: Subject.Startup },
  { name: 'PE', code: Subject.PE },
  { name: 'Discrete Maths', code: Subject.DiscMaths },
]);

const deleteTutorHandler = async () => {
  if (tutor.value.id) {
    await deleteTutor(tutor.value.id);
    load();

    clearForm();

    router.push({ name: 'Tuutorid' });
  } else {
    console.error('');
  }
};

const clearForm = () => {
  tutor.value.name = '';
  tutor.value.town = undefined;
  tutor.value.university = undefined;
  tutor.value.speciality = undefined;
  tutor.value.mail = '';
  tutor.value.subjects = [];
  tutor.value.hourlyPrice = 0;
};
</script>

<style scoped></style>

@/model/tutor @/stores/tutorsStore
