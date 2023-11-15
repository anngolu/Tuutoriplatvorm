<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Vali sinule mugav aeg</h1>
      <DataTable :value="schedules">
        <!-- <Column field="name" header="Nimi" /> -->
        <Column field="tutor.name" header="Tuutori nimi" /> 
        <Column header="Aine">
          <template #body="slotProps">
            {{ subjectsToStringConvert(slotProps.data.subjects) }}
          </template>
        </Column>
        <Column field="hourlyPrice" header="Tunnihind" sortable style>
          <template #body="slotProps">
            {{ slotProps.data.hourlyPrice }}&#x20AC;/tund
          </template>
        </Column>
        <Column field="startTime" header="Alguse aeg">
          <template #body="slotProps">
            {{ dateTimeFormatter(slotProps.data.startTime) }}
          </template>
        </Column> 
        <Column field="endTime" header="Lõpetamise aeg">
          <template #body="slotProps">
            {{ dateTimeFormatter(slotProps.data.endTime) }}
          </template>
        </Column>
        <Column field="" header="Broneeri">
          <template >
            <button
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-900 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
             
            >
            <span
              class="absolute left-0 inset-y-0 flex items-center pl-3"
            ></span>
            Broneeri
          </button>
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Subject } from '@/model/schedule';
import { useScheduleStore } from '@/stores/scheduleStore';
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';

const scheduleStore = useScheduleStore();


const { schedules } = storeToRefs(scheduleStore);

const subjectsToStringConvert = (subjects: Subject[]) => {
  return subjects.join(', ');
};

const dateTimeFormatter = (timeStamp: string): string => {
  const time = new Date(timeStamp);
  const day = time.getDate();
  const month = time.getMonth();
  const year = time.getFullYear();
  const hour = time.getHours();
  const minutes = time.getMinutes();
  return "" + day + '/' + month + '/' + year + ' ' + hour + ':' + minutes
}


onMounted(() => {
  scheduleStore.load();
});
</script>
@/stores/tutorsStore
