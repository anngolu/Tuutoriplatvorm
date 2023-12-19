<template>
  <div class="min-h-screen bg-gray-50 py-12 px-4 sm:px-6 lg:px=8 text-dark-300">
    <div class="text-center">
      <h1 class="font-bold">Vali sinule mugav aeg</h1>
      <DataTable :value="schedules">
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
        <Column field="student.stName" header="Tudengi nimi" />
        <Column v-if="authStore.isStudent()" field="" header="Broneeri">
          <template #body="slotProps">
            <Button v-if="new Date(slotProps.data.startTime) < new Date()" severity="secondary">Möödas</Button>
            <Button v-else-if="slotProps.data.student?.id === accountStore.account?.id"  @click="unregisterSchedule(slotProps.data.id)" severity="warning">Tühista</Button>
            <Button v-else-if="slotProps.data.student" severity="danger" :disabled="slotProps.data.student">Broneritud</Button>
            <Button v-else @click="registerToSchedule(slotProps.data.id)">Broneeri</Button>
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Subject } from '@/model/schedule';
import { useScheduleStore } from '@/stores/scheduleStore';
import { useAuthStore } from '@/stores/authStore';
import { useAccountStore } from '@/stores/accountStore';
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';

const scheduleStore = useScheduleStore();
const authStore = useAuthStore();
const accountStore = useAccountStore();

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
  return '' + day + '/' + month + '/' + year + ' ' + hour + ':' + minutes;
};

onMounted(() => {
  scheduleStore.load();
  accountStore.load();
});

const registerToSchedule = async (id: number) => {
  scheduleStore.registerStudent(id);
};

const unregisterSchedule = async (id: number) => {
  scheduleStore.unregisterStudent(id);
};
</script>
@/stores/tutorsStore
