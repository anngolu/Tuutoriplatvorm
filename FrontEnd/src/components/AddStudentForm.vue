<template>
  <div class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">

          <div>
            <label for="name">Nimi</label>
            <input
              id="name"
              name="name"
              v-model="student.stName"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Nimi"
            />
          </div>

          <div>
            <label for="town">Linn</label>
            <select
              id="town"
              name="town"
              v-model="student.stTown"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Linn">
              <option value="Tartu">Tartu</option>
              <option value="Tallinn">Tallinn</option>
              <option value="Narva">Narva</option>
              <option value="KohtlaJarve">Kohtla-Järve</option>
            </select>
          </div>

          <div>
            <label for="university">Ülikool</label>
            <select
              id="university"
              name="university"
              v-model="student.stUniversity"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Ülikool">
              <option value="UniversityOfTartu">University of Tartu</option>
              <option value="TallinnTechnicalUniversity">Tallinn Technical University</option>
              <option value="TallinnUniversity">Tallinn University</option>
              <option value="TallinnCollegeOfHealth">Tallinn College Of Health</option>
              <option value="TartuHigherArtSchool">Tartu Higher Art School</option>
            </select>
          </div>

          <div>
            <label for="speciality">Fakulteet</label>
            <select
              id="faculty"
              name="faculty"
              v-model="student.stSpeciality"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Fakulteet">
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
              v-model="student.stMail"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Mail"
            />
          </div>

          <div>
            <label for="subject">Ained lisaõppimiseks</label>
            <select
              id="subject"
              name="subject"
              v-model="student.stSubject"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Aine">
              <option value="Economics">Economics</option>
              <option value="Maths">Maths</option>
              <option value="Programming">Programming</option>
              <option value="Startup">Start up</option>
              <option value="PE">PE</option>
              <option value="DiscMaths">Discrete Maths</option>
            </select>
          </div>

          <div>
            <button
              @click.prevent="submitForm"
              class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
            >
              <span class="absolute left-0 inset-y-0 flex items-center pl-3">
              </span>
              Lisa tudeng
            </button>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { StSpeciality, StSubject, StTown, StUniversity, Student } from '@/model/student';
import { useStudentsStore } from '@/stores/studentsStore';
import { Ref, ref } from 'vue';
import { useRouter } from 'vue-router';

const student: Ref<Student> = ref({
  stName: '',
  stTown: StTown,
  stUniversity: StUniversity,
  stSpeciality: StSpeciality,
  stMail: '',
  stSubject: StSubject,    // Add this property
});

const { addStudent } = useStudentsStore();
const router = useRouter();

const submitForm = () => {
  addStudent({ ...student.value });

  student.value.stName = '';
  student.value.stTown = undefined;
  student.value.stUniversity = undefined;
  student.value.stSpeciality = undefined;
  student.value.stMail = '';
  student.value.stSubject = undefined
  
  router.push({ name: 'Tudengid' });
};
</script>

function useStudentStore(): { addStudent: any; } {
  throw new Error('Function not implemented.');
}
@/model/student @/stores/studentsStore