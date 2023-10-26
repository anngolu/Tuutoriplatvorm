<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Tudengite nimekiri</h1>
      <DataTable :value="students">
        <Column field="stName" header="Nimi" />
        <Column field="stTown" header="Linn" />
        <Column field="stUniversity" header="Ülikool" />
        <Column field="stSpeciality" header="Fakulteet" />
        <Column field="stSubject" header="Ained lisaõppimiseks" />
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useStudentsStore } from '@/stores/studentsStore';
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';

const studentsStore = useStudentsStore();
const {students} = storeToRefs(studentsStore);

onMounted(() => {
  studentsStore.load();
});

// const studentsWithAge = students.map((student) => {
//   const birthDate = new Date(student.birthday);
//   const today = new Date();
//   const ageDiff = today.getFullYear() - birthDate.getFullYear();
//   const birthMonth = birthDate.getMonth();
//   const currentMonth = today.getMonth();

//   if (
//     currentMonth < birthMonth ||
//     (currentMonth === birthMonth && today.getDate() < birthDate.getDate())
//   ) {
//     return {
//       ...student,
//       age: ageDiff - 1,
//     };
//   }

//   return {
//     ...student,
//     age: ageDiff,
//   };
// });
</script>
@/stores/studentsStore
