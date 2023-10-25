<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">{{ title }}</h1>
      <DataTable :value="tutors">
        <Column field="name" header="Nimi" />
        <Column field="university" header="Ülikool" />
        <Column field="speciality" header="Teaduskond" />
        <Column field="subject" header="Aine" />
        <Column field="hourlyPrice" header="Tunnihind" />
        <Column field="grade" header="Reiting" />
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
//import { storeToRefs } from 'pinia';
import { useTutorsStore } from '@/stores/tutorsStore';

defineProps<{ title: String }>();
//const { tutors } = storeToRefs(tutorsStore);

const { tutors } = useTutorsStore();

// const tutorsWithAge = tutors.map((tutor) => {
//   const birthDate = new Date(tutor.birthday);
//   const today = new Date();
//   const ageDiff = today.getFullYear() - birthDate.getFullYear();
  
//   const birthMonth = birthDate.getMonth();
//   const currentMonth = today.getMonth();

//   if (
//     currentMonth < birthMonth ||
//     (currentMonth === birthMonth && today.getDate() < birthDate.getDate())
//   ) {
//     return {
//       ...tutor,
//       age: ageDiff - 1,
//     };
//   }

//   return {
//     ...tutor,
//     age: ageDiff,
//   };
//});
</script>
@/stores/tutorsStore
