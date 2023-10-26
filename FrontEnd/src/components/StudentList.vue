<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">{{ title }}</h1>
      <DataTable :value="students">
        <Column field="name" header="Nimi" />
        <Column field="town" header="Linn" />
        <Column field="university" header="Ülikool" />
        <Column field="speciality" header="Fakulteet" />
        <Column field="subject" header="Ained lisaõppimiseks" />
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useStudentsStore } from '@/stores/studentsStore';

defineProps<{ title: String }>();

const { students } = useStudentsStore();

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
