<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">{{ title }}</h1>
      <DataTable :value="tutorsWithAge">
        <Column field="code" header="Tuutori ID" />
        <Column field="name" header="Nimi" />
        <Column field="surname" header="Perenimi" />
        <Column field="university" header="Ülikool" />
        <Column field="faculty" header="Teaduskond" />
        <Column field="status" header="Olek" />
        <Column field="gender" header="Sugu" />
        <Column field="hourlyPrice" header="Tunnihind" />
        <Column field="grade" header="Reiting" />
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useTutorsStore } from '@/stores/tutorsStore';

defineProps<{ title: String }>();

const { tutors } = useTutorsStore();

const tutorsWithAge = tutors.map((tutor) => {
  const birthDate = new Date(tutor.birthday);
  const today = new Date();
  const ageDiff = today.getFullYear() - birthDate.getFullYear();
  
  const birthMonth = birthDate.getMonth();
  const currentMonth = today.getMonth();

  if (
    currentMonth < birthMonth ||
    (currentMonth === birthMonth && today.getDate() < birthDate.getDate())
  ) {
    return {
      ...tutor,
      age: ageDiff - 1,
    };
  }

  return {
    ...tutor,
    age: ageDiff,
  };
});
</script>
@/stores/tutorsStore
