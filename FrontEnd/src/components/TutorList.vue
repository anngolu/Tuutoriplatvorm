<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Tuutorite nimekiri</h1>
      <input placeholder="Otsi nime järgi" v-model="nameSearch" />
      <DataTable :value="searchResult">
        <Column field="name" header="Nimi" />
        <Column field="university" header="Ülikool" />
        <Column field="speciality" header="Teaduskond" />
        <Column header="Aine">
          <template #body="slotProps">
            {{ subjectsToStringConvert(slotProps.data.subjects) }}
          </template>
        </Column>
        <Column field="hourlyPrice" header="Tunnihind" sortable style />
        <Column field="averageRate" header="Reiting" sortable style />
        <Column header="Hinda">
          <template #body="slotProps">
            <Rating
              v-on:change="submitRate($event, slotProps.data.id)"
              :cancel="false"
            />
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
//import { storeToRefs } from 'pinia';
import { useTutorsStore } from '@/stores/tutorsStore';
import { RatingChangeEvent } from 'primevue/rating';
import { onMounted, ref, computed } from 'vue';
import { Subject } from '@/model/tutor';

const tutorsStore = useTutorsStore();

//const { tutors } = storeToRefs(tutorsStore);
const nameSearch = ref('');
const submitRate = (event: RatingChangeEvent, id: string) => {
  // console.log(event);
  tutorsStore.calculateRating(id, event.value).then((_) => tutorsStore.load());
};

// /* // watch(nameSearch,(val)=>{
//   const searchResult=tutorsStore.searchTutorByName(val)
//   console.log("vaste: ", searchResult)
// })
//  */

const subjectsToStringConvert = (subjects: Subject[]) => {
  return subjects.join(', ');
};

const searchResult = computed(() => {
  return tutorsStore.searchTutorByName(nameSearch.value);
});

onMounted(() => {
  tutorsStore.load();
});
</script>
@/stores/tutorsStore
