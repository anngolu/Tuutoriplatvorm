<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Tuutorite nimekiri</h1>
      <input placeholder="Otsi nime järgi" v-model="nameSearch"> 
      <input placeholder="Otsi ülikooli järgi" v-model="universitySearch" />
      <DataTable :value="filteredTutors">
        <Column field="name" header="Nimi" />
        <Column field="university" header="Ülikool" />
        <Column field="speciality" header="Teaduskond" />
        <Column field="subject" header="Aine" />
        <Column field="hourlyPrice" header="Tunnihind" sortable style/>
        <Column field="hourlyPrice" header="Tunnihind" sortable style />
        <Column field="averageRate" header="Reiting" sortable style/>
        <Column header="Hinda">
          <template #body="slotProps">
              <Rating v-on:change="submitRate($event, slotProps.data.id)" :cancel="false" />
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
import { onMounted, ref, computed} from 'vue';


const tutorsStore = useTutorsStore();
const nameSearch = ref("");
const universitySearch = ref("");

const submitRate = (event: RatingChangeEvent, id: string) => {
  tutorsStore.calculateRating(id, event.value)
    .then(_ => tutorsStore.load());
}

const filteredTutors = computed(() => {
  return tutorsStore.tutors.filter((tutor) => {
    const nameMatch = tutor.name.toLowerCase().includes(nameSearch.value.toLowerCase());
    const universityMatch = tutor.university?.toLowerCase().includes(universitySearch.value.toLowerCase());

    return nameMatch && universityMatch;
  });
});

onMounted(() => {
  tutorsStore.load();
});
</script>
@/stores/tutorsStore
