<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Tudengite nimekiri</h1>
      <DataTable :value="students">
        <Column field="description" header="Kirjeldus" />
        <Column>
          <template #body="{ data }">
            <button
              class="border bg-red-400 text-red-900 py-0 px-2 border-red-900 font-bold"
              @click="remove(data)"
            >
              X
            </button>
          </template>
        </Column>
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
import { useTutorsStore } from '@/stores/tutorsStore';
import { Tutor } from '@/model/tutor';

const remove = (tutor: Tutor) => {
  tutorsStore.deleteTutor(tutor);
};

const studentsStore = useStudentsStore();
const {students} = storeToRefs(studentsStore);

onMounted(() => {
  studentsStore.load();
});
</script>
@/stores/studentsStore
