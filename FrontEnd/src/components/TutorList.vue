<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <h1 class="text-3xl mb-5 font-semibold">Tuutorite nimekiri</h1>
    <div class="mb-5 flex flex-start gap-3">
      <span class="p-input-icon-left">
        <i class="pi pi-search" />
        <InputText
          v-model="nameSearch"
          size="small"
          placeholder="Otsi nime järgi"
        />
      </span>

      <span class="p-input-icon-left">
        <i class="pi pi-search" />
        <InputText
          v-model="universitySearch"
          size="small"
          placeholder="Otsi ülikooli järgi"
        />
      </span>

      <span class="p-input-icon-left">
        <i class="pi pi-search" />
        <InputText
          v-model="specialitySearch"
          size="small"
          placeholder="Otsi teaduskonna järgi"
        />
      </span>
    </div>
    <div class="flex flex-wrap flex-start gap-3">
      <div
        class="card flex align-items-center justify-content-center"
        v-for="tutor in filteredTutors"
        :key="tutor.id"
      >
        <Card style="width: 25em" class="flex">
          <template #header>
            <img
              alt="user header"
              class="w-20 m-2"
              :src="`/Photo${tutor.photoUrlId}.jpg`"
            />
          </template>
          <template #title> {{ tutor.name }} </template>
          <template #subtitle>
            <span class="mr-2">
              {{ tutor.averageRate ? tutor.averageRate : 0 }}
              <i class="pi pi-star-fill" style="color: gold"></i>
            </span>
            <span>
              {{ tutor.hourlyPrice ? tutor.hourlyPrice : 0 }}&#x20AC;/tund
            </span>
          </template>
          <template #content>
            <p class="m-0 text-xs">
              {{ tutor.town }} &bull; {{ tutor.university }} &bull;
              {{ tutor.speciality }}
            </p>
            <p><b>Õpetan:</b> {{ subjectsToStringConvert(tutor.subjects) }}</p>
          </template>
          <template #footer>
            <Rating
              v-on:change="submitRate($event, tutor.id)"
              :cancel="false"
            />
          </template>
        </Card>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
//import { storeToRefs } from 'pinia';
//import { Tutor } from '@/model/tutorlist';
import { Subject } from '@/model/schedule';
import { RatingChangeEvent } from 'primevue/rating';
import { onMounted, ref, computed } from 'vue';
import { useTutorsStore } from '@/stores/tutorsStore';
//import { storeToRefs } from 'pinia';

const tutorsStore = useTutorsStore();
//const { tutors } = storeToRefs(tutorsStore);
const nameSearch = ref('');
const universitySearch = ref('');
const specialitySearch = ref('');

const submitRate = (event: RatingChangeEvent, id?: number) => {
  tutorsStore.calculateRating(id!, event.value).then((_) => tutorsStore.load());
};

const subjectsToStringConvert = (subjects: Subject[] = []) => {
  return subjects.join(', ');
};

const filteredTutors = computed(() => {
  return tutorsStore.tutors.filter((tutor) => {
    const nameMatch = tutor.name
      ?.toLowerCase()
      .includes(nameSearch.value.toLowerCase());
    const universityMatch = tutor.university
      ?.toLowerCase()
      .includes(universitySearch.value.toLowerCase());
    const specialityMatch = tutor.speciality
      ?.toLowerCase()
      .includes(specialitySearch.value.toLowerCase());

    return nameMatch && universityMatch && specialityMatch;
  });
});

onMounted(() => {
  tutorsStore.load();
});
</script>