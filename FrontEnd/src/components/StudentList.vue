<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">{{ title }}</h1>
      <DataTable :value="studentsWithAge">
        <Column field="code" header="Tudengi ID" />
        <Column field="name" header="Nimi" />
        <Column field="surname" header="Perenimi" />
        <Column field="university" header="Ülikool" />
        <Column field="subject" header="Ained lisaõppimiseks" />
        <Column field="status" header="Olek" />
        <Column field="gender" header="Sugu" />
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useStudentStore } from '@/stores/studentsStore';

defineProps<{ title: String }>();

const { students } = useStudentStore();

const studentsWithAge = students.map((student) => {
  const birthDate = new Date(student.birthday);
  const today = new Date();
  const ageDiff = today.getFullYear() - birthDate.getFullYear();
  const birthMonth = birthDate.getMonth();
  const currentMonth = today.getMonth();

  if (
    currentMonth < birthMonth ||
    (currentMonth === birthMonth && today.getDate() < birthDate.getDate())
  ) {
    return {
      ...student,
      age: ageDiff - 1,
    };
  }

  return {
    ...student,
    age: ageDiff,
  };
});
</script>
@/stores/studentsStore
