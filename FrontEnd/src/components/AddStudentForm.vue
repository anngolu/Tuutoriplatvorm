<template>
  <div class="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
    <form class="max-w-md w-full space-y-8">
      <div class="rounded-md shadow-sm -space-y-px">
        <div class="mt-8 space-y-6">
          <div>
            <label for="code">Tudengi id</label>
            <input
              id="code"
              name="code"
              v-model="student.code"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Tudengi ID"
            />
          </div>

          <div>
            <label for="name">Eesnimi</label>
            <input
              id="name"
              name="name"
              v-model="student.name"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Nimi"
            />
          </div>
          <div>
            <label for="surname">Perenimi</label>
            <input
              id="surname"
              name="surname"
              v-model="student.surname"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Perenimi"
            />
          </div>
          <div>
            <label for="status">Olek</label>
            <select
              id="status"
              name="status"
              v-model="student.status"
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
              v-model="student.university"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Ülikool"
            />
          </div>

          <div>
            <label for="subject">Ained lisaõppimiseks</label>
            <input
              id="subject"
              name="subject"
              v-model="student.subject"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Ained lisaõppimiseks"
            />
          </div>

          <div>
            <label for="status">Gender</label>
            <select
              id="gender"
              name="status"
              v-model="student.gender"
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
              placeholder="Olek2"
            >
              <option value="M">Male</option>
              <option value="N">Female</option>
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
import { Student, StudentGender, StudentStatus } from '@/model/student';
import { useStudentStore } from '@/stores/studentsStore';
import { Ref, ref } from 'vue';
import { useRouter } from 'vue-router';

const student: Ref<Student> = ref({
  name: '',
  surname: '',
  status: StudentStatus.Active,
  gender: StudentGender.Male,
  code: '',
  university: '', // Add this property
  subject: '',    // Add this property
});

const { addStudent } = useStudentStore();
const router = useRouter();

const submitForm = () => {
  addStudent({ ...student.value });

  student.value.name = '';
  student.value.surname = '';
  student.value.code = '';
  student.value.status = StudentStatus.Active;
  student.value.gender = StudentGender.Male;
  
  router.push({ name: 'Tudengid' });
};
</script>
@/model/student @/stores/studentsStore