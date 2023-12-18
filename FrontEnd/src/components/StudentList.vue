<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Tudengite nimekiri</h1>
      <DataTable :value="students">
        <Column field="description" header="Kirjeldus" />
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
</script>
@/stores/studentsStore
